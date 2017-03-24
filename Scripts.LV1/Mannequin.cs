/**************************** Mannequin.cs *******************************
 *
 *					        (C) 2015, by Lokai
 *	
 * 14th Anniversary Reward item, with optional costs for use.
 *   
/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Multis;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	public class Mannequin : BaseCreature
	{
        // THESE CAN BE CUSTOMIZED TO SUIT YOUR SHARD ===================================

        // Set 'true' if you want to charge Gold for each use of the Customizations gump.
	    private const bool CHARGE_FOR_CUSTOMIZATIONS = true; // <-------- IMPORTANT! ===

        // These FEES are only used if the above bool is set to true.
	    private const int FEE_TO_RANDOMIZE = 5000; 
	    private const int FEE_TO_CHANGE_RACE = 1000;
	    private const int FEE_TO_CHANGE_GENDER = 750;
        private const int FEE_TO_CHANGE_HAIR = 250;
        private const int FEE_TO_CHANGE_FACIAL_HAIR = 250;
        private const int FEE_TO_CHANGE_SKIN_COLOR = 250;
        private const int FEE_TO_CHANGE_HAIR_COLOR = 250;

        // Set 'true' if you want the quick-change feature to expend STAMINA points
        private const bool STAM_LOSS_FOR_CHANGE = true; // <-------- IMPORTANT! ========

        // This cost will only be used if the above bool is set to true.
	    private const int STAM_LOSS = 8;

        // ==============================================================================

		public override bool ClickTitle{ get{ return false; } }
		public override bool NoHouseRestrictions{ get{ return true; } }
		public override bool AllowEquipFrom( Mobile from ){ return m_Owner == from; }
		public override bool CheckNonlocalLift( Mobile from, Item item ){ return m_Owner == from; }
		public override bool CanBeDamaged(){ return false; }
		public override bool CanBeRenamedBy( Mobile from ){ return m_Owner == from; }
		public override bool CanPaperdollBeOpenedBy(Mobile from){ return true; }

	    public override bool OnDragDrop(Mobile from, Item dropped)
	    {
            if (m_Owner == from && (dropped is BaseClothing || dropped is BaseArmor || dropped is BaseJewel || dropped is BaseWeapon))
	        {
	            return EquipItem(dropped);
	        }

	        if (m_Owner == from && dropped is Container)
	        {
	            Container container = (Container) dropped;
	            if (container.Items.Count <= 0)
                {
                    List<Item> dummyItems = new List<Item>();
                    foreach (var item in Items)
                    {
                        if (item is BaseClothing || item is BaseArmor || item is BaseJewel || item is BaseWeapon)
                        {
                            dummyItems.Add(item);
                        }
                    }
                    foreach (var item in dummyItems)
                    {
                        container.DropItem(item);
                    }

                    Say("I put everything I was wearing into that container.");
                    return false;
	            }
	            else
                {
                    List<Item> containerItems = new List<Item>();
                    foreach (var item in (container.Items))
                    {
                        if (item is BaseClothing || item is BaseArmor || item is BaseJewel || item is BaseWeapon)
                        {
                            containerItems.Add(item);
                        }
                    }
                    foreach (var item in containerItems)
                    {
                        EquipItem(item);
                    }

                    Say("I equipped everything from that container that I could.");
                    return false;
	            }
	        }

	        Say("I don't need that!");
	        return false;
	    }

	    public override bool CheckEquip(Item item)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                if (Items[i].CheckConflictingLayer(this, item, item.Layer) ||
                    item.CheckConflictingLayer(this, Items[i], Items[i].Layer))
                {
                    Say("I am already wearing something there!");
                    return false;
                }
            }

            return true;
	    }

	    public override void OnDoubleClick(Mobile from)
	    {
	        if (from == Owner)
	        {
	            if (SwitchClothes(from))
                {
                    from.FixedParticles(0x376A, 8, 16, 5030, EffectLayer.Waist);
                    FixedParticles(0x376A, 8, 16, 5030, EffectLayer.Waist);
	            }
	        }
            else
	            base.OnDoubleClick(from);
	    }

	    public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

	        if (from == Owner)
	        {
	            list.Add(new CustomizeBodyEntry(from, this));
	            list.Add(new SwitchClothesEntry(from, this));
	            list.Add(new RotateEntry(from, this));
	            list.Add(new RedeedEntry(from, this));
	        }
	    }

	    private class CustomizeBodyEntry : ContextMenuEntry
        {
            private Mobile from;
            private Mannequin dummy;

            public CustomizeBodyEntry(Mobile mob, Mannequin mann)
                : base(1151585, 4)
            {
                from = mob;
                dummy = mann;
	        }

            public override void OnClick()
            {
                if (from == dummy.Owner)
                {
                    from.SendGump(new MannequinGump(from, dummy));
                }
            }
	    }

	    private class SwitchClothesEntry : ContextMenuEntry
	    {
	        private Mobile from;
	        private Mannequin dummy;

            public SwitchClothesEntry(Mobile mob, Mannequin mann)
                : base(1151606, 4)
            {
                from = mob;
                dummy = mann;
            }

	        public override void OnClick()
            {
                if (from == dummy.Owner)
                {
                    if (dummy.SwitchClothes(from))
                    {
                        from.FixedParticles(0x376A, 8, 16, 5030, EffectLayer.Waist);
                        dummy.FixedParticles(0x376A, 8, 16, 5030, EffectLayer.Waist);
                    }
                }
	        }
        }

        private class RotateEntry : ContextMenuEntry
        {
            private Mobile from;
            private Mannequin dummy;

            public RotateEntry(Mobile mob, Mannequin mann)
                : base(1151586, 4)
            {
                from = mob;
                dummy = mann;
            }

            public override void OnClick()
            {
                if (from == dummy.Owner)
                {
                    int direction = (int)dummy.Direction;
                    direction++;
                    if (direction > 0x7) direction = 0x0;
                    dummy.Direction = (Direction)direction;
                }
            }
        }

        private class RedeedEntry : ContextMenuEntry
        {
            private Mobile from;
            private Mannequin dummy;

            public RedeedEntry(Mobile mob, Mannequin mann)
                : base(1151601, 4)
            {
                from = mob;
                dummy = mann;
            }

            public override void OnClick()
            {
                if (from == dummy.Owner)
                {
                    List<Item> dummyItems = new List<Item>();
                    foreach (var item in dummy.Items)
                    {
                        if (item is BaseClothing || item is BaseArmor || item is BaseJewel || item is BaseWeapon)
                        {
                            dummyItems.Add(item);
                        }
                    }
                    if (dummyItems.Count > 0)
                    {
                        foreach (var item in dummyItems)
                        {
                            from.AddToBackpack(item);
                        }

                        from.SendMessage("I put everything I was wearing into your Backpack.");
                    }

                    dummy.Delete();
                    from.AddToBackpack(new MannequinDeed());
                }
            }
        }

        private bool SwitchClothes(Mobile from)
        {
            if (BaseHouse.FindHouseAt(from) == null || !BaseHouse.FindHouseAt(from).IsOwner(from))
            {
                from.SendMessage("You must be in your house to use this.");
                return false;
            }

            if (BaseHouse.FindHouseAt(this) == null || !BaseHouse.FindHouseAt(this).IsOwner(from))
            {
                from.SendMessage("Your mannequin must be in your own house to use it.");
                return false;
            }

            if (BaseHouse.FindHouseAt(this) != null && BaseHouse.FindHouseAt(from) != null &&
                BaseHouse.FindHouseAt(this) != BaseHouse.FindHouseAt(from))
            {
                from.SendMessage("You and your mannequin must be in the same house to do that!");
                return false;
            }

            if (!CanSee(from) || !from.InLOS(this))
            {
                from.SendMessage("You and your mannequin must be able to see eachother to do that.");
                return false;
            }

            if (STAM_LOSS_FOR_CHANGE)
            {
                if (from.Stam <= STAM_LOSS)
                {
                    from.SendMessage("You don't have the energy to make a quick change at this time.");
                    return false;
                }
            }

            List<Item> mannequinItems = new List<Item>();
            List<Item> mobileItems = new List<Item>();

            foreach (Item item in Items)
            {
                if (IsEquipped(item) && !(item is Backpack))
                {
                    mannequinItems.Add(item);
                }
            }

            foreach (Item item in from.Items)
            {
                if (IsEquipped(item) && !(item is Backpack))
                {
                    mobileItems.Add(item);
                }
            }

            foreach (Item item in mobileItems)
            {
                from.RemoveItem(item);
            }

            foreach (Item item in mannequinItems)
            {
                RemoveItem(item);
            }

            foreach (Item item in mobileItems)
            {
                EquipItem(item);
            }

            bool someRemoved = false;
            int itemsAdded = 0;
            foreach (Item item in mannequinItems)
            {
                if (from.EquipItem(item))
                {
                    itemsAdded++;
                }
                else
                {
                    someRemoved = true;
                    if (!from.AddToBackpack(item))
                        item.DropToWorld(from, from.Location);
                }
            }

            if (itemsAdded > 0 && STAM_LOSS_FOR_CHANGE)
            {
                from.Stam -= STAM_LOSS;
            }

            if (someRemoved)
            {
                from.SendMessage("You were not able to equip everything.");
                return false;
            }

            return true;
        }

	    private bool IsEquipped(Item item)
	    {
	        return item != null && item.Parent is Mobile && ((Mobile) item.Parent).FindItemOnLayer(item.Layer) == item &&
	               item.Layer != Layer.Mount && item.Layer != Layer.Bank && 
                   item.Layer != Layer.Invalid && item.Layer != Layer.Backpack;
	    }

	    private bool CanEquip(Item item)
	    {
            if (item.Layer != Layer.Invalid)
            {
                if (this.FindItemOnLayer(item.Layer) == null)
                {
                    return true;
                }
                else
                {
                    Say("I am already wearing something on that Layer!");
                }
            }
            else
                Say("The Layer of that Item is Invalid!");

	        return false;
	    }


        public override bool EquipItem(Item item)
        {
            if (item == null)
            {
                Say("That item is no good!");
                return false;
            }

            if (item.Deleted)
            {
                Say("The item was deleted!");
                return false;
            }

            if (!CanEquip(item))
            {
                return false;
            }

            if (CheckEquip(item) && OnEquip(item) && item.OnEquip(this))
            {
                AddItem(item);
                return true;
            }

            Say("I can't equip that!");
            return false;
        }
	    public override bool IsInvulnerable { get { return true; } }

	    private Mobile m_Owner;

        public Mobile Owner { get { return m_Owner; } }

		[Constructable]
		public Mannequin(Mobile owner) : base( AIType.AI_Use_Default, FightMode.None, 1, 1, 0.2, 0.2 )
		{
			m_Owner = owner;
		    Female = owner.Female;
		    Race = owner.Race;
			Name = "Mannequin";
			Title = "";
			NameHue = 1150;

		    SetBody();

			CantWalk = true;
			Direction = Direction.South;
		    Blessed = true;
		}

	    public void SetBody()
	    {
	        switch (Race.RaceID)
	        {
	            case 0: // Human
	                Body = Female ? 401 : 400;
	                break;
                case 1: // Elf
                    Body = Female ? 606 : 605;
	                break;
                case 2: // Gargoyle
                    Body = Female ? 667 : 666;
	                break;
            }
            int hairHue = Race.RandomHairHue();
            Hue = Race.RandomSkinHue();
            HairItemID = Race.RandomHair(Female);
            HairHue = hairHue;
            FacialHairItemID = Race.RandomFacialHair(Female);
            FacialHairHue = hairHue;
        }

	    public static readonly CustomHuePicker HumanHairColor = new CustomHuePicker(new CustomHueGroup[]
	    {
	        new CustomHueGroup("Hair Color 0", new int[] {1102, 1103, 1104, 1105, 1106, 1107, 1108, 1109}),
	        new CustomHueGroup("Hair Color 1", new int[] {1110, 1111, 1112, 1113, 1114, 1115, 1116, 1117}),
	        new CustomHueGroup("Hair Color 2", new int[] {1118, 1119, 1120, 1121, 1122, 1123, 1124, 1125}),
	        new CustomHueGroup("Hair Color 3", new int[] {1126, 1127, 1128, 1129, 1130, 1131, 1132, 1133}),
	        new CustomHueGroup("Hair Color 4", new int[] {1134, 1135, 1136, 1137, 1138, 1139, 1140, 1141}),
	        new CustomHueGroup("Hair Color 5", new int[] {1142, 1143, 1144, 1145, 1146, 1147, 1148, 1149})
	    }, false, "Hair Color");

	    public static readonly CustomHuePicker HumanSkinColor = new CustomHuePicker(new CustomHueGroup[]
	    {
	        new CustomHueGroup("Skin Color 0", new int[] {1002, 1003, 1004, 1005, 1006, 1007, 1008, 1009}),
	        new CustomHueGroup("Skin Color 1", new int[] {1010, 1011, 1012, 1013, 1014, 1015, 1016, 1017}),
	        new CustomHueGroup("Skin Color 2", new int[] {1018, 1019, 1020, 1021, 1022, 1023, 1024, 1025}),
	        new CustomHueGroup("Skin Color 3", new int[] {1026, 1027, 1028, 1029, 1030, 1031, 1032, 1033}),
	        new CustomHueGroup("Skin Color 4", new int[] {1034, 1035, 1036, 1037, 1038, 1039, 1040, 1041}),
	        new CustomHueGroup("Skin Color 5", new int[] {1042, 1043, 1044, 1045, 1046, 1047, 1048, 1049}),
	        new CustomHueGroup("Skin Color 6", new int[] {1050, 1051, 1052, 1053, 1054, 1055, 1056, 1057, 1058})
	    }, false, "Skin Color");

	    public static readonly CustomHuePicker ElfSkinColor = new CustomHuePicker(new CustomHueGroup[]
	    {
	        new CustomHueGroup("Skin Color 0", new int[] {0x0BF, 0x24D, 0x24E, 0x24F}),
	        new CustomHueGroup("Skin Color 1", new int[] {0x353, 0x361, 0x367, 0x374, 0x375, 0x376}),
	        new CustomHueGroup("Skin Color 2", new int[] {0x381, 0x382, 0x383, 0x384, 0x385, 0x389}),
	        new CustomHueGroup("Skin Color 3", new int[] {0x3DE, 0x3E5, 0x3E6, 0x3E8, 0x3E9, 0x3CB, 0x4A7, 0x4DE}),
	        new CustomHueGroup("Skin Color 4", new int[] {0x51D, 0x53F, 0x579, 0x76B, 0x76C, 0x76D, 0x835, 0x903})
	    }, false, "Skin Color");

	    public static readonly CustomHuePicker ElfHairColor = new CustomHuePicker(new CustomHueGroup[]
	    {
	        new CustomHueGroup("Hair Color 0", new int[] {0x034, 0x035, 0x036, 0x037, 0x038, 0x039}),
	        new CustomHueGroup("Hair Color 1", new int[] {0x058, 0x08E, 0x08F, 0x090, 0x091, 0x092, 0x101}),
	        new CustomHueGroup("Hair Color 2", new int[] {0x159, 0x15A, 0x15B, 0x15C, 0x15D, 0x15E}),
	        new CustomHueGroup("Hair Color 3", new int[] {0x128, 0x12F, 0x1BD, 0x1E4, 0x1F3}),
	        new CustomHueGroup("Hair Color 4", new int[] {0x207, 0x211, 0x239, 0x251, 0x26C, 0x2C3}),
	        new CustomHueGroup("Hair Color 5", new int[] {0x2C9, 0x31D, 0x31E, 0x31F}),
	        new CustomHueGroup("Hair Color 6", new int[] {0x320, 0x321, 0x322, 0x323, 0x324, 0x325, 0x326}),
	        new CustomHueGroup("Hair Color 7", new int[] {0x369, 0x386, 0x387, 0x388, 0x389, 0x38A}),
	        new CustomHueGroup("Hair Color 8", new int[] {0x59D, 0x6B8, 0x725, 0x853})
	    }, false, "Hair Color");

	    public static readonly CustomHuePicker GargoyleHairColor = new CustomHuePicker(new CustomHueGroup[]
	    {
	        new CustomHueGroup("Hair Color 0", new int[] {0x709, 0x70B, 0x70D, 0x70F, 0x711}),
	        new CustomHueGroup("Hair Color 1", new int[] {0x763, 0x765, 0x768, 0x76B}),
	        new CustomHueGroup("Hair Color 2", new int[] {0x6F3, 0x6F1, 0x6EF, 0x6E4, 0x6E2, 0x6E0}),
	        new CustomHueGroup("Hair Color 3", new int[] {0x709, 0x70B, 0x70D})
	    }, false, "Hair Color");

	    public static readonly CustomHuePicker GargoyleSkinColor = new CustomHuePicker(new CustomHueGroup[]
	    {
	        new CustomHueGroup("Skin Color 0", new int[] {0x6DB, 0x6DC, 0x6DD, 0x6DE, 0x6DF}),
	        new CustomHueGroup("Skin Color 1", new int[] {0x6E0, 0x6E1, 0x6E2, 0x6E3, 0x6E4}),
	        new CustomHueGroup("Skin Color 2", new int[] {0x6E5, 0x6E6, 0x6E7, 0x6E8, 0x6E9}),
	        new CustomHueGroup("Skin Color 3", new int[] {0x6EA, 0x6EB, 0x6EC, 0x6ED, 0x6EE}),
	        new CustomHueGroup("Skin Color 4", new int[] {0x6EF, 0x6F0, 0x6F1, 0x6F2, 0x6F3})
	    }, false, "Skin Color");

        

	    public override void GenerateLoot()
		{
		}

		public Mannequin( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( m_Owner );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Owner = reader.ReadMobile();
		}

        private class MannequinGump : Gump
        {
            private Mobile m_From;
            private Mannequin m_Mannequin;

            private void AddBackground()
            {
                AddPage(0);

                AddBackground(0, 0, 500, 400, 3600);

                AddImage(240, 18, 1800);
                AddImage(240, 18, GetLgBodyId(), GetHue(m_Mannequin.Hue)); // Body
                AddImage(240, 18, GetHairId(m_Mannequin.HairItemID), GetHue(m_Mannequin.HairHue)); // Hair
                if (!m_Mannequin.Female)
                    AddImage(240, 18, GetHairId(m_Mannequin.FacialHairItemID), GetHue(m_Mannequin.FacialHairHue)); // Facial Hair

                AddLabel(100, 18, 1153, "Mannequin CUSTOMIZATION MENU");
            }

            private void AddButtons()
            {
                AddButton(20, 80, 4005, 4007, (int)Buttons.RANDOMIZE, GumpButtonType.Reply, 0);
                AddLabel(60, 80, 1152, string.Format("Randomize{0}",
                    CHARGE_FOR_CUSTOMIZATIONS ? " (" + FindAmount((int) Buttons.RANDOMIZE) + " Gold)" : ""));

                AddButton(20, 120, 4005, 4007, (int)Buttons.CHANGE_RACE, GumpButtonType.Reply, 0);
                AddLabel(60, 120, 1152, string.Format("Change Race{0}",
                    CHARGE_FOR_CUSTOMIZATIONS ? " (" + FindAmount((int)Buttons.CHANGE_RACE) + " Gold)" : ""));

                AddButton(20, 160, 4005, 4007, (int)Buttons.CHANGE_GENDER, GumpButtonType.Reply, 0);
                AddLabel(60, 160, 1152, string.Format("Switch Gender{0}",
                    CHARGE_FOR_CUSTOMIZATIONS ? " (" + FindAmount((int)Buttons.CHANGE_GENDER) + " Gold)" : ""));

                AddButton(20, 200, 4005, 4007, (int)Buttons.CHANGE_HAIR, GumpButtonType.Reply, 0);
                AddLabel(60, 200, 1152, string.Format("Change Hair Style{0}",
                    CHARGE_FOR_CUSTOMIZATIONS ? " (" + FindAmount((int)Buttons.CHANGE_HAIR) + " Gold)" : ""));

                if (m_Mannequin.Female)
                    AddImage(20, 240, 4005);
                else
                    AddButton(20, 240, 4005, 4007, (int)Buttons.CHANGE_FACIAL_HAIR, GumpButtonType.Reply, 0);
                AddLabel(60, 240, m_Mannequin.Female ? 0x20 : 1152, string.Format("Change Facial Hair{0}",
                    CHARGE_FOR_CUSTOMIZATIONS ? " (" + FindAmount((int)Buttons.CHANGE_FACIAL_HAIR) + " Gold)" : ""));

                AddButton(20, 280, 4005, 4007, (int)Buttons.CHANGE_HAIR_COLOR, GumpButtonType.Reply, 0);
                AddLabel(60, 280, 1152, string.Format("Hair Color{0}",
                    CHARGE_FOR_CUSTOMIZATIONS ? " (" + FindAmount((int)Buttons.CHANGE_HAIR_COLOR) + " Gold)" : ""));

                AddButton(20, 320, 4005, 4007, (int)Buttons.CHANGE_SKIN_COLOR, GumpButtonType.Reply, 0);
                AddLabel(60, 320, 1152, string.Format("Skin Color{0}",
                    CHARGE_FOR_CUSTOMIZATIONS ? " (" + FindAmount((int)Buttons.CHANGE_SKIN_COLOR) + " Gold)" : ""));

                AddButton(225, 362, 4014, 4016, (int)Buttons.CLOSE, GumpButtonType.Reply, 0);
                AddLabel(265, 362, 1265, "Close");
            }

            private int GetHue(int fromHue)
            {
                int hue = 0;
                switch (m_Mannequin.Race.Name)
                {
                    case "Human":
                    case "Elf":
                    case "Gargoyle":
                        if (fromHue > 32768)
                            hue = fromHue - 32768;
                        else
                            hue = fromHue;
                        break;
                }
                return hue;
            }

            private int GetLgBodyId()
            {
                switch (m_Mannequin.Race.Name)
                {
                    case "Human":
                        return m_Mannequin.Female ? 1888 : 1889;
                    case "Elf":
                        return m_Mannequin.Female ? 1893 : 1894;
                    case "Gargoyle":
                        return m_Mannequin.Female ? 1898 : 1899;
                }
                return 1889;
            }

            private int GetHairId(int fromHairId)
            {
                switch (fromHairId)
                {
                    // ELF HAIR
                    case 0x2FC0: //Long Feather
                        return m_Mannequin.Female ? 1775 : 1785;
                    case 0x2FC1: //Short
                        return m_Mannequin.Female ? 1776 : 1786;
                    case 0x2FC2: //Mullet
                        return m_Mannequin.Female ? 1777 : 1787;
                    case 0x2FCE: //Knob
                        return m_Mannequin.Female ? 1779 : 1790;
                    case 0x2FCF: //Braided
                        return m_Mannequin.Female ? 1780 : 1791;
                    case 0x2FD1: //Spiked
                        return m_Mannequin.Female ? 1783 : 1793;
                    case 0x2FCC: //Flower
                        return 1778;
                    case 0x2FBF: //Mid-long
                        return 1784;
                    case 0x2FD0: //Bun
                        return 1782;
                    case 0x2FCD: //Long
                        return 1789;

                    // HUMAN HAIR
                    case 0x203B: //Short
                        return m_Mannequin.Female ? 1847 : 1875;
                    case 0x203C: //Long
                        return m_Mannequin.Female ? 1837 : 1876;
                    case 0x203D: //Pony Tail
                        return m_Mannequin.Female ? 1845 : 1879;
                    case 0x2044: //Mohawk
                        return m_Mannequin.Female ? 1843 : 1877;
                    case 0x2045: //Pageboy
                        return m_Mannequin.Female ? 1844 : 1871;
                    case 0x2047: //Curly
                        return m_Mannequin.Female ? 1839 : 1873;
                    case 0x2049: //Two tails
                        return m_Mannequin.Female ? 1836 : 1870;
                    case 0x204A: //Top Knot
                        return m_Mannequin.Female ? 1840 : 1874;
                    case 0x2046: //Buns
                        return 1841;
                    case 0x2048: //Receeding Hair
                        return 1878;

                    // FACIAL HAIR
                    case 0x203E: // Long Beard
                        return m_Mannequin.Female ? 30088 : 1883;
                    case 0x203F: // Short Beard
                        return m_Mannequin.Female ? 30088 : 1885;
                    case 0x2040: // Goatee
                        return m_Mannequin.Female ? 30088 : 1881;
                    case 0x2041: // Moustache
                        return m_Mannequin.Female ? 30088 : 1884;
                    case 0x204B: // Short Beard and Moustache
                        return m_Mannequin.Female ? 30088 : 1886;
                    case 0x204C: // Long Beard and Moustache
                        return m_Mannequin.Female ? 30088 : 1882;
                    case 0x204D: // Vandyke
                        return m_Mannequin.Female ? 30088 : 1887;

                    // GARGOYLE MALE HAIR-ID HORNS
                    case 0x4258:
                        return 1900;
                    case 0x4259:
                        return 1901;
                    case 0x425A:
                        return 1907;
                    case 0x425B:
                        return 1902;
                    case 0x425C:
                        return 1908;
                    case 0x425D:
                        return 1910;
                    case 0x425E:
                        return 1910;
                    case 0x425F:
                        return 1911;

                    case 0x4261:
                        return 1952;
                    case 0x4262:
                        return 1953;
                    case 0x4273:
                        return 1950;
                    case 0x4274:
                        return 1954;
                    case 0x4275:
                        return 1951;
                    case 0x42B1:
                        return 1918;
                    case 0x42AA:
                        return 1953;
                    case 0x42AB:
                        return 1917;

                    // GARGOYLE FACIAL HORNS
                    case 0x42AD:
                        return m_Mannequin.Female ? 30088 : 1903;
                    case 0x42AE:
                        return m_Mannequin.Female ? 30088 : 1904;
                    case 0x42AF:
                        return m_Mannequin.Female ? 30088 : 1905;
                    case 0x42B0:
                        return m_Mannequin.Female ? 30088 : 1906;
                }
                return 30088;
            }

            public MannequinGump(Mobile from, Mannequin mannequin)
                : this(from, mannequin, "", false)
            {
            }

            public MannequinGump(Mobile from, Mannequin mannequin, string message, bool success)
                : base(0, 0)
            {
                m_From = from;
                m_Mannequin = mannequin;

                from.CloseGump(typeof (MannequinGump));

                AddBackground();
                AddButtons();
                if (message.Length > 0)
                {
                    message = CHARGE_FOR_CUSTOMIZATIONS
                        ? message.Replace("ZZHAIR", string.Format("{0}", FEE_TO_CHANGE_HAIR_COLOR))
                        : "";
                    message = CHARGE_FOR_CUSTOMIZATIONS
                        ? message.Replace("ZZSKIN", string.Format("{0}", FEE_TO_CHANGE_SKIN_COLOR))
                        : "";
                    AddLabel(60, 49, success ? 0x40 : 0x20, message);
                }
            }

            private enum Buttons
            {
                RANDOMIZE = 1,
                CHANGE_GENDER,
                CHANGE_HAIR_COLOR,
                CHANGE_FACIAL_HAIR,
                CHANGE_HAIR,
                CHANGE_SKIN_COLOR,
                CHANGE_RACE,
                CLOSE = 99
            }

            private string[] messages = { "", "randomization", "gender change", "hair color", "facial hair change", "hair style", "skin change", "race change" };

            private int FindAmount(int modType)
            {
                switch ((Buttons) modType)
                {
                    case Buttons.RANDOMIZE:
                        return FEE_TO_RANDOMIZE;
                    case Buttons.CHANGE_RACE:
                        return FEE_TO_CHANGE_RACE;
                    case Buttons.CHANGE_GENDER:
                        return FEE_TO_CHANGE_GENDER;
                    case Buttons.CHANGE_HAIR:
                        return FEE_TO_CHANGE_HAIR;
                    case Buttons.CHANGE_FACIAL_HAIR:
                        return FEE_TO_CHANGE_FACIAL_HAIR;
                    case Buttons.CHANGE_SKIN_COLOR:
                        return FEE_TO_CHANGE_SKIN_COLOR;
                    case Buttons.CHANGE_HAIR_COLOR:
                        return FEE_TO_CHANGE_HAIR_COLOR;
                }
                return 0;
            }

            public override void OnResponse(NetState state, RelayInfo info)
            {
                int button = info.ButtonID;
                if (button < 1 || button >= 99)
                    return;

                bool success = false;
                string message = "";

                if (CHARGE_FOR_CUSTOMIZATIONS)
                {
                    int amount = FindAmount(button);
                    Container pack = state.Mobile.Backpack;
                    if (pack == null || !pack.ConsumeTotal(typeof (Gold), amount))
                    {
                        m_From.SendGump(new MannequinGump(m_From, m_Mannequin, "* Thou dost not have enough Gold. *", false));
                        return;
                    }
                    message = string.Format("{0} Gold was taken for the {1}.", amount, messages[button]);
                    success = true;
                }
                switch (info.ButtonID)
                {
                    case (int)Buttons.RANDOMIZE:
                        // Randomize...
                        m_Mannequin.Female = Utility.RandomBool();
                        m_Mannequin.Race = Race.Races[Utility.Random(Race.AllRaces.Count)];
                        m_Mannequin.SetBody();
                        m_From.SendGump(new MannequinGump(m_From, m_Mannequin, message, success));
                        break;
                    case (int)Buttons.CHANGE_GENDER:
                        // Change gender...
                        m_Mannequin.Female = !m_Mannequin.Female;
                        UpdateBody();
                        m_From.SendGump(new MannequinGump(m_From, m_Mannequin, message, success));
                        break;
                    case (int)Buttons.CHANGE_HAIR_COLOR:
                        // Change Hair Color...
                        switch (m_Mannequin.Race.RaceID)
                        {
                            case 0: // Human
                                m_From.SendGump(new CustomHuePickerGump(m_Mannequin, HumanHairColor, HairCallback, m_From));
                                break;
                            case 1: // Elf
                                m_From.SendGump(new CustomHuePickerGump(m_Mannequin, ElfHairColor, HairCallback, m_From));
                                break;
                            case 2: // Gargoyle
                                m_From.SendGump(new CustomHuePickerGump(m_Mannequin, GargoyleHairColor, HairCallback, m_From));
                                break;
                        }
                        break;
                    case (int)Buttons.CHANGE_SKIN_COLOR:
                        // Change Skin Color...
                        switch (m_Mannequin.Race.RaceID)
                        {
                            case 0: // Human
                                m_From.SendGump(new CustomHuePickerGump(m_Mannequin, HumanSkinColor, SkinCallback, m_From));
                                break;
                            case 1: // Elf
                                m_From.SendGump(new CustomHuePickerGump(m_Mannequin, ElfSkinColor, SkinCallback, m_From));
                                break;
                            case 2: // Gargoyle
                                m_From.SendGump(new CustomHuePickerGump(m_Mannequin, GargoyleSkinColor, SkinCallback, m_From));
                                break;
                        }
                        break;
                    case (int)Buttons.CHANGE_HAIR:
                        // Change Hairstyle...
                        Utility.AssignRandomHair(m_Mannequin);
                        m_From.SendGump(new MannequinGump(m_From, m_Mannequin, message, success));
                        break;
                    case (int)Buttons.CHANGE_FACIAL_HAIR:
                        // Change Facial Hairstyle...
                        Utility.AssignRandomFacialHair(m_Mannequin);
                        m_From.SendGump(new MannequinGump(m_From, m_Mannequin, message, success));
                        break;
                    case (int)Buttons.CHANGE_RACE:
                        // Change Race...
                        if (m_Mannequin.Race.RaceID >= Race.AllRaces.Count - 1)
                        {
                            m_Mannequin.Race = Race.AllRaces[0];
                        }
                        else
                        {
                            m_Mannequin.Race = Race.AllRaces[m_Mannequin.Race.RaceID + 1];
                        }
                        UpdateBody();
                        m_From.SendGump(new MannequinGump(m_From, m_Mannequin, message, success));
                        break;
                    default:
                        break;
                }

            }

            private void UpdateBody()
            {
                switch (m_Mannequin.Race.RaceID)
                {
                    case 0: // Human
                        m_Mannequin.Body = m_Mannequin.Female ? 401 : 400;
                        break;
                    case 1: // Elf
                        m_Mannequin.Body = m_Mannequin.Female ? 606 : 605;
                        break;
                    case 2: // Gargoyle
                        m_Mannequin.Body = m_Mannequin.Female ? 667 : 666;
                        break;
                }
                Utility.AssignRandomHair(m_Mannequin);
                Utility.AssignRandomFacialHair(m_Mannequin);
                m_Mannequin.Hue = m_Mannequin.Race.RandomSkinHue();
                m_Mannequin.InvalidateProperties();
            }
        }

        private static void HairCallback(Mobile from, object state, int hue)
        {
            from.HairHue = hue;
            if (state is Mobile && from is Mannequin && ((Mobile)state) == ((Mannequin)from).Owner)
            {
                ((Mannequin)from).InvalidateProperties();
                ((Mobile) state).SendGump(new MannequinGump(((Mobile) state), ((Mannequin) from),
                    string.Format("ZZHAIR Gold was taken for the hair color change."), true));
            }
        }

        private static void SkinCallback(Mobile from, object state, int hue)
        {
            from.Hue = hue;
            if (state is Mobile && from is Mannequin && ((Mobile)state) == ((Mannequin)from).Owner)
            {
                ((Mannequin)from).InvalidateProperties();
                ((Mobile)state).SendGump(new MannequinGump(((Mobile)state), ((Mannequin)from),
                    string.Format("ZZSKIN Gold was taken for the skin color change."), true));
            }
        }
	}

    [Flipable(0x14F0, 0x14EF)]
    public class MannequinDeed : Item
    {
        public override int LabelNumber
        {
            get { return 1151602; }
        }

        [Constructable]
        public MannequinDeed()
            : base(0x14F0)
        {
            Name = "Mannequin Deed";
            LootType = LootType.Blessed;
        }

        public MannequinDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                if (BaseHouse.FindHouseAt(from) != null && BaseHouse.FindHouseAt(from).Owner == from)
                {
                    from.Target = new PlaceMannequinTarget(this);
                }
                else
                {
                    from.SendLocalizedMessage(502092); // You must be in your house to do this.
                }
            }
            else
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
        }

        private class PlaceMannequinTarget : Target
        {
            private MannequinDeed mDeed;

            public PlaceMannequinTarget(MannequinDeed deed)
                : base(10, true, TargetFlags.None)
            {
                mDeed = deed;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is StaticTarget)
                {
                    Point3D p = new Point3D((IPoint3D)targeted);
                    BaseHouse house = BaseHouse.FindHouseAt(p, from.Map, p.Z);
                    if (house != null && house.Owner == from)
                    {
                        Mannequin m =
                            (Mannequin)Activator.CreateInstance(typeof(Mannequin), new object[] { from });
                        m.MoveToWorld(p, from.Map);
                        m.Direction = Direction.South;
                        mDeed.Delete();
                    }
                }
                else if (targeted is Item)
                {

                }
            }
        }
    }
}