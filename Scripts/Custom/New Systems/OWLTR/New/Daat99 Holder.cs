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
using System;
using System.Collections;
using daat99;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class NewDaat99Holder
	{
		private ArrayList alItemTypeList;
		public ArrayList ItemTypeList{ get{ return alItemTypeList; } set{ alItemTypeList = value; } }
		
		private ArrayList alResources;
		public ArrayList Resources{ get{ return alResources; } set{ alResources = value; } }
		
		private DateTime dtNextReward;
		public TimeSpan NextReward
		{
			get
			{
				TimeSpan ts = dtNextReward - DateTime.Now;

				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;

				return ts;
			}
			set
			{
				try{ dtNextReward = DateTime.Now + value; }
				catch{}
			}
		}

		private int iItemsCrafted;
		public int ItemsCrafted{ get{ return iItemsCrafted; } set{ iItemsCrafted = value; } }

		public NewDaat99Holder()
		{
			DefaultHolder(this);//need to set default holder values here
		}

		public NewDaat99Holder( ArrayList ItemTypeList, ArrayList resources, TimeSpan nextreward, int itemscrafted )
		{
			alItemTypeList = ItemTypeList;
			alResources = resources;
			NextReward = nextreward;
			iItemsCrafted = itemscrafted;
		}

		public void DefaultHolder( NewDaat99Holder dh )
		{
			alItemTypeList = new ArrayList();
			alResources = new ArrayList();
			for (int ii = 0; ii < RecipesLists.All.Count; ii++)
				alItemTypeList.Add((Type)RecipesLists.All[ii]);
			for (int ii = 0; ii < RecipesLists.Resources.Count; ii++)
				alResources.Add(RecipesLists.Resources[ii]);
			
			int i = 0;
			int backup = 0;
			Type temp;

			//Tinkering
			if ( RecipesLists.TN1.Count > 1 )
			{
				for (i = 0; i < 10; i++)
				{
					temp = (Type)RecipesLists.TN1[Utility.Random((int)(RecipesLists.TN1.Count))];
					if ( dh.alItemTypeList.Contains( temp ) )
					{
						dh.alItemTypeList.Remove( temp );
						if (backup != 0)
						{
							backup = 0;
							break;
						}
						else
							backup++;
					}
				}
			}
			else if ( RecipesLists.TN1.Count == 1 && dh.alItemTypeList.Contains( (Type)RecipesLists.TN1[0] ) )
				dh.alItemTypeList.Remove( (Type)RecipesLists.TN1[0] );
			
			if (RecipesLists.TN2.Count > 0)
			{
				temp = (Type)RecipesLists.TN2[Utility.Random((int)(RecipesLists.TN2.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.TN3.Count > 0)
			{
				temp = (Type)RecipesLists.TN3[Utility.Random((int)(RecipesLists.TN3.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.TN4.Count > 0)
			{
				temp = (Type)RecipesLists.TN4[Utility.Random((int)(RecipesLists.TN4.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.TN5.Count > 0)
			{
				temp = (Type)RecipesLists.TN5[Utility.Random((int)(RecipesLists.TN5.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}

			//Blacksmithy
			if ( RecipesLists.BS1.Count > 1 )
			{
				for (i = 0; i < 10; i++)
				{
					temp = (Type)RecipesLists.BS1[Utility.Random((int)(RecipesLists.BS1.Count))];
					if ( dh.alItemTypeList.Contains( temp ) )
					{
						dh.alItemTypeList.Remove( temp );
						if (backup != 0)
						{
							backup = 0;
							break;
						}
						else
							backup++;
					}
				}
			}
			else if ( RecipesLists.BS1.Count == 1 && dh.alItemTypeList.Contains( (Type)RecipesLists.BS1[0] ) )
				dh.alItemTypeList.Remove( (Type)RecipesLists.BS1[0] );
			if (RecipesLists.BS2.Count > 0)
			{
				temp = (Type)RecipesLists.BS2[Utility.Random((int)(RecipesLists.BS2.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.BS3.Count > 0)
			{
				temp = (Type)RecipesLists.BS3[Utility.Random((int)(RecipesLists.BS3.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.BS4.Count > 0)
			{
				temp = (Type)RecipesLists.BS4[Utility.Random((int)(RecipesLists.BS4.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.BS5.Count > 0)
			{
				temp = (Type)RecipesLists.BS5[Utility.Random((int)(RecipesLists.BS5.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			
			//Tailoring
			if ( RecipesLists.TL1.Count > 1 )
			{
				for (i = 0; i < 10; i++)
				{
					temp = (Type)RecipesLists.TL1[Utility.Random((int)(RecipesLists.TL1.Count))];
					if ( dh.alItemTypeList.Contains( temp ) )
					{
						dh.alItemTypeList.Remove( temp );
						if (backup != 0)
						{
							backup = 0;
							break;
						}
						else
							backup++;
					}
				}
			}
			else if ( RecipesLists.TL1.Count == 1 && dh.alItemTypeList.Contains( (Type)RecipesLists.TL1[0] ) )
				dh.alItemTypeList.Remove( (Type)RecipesLists.TL1[0] );
			if (RecipesLists.TL2.Count > 0)
			{
				temp = (Type)RecipesLists.TL2[Utility.Random((int)(RecipesLists.TL2.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.TL3.Count > 0)
			{
				temp = (Type)RecipesLists.TL3[Utility.Random((int)(RecipesLists.TL3.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.TL4.Count > 0)
			{
				temp = (Type)RecipesLists.TL4[Utility.Random((int)(RecipesLists.TL4.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.TL5.Count > 0)
			{
				temp = (Type)RecipesLists.TL5[Utility.Random((int)(RecipesLists.TL5.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			
			//Cooking
			if ( RecipesLists.CK1.Count > 1 )
			{
				for (i = 0; i < 10; i++)
				{
					temp = (Type)RecipesLists.CK1[Utility.Random((int)(RecipesLists.CK1.Count))];
					if ( dh.alItemTypeList.Contains( temp ) )
					{
						dh.alItemTypeList.Remove( temp );
						if (backup != 0)
						{
							backup = 0;
							break;
						}
						else
							backup++;
					}
				}
			}
			else if ( RecipesLists.CK1.Count == 1 && dh.alItemTypeList.Contains( (Type)RecipesLists.CK1[0] ) )
				dh.alItemTypeList.Remove( (Type)RecipesLists.CK1[0] );
			if (RecipesLists.CK2.Count > 0)
			{
				temp = (Type)RecipesLists.CK2[Utility.Random((int)(RecipesLists.CK2.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.CK3.Count > 0)
			{
				temp = (Type)RecipesLists.CK3[Utility.Random((int)(RecipesLists.CK3.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.CK4.Count > 0)
			{
				temp = (Type)RecipesLists.CK4[Utility.Random((int)(RecipesLists.CK4.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.CK5.Count > 0)
			{
				temp = (Type)RecipesLists.CK5[Utility.Random((int)(RecipesLists.CK5.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}

			//Alchemy
			if ( RecipesLists.ACall.Count > 1 )
			{
				for (i = 0; i < 10; i++)
				{
					temp = (Type)RecipesLists.ACall[Utility.Random((int)(RecipesLists.ACall.Count))];
					if ( dh.alItemTypeList.Contains( temp ) )
					{
						dh.alItemTypeList.Remove( temp );
						if (backup != 0)
						{
							backup = 0;
							break;
						}
						else
							backup++;
					}
				}
			}

			//Inscription
			if ( RecipesLists.IN1.Count > 1 )
			{
				for (i = 0; i < 10; i++)
				{
					temp = (Type)RecipesLists.IN1[Utility.Random((int)(RecipesLists.IN1.Count))];
					if ( dh.alItemTypeList.Contains( temp ) )
					{
						dh.alItemTypeList.Remove( temp );
						if (backup != 0)
						{
							backup = 0;
							break;
						}
						else
							backup++;
					}
				}
			}
			else if ( RecipesLists.IN1.Count == 1 && dh.alItemTypeList.Contains( (Type)RecipesLists.IN1[0] ) )
				dh.alItemTypeList.Remove( (Type)RecipesLists.IN1[0] );
			if (RecipesLists.IN2.Count > 0)
			{
				temp = (Type)RecipesLists.IN2[Utility.Random((int)(RecipesLists.IN2.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.IN3.Count > 0)
			{
				temp = (Type)RecipesLists.IN3[Utility.Random((int)(RecipesLists.IN3.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.IN4.Count > 0)
			{
				temp = (Type)RecipesLists.IN4[Utility.Random((int)(RecipesLists.IN4.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.IN5.Count > 0)
			{
				temp = (Type)RecipesLists.IN5[Utility.Random((int)(RecipesLists.IN5.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}

			//BowFletching
			if (RecipesLists.BF1.Count > 0)
			{
				temp = (Type)RecipesLists.BF1[Utility.Random((int)(RecipesLists.BF1.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}

			//Carpentry
			if ( RecipesLists.CR1.Count > 1 )
			{
				for (i = 0; i < 10; i++)
				{
					temp = (Type)RecipesLists.CR1[Utility.Random((int)(RecipesLists.CR1.Count))];
					if ( dh.alItemTypeList.Contains( temp ) )
					{
						dh.alItemTypeList.Remove( temp );
						if (backup != 0)
						{
							backup = 0;
							break;
						}
						else
							backup++;
					}
				}
			}
			else if ( RecipesLists.CR1.Count == 1 && dh.alItemTypeList.Contains( (Type)RecipesLists.CR1[0] ) )
				dh.alItemTypeList.Remove( (Type)RecipesLists.CR1[0] );
			if (RecipesLists.CR2.Count > 0)
			{
				temp = (Type)RecipesLists.CR2[Utility.Random((int)(RecipesLists.CR2.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.CR3.Count > 0)
			{
				temp = (Type)RecipesLists.CR3[Utility.Random((int)(RecipesLists.CR3.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.CR4.Count > 0)
			{
				temp = (Type)RecipesLists.CR4[Utility.Random((int)(RecipesLists.CR4.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
			if (RecipesLists.CR5.Count > 0)
			{
				temp = (Type)RecipesLists.CR5[Utility.Random((int)(RecipesLists.CR5.Count))];
				if ( dh.alItemTypeList.Contains( temp ) )
					dh.alItemTypeList.Remove( temp );
			}
		}
		
		public void GiveDedication( Mobile from, CraftSystem cs )
		{
			if ( alItemTypeList.Count < 1 )
				return;
			Type type = alItemTypeList[Utility.Random(alItemTypeList.Count)] as Type;
			for ( int i = 0; i < 25; i++ )
			{
				if		( cs is DefTinkering	&& RecipesLists.TNall.Contains( type ) ) break;
				else if ( cs is DefBlacksmithy	&& RecipesLists.BSall.Contains( type ) ) break;
				else if ( cs is DefCooking		&& RecipesLists.CKall.Contains( type ) ) break;
				else if ( cs is DefGlassblowing	&& RecipesLists.GBall.Contains( type ) ) break;
				else if ( cs is DefAlchemy		&& RecipesLists.ACall.Contains( type ) ) break;
				else if ( cs is DefInscription	&& RecipesLists.INall.Contains( type ) ) break;
				else if ( cs is DefBowFletching	&& RecipesLists.BFall.Contains( type ) ) break;
				else if ( cs is DefMasonry		&& RecipesLists.MSall.Contains( type ) ) break;
				else if ( cs is DefCarpentry	&& RecipesLists.CRall.Contains( type ) ) break;
				type = alItemTypeList[Utility.Random(alItemTypeList.Count)] as Type;
			}
			if (type == null)
				return;
			
			string s_Key = type.Name, s_Temp = type.Name;
			int i_Break = s_Temp.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(),1);
			if ( i_Break > -1 )
			{
				s_Key = s_Temp.Substring( 0, i_Break );
				s_Temp = s_Temp.Substring( i_Break );
				i_Break = s_Temp.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(),1);
				while ( i_Break > -1 )
				{
					s_Key = s_Key + " " + s_Temp.Substring(0, i_Break );
					s_Temp =  s_Temp.Substring( i_Break );
					i_Break = s_Temp.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(),1);
				}
				if ( s_Temp != null && s_Temp != s_Key )
					s_Key += " " + s_Temp;
			}
			
			alItemTypeList.Remove(type);
			from.SendMessage(88, "Your dedication to crafting has paid off, you felt an inspiration and you learned how to make {0}.", s_Key );
			
			iItemsCrafted -= 100;
			NextReward = TimeSpan.FromHours( 24.0 );
		}

		public void Serialize( GenericWriter writer )
		{ 
			writer.Write( (int) 0 ); // version
			writer.Write( (TimeSpan) NextReward );
			writer.Write( (int) iItemsCrafted );
			writer.Write( alItemTypeList.Count );

			for ( int i = 0; i < alItemTypeList.Count; ++i )
			{
				if( alItemTypeList[i] != null ) //MUST HAVE THIS NULL CHECK serial 005
					writer.Write( (string) alItemTypeList[i].ToString() );
				else
					writer.Write( (string)"error - bad type" );
			}

			writer.Write( alResources.Count );
			for ( int i = 0; i < alResources.Count; ++i )
				writer.Write( (int) alResources[i] );
		}

		public NewDaat99Holder( GenericReader reader )  //deserialize
		{ 
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					NextReward = reader.ReadTimeSpan();
					iItemsCrafted = reader.ReadInt();

					int length = reader.ReadInt();
					alItemTypeList = new ArrayList();
					for (int i=0; i < length; i++)
					{
						try { alItemTypeList.Add(ScriptCompiler.FindTypeByFullName(reader.ReadString())); }
						catch{}
					}

					length = reader.ReadInt();
					alResources = new ArrayList();
					for (int i=0; i < length; i++)
					{
						try { alResources.Add((CraftResource)reader.ReadInt()); }
						catch{}
					}
					break;
				}
			}
		} 
	}

	public class Daat99HolderGump : Gump
	{
		private PlayerMobile pmFrom;
		private NewDaat99Holder dhNDH;
		private Mobile mOwner;
		private bool bAdd;
		public Daat99HolderGump(Mobile from, NewDaat99Holder dh, Mobile owner, bool add) : base(0, 0)
		{
			if (!(from is PlayerMobile))
				return;

			pmFrom = (PlayerMobile)from;
			dhNDH = dh;
			mOwner = owner;
			bAdd = add;
			pmFrom.CloseGump(typeof(Daat99HolderGump));

			AddPage(0);
			AddBackground(3, 3, 365, 430, 2600);
			
			AddHtml(45, 25, 280, 20, String.Format("<basefont color=#0000ff><center>{0}</basefont></center>", mOwner.Name + "'s Daat99 Holder"), false, false);
			AddLabel(30, 50, 33, "Level");
			AddImage(120, 50, 2225);
			AddImage(150, 50, 2226);
			AddImage(180, 50, 2227);
			AddImage(210, 50, 2228);
			AddImage(240, 50, 2229);
			AddImage(270, 50, 2230);
			AddLabel(300, 50, 33, "All:");
			
			AddLabel(30, 75, 64, "Tinkering:");
			AddLabel(30, 100, 64, "Blacksmithy:");
			AddLabel(30, 125, 64, "Tailoring:");
			AddLabel(30, 150, 64, "Cooking:");
			AddLabel(30, 175, 64, "Glassblowing:");
			AddLabel(30, 200, 64, "Alchemy:");
			AddLabel(30, 225, 64, "Inscription:");
			AddLabel(30, 250, 64, "Bowfletching:");
			AddLabel(30, 275, 64, "Masonry:");
			AddLabel(30, 300, 64, "Carpentry:");
			AddLabel(30, 325, 64, "All:");
			
			for (int skill = 1; skill <= 11; skill++)
				for (int level = 1; level <= 7; level++)
					AddButton(90 + level*30, 50 + skill*25, 9020, 9021, level + skill*100, GumpButtonType.Reply, 0);

			AddLabel(30, 345, 64, "Resources:");
			AddLabel(100, 345, 40, "Ore:");
			AddButton(125, 345, 9020, 9021, 51, GumpButtonType.Reply, 0);
			AddLabel(150, 345, 40, "Wood:");
			AddButton(185, 345, 9020, 9021, 52, GumpButtonType.Reply, 0);
			AddLabel(210, 345, 40, "Leather:");
			AddButton(260, 345, 9020, 9021, 53, GumpButtonType.Reply, 0);
			AddLabel(285, 345, 40, "Scale:");
			AddButton(320, 345, 9020, 9021, 54, GumpButtonType.Reply, 0);
			
			AddLabel( 30, 365, 30, @"Press above to add\remove items from the holder.");
			AddRadio( 70, 383, 9727, 9730, add, 1 );
			AddLabel( 105, 385, 32, "Add");

			AddButton( 145 , 385, 1214, 1213, 100, GumpButtonType.Reply, 0);

			AddRadio( 230, 383, 9727, 9730, !add, 0 );
			AddLabel( 265, 385, 32, "Remove");
		}
		public override void OnResponse(NetState state, RelayInfo info)
		{
			Mobile from = state.Mobile;
			if (dhNDH == null)
				return;
			if (info.IsSwitched(1))
			{
				switch (info.ButtonID)
				{
					case 51: { for ( int i=0; i < RecipesLists.Metal.Length; i++)	if ( dhNDH.Resources.Contains(RecipesLists.Metal[i])) dhNDH.Resources.Remove((CraftResource)RecipesLists.Metal[i]); break; }
					case 52: { for ( int i=0; i < RecipesLists.Wood.Length; i++)	if ( dhNDH.Resources.Contains(RecipesLists.Wood[i])) dhNDH.Resources.Remove((CraftResource)RecipesLists.Wood[i]); break; }
					case 53: { for ( int i=0; i < RecipesLists.Leather.Length; i++)	if ( dhNDH.Resources.Contains(RecipesLists.Leather[i])) dhNDH.Resources.Remove((CraftResource)RecipesLists.Leather[i]); break; }
					case 54: { for ( int i=0; i < RecipesLists.Scales.Length; i++)	if ( dhNDH.Resources.Contains(RecipesLists.Scales[i])) dhNDH.Resources.Remove((CraftResource)RecipesLists.Scales[i]); break; }
					case 101: { for (int i=0; i < RecipesLists.TN1.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TN1[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TN1[i]); break; }
					case 102: { for (int i=0; i < RecipesLists.TN2.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TN2[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TN2[i]); break; }
					case 103: { for (int i=0; i < RecipesLists.TN3.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TN3[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TN3[i]); break; }
					case 104: { for (int i=0; i < RecipesLists.TN4.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TN4[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TN4[i]); break; }
					case 105: { for (int i=0; i < RecipesLists.TN5.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TN5[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TN5[i]); break; }
					case 106: { for (int i=0; i < RecipesLists.TN6.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TN6[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TN6[i]); break; }
					case 107: { for (int i=0; i < RecipesLists.TNall.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.TNall[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TNall[i]); break; }
					case 201: { for (int i=0; i < RecipesLists.BS1.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BS1[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BS1[i]); break; }
					case 202: { for (int i=0; i < RecipesLists.BS2.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BS2[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BS2[i]); break; }
					case 203: { for (int i=0; i < RecipesLists.BS3.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BS3[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BS3[i]); break; }
					case 204: { for (int i=0; i < RecipesLists.BS4.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BS4[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BS4[i]); break; }
					case 205: { for (int i=0; i < RecipesLists.BS5.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BS5[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BS5[i]); break; }
					case 206: { for (int i=0; i < RecipesLists.BS6.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BS6[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BS6[i]); break; }
					case 207: { for (int i=0; i < RecipesLists.BSall.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.BSall[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BSall[i]); break; }
					case 301: { for (int i=0; i < RecipesLists.TL1.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TL1[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TL1[i]); break; }
					case 302: { for (int i=0; i < RecipesLists.TL2.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TL2[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TL2[i]); break; }
					case 303: { for (int i=0; i < RecipesLists.TL3.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TL3[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TL3[i]); break; }
					case 304: { for (int i=0; i < RecipesLists.TL4.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TL4[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TL4[i]); break; }
					case 305: { for (int i=0; i < RecipesLists.TL5.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TL5[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TL5[i]); break; }
					case 306: { for (int i=0; i < RecipesLists.TL6.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.TL6[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TL6[i]); break; }
					case 307: { for (int i=0; i < RecipesLists.TLall.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.TLall[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.TLall[i]); break; }
					case 401: { for (int i=0; i < RecipesLists.CK1.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CK1[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CK1[i]); break; }
					case 402: { for (int i=0; i < RecipesLists.CK2.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CK2[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CK2[i]); break; }
					case 403: { for (int i=0; i < RecipesLists.CK3.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CK3[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CK3[i]); break; }
					case 404: { for (int i=0; i < RecipesLists.CK4.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CK4[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CK4[i]); break; }
					case 405: { for (int i=0; i < RecipesLists.CK5.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CK5[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CK5[i]); break; }
					case 406: { for (int i=0; i < RecipesLists.CK6.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CK6[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CK6[i]); break; }
					case 407: { for (int i=0; i < RecipesLists.CKall.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.CKall[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CKall[i]); break; }
					case 501: { for (int i=0; i < RecipesLists.GB1.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.GB1[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.GB1[i]); break; }
					case 502: { for (int i=0; i < RecipesLists.GB2.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.GB2[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.GB2[i]); break; }
					case 503: { for (int i=0; i < RecipesLists.GB3.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.GB3[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.GB3[i]); break; }
					case 504: { for (int i=0; i < RecipesLists.GB4.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.GB4[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.GB4[i]); break; }
					case 505: { for (int i=0; i < RecipesLists.GB5.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.GB5[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.GB5[i]); break; }
					case 506: { for (int i=0; i < RecipesLists.GB6.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.GB6[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.GB6[i]); break; }
					case 507: { for (int i=0; i < RecipesLists.GBall.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.GBall[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.GBall[i]); break; }
					case 601: { for (int i=0; i < RecipesLists.AC1.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.AC1[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.AC1[i]); break; }
					case 602: { for (int i=0; i < RecipesLists.AC2.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.AC2[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.AC2[i]); break; }
					case 603: { for (int i=0; i < RecipesLists.AC3.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.AC3[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.AC3[i]); break; }
					case 604: { for (int i=0; i < RecipesLists.AC4.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.AC4[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.AC4[i]); break; }
					case 605: { for (int i=0; i < RecipesLists.AC5.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.AC5[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.AC5[i]); break; }
					case 606: { for (int i=0; i < RecipesLists.AC6.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.AC6[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.AC6[i]); break; }
					case 607: { for (int i=0; i < RecipesLists.ACall.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.ACall[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.ACall[i]); break; }
					case 701: { for (int i=0; i < RecipesLists.IN1.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.IN1[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.IN1[i]); break; }
					case 702: { for (int i=0; i < RecipesLists.IN2.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.IN2[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.IN2[i]); break; }
					case 703: { for (int i=0; i < RecipesLists.IN3.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.IN3[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.IN3[i]); break; }
					case 704: { for (int i=0; i < RecipesLists.IN4.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.IN4[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.IN4[i]); break; }
					case 705: { for (int i=0; i < RecipesLists.IN5.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.IN5[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.IN5[i]); break; }
					case 706: { for (int i=0; i < RecipesLists.IN6.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.IN6[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.IN6[i]); break; }
					case 707: { for (int i=0; i < RecipesLists.INall.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.INall[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.INall[i]); break; }
					case 801: { for (int i=0; i < RecipesLists.BF1.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BF1[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BF1[i]); break; }
					case 802: { for (int i=0; i < RecipesLists.BF2.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BF2[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BF2[i]); break; }
					case 803: { for (int i=0; i < RecipesLists.BF3.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BF3[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BF3[i]); break; }
					case 804: { for (int i=0; i < RecipesLists.BF4.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BF4[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BF4[i]); break; }
					case 805: { for (int i=0; i < RecipesLists.BF5.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BF5[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BF5[i]); break; }
					case 806: { for (int i=0; i < RecipesLists.BF6.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.BF6[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BF6[i]); break; }
					case 807: { for (int i=0; i < RecipesLists.BFall.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.BFall[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.BFall[i]); break; }
					case 901: { for (int i=0; i < RecipesLists.MS1.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.MS1[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.MS1[i]); break; }
					case 902: { for (int i=0; i < RecipesLists.MS2.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.MS2[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.MS2[i]); break; }
					case 903: { for (int i=0; i < RecipesLists.MS3.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.MS3[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.MS3[i]); break; }
					case 904: { for (int i=0; i < RecipesLists.MS4.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.MS4[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.MS4[i]); break; }
					case 905: { for (int i=0; i < RecipesLists.MS5.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.MS5[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.MS5[i]); break; }
					case 906: { for (int i=0; i < RecipesLists.MS6.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.MS6[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.MS6[i]); break; }
					case 907: { for (int i=0; i < RecipesLists.MSall.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.MSall[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.MSall[i]); break; }
					case 1001: { for (int i=0; i < RecipesLists.CR1.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CR1[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CR1[i]); break; }
					case 1002: { for (int i=0; i < RecipesLists.CR2.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CR2[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CR2[i]); break; }
					case 1003: { for (int i=0; i < RecipesLists.CR3.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CR3[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CR3[i]); break; }
					case 1004: { for (int i=0; i < RecipesLists.CR4.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CR4[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CR4[i]); break; }
					case 1005: { for (int i=0; i < RecipesLists.CR5.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CR5[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CR5[i]); break; }
					case 1006: { for (int i=0; i < RecipesLists.CR6.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.CR6[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CR6[i]); break; }
					case 1007: { for (int i=0; i < RecipesLists.CRall.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.CRall[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.CRall[i]); break; }
					case 1101: { for (int i=0; i < RecipesLists.Lvl1.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl1[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.Lvl1[i]); break; }
					case 1102: { for (int i=0; i < RecipesLists.Lvl2.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl2[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.Lvl2[i]); break; }
					case 1103: { for (int i=0; i < RecipesLists.Lvl3.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl3[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.Lvl3[i]); break; }
					case 1104: { for (int i=0; i < RecipesLists.Lvl4.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl4[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.Lvl4[i]); break; }
					case 1105: { for (int i=0; i < RecipesLists.Lvl5.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl5[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.Lvl5[i]); break; }
					case 1106: { for (int i=0; i < RecipesLists.Lvl6.Count; i++)	if ( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl6[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.Lvl6[i]); break; }
					case 1107: { for (int i=0; i < RecipesLists.All.Count; i++)		if ( dhNDH.ItemTypeList.Contains( RecipesLists.All[i] ) ) dhNDH.ItemTypeList.Remove((Type)RecipesLists.All[i]); break; }
				}
			}
			else
			{
				switch (info.ButtonID)
				{
					case 51: { for ( int i=0; i < RecipesLists.Metal.Length; i++)	if (!( dhNDH.Resources.Contains(RecipesLists.Metal[i]))) dhNDH.Resources.Add((CraftResource)RecipesLists.Metal[i]); break; }
					case 52: { for ( int i=0; i < RecipesLists.Wood.Length; i++)	if (!( dhNDH.Resources.Contains(RecipesLists.Wood[i]))) dhNDH.Resources.Add((CraftResource)RecipesLists.Wood[i]); break; }
					case 53: { for ( int i=0; i < RecipesLists.Leather.Length; i++)	if (!( dhNDH.Resources.Contains(RecipesLists.Leather[i]))) dhNDH.Resources.Add((CraftResource)RecipesLists.Leather[i]); break; }
					case 54: { for ( int i=0; i < RecipesLists.Scales.Length; i++)	if (!( dhNDH.Resources.Contains(RecipesLists.Scales[i]))) dhNDH.Resources.Add((CraftResource)RecipesLists.Scales[i]); break; }
					case 101: { for (int i=0; i < RecipesLists.TN1.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TN1[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TN1[i]); break; }
					case 102: { for (int i=0; i < RecipesLists.TN2.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TN2[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TN2[i]); break; }
					case 103: { for (int i=0; i < RecipesLists.TN3.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TN3[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TN3[i]); break; }
					case 104: { for (int i=0; i < RecipesLists.TN4.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TN4[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TN4[i]); break; }
					case 105: { for (int i=0; i < RecipesLists.TN5.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TN5[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TN5[i]); break; }
					case 106: { for (int i=0; i < RecipesLists.TN6.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TN6[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TN6[i]); break; }
					case 107: { for (int i=0; i < RecipesLists.TNall.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TNall[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TNall[i]); break; }
					case 201: { for (int i=0; i < RecipesLists.BS1.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BS1[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BS1[i]); break; }
					case 202: { for (int i=0; i < RecipesLists.BS2.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BS2[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BS2[i]); break; }
					case 203: { for (int i=0; i < RecipesLists.BS3.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BS3[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BS3[i]); break; }
					case 204: { for (int i=0; i < RecipesLists.BS4.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BS4[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BS4[i]); break; }
					case 205: { for (int i=0; i < RecipesLists.BS5.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BS5[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BS5[i]); break; }
					case 206: { for (int i=0; i < RecipesLists.BS6.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BS6[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BS6[i]); break; }
					case 207: { for (int i=0; i < RecipesLists.BSall.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BSall[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BSall[i]); break; }
					case 301: { for (int i=0; i < RecipesLists.TL1.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TL1[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TL1[i]); break; }
					case 302: { for (int i=0; i < RecipesLists.TL2.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TL2[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TL2[i]); break; }
					case 303: { for (int i=0; i < RecipesLists.TL3.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TL3[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TL3[i]); break; }
					case 304: { for (int i=0; i < RecipesLists.TL4.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TL4[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TL4[i]); break; }
					case 305: { for (int i=0; i < RecipesLists.TL5.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TL5[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TL5[i]); break; }
					case 306: { for (int i=0; i < RecipesLists.TL6.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TL6[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TL6[i]); break; }
					case 307: { for (int i=0; i < RecipesLists.TLall.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.TLall[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.TLall[i]); break; }
					case 401: { for (int i=0; i < RecipesLists.CK1.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CK1[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CK1[i]); break; }
					case 402: { for (int i=0; i < RecipesLists.CK2.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CK2[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CK2[i]); break; }
					case 403: { for (int i=0; i < RecipesLists.CK3.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CK3[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CK3[i]); break; }
					case 404: { for (int i=0; i < RecipesLists.CK4.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CK4[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CK4[i]); break; }
					case 405: { for (int i=0; i < RecipesLists.CK5.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CK5[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CK5[i]); break; }
					case 406: { for (int i=0; i < RecipesLists.CK6.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CK6[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CK6[i]); break; }
					case 407: { for (int i=0; i < RecipesLists.CKall.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CKall[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CKall[i]); break; }
					case 501: { for (int i=0; i < RecipesLists.GB1.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.GB1[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.GB1[i]); break; }
					case 502: { for (int i=0; i < RecipesLists.GB2.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.GB2[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.GB2[i]); break; }
					case 503: { for (int i=0; i < RecipesLists.GB3.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.GB3[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.GB3[i]); break; }
					case 504: { for (int i=0; i < RecipesLists.GB4.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.GB4[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.GB4[i]); break; }
					case 505: { for (int i=0; i < RecipesLists.GB5.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.GB5[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.GB5[i]); break; }
					case 506: { for (int i=0; i < RecipesLists.GB6.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.GB6[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.GB6[i]); break; }
					case 507: { for (int i=0; i < RecipesLists.GBall.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.GBall[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.GBall[i]); break; }
					case 601: { for (int i=0; i < RecipesLists.AC1.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.AC1[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.AC1[i]); break; }
					case 602: { for (int i=0; i < RecipesLists.AC2.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.AC2[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.AC2[i]); break; }
					case 603: { for (int i=0; i < RecipesLists.AC3.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.AC3[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.AC3[i]); break; }
					case 604: { for (int i=0; i < RecipesLists.AC4.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.AC4[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.AC4[i]); break; }
					case 605: { for (int i=0; i < RecipesLists.AC5.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.AC5[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.AC5[i]); break; }
					case 606: { for (int i=0; i < RecipesLists.AC6.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.AC6[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.AC6[i]); break; }
					case 607: { for (int i=0; i < RecipesLists.ACall.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.ACall[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.ACall[i]); break; }
					case 701: { for (int i=0; i < RecipesLists.IN1.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.IN1[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.IN1[i]); break; }
					case 702: { for (int i=0; i < RecipesLists.IN2.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.IN2[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.IN2[i]); break; }
					case 703: { for (int i=0; i < RecipesLists.IN3.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.IN3[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.IN3[i]); break; }
					case 704: { for (int i=0; i < RecipesLists.IN4.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.IN4[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.IN4[i]); break; }
					case 705: { for (int i=0; i < RecipesLists.IN5.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.IN5[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.IN5[i]); break; }
					case 706: { for (int i=0; i < RecipesLists.IN6.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.IN6[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.IN6[i]); break; }
					case 707: { for (int i=0; i < RecipesLists.INall.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.INall[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.INall[i]); break; }
					case 801: { for (int i=0; i < RecipesLists.BF1.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BF1[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BF1[i]); break; }
					case 802: { for (int i=0; i < RecipesLists.BF2.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BF2[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BF2[i]); break; }
					case 803: { for (int i=0; i < RecipesLists.BF3.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BF3[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BF3[i]); break; }
					case 804: { for (int i=0; i < RecipesLists.BF4.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BF4[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BF4[i]); break; }
					case 805: { for (int i=0; i < RecipesLists.BF5.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BF5[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BF5[i]); break; }
					case 806: { for (int i=0; i < RecipesLists.BF6.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BF6[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BF6[i]); break; }
					case 807: { for (int i=0; i < RecipesLists.BFall.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.BFall[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.BFall[i]); break; }
					case 901: { for (int i=0; i < RecipesLists.MS1.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.MS1[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.MS1[i]); break; }
					case 902: { for (int i=0; i < RecipesLists.MS2.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.MS2[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.MS2[i]); break; }
					case 903: { for (int i=0; i < RecipesLists.MS3.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.MS3[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.MS3[i]); break; }
					case 904: { for (int i=0; i < RecipesLists.MS4.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.MS4[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.MS4[i]); break; }
					case 905: { for (int i=0; i < RecipesLists.MS5.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.MS5[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.MS5[i]); break; }
					case 906: { for (int i=0; i < RecipesLists.MS6.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.MS6[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.MS6[i]); break; }
					case 907: { for (int i=0; i < RecipesLists.MSall.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.MSall[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.MSall[i]); break; }
					case 1001: { for (int i=0; i < RecipesLists.CR1.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CR1[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CR1[i]); break; }
					case 1002: { for (int i=0; i < RecipesLists.CR2.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CR2[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CR2[i]); break; }
					case 1003: { for (int i=0; i < RecipesLists.CR3.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CR3[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CR3[i]); break; }
					case 1004: { for (int i=0; i < RecipesLists.CR4.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CR4[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CR4[i]); break; }
					case 1005: { for (int i=0; i < RecipesLists.CR5.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CR5[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CR5[i]); break; }
					case 1006: { for (int i=0; i < RecipesLists.CR6.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CR6[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CR6[i]); break; }
					case 1007: { for (int i=0; i < RecipesLists.CRall.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.CRall[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.CRall[i]); break; }
					case 1101: { for (int i=0; i < RecipesLists.Lvl1.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl1[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.Lvl1[i]); break; }
					case 1102: { for (int i=0; i < RecipesLists.Lvl2.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl2[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.Lvl2[i]); break; }
					case 1103: { for (int i=0; i < RecipesLists.Lvl3.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl3[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.Lvl3[i]); break; }
					case 1104: { for (int i=0; i < RecipesLists.Lvl4.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl4[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.Lvl4[i]); break; }
					case 1105: { for (int i=0; i < RecipesLists.Lvl5.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl5[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.Lvl5[i]); break; }
					case 1106: { for (int i=0; i < RecipesLists.Lvl6.Count; i++)	if (!( dhNDH.ItemTypeList.Contains( RecipesLists.Lvl6[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.Lvl6[i]); break; }
					case 1107: { for (int i=0; i < RecipesLists.All.Count; i++)		if (!( dhNDH.ItemTypeList.Contains( RecipesLists.All[i] ) )) dhNDH.ItemTypeList.Add((Type)RecipesLists.All[i]); break; }
				}
			}
			if (info.ButtonID == 100)
				dhNDH.DefaultHolder( dhNDH );
			else if (info.ButtonID >= 51)
				from.SendGump( new Daat99HolderGump(pmFrom, dhNDH, mOwner, info.IsSwitched(1)) );
		}
	}
}