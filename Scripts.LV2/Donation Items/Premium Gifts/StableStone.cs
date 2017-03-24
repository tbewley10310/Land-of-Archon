/////////////////////////////////////////////////
////// Stable Stone Created By Viago
////// runuo.com    |  www.fallensouls.org
/////////////////////////////////////////////////

using System; 
using System.Collections; 
using Server.Items; 
using Server.Misc; 
using Server.Network; 
using Server.Mobiles; 
using Server.Multis; 
using Server.Gumps;
using Server.Targeting;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Items 
{ 
public class StableStone : Item
	{ 

      		[Constructable] 
      		public StableStone() : base( 6251 ) 
      		{ 
         		Name = "The Stable Stone"; 
         		Movable = true;
      		} 

      		public StableStone( Serial serial ) : base( serial ) 
      		{ 
      		} 
		private class StableEntry : ContextMenuEntry
		{
			private StableStone m_Trainer;
			private Mobile m_From;

			public StableEntry( StableStone trainer, Mobile from ) : base( 6126, 12 )
			{
				m_Trainer = trainer;
				m_From = from;
			}

			public override void OnClick()
			{
				m_Trainer.BeginStable( m_From );
			}
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list  )
		{
			base.GetContextMenuEntries( from, list );
			if ( from.Alive )
			{
				list.Add( new StableEntry( this, from ) );

				if ( from.Stabled.Count > 0 )
					list.Add( new ClaimListEntry( this, from ) );
			}
		}
		public static int GetMaxStabled( Mobile from )
		{
			double taming = from.Skills[SkillName.AnimalTaming].Value;
			double anlore = from.Skills[SkillName.AnimalLore].Value;
			double vetern = from.Skills[SkillName.Veterinary].Value;
			double sklsum = taming + anlore + vetern;

			int max;

			if ( sklsum >= 240.0 )
				max = 5;
			else if ( sklsum >= 200.0 )
				max = 4;
			else if ( sklsum >= 160.0 )
				max = 3;
			else
				max = 2;

			if ( taming >= 100.0 )
				max += (int)((taming - 90.0) / 10);

			if ( anlore >= 100.0 )
				max += (int)((anlore - 90.0) / 10);

			if ( vetern >= 100.0 )
				max += (int)((vetern - 90.0) / 10);

			return max;
		}
		private class StableTarget : Target
		{
			private StableStone m_Trainer;

			public StableTarget( StableStone trainer ) : base( 12, false, TargetFlags.None )
			{
				m_Trainer = trainer;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is BaseCreature )
					m_Trainer.EndStable( from, (BaseCreature)targeted );
				else if ( targeted == from )
						from.SendMessage ("HA HA HA! Sorry, the stable stone isnt an inn!");
				else
						from.SendMessage ("You can't stable that!");
			}
		}
		public void BeginStable( Mobile from )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			if ( from.Stabled.Count >= GetMaxStabled( from ) )
			{
						from.SendMessage ("You can't stable that! You Have too many ets stabled, you have reached your max amount");
			}
			else
			{
						from.SendMessage ("The Stable Stone Charges 30 Gold, per pet for each Real World week!");
						from.SendMessage ("the gold is automaticly withdrawn form your bank account");
						from.SendMessage ("Target the Animal you Wish to stable!");
				from.Target = new StableTarget( this );
			}
		}

		public void EndStable( Mobile from, BaseCreature pet )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			if ( !pet.Controlled || pet.ControlMaster != from )
			{
						from.SendMessage ("You do not own that pet!");
			}
			else if ( pet.IsDeadPet )
			{
						from.SendMessage ("Living pets only, please!");
			}
			else if ( pet.Summoned )
			{
						from.SendMessage ("You can not stable summoned creatures");
			}
			else if ( pet.Body.IsHuman )
			{
						from.SendMessage ("You do not own that pet!");
			}
			else if ( (pet is PackLlama || pet is PackHorse || pet is Beetle) && (pet.Backpack != null && pet.Backpack.Items.Count > 0) )
			{
						from.SendMessage ("You need to unload the Pack Animal Befor You Can Stable It!");
			}
			else if ( pet.Combatant != null && pet.InRange( pet.Combatant, 12 ) && pet.Map == pet.Combatant.Map )
			{
						from.SendMessage (" Your pet seems to be busy at the moment, try agen when its not!");
			}
			else if ( from.Stabled.Count >= GetMaxStabled( from ) )
			{
						from.SendMessage (" You have too many pets in the stables!");
			}
			else
			{
				Container bank = from.BankBox;

				if ( bank != null && bank.ConsumeTotal( typeof( Gold ), 30 ) )
				{
					pet.ControlTarget = null;
					pet.ControlOrder = OrderType.Stay;
					pet.Internalize();

					pet.SetControlMaster( null );
					pet.SummonMaster = null;

					pet.IsStabled = true;
					from.Stabled.Add( pet );
						from.SendMessage ("thy pet is stabled. Thou mayst recover it by saying 'claim' to me. In one real world week,");
						from.SendMessage ("if your pet is not claimed by then, I shall sell it off if it is not claimed!");
				}
				else
				{
						from.SendMessage ("You Lack The nessasary bank funds to do this");
				}
			}
		}
		private class ClaimListGump : Gump
		{
			private StableStone m_Trainer;
			private Mobile m_From;
			private ArrayList m_List;

			public ClaimListGump( StableStone trainer, Mobile from, ArrayList list ) : base( 50, 50 )
			{
				m_Trainer = trainer;
				m_From = from;
				m_List = list;

				from.CloseGump( typeof( ClaimListGump ) );

				AddPage( 0 );

				AddBackground( 0, 0, 325, 120 + (list.Count * 20), 9250 );
				AddAlphaRegion( 5, 5, 325, 120 + (list.Count * 20) );

				AddHtml( 15, 15, 275, 20, "<BASEFONT COLOR=#FFFFFF>Select a pet to retrieve from the stables:</BASEFONT>", false, false );

				for ( int i = 0; i < list.Count; ++i )
				{
					BaseCreature pet = list[i] as BaseCreature;

					if ( pet == null || pet.Deleted )
						continue;
			AddLabel(32, 35, 160, "Pet Name");AddLabel(175, 35, 160, "Pet Bonded?");
			AddLabel(32, 65 + (i * 20), 55,  pet.Name);
			AddLabel(175, 65 + (i * 20), 55,  pet.IsBonded.ToString());
					AddButton( 15, 69 + (i * 20), 10006, 10006, i + 1, GumpButtonType.Reply, 0 );
			//		AddHtml( 32, 35 + (i * 20), 275, 18,  pet.Name, pet.Title , "Bonded? " , pet.IsBonded , false, false );
				}
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				int index = info.ButtonID - 1;

				if ( index >= 0 && index < m_List.Count )
					m_Trainer.EndClaimList( m_From, m_List[index] as BaseCreature );
			}
		}

		private class ClaimAllEntry : ContextMenuEntry
		{
			private StableStone m_Trainer;
			private Mobile m_From;

			public ClaimAllEntry( StableStone trainer, Mobile from ) : base( 6127, 12 )
			{
				m_Trainer = trainer;
				m_From = from;
			}

			public override void OnClick()
			{
				m_Trainer.Claim( m_From );
			}
		}
		
		public void BeginClaimList( Mobile from )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			ArrayList list = new ArrayList();

			for ( int i = 0; i < from.Stabled.Count; ++i )
			{
				BaseCreature pet = from.Stabled[i] as BaseCreature;

				if ( pet == null || pet.Deleted )
				{
					pet.IsStabled = false;
					from.Stabled.RemoveAt( i );
					--i;
					continue;
				}

				list.Add( pet );
			}

			if ( list.Count > 0 )
				from.SendGump( new ClaimListGump( this, from, list ) );
			else
						from.SendMessage ("But I have no animals stabled with me at the moment!");
		}

		public void EndClaimList( Mobile from, BaseCreature pet )
		{
			if ( pet == null || pet.Deleted || from.Map != this.Map || !from.Stabled.Contains( pet ) || !from.CheckAlive() )
				return;

			if ( (from.Followers + pet.ControlSlots) <= from.FollowersMax )
			{
				pet.SetControlMaster( from );

				if ( pet.Summoned )
					pet.SummonMaster = from;

				pet.ControlTarget = from;
				pet.ControlOrder = OrderType.Follow;

				pet.MoveToWorld( from.Location, from.Map );

				pet.IsStabled = false;
				from.Stabled.Remove( pet );
						from.SendMessage ("Here you go...");
			}
			else
			{
						from.SendMessage ( "That Pet remained in the stables because you have too many followers");
			}
		}
		public void Claim( Mobile from )
		{
			if ( Deleted || !from.CheckAlive() )
				return;

			bool claimed = false;
			int stabled = 0;

			for ( int i = 0; i < from.Stabled.Count; ++i )
			{
				BaseCreature pet = from.Stabled[i] as BaseCreature;

				if ( pet == null || pet.Deleted )
				{
					pet.IsStabled = false;
					from.Stabled.RemoveAt( i );
					--i;
					continue;
				}

				++stabled;

				if ( (from.Followers + pet.ControlSlots) <= from.FollowersMax )
				{
					pet.SetControlMaster( from );

					if ( pet.Summoned )
						pet.SummonMaster = from;

					pet.ControlTarget = from;
					pet.ControlOrder = OrderType.Follow;
			pet.Location = new Point3D( pet.X, pet.Y, 0 );
        			World.AddMobile( pet );
					pet.IsStabled = false;
					from.Stabled.RemoveAt( i );
					--i;

					claimed = true;
					
				}
				else
				{
						from.SendMessage ("That Pet remained in the stables because you have too many followers");
				}
			}

			if ( claimed )
						from.SendMessage (" Here you go...");

			if ( stabled == 0 )
						from.SendMessage ("But I have no animals stabled with me at the moment!");
		}
      		public override bool HandlesOnSpeech{ get{ return true; } } 
		public override void OnSpeech( SpeechEventArgs e )
		{
			if ( !e.Handled && e.HasKeyword( 0x0008 ) )
			{
				e.Handled = true;
				BeginStable( e.Mobile );
			}
			else if ( !e.Handled && e.HasKeyword( 0x0009 ) )
			{
				e.Handled = true;

				if ( !Insensitive.Equals( e.Speech, "Claim" ) )
					BeginClaimList( e.Mobile );
				else
					BeginClaimList( e.Mobile );
			}
			else
			{
				base.OnSpeech( e );
			}
		}
		private class ClaimListEntry : ContextMenuEntry
		{
			private StableStone m_Trainer;
			private Mobile m_From;

			public ClaimListEntry( StableStone trainer, Mobile from ) : base( 6146, 12 )
			{
				m_Trainer = trainer;
				m_From = from;
			}

			public override void OnClick()
			{
				m_Trainer.BeginClaimList( m_From );
               		m_From.PlaySound( 1050 );
			}
		}
      		public override void Serialize( GenericWriter writer ) 
      		{ 
         		base.Serialize( writer ); 

         		writer.Write( (int) 0 ); // version 
      		} 

      		public override void Deserialize( GenericReader reader ) 
      		{ 
         		base.Deserialize( reader ); 

         		int version = reader.ReadInt(); 
      		} 
   	} 
} 
