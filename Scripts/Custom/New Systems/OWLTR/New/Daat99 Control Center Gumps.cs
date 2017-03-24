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
using Server;
using Server.Engines.BulkOrders;
using Server.Gumps; 
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Commands;

namespace daat99
{
	public class Daat99CustomOWLTRGump : Gump 
	{
		private bool b_ForStaff;
		private PlayerMobile p_From;

		private static readonly int OPTIONS_DIFF = 100;
		
		
		private enum BUTTONS_ENUM 
		{
			OK = 0,		WEBSITE,	TOKENS_EXCHANGE_AMOUNT,		TOKENS_EXCHANGE_SET,	FIRST_PAGE_INDEX
		}
		public Daat99CustomOWLTRGump( PlayerMobile from ) : base( 100, 100 ) 
		{
			p_From = from;
			if (from.AccessLevel >= AccessLevel.Administrator)
				b_ForStaff = true;
			else
				b_ForStaff = false;

			AddPage( 0 ); 
			AddBackground( 0, 0, 560, 480, 3500 ); //white
			string version = String.Format("{0}.{1:00}{2}", Daat99OWLTR.MajorVersion, Daat99OWLTR.MinorVersion, Daat99OWLTR.BuildNumber == 0 ? "" : "." + Daat99OWLTR.BuildNumber.ToString("00"));
			AddHtml( 65, 15, 450, 20, "<basefont color=#ff0000>Daat99's O.W.L.T.R (Ore Wood Leather Tokens Recipes) " + version + " Control Center:</basefont>", false, false ); 

			AddLabel(15,  40, 2, @"===================");
			AddLabel(55,  50, 2, @" /\");
			AddLabel(16,  60, 2, @" -----/---\-----");
			AddLabel(20,  70, 2, @" \ /     \ /");
			AddLabel(28,  80, 2, @" /       \");
			AddLabel(30,  80, 2, @" \       /");
			AddLabel(19,  90, 2, @" / \     / \");
			AddLabel(17, 100, 2, @" -----\---/-----");
			AddLabel(57, 110, 2, @" \/");
			AddLabel(15, 120, 2, @"===================");

			AddButton(160, 40, 5526, 5527, OPTIONS_DIFF + (int)BUTTONS_ENUM.WEBSITE, GumpButtonType.Reply, 0); //web site

			AddLabel( 155, 68, 1263, "Hall of Helpers" );
			AddButton( 135, 70, 4033, 4033, (int)BUTTONS_ENUM.FIRST_PAGE_INDEX + 1, GumpButtonType.Page, 1 );

			AddLabel( 35, 138, 70, @"Ubber Resources & Harvesting" );
			AddButton(15, 140, 4033, 4033, (int)BUTTONS_ENUM.FIRST_PAGE_INDEX + 2, GumpButtonType.Page, 2);

			AddLabel( 35, 158, 70, @"A_Li_N's Clean Champ" );
			AddButton(15, 160, 4033, 4033, (int)BUTTONS_ENUM.FIRST_PAGE_INDEX + 3, GumpButtonType.Page, 3);

			AddLabel( 35, 178, 70, @"Custom Craftables" );
			AddButton(15, 180, 4033, 4033, (int)BUTTONS_ENUM.FIRST_PAGE_INDEX + 4, GumpButtonType.Page, 4);

			AddLabel( 35, 198, 70, @"MuleForge\RunicJewelry\StorageResources" );
			AddButton(15, 200, 4033, 4033, (int)BUTTONS_ENUM.FIRST_PAGE_INDEX + 5, GumpButtonType.Page, 5);
			
			AddLabel( 35, 218, 70, @"Monsters and BoDs Tokens" );
			AddButton(15, 220, 4033, 4033, (int)BUTTONS_ENUM.FIRST_PAGE_INDEX + 6, GumpButtonType.Page, 6);

			AddLabel( 35, 238, 70, @"Harvesting and Crafting Tokens" );
			AddButton(15, 240, 4033, 4033, (int)BUTTONS_ENUM.FIRST_PAGE_INDEX + 7, GumpButtonType.Page, 7);

			AddLabel( 35, 258, 70, @"Recipe Crafting" );
			AddButton(15, 260, 4033, 4033, (int)BUTTONS_ENUM.FIRST_PAGE_INDEX + 8, GumpButtonType.Page, 8);

			AddLabel( 35, 278, 70, @"Resource Cost and Lottery\Exchange" );
			AddButton(15, 280, 4033, 4033, (int)BUTTONS_ENUM.FIRST_PAGE_INDEX + 9, GumpButtonType.Page, 9);

			AddLabel(35, 298, 70, @"Master Storage\Looter");
			AddButton(15, 300, 4033, 4033, (int)BUTTONS_ENUM.FIRST_PAGE_INDEX + 10, GumpButtonType.Page, 10);

			///DO NOT CHANGE THESE LINES
			AddPage( 1 ); //hall of helpers
			///DO NOT CHANGE THESE LINES
			///DO NOT CHANGE THESE LINES
			///DO NOT CHANGE THESE LINES
			///DO NOT CHANGE THESE LINES
			AddHtml(260, 45, 285, 20, String.Format("<basefont color=#ff00ff>Hall of Helpers:</font>"), false, false);
			///DO NOT CHANGE THESE LINES
			///DO NOT CHANGE THESE LINES
			AddHtml(260, 65, 285, 40, String.Format("<basefont color=#00ff00>I would like to say special Thanks for a huge assistance in testing efforts to:</font>"), false, false);
			///DO NOT CHANGE THESE LINES
			///DO NOT CHANGE THESE LINES
			AddHtml(260, 105, 285, 40, String.Format("<basefont color=#0000ff>Hammerhand, Alyssa Dark, GhostRiderGrey, John Moore, frank dalton and Thomas Gordon.</font>"), false, false);
			///DO NOT CHANGE THESE LINES
			///DO NOT CHANGE THESE LINES
			AddHtml(260, 145, 285, 40, String.Format("<basefont color=#ff0000>I would also like to say Thanks to my fellow RunUO & ServUO members:</font>"), false, false);
			///DO NOT CHANGE THESE LINES
			///DO NOT CHANGE THESE LINES
            AddHtml(260, 185, 285, 220, String.Format("<basefont color=#0000ff>ViWinfii, Lokai, UOT, ArteGordon, Guadah, Ashenfall, Ashlars and his beloved Morrigan, beau, Raider, Liam, telekea, porker, A_Li_N, Roseanne, RANCID77, Tark, n0brain, Arthemis, jjarmis, ssalter, Raelis, Briseis, Rift, bzk90, RoninGT, Memnoch, feralfreak, DaZiL, joshw, Greystar, XxSP1DERxX, Joeku, Freya, francecio, pvtjoker, Kiki, Viago, ChaosSally, Khephren, awakenlands, ChaosSally, Sotho Tal Ker, Wilcard, Beldr, Thundar, TesterSam, CynsPixie, Sunshine, TMSTKSBK, artio, Turmoil, KatNyte, Jakob, STalKer-X, ASayre8, alexander, Bham, toddjumper, Arvoreen, IndigoParadox, MatrixMan, Jebbit, Sorious, AdminVile, arul, RipRizzle.</font>"), false, false);
			///DO NOT CHANGE THESE LINES
			///DO NOT CHANGE THESE LINES
			///DO NOT CHANGE THESE LINES
			///DO NOT CHANGE THESE LINES
			
			AddPage( 2 ); 
			//ubber resources
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.UBBER_RESOURCES).AddToGump(this, 260, 35, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.UBBER_RESOURCES, true, true); 
			
			// mining
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.DAAT99_MINING).AddToGump(this, 260, 175, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.DAAT99_MINING, true); 

			// lumberjacking
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.DAAT99_LUMBERJACKING).AddToGump(this, 260, 325, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.DAAT99_LUMBERJACKING, true); 
			
			AddPage( 3 );
			//A_Li_N clean champ
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.A_LI_N_CLEAN_CHAMP).AddToGump(this, 260, 35, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.A_LI_N_CLEAN_CHAMP, true); 

			//A_Li_N 
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.SAVE_CLEAN_CHAMP_GOLD).AddToGump(this, 260, 175, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.SAVE_CLEAN_CHAMP_GOLD, true); 
			
			AddPage( 4 ); //custom craftables
			//BankHive
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.CRAFTING_BANK_HIVE).AddToGump(this, 260, 35, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.CRAFTING_BANK_HIVE, true); 
			
			//Storage Deeds
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.CRAFTING_STORAGE_DEEDS).AddToGump(this, 260, 135, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.CRAFTING_STORAGE_DEEDS, true); 

			//Mobile Forge
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.CRAFTING_MOBILE_FORGE).AddToGump(this, 260, 255, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.CRAFTING_MOBILE_FORGE, true); 

			AddPage( 5 );
			//Mule Forge
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.MULE_FORGE).AddToGump(this, 260, 35, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.MULE_FORGE, true); 

			//Runic Jewelry 
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.CRAFT_RUNIC_JEWELRY).AddToGump(this, 260, 175, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.CRAFT_RUNIC_JEWELRY, true); 
			
			//Use Storage Resources
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.USE_STORAGE_RESOURCES).AddToGump(this, 260, 315, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.USE_STORAGE_RESOURCES, true); 
			
			AddPage( 6 );
			//Monster Give Tokens
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.MONSTER_GIVE_TOKENS).AddToGump(this, 260, 35, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.MONSTER_GIVE_TOKENS, true); 

			//Bod Give Tokens 
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.BOD_GIVE_TOKENS).AddToGump(this, 260, 175, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.BOD_GIVE_TOKENS, true); 
			
			AddPage( 7 );
			//Harvest Give Tokens
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.HARVEST_GIVE_TOKENS).AddToGump(this, 260, 35, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.HARVEST_GIVE_TOKENS, true);

			//Craft Give Tokens 
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.CRAFT_GIVE_TOKENS).AddToGump(this, 260, 255, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.CRAFT_GIVE_TOKENS, true); 
			
			AddPage( 8 );
			//Recipe Craft
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.RECIPE_CRAFT).AddToGump(this, 260, 35, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.RECIPE_CRAFT, true); 
			
			//DedicationRecipes
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.DEDICATION_RECIPE).AddToGump(this, 260, 125, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.DEDICATION_RECIPE, true); 

			//crafts
			AddHtml( 260, 225, 285, 20, @"<basefont color=#ff0000>Enable\Disable each craft individualy:</font>", false, false );
			//alchemy
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.ALCHEMY_RECIPES).AddToGump(this, 260, 245, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.ALCHEMY_RECIPES);
			
			//Blacksmithy
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.BLACKSMITH_RECIPES).AddToGump(this, 260, 265, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.BLACKSMITH_RECIPES);
			
			//BowFletching
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.BOWFLETCH_RECIPES).AddToGump(this, 260, 285, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.BOWFLETCH_RECIPES);
			
			//Carpentry
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.CARPENTRY_RECIPES).AddToGump(this, 260, 305, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.CARPENTRY_RECIPES);
			
			//Cooking
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.COOKING_RECIPES).AddToGump(this, 260, 325, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.COOKING_RECIPES); 
			
			//Glassblowing
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.GLASSBLOWING_RECIPES).AddToGump(this, 260, 345, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.GLASSBLOWING_RECIPES); 
			
			//Inscription
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.INSCRIPTION_RECIPES).AddToGump(this, 260, 365, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.INSCRIPTION_RECIPES); 
			
			//Masonry
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.MASONRY_RECIPES).AddToGump(this, 260, 385, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.MASONRY_RECIPES); 

			//Glassblowing
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.TAILORING_RECIPES).AddToGump(this, 260, 405, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.TAILORING_RECIPES);

			//Tinkering
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.TINKERING_RECIPES).AddToGump(this, 260, 425, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.TINKERING_RECIPES); 
			
			//Resources
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.RECIPE_HARVESTING).AddToGump(this, 260, 445, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.RECIPE_HARVESTING); 
			
			AddPage( 9 );
			//Resource Cost
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.RESOURCE_COST).AddToGump(this, 260, 35, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.RESOURCE_COST, true); 

			//Tokens Lottery
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.TOKENS_LOTTERY).AddToGump(this, 260, 175, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.TOKENS_LOTTERY, true); 
			
			//Tokens Exchange
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.TOKENS_EXCHANGE).AddToGump(this, 260, 320, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.TOKENS_EXCHANGE, true); 
			AddHtml( 260, 380, 240, 20, String.Format( "<basefont color=#111111>Each token cost " + LadyLuck.TokenCostInGold + " gold coins.</font>" ), false, false );
			if (b_ForStaff)
			{
				AddLabel( 305, 415, 20, "Set a new price:");
				AddTextEntry( 415, 417, 90, 20, 32, (int)BUTTONS_ENUM.TOKENS_EXCHANGE_AMOUNT, LadyLuck.TokenCostInGold.ToString() );
				AddButton(260, 407, 2642, 2643, (int)BUTTONS_ENUM.TOKENS_EXCHANGE_SET, GumpButtonType.Reply, 0);
			}

			//Master Storage
			AddPage(10);
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.BLESSED_STORAGE).AddToGump(this, 260, 35, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.BLESSED_STORAGE, true); 
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.GOLD_STORAGE).AddToGump(this, 260, 115, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.GOLD_STORAGE, true); 
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.TOKEN_STORAGE).AddToGump(this, 260, 210, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.TOKEN_STORAGE, true); 
			OWLTROptionsManager.GetOption(OWLTROptionsManager.OPTIONS_ENUM.STORAGE_KEEP_ITEMS_DEATH).AddToGump(this, 260, 310, b_ForStaff, OPTIONS_DIFF + (int)OWLTROptionsManager.OPTIONS_ENUM.STORAGE_KEEP_ITEMS_DEATH, true);
			AddHtml(260, 420, 285, 40, "<basefont color=#770000>NOTE: Changes are immediate but existing MasterStorage items will show the old values until used.</font>", false, false);
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			Mobile from = state.Mobile;
			if (info.ButtonID == (int)BUTTONS_ENUM.WEBSITE)
				from.LaunchBrowser( "http://daat99.home.dyndns.org/index.html" );
			else if (!b_ForStaff)
				return;
			else if (info.ButtonID >= OPTIONS_DIFF) //switch settings
			{
				int optionId = info.ButtonID - OPTIONS_DIFF;
				if (Enum.IsDefined(typeof(OWLTROptionsManager.OPTIONS_ENUM), optionId))
					OWLTROptionsManager.SwitchOption((OWLTROptionsManager.OPTIONS_ENUM)optionId);
				else
					from.SendMessage(1173, "Unable to interpret the option id: " + optionId);
			}
			else if (info.ButtonID == (int)BUTTONS_ENUM.TOKENS_EXCHANGE_SET)
			{
				TextRelay tr_Text = info.GetTextEntry( (int)BUTTONS_ENUM.TOKENS_EXCHANGE_AMOUNT );
				if(tr_Text != null)
				{
					int iNewPrice = 0;
					try { iNewPrice = Convert.ToInt32(tr_Text.Text,10); } 
					catch { from.SendMessage("Please make sure you wrote only numbers."); }
					if (iNewPrice > 60000)
						from.SendMessage(32, "You can't set the price for more then 60k gold per token.");
					else if (iNewPrice > 0)
					{
						LadyLuck.TokenCostInGold = iNewPrice;
						from.SendMessage(88, "You set a new price for tokens, from now on each tokens will be exchanged for {0} gold", iNewPrice);
					}
				}
			}
			if (info.ButtonID != (int)BUTTONS_ENUM.OK)
				from.SendGump( new Daat99CustomOWLTRGump(p_From) );
		}
	}

	public class OWLTRbodGump : Gump
	{
		private PlayerMobile pm_From;
		public OWLTRbodGump( PlayerMobile from ) : base(0, 0)
		{
			pm_From = from;
			from.CloseGump(typeof(OWLTRbodGump));
			Resizable=false;
			AddPage(0);
		//	AddBackground(0, 0, 390, 125, 3600);
            AddBackground(0, 0, 390, 200, 3600);
			AddLabel(110, 20, 89, @"daat99's OWLTR Bod Gump");

				
			string s_BS = String.Format( "{0}:{1}:{2}", from.NextSmithBulkOrder.Hours, from.NextSmithBulkOrder.Minutes, from.NextSmithBulkOrder.Seconds );
			if (from.NextSmithBulkOrder == TimeSpan.Zero)
			{
				AddButton(25, 43, 5534, 5535, 1, GumpButtonType.Reply, 0);
				AddLabel(95, 45, 69, "Use the button to take a blacksmith bod now." );
			}				
			else
				AddLabel(50, 45, 69, "Next Blacksmithy bod will be available in: " + s_BS );
				
			string s_TL = String.Format( "{0}:{1}:{2}", from.NextTailorBulkOrder.Hours, from.NextTailorBulkOrder.Minutes, from.NextTailorBulkOrder.Seconds );
			if (from.NextTailorBulkOrder == TimeSpan.Zero)
			{
				AddButton(25, 73, 5534, 5535, 2, GumpButtonType.Reply, 0);
				AddLabel(95, 75, 69, "Use the button to take a tailoring bod now." );
			}				
			else
				AddLabel(60, 75, 69, "Next Tailoring bod will be available in: " + s_TL );

            string s_CP = String.Format("{0}:{1}:{2}", from.NextCarpenterBulkOrder.Hours, from.NextCarpenterBulkOrder.Minutes, from.NextCarpenterBulkOrder.Seconds);
            if (from.NextCarpenterBulkOrder == TimeSpan.Zero)
            {
                AddButton(25, 103, 5534, 5535, 3, GumpButtonType.Reply, 0);
                AddLabel(95, 105, 69, "Use the button to take a carpentry bod now.");
            }
            else
                AddLabel(70, 105, 69, "Next Carpenter bod will be available in: " + s_CP);

            string s_BF = String.Format("{0}:{1}:{2}", from.NextFletcherBulkOrder.Hours, from.NextFletcherBulkOrder.Minutes, from.NextFletcherBulkOrder.Seconds);
            if (from.NextFletcherBulkOrder == TimeSpan.Zero)
            {
                AddButton(25, 133, 5534, 5535, 4, GumpButtonType.Reply, 0);
                AddLabel(95, 135, 69, "Use the button to take a fletcher bod now.");
            }
            else
                AddLabel(80, 135, 69, "Next Fletcher bod will be available in: " + s_BF);
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			Mobile from = state.Mobile;
			switch (info.ButtonID)
			{
				default: from.CloseGump(typeof(OWLTRbodGump)); break;
				case 1:
				{
					if ( pm_From != null && pm_From.NextSmithBulkOrder == TimeSpan.Zero )
					{
						double theirSkill = pm_From.Skills[SkillName.Blacksmith].Base;
						if (theirSkill < 0.1)
						{
							pm_From.SendMessage("You need more Blacksmithy skill to get Blacksmith bods!!!");
							break;
						}
						if ( theirSkill >= 70.1 )
							pm_From.NextSmithBulkOrder = TimeSpan.FromHours( 6.0 );
						else if ( theirSkill >= 50.1 )
							pm_From.NextSmithBulkOrder = TimeSpan.FromHours( 2.0 );
						else
							pm_From.NextSmithBulkOrder = TimeSpan.FromHours( 1.0 );

						if ( theirSkill >= 70.1 && ((theirSkill - 40.0) / 300.0) > Utility.RandomDouble() )
							pm_From.SendGump( new LargeBODAcceptGump( from, new LargeSmithBOD() ) );
						else
						{
							SmallSmithBOD ssb = SmallSmithBOD.CreateRandomFor( from ) as SmallSmithBOD;
							if (ssb == null)
								pm_From.SendMessage(32, "Due to your lack in skills you just lost the bod, you better train before you ask for another one...");
							else
								pm_From.SendGump( new SmallBODAcceptGump( from, ssb ) );
						}
					}
					break;
				}
				case 2:
				{
					if ( pm_From != null && pm_From.NextTailorBulkOrder == TimeSpan.Zero )
					{
						double theirSkill = pm_From.Skills[SkillName.Tailoring].Base;
						if (theirSkill < 0.1)
						{
							pm_From.SendMessage("You need more Tailoring skill to get Tailoring bods!!!");
							break;
						}
						if ( theirSkill >= 70.1 )
							pm_From.NextTailorBulkOrder = TimeSpan.FromHours( 6.0 );
						else if ( theirSkill >= 50.1 )
							pm_From.NextTailorBulkOrder = TimeSpan.FromHours( 2.0 );
						else
							pm_From.NextTailorBulkOrder = TimeSpan.FromHours( 1.0 );

						if ( theirSkill >= 70.1 && ((theirSkill - 40.0) / 300.0) > Utility.RandomDouble() )
							pm_From.SendGump( new LargeBODAcceptGump( from, new LargeTailorBOD() ) );
						else
						{
							SmallTailorBOD stb = SmallTailorBOD.CreateRandomFor( from ) as SmallTailorBOD;
							if (stb == null)
								pm_From.SendMessage(32, "Due to your lack in skills you just lost the bod, you better train before you ask for another one...");
							else
								pm_From.SendGump( new SmallBODAcceptGump( from, stb ) );
						}
					}
					break;
				}
                case 3:
                {
                    if (pm_From != null && pm_From.NextCarpenterBulkOrder == TimeSpan.Zero)
                    {
                        double theirSkill = pm_From.Skills[SkillName.Carpentry].Base;
                        if (theirSkill < 0.1)
                        {
                            pm_From.SendMessage("You need more Carpentry skill to get Carpenter bods!!!");
                            break;
                        }
                        if (theirSkill >= 70.1)
                            pm_From.NextCarpenterBulkOrder = TimeSpan.FromHours(6.0);
                        else if (theirSkill >= 50.1)
                            pm_From.NextCarpenterBulkOrder = TimeSpan.FromHours(2.0);
                        else
                            pm_From.NextCarpenterBulkOrder = TimeSpan.FromHours(1.0);

                        if (theirSkill >= 70.1 && ((theirSkill - 40.0) / 300.0) > Utility.RandomDouble())
                            pm_From.SendGump(new LargeBODAcceptGump(from, new LargeCarpenterBOD()));
                        else
                        {
                            SmallCarpenterBOD ssb = SmallCarpenterBOD.CreateRandomFor(from) as SmallCarpenterBOD;
                            if (ssb == null)
                                pm_From.SendMessage(32, "Due to your lack in skills you just lost the bod, you better train before you ask for another one...");
                            else
                                pm_From.SendGump(new SmallBODAcceptGump(from, ssb));
                        }
                    }
                    break;
                }
                case 4:
                {
                    if (pm_From != null && pm_From.NextFletcherBulkOrder == TimeSpan.Zero)
                    {
                        double theirSkill = pm_From.Skills[SkillName.Fletching].Base;
                        if (theirSkill < 0.1)
                        {
                            pm_From.SendMessage("You need more BowFletching skill to get Fletcher bods!!!");
                            break;
                        }
                        if (theirSkill >= 70.1)
                            pm_From.NextFletcherBulkOrder = TimeSpan.FromHours(6.0);
                        else if (theirSkill >= 50.1)
                            pm_From.NextFletcherBulkOrder = TimeSpan.FromHours(2.0);
                        else
                            pm_From.NextFletcherBulkOrder = TimeSpan.FromHours(1.0);

                        if (theirSkill >= 70.1 && ((theirSkill - 40.0) / 300.0) > Utility.RandomDouble())
                            pm_From.SendGump(new LargeBODAcceptGump(from, new LargeFletcherBOD()));
                        else
                        {
                            SmallFletcherBOD stb = SmallFletcherBOD.CreateRandomFor(from) as SmallFletcherBOD;
                            if (stb == null)
                                pm_From.SendMessage(32, "Due to your lack in skills you just lost the bod, you better train before you ask for another one...");
                            else
                                pm_From.SendGump(new SmallBODAcceptGump(from, stb));
                        }
                    }
                    break;
                }
			}
		}
	}
	public class MissingRecipesGump : Gump
	{
		private PlayerMobile p_From;
		private int i_Page;

		public MissingRecipesGump( PlayerMobile from, int page ) : base( 100, 100 ) 
		{
			p_From = from;
			i_Page = page;
			from.CloseGump(typeof(MissingRecipesGump));

			Resizable=false;
			
			if ( !Daat99OWLTR.StaticHolders.Contains((Mobile)from) )
				return;
			
			NewDaat99Holder dh = Daat99OWLTR.StaticHolders[from] as NewDaat99Holder;
			int count = page * 30, i_Limit = dh.ItemTypeList.Count;
			
			AddPage(0);
			AddBackground(0, 0, 450, 450, 9350);
			AddLabel(40,  20, 2, @"===================");
			AddLabel(80,  30, 2, @" /\");
			AddLabel(41,  40, 2, @" -----/---\-----");
			AddLabel(45,  50, 2, @" \ /     \ /");
			AddLabel(53,  60, 2, @" /       \");
			AddLabel(55,  60, 2, @" \       /");
			AddLabel(44,  70, 2, @" / \     / \");
			AddLabel(42,  80, 2, @" -----\---/-----");
			AddLabel(82,  90, 2, @" \/");
			AddLabel(40, 100, 2, @"===================");
			
			AddButton(285, 80, 5526, 5527, 999, GumpButtonType.Reply, 0); //help
			if (page != 0)
				AddButton(235, 80, 4015, 4016, 1, GumpButtonType.Reply, 0);//previos
			if (count + 30 < i_Limit)
				AddButton(365, 80, 4006, 4007, 2, GumpButtonType.Reply, 0);//next
			
			AddHtml( 180, 50, 240, 20, String.Format( "<basefont color=#000088><center>Missing Crafting Recipes:</center></font>" ), false, false );
			if ( dh.ItemTypeList == null || dh.ItemTypeList.Count < 1 )
				AddHtml( 180, 20, 240, 20, String.Format( "<basefont color=#008800><center>{0} don't need recipes.</center></font>", from.Name ), false, false );
			else
			{
				AddHtml( 180, 20, 240, 20, String.Format( "<basefont color=#008800><center>{0} need {1} recipes.</center></font>", from.Name, dh.ItemTypeList.Count ), false, false );
				AddPage(1);
				for (int i = 0; i < 15; i++)
				{
					if ( count < i_Limit )
					{
						string s_Key = ((Type)dh.ItemTypeList[count]).Name, s_Temp = ((Type)dh.ItemTypeList[count]).Name;
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
						AddHtml( 20, 130 + i*20, 210, 20, String.Format( "<basefont color=#0000ff>{0}. {1}</font>", count + 1, s_Key ), false, false );
					}
					count++;
					if ( count < i_Limit )
					{
						string s_Key = ((Type)dh.ItemTypeList[count]).Name, s_Temp = ((Type)dh.ItemTypeList[count]).Name;
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
						AddHtml( 230, 130 + i*20, 210, 20, String.Format( "<basefont color=#0000ff>{0}. {1}</font>", count + 1, s_Key ), false, false );
					}
					count++;
				}
			}
		}
		public override void OnResponse(NetState state, RelayInfo info)
		{
			Mobile from = state.Mobile;
			int count = i_Page * 30;
			switch (info.ButtonID)
			{
				default: from.CloseGump(typeof(MissingRecipesGump)); break;
				case 1: { from.SendGump( new MissingRecipesGump(p_From, i_Page - 1) ); break; }
				case 2: { from.SendGump( new MissingRecipesGump(p_From, i_Page + 1) ); break; }
				case 999:
				{
					from.LaunchBrowser( "http://www.angelfire.com/trek/daat99/index.html" );
					from.SendGump( new MissingRecipesGump(p_From, i_Page) );
					break;
				}
			}
		}
	}
}	