/*
 created by:
     /\            888                   888     .d8888b.   .d8888b.  
____/_ \____       888                   888    d88P  Y88b d88P  Y88b 
\  ___\ \  /       888                   888    888    888 888    888 
 \/ /  \/ /    .d88888  8888b.   8888b.  888888 Y88b. d888 Y88b. d888 
 / /\__/_/\   d88" 888     "88b     "88b 888     "Y888P888  "Y888P888 
/__\ \_____\  888  888 .d888888 .d888888 888           888        888 
    \  /      Y88b 888 888  888 888  888 Y88b.  Y88b  d88P Y88b  d88P 
     \/        "Y88888 "Y888888 "Y888888  "Y888  "Y8888P"   "Y8888P"  
*/
//Made by daat99 based on beatle script
using Server.Items;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Mobiles
{
	[CorpseName( "a mule corpse" )]
	public class Mule : BaseMount
	{
		public override bool SubdueBeforeTame{ get{ return true; } } // Must be beaten into submission

		private bool b_BeforeTame;
		public bool BeforeTame{ get{ return b_BeforeTame; } set { b_BeforeTame = value; InvalidateProperties(); } }

		[Constructable]
		public Mule() : this (30.0, false)
		{
		}

		[Constructable]
		public Mule(double d_MinTame, bool b_BeforeTame) : base( "a mule", 0x76, 0x3EB2, AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0xA8;
			
			SetStr( 200 );
			SetDex( 75 );
			SetInt( 150 );

			SetHits( 95, 105 );

			SetDamage( 6, 17 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Cold, 55, 60 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 15, 22 );

			SetSkill( SkillName.MagicResist, 90.0 );
			SetSkill( SkillName.Tactics, 75.0 );
			SetSkill( SkillName.Wrestling, 80.1, 90.0 );
			SetSkill( SkillName.EvalInt, 10.1, 11.0 );
			SetSkill( SkillName.Magery, 10.1, 11.0 );
			SetSkill( SkillName.Meditation, 10.1, 11.0 );
			
			Fame = 2000;
			Karma = -2000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = d_MinTame;

			Container pack = Backpack;

			if ( pack != null )
				pack.Delete();

			pack = new StrongBackpack();
			pack.Movable = false;

			AddItem( pack );

			BeforeTame = b_BeforeTame;
		}

		public override void OnBeforeTame()
		{
			if (BeforeTame == true)
			{
				PackItem( new SpinedLeather(100) );
				PackItem( new HornedLeather(90) );
				PackItem( new BarbedLeather(80) );
				PackItem( new PolarLeather(70) );
				PackItem( new SyntheticLeather(60) );
				PackItem( new BlazeLeather(50) );
				PackItem( new DaemonicLeather(40) );
				PackItem( new ShadowLeather(30) );
				PackItem( new FrostLeather(20) );
				PackItem( new EtherealLeather(10) );
				MinTameSkill = 30.0;
				BeforeTame = false;
			}
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;

			return base.GetAngerSound();
		}

		#region Pack Animal Methods
		public override bool OnBeforeDeath()
		{
			if ( !base.OnBeforeDeath() )
				return false;

			PackAnimal.CombineBackpacks( this );

			return true;
		}

		public override bool IsSnoop( Mobile from )
		{
			if ( PackAnimal.CheckAccess( this, from ) )
				return false;

			return base.IsSnoop( from );
		}

		public override bool OnDragDrop( Mobile from, Item item )
		{
			if ( CheckFeed( from, item ) )
				return true;

			if ( PackAnimal.CheckAccess( this, from ) )
			{
				AddToBackpack( item );
				return true;
			}

			return base.OnDragDrop( from, item );
		}

		public override bool CheckNonlocalDrop( Mobile from, Item item, Item target )
		{
			return PackAnimal.CheckAccess( this, from );
		}

		public override bool CheckNonlocalLift( Mobile from, Item item )
		{
			return PackAnimal.CheckAccess( this, from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			PackAnimal.GetContextMenuEntries( this, from, list );
		}
		#endregion


		public Mule( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version
			//version 1
			writer.Write( (bool) b_BeforeTame);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			if (version == 2)
				b_BeforeTame = reader.ReadBool();
			if (version == 1)
			{
				b_BeforeTame = reader.ReadBool();
				bool b = reader.ReadBool();
			}
			if (version == 0)
			{
				b_BeforeTame = false;
				MinTameSkill = 30;
			}
			if (AI == AIType.AI_Melee)
			{
				AI = AIType.AI_Mage;
				SetSkill( SkillName.EvalInt, 10.1, 11.0 );
				SetSkill( SkillName.Magery, 10.1, 11.0 );
				SetSkill( SkillName.Meditation, 10.1, 11.0 );
			}
		}
	}
}