using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefPumpkinCarve : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Cooking;	}
		}

		public override int GumpTitleNumber
		{
			get { return 0; } // Use String
		}

		public override string GumpTitleString
		{
			get { return "<basefont color=#FFFFFF><CENTER>PUMPKIN CARVING</CENTER></basefont>"; } 
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefPumpkinCarve();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

        private DefPumpkinCarve()
            : base(1, 1, 1.25)// base( 1, 1, 1.5 )
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
			from.PlaySound( 0x21 );
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
                    return 1154339; // *You carefully carve the pumpkin*
			}
		}


// format of AddCraft: AddCraft( typeof( ThingToMake ), Category (text or ##),
//			ThingToMake (text or ##), minskill, maxskill, typeof( FirstThingToConsume),
//			FirstThingToConsume (text or ##), Qty,
//			ErrorMessageForNotHavingFirstThingToConsume (text or ##) );
// format of AddRes:   AddRes( index, typeof( SecondThingToConsume ),
//			SecondThingToConsume (text or ##), Qty,
//			ErrorMessageForNotHavingSecondThingToConsume (text or ##) );

// index = AddCraft( typeof( Make ), Category, Make, minskill, maxskill, typeof( Consume1 ), Consume1, qty, Error );
// AddRes( index, typeof( Consume2 ), Consume2, qty, Error );

		public override void InitCraftList()
		{
			int index = -1;
            index = AddCraft(typeof(PumpkinTallWitch), "Tall Pumpkins", "Tall Pumpkin Witch", 0.0, 0.0, typeof(PumpkinTall), 1123239, 1, "You don't have enough Pumpkins.");
            index = AddCraft(typeof(PumpkinTallUO), "Tall Pumpkins", "Tall Pumpkin UO", 0.0, 0.0, typeof(PumpkinTall), 1123239, 1, "You don't have enough Pumpkins.");
            index = AddCraft(typeof(PumpkinTallAnkh), "Tall Pumpkins", "Tall Pumpkin Ankh", 0.0, 0.0, typeof(PumpkinTall), 1123239, 1, "You don't have enough Pumpkins.");
            index = AddCraft(typeof(PumpkinTallSpider), "Tall Pumpkins", "Tall Pumpkin Spider", 0.0, 0.0, typeof(PumpkinTall), 1123239, 1, "You don't have enough Pumpkins.");
            index = AddCraft(typeof(PumpkinTallDemon), "Tall Pumpkins", "Tall Pumpkin Demon", 0.0, 0.0, typeof(PumpkinTall), 1123239, 1, "You don't have enough Pumpkins.");
            index = AddCraft(typeof(PumpkinTallBat), "Tall Pumpkins", "Tall Pumpkin Bat", 0.0, 0.0, typeof(PumpkinTall), 1123239, 1, "You don't have enough Pumpkins.");
            index = AddCraft(typeof(PumpkinTallScalele), "Tall Pumpkins", "Tall Pumpkin Scalele", 0.0, 0.0, typeof(PumpkinTall), 1123239, 1, "You don't have enough Pumpkins.");
            index = AddCraft(typeof(PumpkinTallSkull), "Tall Pumpkins", "Tall Pumpkin Skull", 0.0, 0.0, typeof(PumpkinTall), 1123239, 1, "You don't have enough Pumpkins.");
            index = AddCraft(typeof(PumpkinTallSpirit), "Tall Pumpkins", "Tall Pumpkin Spirit", 0.0, 0.0, typeof(PumpkinTall), 1123239, 1, "You don't have enough Pumpkins.");
		}
	}
}