using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefBeerBrewing : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Poisoning; }
		}

		public override int GumpTitleNumber
		{
			get { return 1044007; } // <CENTER>Beer Brewing</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefBeerBrewing();

				return m_CraftSystem;
			}
		}

		private DefBeerBrewing() : base( 1, 1, 1.25 )// base( 1, 1, 3.0 )
		{
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			if ( item.NameNumber == 1044258 ) // potion keg
				return 0.5; // 50%

			return 0.0; // 0%
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
			// no sound
			//from.PlaySound( 0x241 );
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
				if ( quality == 0 )
					return 502785; // You were barely able to make this item.  It's quality is below average.
				else if ( makersMark && quality == 2 )
					return 1044156; // You create an exceptional quality item and affix your maker's mark.
				else if ( quality == 2 )
					return 1044155; // You create an exceptional quality item.
				else				
					return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
      int index = -1;

			//Long Necks
      AddCraft( typeof( LongNeckBottleOfMillerLite ), "Long Necks", "a LongNeck Bottle Of Miller Lite", 0.0, 10.4, typeof( Hop1 ), "Hop1", 10 );
      AddCraft( typeof( LongNeckBottleOfMGD ), "Long Necks", "a LongNeck Bottle Of Miller Genuine Draft", 10.0, 20.4, typeof( Hop1 ), "Hop1", 10 );
      AddCraft( typeof( LongNeckBottleOfCoolersLite ), "Long Necks", "a LongNeck Bottle Of Coolers Lite", 20.0, 35.4, typeof( Hop1 ), "Hop1", 10 );
      AddCraft( typeof( LongNeckBottleOfBudLight ), "Long Necks", "a LongNeck Bottle Of Bud Light", 35.0, 50.4, typeof( Hop1 ), "Hop1", 15 );
      AddCraft( typeof( LongNeckBottleOfBudWiser ), "Long Necks", "a LongNeck Bottle Of Bud Wiser", 50.0, 65.4, typeof( Hop1 ), "Hop1", 15 );
      AddCraft( typeof( LongNeckBottleOfCorna ), "Long Necks", "a LongNeck Bottle Of Corna", 65.0, 78.4, typeof( Hop1 ), "Hop1", 15 );
      AddCraft( typeof( LongNeckBottleOfCornaLite ), "Long Necks", "a LongNeck Bottle Of Corna Lite", 78.0, 90.4, typeof( Hop1 ), "Hop1", 20 );
      AddCraft( typeof( LongNeckBottleOfWildturkey ), "Long Necks", "a LongNeck Bottle Of Wild Turkey", 90.0, 105.4, typeof( Hop1 ), "Hop1", 20 );
            
      //Kegs
      AddCraft( typeof( BeerKeg ), "Kegs", "a beer Keg", 105.0, 110.4, typeof(Board), "Board", 20);
      AddCraft( typeof( PonyKeg ), "Kegs", "a Pony Keg", 110.0, 120.0, typeof(Board), "Board", 10);
      
      //Tool
      AddCraft( typeof( BeerBreweringTools ), "Tool", "a Beer Brewers Tools", 20.0, 30.4, typeof(Board), "Board", 20);
      

			MarkOption = true;
			Repair = true;
		}
	}
}