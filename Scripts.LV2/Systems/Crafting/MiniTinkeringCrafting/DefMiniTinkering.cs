// Made by RANCID77 aka EARL...
// I dont care if you use this as a base or modify it...
// Just plz leave this header.. thnx ...
using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefMiniTinkering : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Tinkering; }
		}

		public override string GumpTitleString
		{
			get{ return "MiniTinkering"; } // <CENTER>Mini Tinkering MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefMiniTinkering();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefMiniTinkering() : base( 1, 1, 1.25 )// base( 1, 1, 3.0 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if ( tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.

			return 0;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			from.PlaySound( 0x241 );
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				if ( lostMaterial )
					return 1044043; // You failed to create the item, and some of your materials are lost.
				else
					return 1044157; // You failed to create the item, but no materials were lost.
			}
			else
			{	
				return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
			int index = -1;

			//Start Tools
			index = AddCraft( typeof( MiniTinkeringTool ), "Tools", "Mini Tinkering Tool", 99.9, 100.0, typeof( IronIngot ), "Iron Ingot", 200 );
			AddRes( index, typeof( Board ), "Boards", 50 );

			//Start Mini Tree
			index = AddCraft( typeof( MiniGreenTree ), "Mini Green Tree", "Mini Green Tree", 110.1, 115.0, typeof( Board ), "Boards",  50 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 200 );

			index = AddCraft( typeof( MiniCherryTree ), "Mini Cherry Tree", "Mini Cherry Tree", 110.1, 115.0, typeof( Board ), "Boards",  50 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 200 );

			index = AddCraft( typeof( MiniPearTree), "Mini Pear Tree", "Mini Pear Tree", 110.1, 115.0, typeof( Board ), "Boards",  50 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 200 );

			//Start Mini Carpet
			index = AddCraft( typeof(  MiniCarpetBrownG ), "Mini Carpet", "Mini Carpet Brown Gold", 110.1, 115.0, typeof( Board ), "Boards", 25 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 100 );

			index = AddCraft( typeof( MiniCarpetBluePattern  ), "Mini Carpet", "Mini Carpet Blue Pattern", 110.1, 115.0, typeof( Board ), "Boards", 25 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 100 );

			index = AddCraft( typeof( MiniCarpetBlueG  ), "Mini Carpet", "Mini Carpet Blue Gold", 110.1, 115.0, typeof( Board ), "Boards", 25 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 100 );

			index = AddCraft( typeof( MiniCarpetBrownFancy ), "Mini Carpet", "Mini Carpet Brown Fancy", 110.1, 115.0, typeof( Board ), "Boards", 25 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( IronIngot  ), "Iron Ingots", 100 );

			index = AddCraft( typeof(  MiniCarpetBrownGPattern ), "Mini Carpet", "Mini Carpet Brown Gold Pattern", 110.1, 115.0, typeof( Board ), "Boards", 25 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( IronIngot  ), "Iron Ingots", 100 );

			index = AddCraft( typeof( MiniCarpetBrownPattern  ), "Mini Carpet", "Mini Carpet Brown Pattern", 110.1, 115.0, typeof( Board ), "Boards", 25 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 100 );

                        //Start Mini Furniture
			index = AddCraft( typeof(  MiniVanityEast ), "Mini Furniture", "Mini Vanity East", 110.1, 115.0, typeof( Board ), "Boards", 100 );
			AddRes( index, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 50 );

			index = AddCraft( typeof( MiniVanitySouth ), "Mini Furniture", "Mini Vanity South", 110.1, 115.0, typeof( Board ), "Boards", 100 );
			AddRes( index, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( IronIngot  ), "Iron Ingots", 50 );

			index = AddCraft( typeof( MiniFullBed  ), "Mini Furniture", "Mini Full Bed", 110.1, 115.0, typeof( Board ), "Boards", 100 );
			AddRes( index, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( IronIngot), "Iron Ingots", 50 );

			index = AddCraft( typeof( MiniRuinedArmoire ), "Mini Furniture", "Mini Ruined Armoire", 110.1, 115.0, typeof( Board ), "Boards", 100 );
			AddRes( index, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 50 );

			index = AddCraft( typeof( MiniRuinedBookcase ), "Mini Furniture", "Mini Ruined Bookcase", 110.1, 115.0, typeof( Board ), "Boards", 100 );
			AddRes( index, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 50 );

			index = AddCraft( typeof( MiniRuinedChest ), "Mini Furniture", "Mini Ruined Chest", 110.1, 115.0, typeof( Board ), "Boards", 100 );
			AddRes( index, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 50 );

                        index = AddCraft( typeof( MiniRuinedChair ), "Mini Furniture", "Mini Ruined Chair", 110.1, 115.0, typeof( Board ), "Boards", 100 );
			AddRes( index, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 50 );

                        index = AddCraft( typeof( MiniRuinedVanity ), "Mini Furniture", "Mini Ruined Vanity", 110.1, 115.0, typeof( Board ), "Boards", 100 );
			AddRes( index, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 50 );

                        index = AddCraft( typeof( MiniCoveredChair ), "Mini Furniture", "Mini Covered Chair", 110.1, 115.0, typeof( Board ), "Boards", 75 );
			AddRes( index, typeof( Cloth ), "Cut Cloth", 50 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 40 );

                        //Start Mini Statues
                        index = AddCraft( typeof( MiniNobleStatueSouth ), "Mini Statues", "Mini Noble Statue South", 110.1, 115.0, typeof( Board ), "Boards", 50 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 200 );

                        index = AddCraft( typeof( MiniNobleStatueEast ), "Mini Statues", "Mini Noble Statue East", 110.1, 115.0, typeof( Board ), "Boards", 50 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 200 );

                        index = AddCraft( typeof( MiniArmorStatueSouth ), "Mini Statues", "Mini Armor Statue South", 110.1, 115.0, typeof( Board ), "Boards", 50 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 200 );

                        index = AddCraft( typeof( MiniArmorStatueEast ), "Mini Statues", "Mini Armor Statue East", 110.1, 115.0, typeof( Board ), "Boards", 50 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 200 );

                        //Start Mini Deco Items
                        index = AddCraft( typeof( MiniFancyCurtain ), "Mini Deco Items", "Mini Fancy Curtain", 110.1, 115.0, typeof( Board ), "Boards", 25 );
			AddRes( index, typeof( Cloth ), "Cut Cloth", 100 );
			AddRes( index, typeof( IronIngot ), "Iron Ingots", 30 );

                        index = AddCraft( typeof( MiniStoneFountain  ), "Mini Deco Items", "Mini Stone Fountain", 110.1, 115.0, typeof( Board ), "Boards", 50 );
		        AddRes( index, typeof( IronIngot ), "Iron Ingots", 200 );

                        index = AddCraft( typeof( MiniSwordAxeDisplay  ), "Mini Deco Items", "Mini Sword Axe Display", 110.1, 115.0, typeof( Board ), "Boards", 50 );
		        AddRes( index, typeof( IronIngot ), "Iron Ingots", 200 );

                        index = AddCraft( typeof( MiniHearthOfHomeFireplace  ), "Mini Deco Items", "Mini Hearth Of Home Fireplace", 110.1, 115.0, typeof( Board ), "Boards", 50 );
		        AddRes( index, typeof( IronIngot ), "Iron Ingots", 200 );

                        index = AddCraft( typeof( MiniIronMaiden   ), "Mini Deco Items", "Mini Iron Maiden", 110.1, 115.0, typeof( Board ), "Boards", 50 );
		        AddRes( index, typeof( IronIngot ), "Iron Ingots", 200 );

                        index = AddCraft( typeof( MiniSosariaTapestry   ), "Mini Deco Items", "Mini Sosaria Tapestry", 110.1, 115.0, typeof( Board ), "Boards", 25 );
                        AddRes( index, typeof( Cloth ), "Cut Cloth", 100 );
		        AddRes( index, typeof( IronIngot ), "Iron Ingots", 50 );

                        index = AddCraft( typeof( MiniGuillotine   ), "Mini Deco Items", "Mini Guillotine", 110.1, 115.0, typeof( Board ), "Boards", 100 );
		        AddRes( index, typeof( IronIngot ), "Iron Ingots", 75 );

                        index = AddCraft( typeof( MiniWoodCoffin   ), "Mini Deco Items", "Mini Wood Coffin", 110.1, 115.0, typeof( Board ), "Boards", 100 );
		        AddRes( index, typeof( IronIngot ), "Iron Ingots", 75 );
                          
                          

		}
	}
}