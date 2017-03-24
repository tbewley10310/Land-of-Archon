using System;
using Server.Items;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.Multis.Deeds;

namespace Server.Engines.Craft
{
    public class DefDecoCraft : CraftSystem
    {
        public override SkillName MainSkill
        {
            get { return SkillName.Carpentry; }
        }

        public override string GumpTitleString
        {
            get { return "<BASEFONT COLOR=#FFFFFF><CENTER>DecoCraft</CENTER></BASEFONT>"; }
        }

        private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefDecoCraft();

                return m_CraftSystem;
            }
        }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.50; // 50%
        }

        private DefDecoCraft()
            : base(1, 1, 1.25)// base( 1, 1, 3.0 )
        {
        }

        public override int CanCraft(Mobile from, BaseTool tool, Type typeItem)
        {
            if (tool.Deleted || tool.UsesRemaining < 0)
                return 1044038; // You have worn out your tool!

            return 0;
        }

        public override void PlayCraftEffect(Mobile from)
        {
            from.PlaySound(0x23D);
        }

        public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
        {
            if (toolBroken)
                from.SendLocalizedMessage(1044038); // You have worn out your tool

            if (failed)
            {
                if (lostMaterial)
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

            // Deco

            index = AddCraft(typeof(DecoHedge1), "Deco", "hedge", 80.0, 100.0, typeof(FertileDirt), "Fertile Dirt", 5);
            index = AddCraft(typeof(DecoHedge2), "Deco", "hedge", 80.0, 100.0, typeof(FertileDirt), "Fertile Dirt", 5);
            index = AddCraft(typeof(UntrimmedDecoHedge1), "Deco", "Untrimmed hedge", 80.0, 100.0, typeof(FertileDirt), "Fertile Dirt", 6);
            index = AddCraft(typeof(UntrimmedDecoHedge2), "Deco", "Untrimmed hedge", 80.0, 100.0, typeof(FertileDirt), "Fertile Dirt", 6);
            index = AddCraft(typeof(TallUntrimmedDecoHedge1), "Deco", "TallUntrimmed hedge", 80.0, 100.0, typeof(FertileDirt), "Fertile Dirt", 8);
            index = AddCraft(typeof(TallUntrimmedDecoHedge2), "Deco", "TallUntrimmed hedge", 80.0, 100.0, typeof(FertileDirt), "Fertile Dirt", 8);

            // Lights
            index = AddCraft(typeof(LampPostLit), "Lights", "lamp post (lit)", 80.0, 100.0, typeof(IronIngot), "Iron Ingot", 100);
            index = AddCraft(typeof(LampPostUnlit), "Lights", "lamp post (unlit)", 80.0, 100.0, typeof(IronIngot), "Iron Ingot", 100);
            index = AddCraft(typeof(FancyLampPostLit), "Lights", "Fancy lamp post (lit)", 80.0, 100.0, typeof(IronIngot), "Iron Ingot", 100);
            index = AddCraft(typeof(FancyLampPostUnlit), "Lights", "Fancy lamp post (unlit)", 80.0, 100.0, typeof(IronIngot), "Iron Ingot", 100);
            index = AddCraft(typeof(DecoBrazier), "Lights", "DecoBrazier", 80.0, 100.0, typeof(IronIngot), "Iron Ingot", 50);
            index = AddCraft(typeof(TallDecoBrazier), "Lights", "TallDecoBrazier", 80.0, 100.0, typeof(IronIngot), "Iron Ingot", 60);

            //Mini Houses
            index = AddCraft(typeof(BrickHouseAddonDeed ), "Mini Houses", "MiniHouseDeed Brick", 80.0, 100.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(FieldstoneHouseAddonDeed), "Mini Houses", "MiniHouseDeed Fieldstone", 80.0, 100.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(SmallBrickHouseAddonDeed), "Mini Houses", "MiniHouseDeed SmallBrick", 80.0, 100.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(LargeHouseWithPatioAddonDeed), "Mini Houses", "MiniHouseDeed LargeHouseWithPatio", 80.0, 100.0, typeof(Board), "Board", 80);
            index = AddCraft(typeof(SmallMarbleWorkshopAddonDeed), "Mini Houses", "MiniHouseDeed SmallMarbleWorkshop", 80.0, 100.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(SmallStoneWorkshopAddonDeed), "Mini Houses", "MiniHouseDeed SmallStoneWorkshop", 80.0, 100.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(TwoStoryLogCabinAddonDeed), "Mini Houses", "MiniHouseDeed TwoStoryLogCabin", 80.0, 100.0, typeof(Board), "Board", 85);
            index = AddCraft(typeof(WoodenHouseAddonDeed), "Mini Houses", "MiniHouseDeed Wooden", 80.0, 100.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(StoneAndPlasterAddonDeed), "Mini Houses", "MiniHouseDeed StoneAndPlaster", 85.0, 105.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(TwoStoryStoneAndPlasterAddonDeed), "Mini Houses", "MiniHouseDeed TwoStoryStoneAndPlaster", 80.0, 100.0, typeof(Board), "Board", 85);
            index = AddCraft(typeof(TwoStoryWoodAndPlasterAddonDeed), "Mini Houses", "MiniHouseDeed TwoStoryWoodAndPlaster", 80.0, 100.0, typeof(Board), "Board", 85);
            index = AddCraft(typeof(SmallStoneTowerAddonDeed), "Mini Houses", "MiniHouseDeed SmallStoneTower", 85.0, 105.0, typeof(Board), "Board", 80);
            index = AddCraft(typeof(TwoStoryVillaAddonDeed), "Mini Houses", "MiniHouseDeed TwoStoryVilla", 85.0, 105.0, typeof(Board), "Board", 85);
            index = AddCraft(typeof(MarbleHouseWithPatioAddonDeed), "Mini Houses", "MiniHouseDeed MarbleHouseWithPatio", 85.0, 105.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(WoodAndPlasterAddonDeed), "Mini Houses", "MiniHouseDeed WoodAndPlaster", 85.0, 105.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(SandstoneHouseWithPatioAddonDeed), "Mini Houses", "MiniHouseDeed SandstoneHouseWithPatio", 85.0, 105.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(ThatchedRoofCottageAddonDeed), "Mini Houses", "MiniHouseDeed ThatchedRoofCottage", 85.0, 105.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(SmallStoneKeepAddonDeed), "Mini Houses", "MiniHouseDeed SmallStoneKeep", 90.0, 110.0, typeof(Board), "Board", 125);
            index = AddCraft(typeof(TowerAddonDeed), "Mini Houses", "MiniHouseDeed Tower", 100.0, 120.0, typeof(Board), "Board", 150);
            index = AddCraft(typeof(CastleAddonDeed), "Mini Houses", "MiniHouseDeed Castle", 100.0, 120.0, typeof(Board), "Board", 200);
            
            // House Furniture

            index = AddCraft(typeof(LargeBenchEastAddonDeed), "House Furniture", "LargeBenchEastAddonDeed", 80.0, 100.0, typeof(Board), "Board", 100);
            index = AddCraft(typeof(LargeBenchSouthAddonDeed), "House Furniture", "LargeBenchSouthAddonDeed", 80.0, 100.0, typeof(Board), "Board", 100);
            index = AddCraft(typeof(VanityEastAddonDeed), "House Furniture", "VanityEastAddonDeed", 80.0, 100.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(VanitySouthAddonDeed), "House Furniture", "VanitySouthAddonDeed", 80.0, 100.0, typeof(Board), "Board", 75);
            index = AddCraft(typeof(TableBlueRunnerEast), "House Furniture", "TableBlueRunnerEast", 80.0, 100.0, typeof(Board), "Board", 50);
            AddSkill(index, SkillName.Tailoring, 80.0, 100.0);
            AddRes(index, typeof(Dyes), 1024009, 4, 1044253);
            AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
            index = AddCraft(typeof(TableBlueRunnerSouth), "House Furniture", "TableBlueRunnerSouth", 80.0, 100.0, typeof(Board), "Board", 50);
            AddSkill(index, SkillName.Tailoring, 80.0, 100.0);
            AddRes(index, typeof(Dyes), 1024009, 4, 1044253);
            AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
            index = AddCraft(typeof(TableRedRunnerEast), "House Furniture", "TableRedRunnerEast", 80.0, 100.0, typeof(Board), "Board", 50);
            AddSkill(index, SkillName.Tailoring, 80.0, 100.0);
            AddRes(index, typeof(Dyes), 1024009, 4, 1044253);
            AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
            index = AddCraft(typeof(TableRedRunnerSouth), "House Furniture", "TableRedRunnerSouth", 80.0, 100.0, typeof(Board), "Board", 50);
            AddSkill(index, SkillName.Tailoring, 80.0, 100.0);
            AddRes(index, typeof(Dyes), 1024009, 4, 1044253);
            AddRes(index, typeof(Cloth), 1044286, 10, 1044287);
            index = AddCraft(typeof(SmallTableBlueRunnerEast), "House Furniture", "SmallTableBlueRunnerEast", 80.0, 100.0, typeof(Board), "Board", 25);
            AddSkill(index, SkillName.Tailoring, 80.0, 100.0);
            AddRes(index, typeof(Dyes), 1024009, 2, 1044253);
            AddRes(index, typeof(Cloth), 1044286, 5, 1044287);
            index = AddCraft(typeof(SmallTableBlueRunnerSouth), "House Furniture", "SmallTableBlueRunnerSouth", 80.0, 100.0, typeof(Board), "Board", 25);
            AddSkill(index, SkillName.Tailoring, 80.0, 100.0);
            AddRes(index, typeof(Dyes), 1024009, 2, 1044253);
            AddRes(index, typeof(Cloth), 1044286, 5, 1044287);
            index = AddCraft(typeof(AbacusEast), "House Furniture", "Abacus East", 80.0, 100.0, typeof(Board), "Board", 15);
            AddRes(index, typeof(Beads), 1024235, 3, 1044253);
            index = AddCraft(typeof(AbacusSouth), "House Furniture", "Abacus South", 80.0, 100.0, typeof(Board), "Board", 15);
            AddRes(index, typeof(Beads), 1024235, 3, 1044253);
            index = AddCraft(typeof(EaselEast), "House Furniture", "EaselEast", 80.0, 100.0, typeof(Board), "Board", 50);
            index = AddCraft(typeof(EaselSouth), "House Furniture", "EaselSouth", 80.0, 100.0, typeof(Board), "Board", 50);
            index = AddCraft(typeof(EaselWithCanvasEast), "House Furniture", "EaselWithCanvasEast", 85.0, 105.0, typeof(Board), "Board", 50);
            AddSkill(index, SkillName.Tailoring, 85.0, 105.0);
            AddRes(index, typeof(Cloth), 1044286, 15, 1044287);
            index = AddCraft(typeof(EaselWithCanvasSouth), "House Furniture", "EaselWithCanvasSouth", 85.0, 105.0, typeof(Board), "Board", 50);
            AddSkill(index, SkillName.Tailoring, 85.0, 105.0);
            AddRes(index, typeof(Cloth), 1044286, 15, 1044287);
            index = AddCraft(typeof(RackOfCanvasesEast), "House Furniture", "RackOfCanvasesEast", 90.0, 110.0, typeof(Board), "Board", 25);
            AddSkill(index, SkillName.Tailoring, 90.0, 110.0);
            AddRes(index, typeof(Cloth), 1044286, 30, 1044287);
            index = AddCraft(typeof(RackOfCanvasesSouth), "House Furniture", "RackOfCanvasesSouth", 90.0, 110.0, typeof(Board), "Board", 25);
            AddSkill(index, SkillName.Tailoring, 90.0, 110.0);
            AddRes(index, typeof(Cloth), 1044286, 30, 1044287);

            //NPC Display Weapons
            index = AddCraft(typeof(DaemonSword), "NPC Display Weapons", "Daemon Sword", 90.0, 110.0, typeof(Board), "Board", 5);
            AddSkill(index, SkillName.Blacksmith, 90.0, 110.0);
            AddRes(index, typeof(IronIngot), 1044036, 5, 1044037);
            index = AddCraft(typeof(EttinHammer), "NPC Display Weapons", "Ettin Hammer", 90.0, 110.0, typeof(Board), "Board", 5);
            AddSkill(index, SkillName.Blacksmith, 90.0, 110.0);
            AddRes(index, typeof(IronIngot), 1044036, 5, 1044037);
            index = AddCraft(typeof(FrostTrollClub), "NPC Display Weapons", "FrostTroll Club", 90.0, 110.0, typeof(Board), "Board", 5);
            AddSkill(index, SkillName.Blacksmith, 90.0, 110.0);
            AddRes(index, typeof(IronIngot), 1044036, 5, 1044037);
            index = AddCraft(typeof(LichesStaff), "NPC Display Weapons", "Liches Staff", 90.0, 110.0, typeof(Board), "Board", 5);
            AddSkill(index, SkillName.Blacksmith, 90.0, 110.0);
            AddRes(index, typeof(IronIngot), 1044036, 5, 1044037);
            index = AddCraft(typeof(LizardmansSpear), "NPC Display Weapons", "Lizardmans Spear", 90.0, 110.0, typeof(Board), "Board", 8);
            AddSkill(index, SkillName.Blacksmith, 90.0, 110.0);
            AddRes(index, typeof(IronIngot), 1044036, 5, 1044037);
            index = AddCraft(typeof(MagicStaff), "NPC Display Weapons", "Magic Staff", 90.0, 110.0, typeof(Board), "Board", 8);
            AddSkill(index, SkillName.Blacksmith, 90.0, 110.0);
            AddRes(index, typeof(IronIngot), 1044036, 5, 1044037);
            index = AddCraft(typeof(OgresClub), "NPC Display Weapons", "Ogres Club", 90.0, 110.0, typeof(Board), "Board", 5);
            AddSkill(index, SkillName.Blacksmith, 90.0, 110.0);
            AddRes(index, typeof(Bone), 1049064, 25, 1049063);
            index = AddCraft(typeof(OphidianBardiche), "NPC Display Weapons", "Ophidian Bardiche", 90.0, 110.0, typeof(Board), "Board", 5);
            AddSkill(index, SkillName.Blacksmith, 90.0, 110.0);
            AddRes(index, typeof(IronIngot), 1044036, 5, 1044037);
            index = AddCraft(typeof(OrcLordBattleaxe), "NPC Display Weapons", "Orc Lord Battleaxe", 90.0, 110.0, typeof(Board), "Board", 5);
            AddSkill(index, SkillName.Blacksmith, 90.0, 110.0);
            AddRes(index, typeof(IronIngot), 1044036, 5, 1044037);
            index = AddCraft(typeof(TerathanSpear), "NPC Display Weapons", "Terathan Spear", 90.0, 110.0, typeof(Board), "Board", 5);
            AddSkill(index, SkillName.Blacksmith, 90.0, 110.0);
            AddRes(index, typeof(IronIngot), 1044036, 5, 1044037);
            index = AddCraft(typeof(TrollMaul), "NPC Display Weapons", "Troll Maul", 90.0, 110.0, typeof(Board), "Board", 8);
            AddSkill(index, SkillName.Blacksmith, 90.0, 110.0);
            AddRes(index, typeof(IronIngot), 1044036, 5, 1044037);
        }
    }
}
