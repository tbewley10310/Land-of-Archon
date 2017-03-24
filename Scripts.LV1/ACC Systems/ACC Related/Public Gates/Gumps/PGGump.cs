using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.ACC.PG
{
	public class PGGump : Gump
	{
		private Mobile     m_From;
		private int        m_Page;
		private PublicGate m_Gate;

		private EntryFlag EFlags;
		private void SetFlag( EntryFlag flag, bool value )
		{
			if( value )
				EFlags |= flag;
			else EFlags &= ~flag;
		}

		public PGGump( Mobile from, int Page, PublicGate gate ) : base( 0, 0 )
		{
			if( !PGSystem.Running )
				return;

			if( PGSystem.CategoryList == null || PGSystem.CategoryList.Count == 0 )
			{
				SetFlag( EntryFlag.StaffOnly, true );
				SetFlag( EntryFlag.Generate, false );
				PGSystem.CategoryList = new List<PGCategory>();
				PGSystem.CategoryList.Add( new PGCategory( "Empty System", EFlags ) );
			}

			m_From = from;
			m_Page = Page;
			m_Gate = gate;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);

            int Locs = CountLocs();
            int Cats = CountCats();
            int BHeightT = Locs;
            int BWidth = 430;

            if (Locs < Cats)
                BHeightT = Cats;

            int BHeight = 280 > (100 + (BHeightT*25)) ? 280 : (100 + (BHeightT * 25));


            AddBackground(0, 0, BWidth, BHeight, 9270);
            AddLabel(20, 10, 1153, "The Grove");
            AddLabel(215, 10, 1153, "Where ya headed?:");

            AddButton( 15, BHeight - 70, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddLabel( 50, BHeight - 70, 1153, "OKAY" );

            AddButton( 15, BHeight - 45, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddLabel( 50, BHeight - 45, 1153, "CANCEL" );

			#region Categories
			int CStart = 35;

			int CurC = 0;
			for( int i = 0; i < PGSystem.CategoryList.Count; i++ )
			{
				PGCategory PGC = PGSystem.CategoryList[i];
				if( PGC != null )
				{
					if( from.AccessLevel >= PGSystem.PGAccessLevel )
					{
                        AddButton( 15, CStart + (CurC * 25), (Page == i ? 2118 : 2117), (Page == i ? 2117 : 2118), 100+i, GumpButtonType.Reply, 0);
                        AddLabel(35, CStart + (CurC * 25), (Page == i ? 53 : PGC.Hue == 0 ? 1153 : PGC.Hue), (Page == i ? (PGC.Name + " <--") : PGC.Name));
						CurC++;
						continue;
					}

					if( PGC.GetFlag( EntryFlag.StaffOnly ) && from.AccessLevel == AccessLevel.Player )
						continue;
					if( !PGC.GetFlag( EntryFlag.StaffOnly ) )
					{
						if( PGC.GetFlag( EntryFlag.Young ) && !((PlayerMobile)from).Young )
							continue;
						if( !PGC.GetFlag( EntryFlag.Reds ) && from.Kills >= 5 )
							continue;
					}

                    AddButton(15, CStart + (CurC * 25), (Page == i ? 2118 : 2117), (Page == i ? 2117 : 2118), 100 + i, GumpButtonType.Reply, 0);
                    AddLabel(35, CStart + (CurC * 25), (Page == i ? 53 : PGC.Hue == 0 ? 1153 : PGC.Hue), (Page == i ? (PGC.Name + " <--") : PGC.Name));
                    CurC++;
				}
			}

			if( from.AccessLevel >= PGSystem.PGAccessLevel )
			{
				AddLabel(   160, BHeight - 70, 1153, "ADD" );
                AddButton(  125, BHeight - 70, 4005, 4007, 2, GumpButtonType.Reply, 0);
                AddLabel(  160, BHeight - 45, 1153, "EDIT");
                AddButton( 125, BHeight - 45, 4005, 4007, 3, GumpButtonType.Reply, 0);
			}
			#endregion //Categories

			#region Locations
			if( Locs == -1 )
				Locs = 0;

			int LStart = 35;


			int CurL = 0;
			PGCategory PGCL = PGSystem.CategoryList[m_Page];
			if( PGCL != null && PGCL.Locations != null )
			{
				for( int i = 0; i < PGCL.Locations.Count; i++ )
				{
					PGLocation PGL = PGCL.Locations[i];
					if( PGL != null )
					{
						if( from.AccessLevel >= PGSystem.PGAccessLevel )
						{
							AddRadio( 215, LStart + (CurL * 25), 210, 211, false, 200+i );
							AddLabel( 235, LStart + (CurL * 25), PGL.Hue == 0 ? 1153 : PGL.Hue, PGL.Name);
							CurL++;
							continue;
						}

						if( PGL.GetFlag( EntryFlag.StaffOnly ) && from.AccessLevel == AccessLevel.Player )
							continue;
						if( !PGL.GetFlag( EntryFlag.StaffOnly ) )
						{
							if( PGL.GetFlag( EntryFlag.Young ) && !((PlayerMobile)from).Young )
								continue;
							if( !PGL.GetFlag( EntryFlag.Reds ) && from.Kills >= 5 )
								continue;
						}

                        AddRadio(215, LStart + (CurL * 25), 210, 211, false, 200 + i);
                        AddLabel(235, LStart + (CurL * 25), PGL.Hue == 0 ? 1153 : PGL.Hue, PGL.Name);
                        CurL++;
					}
				}
			}


			if( from.AccessLevel >= PGSystem.PGAccessLevel )
			{

                AddButton(215, BHeight - 45, 4005, 4007, 6, GumpButtonType.Reply, 0);
                AddLabel(250, BHeight - 45, 1153, "Add Current");

                AddLabel(370, BHeight - 70, 1153, "ADD");
                AddButton(335, BHeight - 70, 4005, 4007, 4, GumpButtonType.Reply, 0);

                AddLabel(370, BHeight - 45, 1153, "EDIT");
                AddButton(335, BHeight - 45, 4005, 4007, 5, GumpButtonType.Reply, 0);

			}
			#endregion //Locations
		}

		private int CountCats()
		{
			int count = 0;
			foreach( PGCategory PGC in PGSystem.CategoryList )
			{
				if( (PGC.GetFlag( EntryFlag.StaffOnly ) && m_From.AccessLevel > AccessLevel.Player) ||
					(!PGC.GetFlag( EntryFlag.StaffOnly ) && ((!PGC.GetFlag( EntryFlag.Reds ) && m_From.Kills < 5) || PGC.GetFlag( EntryFlag.Reds ))) ||
					(m_From.AccessLevel > AccessLevel.Player) )
					count++;
			}
			return count;
		}

		private int CountLocs()
		{
			if( m_Page < 0 || m_Page >= PGSystem.CategoryList.Count )
				return -1;

			int count = 0;
			PGCategory PGC = PGSystem.CategoryList[m_Page];
			if( PGC != null && PGC.Locations != null )
			{
                IEnumerator<PGLocation> PGL = PGC.Locations.GetEnumerator();
                while(PGL.MoveNext())
                {
					if( (PGL.Current.GetFlag( EntryFlag.StaffOnly ) && m_From.AccessLevel > AccessLevel.Player) ||
                        (!PGL.Current.GetFlag(EntryFlag.StaffOnly) && ((!PGL.Current.GetFlag(EntryFlag.Reds) && m_From.Kills < 5) || PGL.Current.GetFlag(EntryFlag.Reds))) ||
						(m_From.AccessLevel > AccessLevel.Player) )
						count++;
				}
			}
			return count;
		}

		private Conditions Flags;
		private void SetFlag( Conditions flag, bool value )
		{
			if( value )
				Flags |= flag;
			else Flags &= ~flag;
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;
			int BID = info.ButtonID;
			int Loc = -1;

			if( !PGSystem.Running )
				return;

			if( m_From.Deleted || m_Gate.Deleted || m_From.Map == null )
				return;

			if( info.Switches.Length > 0 )
				Loc = info.Switches[0];

			Loc -= 200;

			if( BID == 0 )
			{
				from.SendMessage( "You choose not to go anywhere." );
				return;
			}

			if( BID == 1 )
			{
				if( Loc <= -1 )
				{
					from.SendMessage( "You must select a location!" );
					from.SendGump( new PGGump( from, m_Page, m_Gate ) );
					return;
				}

				PGCategory PGC = PGSystem.CategoryList[m_Page];
				if( PGC == null )
					return;

				PGLocation PGL = PGC.Locations[Loc];
				if( PGL == null )
					return;

				if( !from.InRange( m_Gate.GetWorldLocation(), 1 ) || from.Map != m_Gate.Map )
				{
					from.SendLocalizedMessage( 1019002 ); // You are too far away to use the gate.
				}
				else if( Factions.Sigil.ExistsOn( from ) && PGL.Map != Factions.Faction.Facet )
				{
					from.SendLocalizedMessage( 1019004 ); // You are not allowed to travel there.
					from.SendGump( new PGGump( from, m_Page, m_Gate ) );
				}
				else if( from.Criminal )
				{
					from.SendLocalizedMessage( 1005561, "", 0x22 ); // Thou'rt a criminal and cannot escape so easily.
				}
				else if( Server.Spells.SpellHelper.CheckCombat( from ) )
				{
					from.SendLocalizedMessage( 1005564, "", 0x22 ); // Wouldst thou flee during the heat of battle??
				}
				else if( from.Spell != null )
				{
					from.SendLocalizedMessage( 1049616 ); // You are too busy to do that at the moment.
				}
				else if( from.Map == PGL.Map && from.InRange( PGL.Location, 1 ) )
				{
					from.SendLocalizedMessage( 1019003 ); // You are already there.
					from.SendGump( new PGGump( from, m_Page, m_Gate ) );
				}
				else if( PGL.GetFlag( EntryFlag.Young ) && !((PlayerMobile)from).Young && from.AccessLevel == AccessLevel.Player )
				{
					from.SendMessage( "You are too old to travel here." );
					from.SendGump( new PGGump( from, m_Page, m_Gate ) );
				}
				else if( !PGL.GetFlag( EntryFlag.Reds ) && from.Kills >= 5 && from.AccessLevel == AccessLevel.Player )
				{
					from.SendMessage( "You too many murders to travel here." );
					from.SendGump( new PGGump( from, m_Page, m_Gate ) );
				}
				else if( PGL.GetFlag( EntryFlag.StaffOnly ) && from.AccessLevel == AccessLevel.Player )
				{
					from.SendMessage( "You are not allowed to travel here." );
					from.SendGump( new PGGump( from, m_Page, m_Gate ) );
				}
				else
				{
					bool charged = false;
					if( PGC.GetFlag( EntryFlag.Charge ) && PGC.Cost > 0 && from.AccessLevel == AccessLevel.Player )
					{
						Container pack = from.Backpack;
						if( pack == null )
							return;
						if( !pack.ConsumeTotal( typeof( Gold ), PGC.Cost ) )
						{
							from.SendMessage( "You require {0} gold to travel there.", PGC.Cost );
							from.SendGump( new PGGump( from, m_Page, m_Gate ) );
							return;
						}
						charged = true;
					}

					if( !charged && PGL.GetFlag( EntryFlag.Charge ) && PGL.Cost > 0 && from.AccessLevel == AccessLevel.Player )
					{
						Container pack = from.Backpack;
						if( pack == null )
							return;
						if( !pack.ConsumeTotal( typeof( Gold ), PGL.Cost ) )
						{
							from.SendMessage( "You require {0} gold to travel there.", PGL.Cost );
							from.SendGump( new PGGump( from, m_Page, m_Gate ) );
							return;
						}
					}

					BaseCreature.TeleportPets( from, PGL.Location, PGL.Map );

					from.Combatant = null;
					from.Warmode = false;
					from.Hidden = true;

					from.MoveToWorld( PGL.Location, PGL.Map );

					Effects.PlaySound( PGL.Location, PGL.Map, 0x1FE );
					from.SendMessage( "You have been teleported to: " + PGL.Name );
				}
			}

			else if( BID >= 100 )
			{
				from.CloseGump( typeof( PGGump ) );
				from.SendGump( new PGGump( from, BID-100, m_Gate ) );
			}

			else if( BID == 2 && from.AccessLevel >= PGSystem.PGAccessLevel)
			{
				SetFlag( Conditions.Adding, true );
				SetFlag( Conditions.Category, true );

				from.CloseGump( typeof( PGAddEditGump ) );
				from.CloseGump( typeof( PGGump ) );
				from.SendGump( new PGGump( from, m_Page, m_Gate ) );
				from.SendGump( new PGAddEditGump( Flags, m_Page, -1, m_Gate ) );
			}

            else if (BID == 3 && from.AccessLevel >= PGSystem.PGAccessLevel)
			{
				SetFlag( Conditions.Adding, false );
				SetFlag( Conditions.Category, true );

				from.CloseGump( typeof( PGAddEditGump ) );
				from.CloseGump( typeof( PGGump ) );
				from.SendGump( new PGGump( from, m_Page, m_Gate ) );
				from.SendGump( new PGAddEditGump( Flags, m_Page, -1, m_Gate ) );
			}

            else if (BID == 4 && from.AccessLevel >= PGSystem.PGAccessLevel)
			{
				SetFlag( Conditions.Adding, true );
				SetFlag( Conditions.Category, false );

				from.CloseGump( typeof( PGAddEditGump ) );
				from.CloseGump( typeof( PGGump ) );
				from.SendGump( new PGGump( from, m_Page, m_Gate ) );
				from.SendGump( new PGAddEditGump( Flags, m_Page, Loc, m_Gate ) );
			}

            else if (BID == 5 && from.AccessLevel >= PGSystem.PGAccessLevel)
			{
				if( Loc <= -1 )
				{
					from.SendMessage( "You must select a location!" );
					from.SendGump( new PGGump( from, m_Page, m_Gate ) );
					return;
				}
				SetFlag( Conditions.Adding, false );
				SetFlag( Conditions.Category, false );

				from.CloseGump( typeof( PGAddEditGump ) );
				from.CloseGump( typeof( PGGump ) );
				from.SendGump( new PGGump( from, m_Page, m_Gate ) );
				from.SendGump( new PGAddEditGump( Flags, m_Page, Loc, m_Gate ) );
			}

            else if (BID == 6 && from.AccessLevel >= PGSystem.PGAccessLevel)
			{
				if( m_Gate.Parent != null )
				{
					from.SendMessage( "You must place the gate in the World to add it." );
					from.SendGump( new PGGump( from, m_Page, m_Gate ) );
					return;
				}

				PGLocation PGL = new PGLocation( "Un-named Gate", EntryFlag.None, m_Gate.Location, m_Gate.Map, 0 );
				if( PGL == null )
				{
					from.SendMessage( "Could not add." );
					from.SendGump( new PGGump( from, m_Page, m_Gate ) );
					return;
				}

				from.SendMessage( "Added the Gate.  Please edit any other features you wish it to have." );
				PGSystem.CategoryList[m_Page].Locations.Add( PGL );
                from.SendGump(new PGGump(from, m_Page, m_Gate));
                from.SendGump(new PGAddEditGump(Flags, m_Page, PGSystem.CategoryList[m_Page].Locations.Count-1, m_Gate));
			}

			else
			{
				from.SendMessage( "Undefined button pressed: {0}", BID );
			}
		}
	}
}