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
//501939 My Color:
//1011402 Color
//1062268 Choose Color
//1062277 Color:

using System;
using Server.Targeting;
using Server.HuePickers;
using Server.ContextMenus;
using Server.Gumps;
using Server.Network;
using System.Collections.Generic;
using Server.Mobiles;

//using Server.Items;
//using Server.Targets;

namespace Server.Items
{
	public class ChargedDyeTub : Item
	{
		private int i_DyeType, i_Charges;

		public int DyeType { get{ return i_DyeType; } set{ i_DyeType = value; InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges { get{ return i_Charges; } set{ i_Charges = value; InvalidateProperties(); } }
		
		[Constructable]
		public ChargedDyeTub() : this ( 50, 0 )
		{
		}
			
		[Constructable]
		public ChargedDyeTub( int charges, int dyetype  ) : base ( 0xFAB )
		{
			i_DyeType = dyetype;
			Charges = charges;
			switch (i_DyeType)
			{
				case 0: default: Name = "Leather Armor Dye Tub"; break;
				case 1: Name = "Metal Armor Dye Tub"; break;
				case 2: Name = "Metal Weapon Dye Tub"; break;
			}
		}

		public override void OnDoubleClick( Mobile from )
		{
			if (IsChildOf(from.Backpack))
			{
				if (Hue == 0) 
				{
					from.SendMessage("Please select a hue...");
					from.SendHuePicker( new InternalPicker( this ) );
				}
				else if (i_Charges < 1)
					from.SendMessage("You don't have enough charges to dye anymore.");
				else switch (i_DyeType)
				{
					case 0: default: from.SendMessage("Please select leather armor to dye..."); from.Target = new InternalTarget( this, 0, Hue ); break;
					case 1: from.SendMessage("Please select metal armor to dye..."); from.Target = new InternalTarget( this, 1, Hue ); break;
					case 2: from.SendMessage("Please select metal weapon to dye..."); from.Target = new InternalTarget( this, 2, Hue ); break;
				}
			}
		}

		public ChargedDyeTub( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( (int) i_DyeType );
			writer.Write( (int) i_Charges );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			i_DyeType = reader.ReadInt();
			i_Charges = reader.ReadInt();
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			AddNameProperty( list );

			if (Charges < 1)
				list.Add("{0} without charges", Name);
			else
				list.Add("{0} with {1} charges", Name, Charges);

			if ( IsSecure )
				AddSecureProperty( list );
			else if ( IsLockedDown )
				AddLockedDownProperty( list );

			if ( DisplayLootType )
				AddLootTypeProperty( list );
		}
		
		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			if (IsChildOf(from.Backpack))
				list.Add( new ChargedDyeTubMenu( from, this ) );
		}

		public static void SelectHueNumber( Mobile from, ChargedDyeTub tub )
		{
			if (tub.IsChildOf(from.Backpack))
				from.SendGump( new ChargedDyeTubGump(from, tub, tub.Hue));
		}

		private class InternalTarget : Target
		{
			private ChargedDyeTub it_Tub;
			private int i_DyeType, i_DyeHue;

			public InternalTarget( ChargedDyeTub tub, int dyetype, int dyehue ) : base( 1, false, TargetFlags.None )
			{
				it_Tub = tub;
				i_DyeType = dyetype;
				i_DyeHue = dyehue;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Item )
				{
					Item item = (Item)targeted;
					if (it_Tub != null)
					{
						if (!(item.IsChildOf(from.Backpack)))
						{			
							from.SendMessage("This must be in your backpack.");
						}
						else if (targeted is ChargedDyeTub)
						{
							ChargedDyeTub tub = targeted as ChargedDyeTub;
							if (it_Tub == tub)
							{
								from.SendMessage("Please select a hue...");
								from.SendHuePicker( new InternalPicker( tub ) );
							}
							else if (tub.DyeType == i_DyeType)
							{
								it_Tub.Charges += tub.Charges;
								from.SendMessage("You combined the dye tubs");
								tub.Delete();
							}
							else
								from.SendMessage("You can't combine different charged dye tubs");
						}
						else switch (i_DyeType)
						{
							case 0: default:  //leather armor
							{
								if ( targeted is BaseArmor && (((BaseArmor)item).MaterialType == ArmorMaterialType.Leather || ((BaseArmor)item).MaterialType == ArmorMaterialType.Studded))
								{
									item.Hue = i_DyeHue;
									from.PlaySound( 0x23E );
									it_Tub.Charges--;
								}
								else
									from.SendMessage("That's not leather armor!!!");
								break;
							}
							case 1: //metal armor
							{
								if ( targeted is BaseArmor && !(targeted is BaseShield) && !(((BaseArmor)item).MaterialType == ArmorMaterialType.Leather || ((BaseArmor)item).MaterialType == ArmorMaterialType.Studded))
								{
									item.Hue = i_DyeHue;
									from.PlaySound( 0x23E );
									it_Tub.Charges--;
								}
								else
									from.SendMessage("That's not metal armor!!!");
								break;
							}
							case 2: //weapons
							{
								if ( targeted is BaseWeapon && !(targeted is BaseRanged) && !(targeted is BaseStaff) && ((BaseWeapon)item).Resource >= CraftResource.Iron && ((BaseWeapon)item).Resource <= CraftResource.Platinum )
								{
									item.Hue = i_DyeHue;
									from.PlaySound( 0x23E );
									it_Tub.Charges--;
								}
								else
									from.SendMessage("That's not metal weapon!!!");
								break;
							}
						}
					}
				}
			}
		}

		private class InternalPicker : HuePicker
		{
			private ChargedDyeTub m_Tub;

			public InternalPicker( ChargedDyeTub tub ) : base( tub.ItemID )
			{
				m_Tub = tub;
			}

			public override void OnResponse( int hue )
			{
				m_Tub.Hue = hue;
			}
		}

		public class ChargedDyeTubMenu : ContextMenuEntry
		{
			private Mobile m_From;
			private ChargedDyeTub c_Tub;

			public ChargedDyeTubMenu( Mobile from, ChargedDyeTub tub ) : base( 5049 )
			{
				m_From = from;
				c_Tub = tub;
			}

			public override void OnClick()
			{
				m_From.SendGump( new ChargedDyeTubGump(m_From, c_Tub, c_Tub.Hue));
			}
		}

		public class ChargedDyeTubGump : Gump
		{
			private int i_Hue;
			private Mobile m_From;
			private ChargedDyeTub c_Tub;

			public ChargedDyeTubGump( Mobile from, ChargedDyeTub tub, int hue ) : base(0, 0)
			{
				m_From = from;
				if (!(m_From is PlayerMobile))
					return;
				c_Tub = tub;
				i_Hue = hue;
				
				Resizable=false;
				AddPage(0);
				AddBackground(20, 20, 320, 130, 2620);
				AddLabel(35, 40, 89, @"Please type which hue number you want to use");
				AddTextEntry(70, 70, 70, 20, i_Hue, 1, i_Hue.ToString());
				AddButton(35, 67, 2644, 2645, 2, GumpButtonType.Reply, 0);
				AddLabel(35, 100, i_Hue, @"This is the current hue number " + i_Hue + ".");
				
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				if ( m_From.Deleted || c_Tub.Deleted ) 
					return; 
				if ( info.ButtonID == 2 )
				{
					TextRelay tr_BuyTickets = info.GetTextEntry( 1 );
					if(tr_BuyTickets != null)
					{
						try
						{
							int i_NewHue = Convert.ToInt32(tr_BuyTickets.Text,10);
							if ( i_NewHue >= 0 && i_NewHue <= 2998 && c_Tub.IsChildOf(m_From.Backpack) ) 
							{
								c_Tub.Hue = i_NewHue;
								m_From.SendGump( new ChargedDyeTubGump( m_From, c_Tub, i_NewHue ) );
							}
							else
								m_From.SendGump( new ChargedDyeTubGump( m_From, c_Tub, i_Hue ) );
						} 
						catch
						{
							m_From.SendMessage("Please make sure you wrote only numbers.");
							m_From.SendGump( new ChargedDyeTubGump( m_From, c_Tub, i_Hue ) );
						}
					}
				}
			}
		}
	}
}