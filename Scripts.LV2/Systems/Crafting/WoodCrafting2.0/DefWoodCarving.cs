// Script Name: DefWoodCarving for WoodCrafting 2.0
// Author: Oak (atticus589 wrote original version)
// Servers: RunUO 2.0
// Date: 7/7/2006
// History: 
//  Wood Craft was originally done by atticus589 in February 2005.
//  Modified for RunUO 1.0 by Oak for Sylvan Dreams shard. Stackable driftwood, Fixed spelling, changed item graphics,  different messages, drops, custom items.
//  Modified for RunUO 2.0 by Oak. Removed custom items that required special graphics, changed drop rate, used 2.0 fishing.cs, etc.
using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefWoodCarving : CraftSystem
	{
		public override SkillName MainSkill
		{
			get{ return SkillName.Fishing; }
		}

		public override string GumpTitleString
		{
			get { return "<basefont color=#FFFFFF><CENTER>WOOD CARVING MENU</CENTER></basefont>"; } 
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefWoodCarving();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefWoodCarving() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
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
			from.PlaySound( 0x1C6 ); 
		}

		private class InternalTimer : Timer
		{
			private Mobile m_From;

			public InternalTimer( Mobile from ) : base( TimeSpan.FromSeconds( 0.7 ) )
			{
				m_From = from;
			}

			protected override void OnTick()
			{
				m_From.PlaySound( 0x1C6 );
			}
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 );

			if ( failed )
			{
				if ( lostMaterial )
					return 1044043;
				else
					return 1044157;
			}
			else
			{
				from.PlaySound( 0x1c6 );

				if ( quality == 0 )
					return 502785;
				else if ( makersMark && quality == 2 )
					return 1044156;
				else if ( quality == 2 )
					return 1044155;
				else
					return 1044154;
			}
		}

		public override void InitCraftList()
		{
			AddCraft( typeof( FishingPole ), "Miscellaneous", "Fishing Pole", 50.0, 95.0, typeof( DriftWood ), "Drift Wood", 5, 1053098 );
			AddCraft( typeof( QuarterStaff ), "Miscellaneous", "Quarter Staff", 55.0, 105.0, typeof( DriftWood ), "Drift Wood", 5, 1053098 );
			AddCraft( typeof( GnarledStaff ), "Miscellaneous", "GnarledStaff", 57.5, 107.5, typeof( DriftWood ), "Drift Wood", 5, 1053098 );
			AddCraft( typeof( Croc ), "Statuettes", "a Wee Crocodile", 110.0, 120.0, typeof( DriftWood ), "Drift Wood", 10, 1053098 );
			AddCraft( typeof( PlainIdol ), "Statuettes", "a Plain Idol", 110.0, 120.0, typeof( DriftWood ), "Drift Wood", 10, 1053098 );
			AddCraft( typeof( Shark ), "Statuettes", "a Hungry Little Shark", 110.0, 120.0, typeof( DriftWood ), "Drift Wood", 10, 1053098 );
			AddCraft( typeof( SeaFrog ), "Statuettes", "a Singing Sea Frog", 110.0, 120.0, typeof( DriftWood ), "Drift Wood", 10, 1053098 );
			AddCraft( typeof( SeaSprite ), "Statuettes", "a Sea Sprite", 110.0, 120.0, typeof( DriftWood ), "Drift Wood", 10, 1053098 );
			AddCraft( typeof( SeaHag ), "Statuettes", "a Sea Hag", 110.0, 120.0, typeof( DriftWood ), "Drift Wood", 10, 1053098 );
			AddCraft( typeof( SeaSpider ), "Statuettes", "a Sea Spider", 110.0, 120.0, typeof( DriftWood ), "Drift Wood", 10, 1053098 );
			AddCraft( typeof( SeaHorseStatue ), "Statuettes", "a Sleek Sea Horse", 100.0, 120.0, typeof( DriftWood ), "Drift Wood", 10, 1053098 );
			AddCraft( typeof( Abacus ), "Statuettes", "an Abacus", 75.0, 120.0, typeof( DriftWood ), "Drift Wood", 10, 1053098 );

// on my shard I added a lot of furniture graphics into the art.mul file. I wrote scripts for them and made them craftable
// via WoodCrafting. An example of setting up a new category is below.
//			AddCraft( typeof( TailorShelf ), "Furniture", "Tailor Shelf", 90.0, 130.0, typeof( DriftWood ), "Drift Wood", 75, 1053098 );
		}
	}
}