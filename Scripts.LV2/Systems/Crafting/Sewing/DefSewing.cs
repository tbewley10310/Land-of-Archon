// Made by RANCID77 aka EARL...
// I dont care if you use this as a base or modify it...
// Just plz leave this header.. thnx ...
using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefSewing : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Tailoring; }
		}

		public override string GumpTitleString
		{
			get{ return "Sewing"; } // <CENTER>Sewing MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefSewing();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefSewing() : base( 1, 1, 1.25 )// base( 1, 1, 4.5 )
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
			from.PlaySound( 0x248 );
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
			index = AddCraft( typeof( SewingShears ), "Tools", "Sewing Shears", 89.9, 100.0, typeof( SpoolOfThread ), "Spool Of Thread", 15 );
			AddSkill( index, SkillName.Tinkering, 70.0, 85.0 );
			AddRes( index, typeof( Cloth ), "Cut Cloth", 10 );			
			AddRes( index, typeof( IronIngot ), 1044036, 5, 1044037 );

			//Start Clothes
			AddCraft( typeof( MagicSkullCap ), "Clothes", "Magic Skull Cap", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicBandana ), "Clothes", "Magic Bandana", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicalWizardsHat ), "Clothes", 1025912, 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicJesterHat ), "Clothes", "Magic Jester Hat", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicDoublet ), "Clothes", "Magic Doublet", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicShirt ), "Clothes", "Magic Shirt", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicFancyShirt ), "Clothes", "Magic Fancy Shirt", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicTunic ), "Clothes", "Magic Tunic", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicSurcoat ), "Clothes", "Magic Surcoat", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicPlainDress ), "Clothes", "Magic Plain Dress", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicFancyDress ), "Clothes", "Magic Fancy Dress", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicCloak ), "Clothes", "Magic Cloak", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicRobe ), "Clothes", "Magic Robe", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicJesterSuit ), "Clothes", "Magic Jester Suit", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicShortPants ), "Clothes", "Magic Short Pants", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicLongPants ), "Clothes", "Magic Long Pants", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicKilt ), "Clothes", "Magic Kilt", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicSkirt ), "Clothes", "Magic Skirt", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicBodySash ), "Clothes", "Magic Body Sash", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicHalfApron ), "Clothes", "Magic Half Apron", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicFullApron ), "Clothes", "Magic Full Apron", 110.0, 130.0, typeof( Cloth ), 1044286, 300, 1044287 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicSandals ), "Clothes", "Magic Sandals", 110.0, 130.0, typeof( Leather ), 1044462, 300, 1044463 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicShoes ), "Clothes", "Magic Shoes", 110.0, 130.0, typeof( Leather ), 1044462, 300, 1044463 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicBoots ), "Clothes", "Magic Boots", 110.0, 130.0, typeof( Leather ), 1044462, 300, 1044463 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );

			AddCraft( typeof( MagicThighBoots ), "Clothes", "Magic Thigh Boots", 110.0, 130.0, typeof( Leather ), 1044462, 300, 1044463 );
			AddSkill( index, SkillName.Magery, 80.0, 100.0 );


			//Start Curtains
			index = AddCraft( typeof( WhiteCurtainEast ), "Curtains", "White Curtain East", 85.1, 120.0, typeof( Cloth ), "Cut Cloth",  10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 10 );

			index = AddCraft( typeof( WhiteCurtainSouth ), "Curtains", "White Curtain South", 85.1, 120.0, typeof( Cloth ), "Cut Cloth",  10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 10 );

			index = AddCraft( typeof( RedCurtainEast1), "Curtains", "Red Curtain East 1", 85.1, 120.0, typeof( Cloth ), "Cut Cloth",  20 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 50 );

			index = AddCraft( typeof( RedCurtainEast2), "Curtains", "Red Curtain East 2", 85.1, 120.0, typeof( Cloth ), "Cut Cloth",  20 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 50 );

			index = AddCraft( typeof( RedCurtainEast3), "Curtains", "Red Curtain East 3", 85.1, 120.0, typeof( Cloth ), "Cut Cloth",  20 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 50 );


			//Start Pillows
			index = AddCraft( typeof( LightPillow ), "Pillows", "Light Pillow", 80.1, 115.0, typeof( Cloth ), "Cut Cloth", 15 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( LightPillowBig ), "Pillows", "Light Pillow Big", 90.1, 115.0, typeof( Cloth ), "Cut Cloth", 25 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 10 );

			index = AddCraft( typeof( LightPillowHuge ), "Pillows", "Light Pillow Huge", 100.1, 115.0, typeof( Cloth ), "Cut Cloth", 30 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 15 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 10 );

			index = AddCraft( typeof( LightPillowFancy ), "Pillows", "Light Pillow Fancy", 80.1, 105.0, typeof( Cloth ), "Cut Cloth", 15 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( LightPillowRound ), "Pillows", "Light Pillow Round", 90.1, 115.0, typeof( Cloth ), "Cut Cloth", 15 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( LongPillowDark1 ), "Pillows", "Long Pillow Dark 1", 100.1, 115.0, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( LongPillowDark2 ), "Pillows", "Long Pillow Dark 2", 80.1, 115.0, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( PillowDark1 ), "Pillows", "Dark Pillow 1", 90.1, 115.0, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( PillowDark2 ), "Pillows", "Dark Pillow 2", 90.1, 115.0, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( PillowDarkFancy ), "Pillows", "Dark Pillow Fancy", 90.1, 115.0, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( PillowDarkRound ), "Pillows", "Dark Pillow Round", 90.1, 115.0, typeof( Cloth ), "Cut Cloth", 20 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( SmallPillow ), "Pillows", "Small Pillow", 90.1, 95.0, typeof( Cloth ), "Cut Cloth", 5 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 3 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 1 );

			//Start Rugs
			index = AddCraft( typeof( BrownBearRugEastDeed ), "Rugs", "Bear Rug East", 100.1, 120.0, typeof( BearSkin ), "Bear Skin", 5 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( BrownBearRugSouthDeed ), "Rugs", "Bear Rug South", 100.1, 120.0, typeof( BearSkin ), "Bear Skin", 5 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( PolarBearRugEastDeed ), "Rugs", "Polar Bear Rug East", 100.1, 120.0, typeof( PolarBearSkin ), "Polar Bear Skin", 5 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			index = AddCraft( typeof( PolarBearRugSouthDeed ), "Rugs", "Polar Bear Rug South", 100.1, 120.0, typeof( PolarBearSkin ), "Polar Bear Skin", 5 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 5 );

			//Start Towel
			index = AddCraft( typeof( FoldedTowel ), "Towel", "Folded Towel", 95.0, 100.0, typeof( Cloth ), "Cut Cloth",  10 );
			AddRes( index, typeof( SpoolOfThread ), "Spool Of Thread", 3 );
			AddRes( index, typeof( Cotton ), "Bale Of Cotton", 5 );

			// Set the overridable material
			SetSubRes( typeof( Leather ), 1049150 );

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes( typeof( Leather ),		1049150, 00.0, 1044462, 1049311 );
			AddSubRes( typeof( SpinedLeather ),	1049151, 65.0, 1044462, 1049311 );
			AddSubRes( typeof( HornedLeather ),	1049152, 80.0, 1044462, 1049311 );
			AddSubRes( typeof( BarbedLeather ),	1049153, 100.0, 1044462, 1049311 );
			//AddSubRes( typeof( DragonLeather ),	//"DRAGON LEATHER / HIDES", 105.0, 1049311 );
			//AddSubRes( typeof( DaemonLeather ),	//"DAEMON LEATHER / HIDES", 110.0, 1049311 );
			//AddSubRes( typeof( FrostLeather ),	//"FROST LEATHER / HIDES", 115.0, 1049311 );
			//AddSubRes( typeof( EtherealLeather ),	//"ETHEREAL LEATHER / HIDES", 117.0, 1049311 );

			MarkOption = true;
			Repair = Core.AOS;
			CanEnhance = Core.AOS;
		}
	}
}