using System;
using Server.Network;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName("Corpse of the neighborhood watch")]
	public class InvasionAnnouncer : Lich
	{

		private static bool m_Talked;
		private static string m_BroadcastMessage = "Everything is looking fine at the moment.  Travel safe.";
		private static bool m_GaveNews;

		[Constructable]
		public InvasionAnnouncer() : base()
		{
			Title = "the Neighborhood Watch";
			Blessed = true;
			CantWalk = true;
			
			SpeechHue = Utility.RandomDyedHue();

			Hue = Utility.RandomSkinHue();

			if ( Female = Utility.RandomBool() )
			{
				Body = 0x191;
				Name = NameList.RandomName( "female" );

				switch( Utility.Random( 2 ) )
				{
					case 0: AddItem( new LeatherSkirt() ); break;
					case 1: AddItem( new LeatherShorts() ); break;
				}

				switch( Utility.Random( 5 ) )
				{
					case 0: AddItem( new FemaleLeatherChest() ); break;
					case 1: AddItem( new FemaleStuddedChest() ); break;
					case 2: AddItem( new LeatherBustierArms() ); break;
					case 3: AddItem( new StuddedBustierArms() ); break;
					case 4: AddItem( new FemalePlateChest() ); break;
				}
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName( "male" );

				AddItem( new PlateChest() );
				AddItem( new PlateArms() );
				AddItem( new PlateLegs() );

				switch( Utility.Random( 3 ) )
				{
					case 0: AddItem( new Doublet( Utility.RandomNondyedHue() ) ); break;
					case 1: AddItem( new Tunic( Utility.RandomNondyedHue() ) ); break;
					case 2: AddItem( new BodySash( Utility.RandomNondyedHue() ) ); break;
				}
			}
			
			Utility.AssignRandomHair( this );

			if( Utility.RandomBool() )
				Utility.AssignRandomFacialHair( this, HairHue );

			Halberd weapon = new Halberd();

			weapon.Movable = false;
			weapon.Crafter = this;
			weapon.Quality = WeaponQuality.Exceptional;

			AddItem( weapon );

			Container pack = new Backpack();

			pack.Movable = false;

			pack.DropItem( new Gold( 10, 25 ) );

			AddItem( pack );

			Skills[SkillName.Anatomy].Base = 120.0;
			Skills[SkillName.Tactics].Base = 120.0;
			Skills[SkillName.Swords].Base = 120.0;
			Skills[SkillName.MagicResist].Base = 120.0;
			Skills[SkillName.DetectHidden].Base = 100.0;			
		}

		public InvasionAnnouncer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			
			writer.Write( (string) m_BroadcastMessage);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			
			m_BroadcastMessage = reader.ReadString();
		}
		
		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if( m_Talked == false )
			{
			  if ( m.InRange( this, 3 ) && m is PlayerMobile)
			   {
					 m_Talked = true;
					 this.Say( m_BroadcastMessage );
					 this.Move( GetDirectionTo( m.Location ) );
					 SpamTimer t = new SpamTimer();
					 t.Start();
				}
			}
		}
		
		public override void OnSpeech( SpeechEventArgs e )
		{
			base.OnSpeech( e );
			
			if ( !e.Handled && InRange( e.Mobile, 3 ) )
			{
				if ( e.HasKeyword( 0x30 ) && m_GaveNews == false )
				{
					m_GaveNews = true;
					this.Say( m_BroadcastMessage );
					this.Move( GetDirectionTo( e.Mobile.Location ) );
					NewsTimer t = new NewsTimer();
					t.Start();
				}
			}
		}

		private class SpamTimer : Timer
		{
			public SpamTimer() : base( TimeSpan.FromMinutes( 1 ) )
			{
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				   m_Talked = false;
			}
		}
		
		private class NewsTimer : Timer
		{
			
			public NewsTimer() : base( TimeSpan.FromSeconds( 30 ) )
			{
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				m_GaveNews = false;
			}
		}

		public static void SetAnnouncement( string str )
		{
			m_BroadcastMessage = str;
		}

		public static void DeleteAnnouncements()
		{
			m_BroadcastMessage = "Everything is looking fine at the moment.  Travel safe.";
		}
	}
}
