using System;
using Server.Engines.Plants;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefGemCraft : CraftSystem
	{
		public override SkillName MainSkill
		{
            get { return SkillName.Blacksmith; }
		}

        public override string GumpTitleString
        {
            get { return "<BASEFONT COLOR=#FFFFFF><CENTER>GEM CRAFT MENU</CENTER></BASEFONT>"; }
        }
     

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefGemCraft();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefGemCraft() : base( 1, 1, 1.25 )// base( 1, 1, 3.1 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.

			return 0;
		}

		public override void PlayCraftEffect( Mobile from )
		{
            from.PlaySound(0x2A);
		}
        


		
		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{

            if (toolBroken) from.SendLocalizedMessage(1044038);

            if (failed)
            {
                if (lostMaterial) return 1044043;
                else return 1044157;
            }
            else
            {
                if (quality == 0) return 502785;
                else if (makersMark && quality == 2) return 1044156;
                else if (quality == 2) return 1044155;
                else return 1044154;
            }


		}

        public override void InitCraftList()
        {
            int index = -1;
            


            index = AddCraft(typeof(MythicAmethyst), "Amethyst", "Mythic Amethyst", 100.0, 125.0, typeof(RawMythicAmethyst), "Raw Mythic Amethyst", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
          
            index = AddCraft(typeof(LegendaryAmethyst), "Amethyst", "Legendary Amethyst", 100.0, 125.0, typeof(RawLegendaryAmethyst), "Raw Legendary Amethyst", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 40);
          
            index = AddCraft(typeof(AncientAmethyst), "Amethyst", "Ancient Amethyst", 100.0, 125.0, typeof(RawAncientAmethyst), "Raw Ancient Amethyst", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 20);
           


            index = AddCraft(typeof(MythicDiamond), "Diamond", "Mythic Diamond", 100.0, 125.0, typeof(RawMythicDiamond), "Raw Mythic Diamond", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
           
            index = AddCraft(typeof(LegendaryDiamond), "Diamond", "Legendary Diamond", 100.0, 125.0, typeof(RawLegendaryDiamond), "Raw Legendary Diamond", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 40);
            
            index = AddCraft(typeof(AncientDiamond), "Diamond", "Ancient Diamond", 100.0, 125.0, typeof(RawAncientDiamond), "Raw Ancient Diamond", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 20);
            


            index = AddCraft(typeof(MythicEmerald), "Emerald", "Mythic Emerald", 100.0, 125.0, typeof(RawMythicEmerald), "Raw Mythic Emerald", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
          
            index = AddCraft(typeof(LegendaryEmerald), "Emerald", "Legendary Emerald", 100.0, 125.0, typeof(RawLegendaryEmerald), "Raw Legendary Emerald", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 40);
           
            index = AddCraft(typeof(AncientEmerald), "Emerald", "Ancient Emerald", 100.0, 125.0, typeof(RawAncientEmerald), "Raw Ancient Emerald", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 20);
             


            index = AddCraft(typeof(MythicRuby), "Ruby", "Mythic Ruby", 100.0, 125.0, typeof(RawMythicRuby), "Raw Mythic Ruby", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            
            index = AddCraft(typeof(LegendaryRuby), "Ruby", "Legendary Ruby", 100.0, 125.0, typeof(RawLegendaryRuby), "Raw Legendary Ruby", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 40);
           
            index = AddCraft(typeof(AncientRuby), "Ruby", "Ancient Ruby", 100.0, 125.0, typeof(RawAncientRuby), "Raw Ancient Ruby", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 20);
          


            index = AddCraft(typeof(MythicSkull), "Skull", "Mythic Skull", 100.0, 125.0, typeof(RawMythicSkull), "Raw Mythic Skull", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            
            index = AddCraft(typeof(LegendarySkull), "Skull", "Legendary Skull", 100.0, 125.0, typeof(RawLegendarySkull), "Raw Legendary Skull", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 40);
             
            index = AddCraft(typeof(AncientSkull), "Skull", "Ancient Skull", 100.0, 125.0, typeof(RawAncientSkull), "Raw Ancient Skull", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 20);
             


            index = AddCraft(typeof(MythicTourmaline), "Tourmaline", "Mythic tourmaline", 100.0, 125.0, typeof(RawMythicTourmaline), "Raw Mythic Tourmaline", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
           
            index = AddCraft(typeof(LegendaryTourmaline), "Tourmaline", "Legendary tourmaline", 100.0, 125.0, typeof(RawLegendaryTourmaline), "Raw Legendary Tourmaline", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 40);
            
            index = AddCraft(typeof(AncientTourmaline), "Tourmaline", "Ancient tourmaline", 100.0, 125.0, typeof(RawAncientTourmaline), "Raw Ancient Tourmaline", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 20);
            


            index = AddCraft(typeof(MythicWood), "Wood", "Mythic Wood", 100.0, 125.0, typeof(RawMythicCrust), "Raw Mythic Crust", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            
            index = AddCraft(typeof(LegendaryWood), "Wood", "Legendary Wood", 100.0, 125.0, typeof(RawLegendaryCrust), "Raw Legendary Crust", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 40);
             
            index = AddCraft(typeof(AncientWood), "Wood", "Ancient Wood", 100.0, 125.0, typeof(RawAncientCrust), "Raw Ancient Crust", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 20);

            //-----------------------------------------------------------------------------------------------------------------------------------------

            index = AddCraft(typeof(GlimmeringGranite), "Stones", "Glimmering Granite", 100.0, 125.0, typeof(RawGlimmeringPiece), "Raw Glimmering Piece", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(GlimmeringClay), "Stones", "Glimmering Clay", 100.0, 125.0, typeof(RawGlimmeringPiece), "Raw Glimmering Piece", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(GlimmeringHeartstone), "Stones", "Glimmering Heartstone", 100.0, 125.0, typeof(RawGlimmeringPiece), "Raw Glimmering Piece", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(GlimmeringGypsum), "Stones", "Glimmering Gypsum", 100.0, 125.0, typeof(RawGlimmeringPiece), "Raw Glimmering Piece", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(GlimmeringIronOre), "Stones", "Glimmering IronOre", 100.0, 125.0, typeof(RawGlimmeringPiece), "Raw Glimmering Piece", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(GlimmeringOnyx), "Stones", "Glimmering Onyx", 100.0, 125.0, typeof(RawGlimmeringPiece), "Raw Glimmering Piece", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(GlimmeringMarble), "Stones", "Glimmering Marble", 100.0, 125.0, typeof(RawGlimmeringPiece), "Raw Glimmering Piece", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(GlimmeringPetrifiedWood), "Stones", "Glimmering Petrified Wood", 100.0, 125.0, typeof(RawGlimmeringPiece), "Raw Glimmering Piece", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(GlimmeringLimestone), "Stones", "Glimmering Limestone", 100.0, 125.0, typeof(RawGlimmeringPiece), "Raw Glimmering Piece", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(GlimmeringBloodrock), "Stones", "Glimmering Bloodrock", 100.0, 125.0, typeof(RawGlimmeringPiece), "Raw Glimmering Piece", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);

            //-------------------------------------------------------------------------------------------------------------------------------------------

            index = AddCraft(typeof(TyrRune), "Runes", "Tyr Rune", 100.0, 125.0, typeof(RawRune), "Raw Rune", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(AhmRune), "Runes", "Ahm Rune", 100.0, 125.0, typeof(RawRune), "Raw Rune", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(MorRune), "Runes", "Mor Rune", 100.0, 125.0, typeof(RawRune), "Raw Rune", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(MefRune), "Runes", "Mef Rune", 100.0, 125.0, typeof(RawRune), "Raw Rune", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(YlmRune), "Runes", "Ylm Rune", 100.0, 125.0, typeof(RawRune), "Raw Rune", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(KotRune), "Runes", "Kot Rune", 100.0, 125.0, typeof(RawRune), "Raw Rune", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(JorRune), "Runes", "Jor Rune", 100.0, 125.0, typeof(RawRune), "Raw Rune", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);

            //--------------------------------------------------------------------------------------------------------------------------------------------

            index = AddCraft(typeof(FenCrystal), "Crystals", "Fen Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(RhoCrystal), "Crystals", "Rho Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(RysCrystal), "Crystals", "Rys Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(WyrCrystal), "Crystals", "Wyr Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(FreCrystal), "Crystals", "Fre Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(TorCrystal), "Crystals", "Tor Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(VelCrystal), "Crystals", "Vel Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(XenCrystal), "Crystals", "Xen Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(PolCrystal), "Crystals", "Pol Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(WolCrystal), "Crystals", "Wol Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(BalCrystal), "Crystals", "Bal Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(TalCrystal), "Crystals", "Tal Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(JalCrystal), "Crystals", "Jal Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(RalCrystal), "Crystals", "Ral Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
            index = AddCraft(typeof(KalCrystal), "Crystals", "Kal Crystal", 100.0, 125.0, typeof(RawCrystal), "Raw Crystal", 1);
            AddSkill(index, SkillName.Blacksmith, 90.0, 100.0);
            AddRes(index, typeof(GemOil), "GemOil", 60);
        }
	}
}