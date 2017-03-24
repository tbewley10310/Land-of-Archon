/*

$Id: 

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

*/

using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Prompts;

namespace Server.Items
{
    public class PowerScrollBookGump : Gump
    {
        private PlayerMobile m_From;
        private PowerScrollBook m_Book;
        private ArrayList m_List;

        private int m_Page;

        private const int LabelColor = 0x7FFF;

        public Item Reconstruct(object obj)
        {
            Item item = null;

            if (obj is PowerScrollBookEntry)
                item = ((PowerScrollBookEntry)obj).Reconstruct();

            return item;
        }

        public bool CheckFilter(object obj)
        {
            if (obj is PowerScrollBookEntry)
            {
                PowerScrollBookEntry e = (PowerScrollBookEntry)obj;

                return CheckFilter(e.Skill, e.SkillValue);
            }

            return false;
        }

        private static SkillName[] m_Skills_Miscellaneous = new SkillName[]
        {
            SkillName.Alchemy,
            SkillName.Blacksmith,
            SkillName.Fletching,
            SkillName.Bushido,
            SkillName.Carpentry,
            SkillName.Chivalry,
            SkillName.Cooking,
            SkillName.Fishing,
            SkillName.Focus,
            SkillName.Healing,
            SkillName.Herding,
            SkillName.Lockpicking,
            SkillName.Lumberjacking,
            SkillName.Magery,
            SkillName.Meditation,
            SkillName.Mining,
            SkillName.Musicianship,
            SkillName.Necromancy,
            SkillName.Ninjitsu,
            SkillName.RemoveTrap,
            SkillName.MagicResist,
            SkillName.Snooping,
            SkillName.Spellweaving,
            SkillName.Stealing,
            SkillName.Stealth,
            SkillName.Tailoring,
            SkillName.Tinkering,
            SkillName.Veterinary
        };

        private static SkillName[] m_Skills_CombatRatings = new SkillName[]
        {
            SkillName.Archery,
            SkillName.ArmsLore,
            SkillName.Fencing,
            SkillName.Lumberjacking,
            SkillName.Macing,
            SkillName.Parry,
            SkillName.Swords,
            SkillName.Tactics,
            SkillName.Wrestling
        };

        private static SkillName[] m_Skills_Actions = new SkillName[]
        {
            SkillName.AnimalTaming,
            SkillName.Begging,
            SkillName.Camping,
            SkillName.Cartography,
            SkillName.DetectHidden,
            SkillName.Discordance,
            SkillName.Hiding,
            SkillName.Inscribe,
            SkillName.Peacemaking,
            SkillName.Poisoning,
            SkillName.Provocation,
            SkillName.SpiritSpeak,
            SkillName.Tracking
        };

        private static SkillName[] m_Skills_LoreKnowledge = new SkillName[]
        {
            SkillName.Anatomy,
            SkillName.AnimalLore,
            SkillName.ArmsLore,
            SkillName.EvalInt,
            SkillName.Forensics,
            SkillName.ItemID,
            SkillName.TasteID
        };

        private static SkillName[] m_Skills_Magical = new SkillName[]
        {
            SkillName.Magery,
            SkillName.Chivalry,
            SkillName.Necromancy,
            SkillName.Spellweaving,
            SkillName.Bushido,
            SkillName.Ninjitsu
        };

        private static SkillName[] m_Skills_Crafting = new SkillName[]
        {
            SkillName.Alchemy,
            SkillName.Blacksmith,
            SkillName.Carpentry,
            SkillName.Cooking,
            SkillName.Fishing,
            SkillName.Fletching,
            SkillName.Inscribe,
            SkillName.Lumberjacking,
            SkillName.Mining,
            SkillName.Tailoring,
            SkillName.Tinkering
        };

        public bool CheckFilter(SkillName skill, int skillvalue)
        {
            PowerScrollFilter f = (m_Book.Filter);

            if (f.IsDefault)
                return true;

            if (f.SkillValue != 0 && f.SkillValue != skillvalue)
                return false;

            if (f.SkillCat != SkillCategory.None)
            {
                if (f.SkillCat == SkillCategory.Miscellaneous)
                {
                    for (int i = 0; i < m_Skills_Miscellaneous.Length; i++)
                        if (m_Skills_Miscellaneous[i] == skill)
                            return true;
                }
                else if (f.SkillCat == SkillCategory.CombatRatings)
                {
                    for (int i = 0; i < m_Skills_CombatRatings.Length; i++)
                        if (m_Skills_CombatRatings[i] == skill)
                            return true;
                }
                else if (f.SkillCat == SkillCategory.Actions)
                {
                    for (int i = 0; i < m_Skills_Actions.Length; i++)
                        if (m_Skills_Actions[i] == skill)
                            return true;
                }
                else if (f.SkillCat == SkillCategory.LoreKnowledge)
                {
                    for (int i = 0; i < m_Skills_LoreKnowledge.Length; i++)
                        if (m_Skills_LoreKnowledge[i] == skill)
                            return true;
                }
                else if (f.SkillCat == SkillCategory.Magical)
                {
                    for (int i = 0; i < m_Skills_Magical.Length; i++)
                        if (m_Skills_Magical[i] == skill)
                            return true;
                }
                else if (f.SkillCat == SkillCategory.CraftingHarvesting)
                {
                    for (int i = 0; i < m_Skills_Crafting.Length; i++)
                        if (m_Skills_Crafting[i] == skill)
                            return true;
                }

                return false;
            }
            return true;
        }

        public int GetIndexForPage(int page)
        {
            int index = 0;

            while (page-- > 0)
                index += GetCountForIndex(index);

            return index;
        }

        public int GetCountForIndex(int index)
        {
            int slots = 0;
            int count = 0;

            ArrayList list = m_List;

            for (int i = index; i >= 0 && i < list.Count; ++i)
            {
                object obj = list[i];

                if (CheckFilter(obj))
                {
                    int add;

                    add = 1;

                    if ((slots + add) > 10)
                        break;

                    slots += add;
                }

                ++count;
            }

            return count;
        }

        public object GetMaterialName()
        {
            string s = "Unknown";
            return s;
        }

        public PowerScrollBookGump(PlayerMobile from, PowerScrollBook book)
            : this(from, book, 0, null)
        {
        }

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            int index = info.ButtonID;

            switch (index)
            {
                case 0: 
                    {
                        break;
                    }
                case 1: 
                    {
                        m_From.SendGump(new PowerScrollFilterGump(m_From, m_Book));
                        break;
                    }
                case 2: 
                    {
                        if (m_Page > 0)
                            m_From.SendGump(new PowerScrollBookGump(m_From, m_Book, m_Page - 1, m_List));

                        return;
                    }
                case 3: 
                    {
                        if (GetIndexForPage(m_Page + 1) < m_List.Count)
                            m_From.SendGump(new PowerScrollBookGump(m_From, m_Book, m_Page + 1, m_List));

                        break;
                    }
                default:
                    {
                        bool canDrop = m_Book.IsChildOf(m_From.Backpack);
                        bool canPrice = canDrop || (m_Book.RootParent is PlayerVendor);

                        index -= 4;

                        int type = index % 2;
                        index /= 2;

                        if (index < 0 || index >= m_List.Count)
                            break;

                        object obj = m_List[index];

                        if (!m_Book.Entries.Contains(obj))
                        {
                            m_From.SendLocalizedMessage(1062382);
                            break;
                        }

                        if (type == 0)
                        {
                            if (m_Book.IsChildOf(m_From.Backpack))
                            {
                                Item item = Reconstruct(obj);

                                if (item != null)
                                {
                                    m_From.AddToBackpack(item);
                                    m_From.SendMessage("The power scroll has been placed in your backpack.");

                                    m_Book.Entries.Remove(obj);
                                    m_Book.InvalidateProperties();

                                    if (m_Book.Entries.Count > 0)
                                        m_From.SendGump(new PowerScrollBookGump(m_From, m_Book, 0, null));
                                    else
                                        m_From.SendLocalizedMessage(1062381);
                                }
                                else
                                {
                                    m_From.SendMessage("Internal error. The power scroll could not be reconstructed.");
                                }
                            }
                        }
                        else 
                        {
                            if (m_Book.IsChildOf(m_From.Backpack))
                            {
                                m_From.Prompt = new SetPricePrompt(m_Book, obj, m_Page, m_List);
                                m_From.SendMessage("Type in a price for the power scroll:");
                            }
                            else if (m_Book.RootParent is PlayerVendor)
                            {
                                PlayerVendor pv = (PlayerVendor)m_Book.RootParent;

                                VendorItem vi = pv.GetVendorItem(m_Book);

                                int price = 0;

                                if (vi != null && !vi.IsForSale)
                                {
                                    if (obj is PowerScrollBookEntry)
                                        price = ((PowerScrollBookEntry)obj).Price;
                                }

                                if (price == 0)
                                    m_From.SendLocalizedMessage(1062382);
                                else
                                    m_From.SendGump(new PowerScrollBuyGump(m_From, m_Book, obj, price));
                            }
                        }

                        break;
                    }
            }
        }

        private class SetPricePrompt : Prompt
        {
            private PowerScrollBook m_Book;
            private object m_Object;
            private int m_Page;
            private ArrayList m_List;

            public SetPricePrompt(PowerScrollBook book, object obj, int page, ArrayList list)
            {
                m_Book = book;
                m_Object = obj;
                m_Page = page;
                m_List = list;
            }

            public override void OnResponse(Mobile from, string text)
            {
                if (!m_Book.Entries.Contains(m_Object))
                {
                    from.SendLocalizedMessage(1062382);
                    return;
                }

                int price = Utility.ToInt32(text);

                if (price < 0 || price > 250000000)
                {
                    from.SendLocalizedMessage(1062390);
                }
                else if (m_Object is PowerScrollBookEntry)
                {
                    ((PowerScrollBookEntry)m_Object).Price = price;

                    from.SendMessage("PowerScroll price set.");

                    if (from is PlayerMobile)
                        from.SendGump(new PowerScrollBookGump((PlayerMobile)from, m_Book, m_Page, m_List));
                }
            }
        }

        public PowerScrollBookGump(PlayerMobile from, PowerScrollBook book, int page, ArrayList list)
            : base(12, 24)
        {
            from.CloseGump(typeof(PowerScrollBookGump));
            from.CloseGump(typeof(PowerScrollFilterGump));

            m_From = from;
            m_Book = book;
            m_Page = page;

            if (list == null)
            {
                list = new ArrayList(book.Entries.Count);

                for (int i = 0; i < book.Entries.Count; ++i)
                {
                    object obj = book.Entries[i];

                    if (CheckFilter(obj))
                        list.Add(obj);
                }
            }

            m_List = list;

            int index = GetIndexForPage(page);
            int count = GetCountForIndex(index);

            int tableIndex = 0;

            PlayerVendor pv = book.RootParent as PlayerVendor;

            bool canDrop = book.IsChildOf(from.Backpack);
            bool canBuy = (pv != null);
            bool canPrice = (canDrop || canBuy);

            if (canBuy)
            {
                VendorItem vi = pv.GetVendorItem(book);

                canBuy = (vi != null && !vi.IsForSale);
            }

            int width = 600;

            if (!canPrice)
                width = 516;

            X = (624 - width) / 2;

            AddPage(0);

            AddBackground(10, 10, width, 439, 5054);
            AddImageTiled(18, 20, width - 17, 420, 2624);

            if (canPrice)
            {
                AddImageTiled(573, 64, 24, 352, 200);
                AddImageTiled(493, 64, 78, 352, 1416);
            }

            if (canDrop)
                AddImageTiled(24, 64, 32, 352, 1416);

            AddImageTiled(58, 64, 36, 352, 200);
            AddImageTiled(96, 64, 133, 352, 1416);
            AddImageTiled(231, 64, 80, 352, 200);
            AddImageTiled(313, 64, 100, 352, 1416);
            AddImageTiled(415, 64, 76, 352, 200);

            for (int i = index; i < (index + count) && i >= 0 && i < list.Count; ++i)
            {
                object obj = list[i];

                if (!CheckFilter(obj))
                    continue;

                AddImageTiled(24, 94 + (tableIndex * 32), canPrice ? 573 : 489, 2, 2624);

                if (obj is PowerScrollBookEntry)
                    ++tableIndex;
            }

            AddAlphaRegion(18, 20, width - 17, 420);
            AddImage(5, 5, 10460);
            AddImage(width - 15, 5, 10460);
            AddImage(5, 424, 10460);
            AddImage(width - 15, 424, 10460);

            AddHtmlLocalized(canPrice ? 266 : 224, 32, 200, 32, 1062220, LabelColor, false, false);
            
            AddLabel(137, 64, 1149, @"Skill Name");
            
            AddLabel(331, 64, 1149, @"Skill Value");
            

            AddButton(35, 32, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddHtmlLocalized(70, 32, 200, 32, 1062476, LabelColor, false, false);

            PowerScrollFilter f = (book.Filter);

            if (f.IsDefault)
                AddHtmlLocalized(canPrice ? 470 : 386, 32, 120, 32, 1062475, 16927, false, false);
            else if (from.UseOwnFilter)
                AddHtmlLocalized(canPrice ? 470 : 386, 32, 120, 32, 1062451, 16927, false, false);
            else
                AddHtmlLocalized(canPrice ? 470 : 386, 32, 120, 32, 1062230, 16927, false, false);

            AddButton(375, 416, 4017, 4018, 0, GumpButtonType.Reply, 0);
            AddHtmlLocalized(410, 416, 120, 20, 1011441, LabelColor, false, false);

            if (canDrop)
                AddHtmlLocalized(26, 64, 50, 32, 1062212, LabelColor, false, false);

            if (canPrice)
            {
                AddHtmlLocalized(516, 64, 200, 32, 1062218, LabelColor, false, false);

                if (canBuy)
                    AddHtmlLocalized(576, 64, 200, 32, 1062219, LabelColor, false, false);
                else
                    AddHtmlLocalized(576, 64, 200, 32, 1062227, LabelColor, false, false);
            }

            tableIndex = 0;

            if (page > 0)
            {
                AddButton(75, 416, 4014, 4016, 2, GumpButtonType.Reply, 0);
                AddHtmlLocalized(110, 416, 150, 20, 1011067, LabelColor, false, false);
            }

            if (GetIndexForPage(page + 1) < list.Count)
            {
                AddButton(225, 416, 4005, 4007, 3, GumpButtonType.Reply, 0);
                AddHtmlLocalized(260, 416, 150, 20, 1011066, LabelColor, false, false);
            }

            for (int i = index; i < (index + count) && i >= 0 && i < list.Count; ++i)
            {
                object obj = list[i];

                if (!CheckFilter(obj))
                    continue;

                if (obj is PowerScrollBookEntry)
                {
                    PowerScrollBookEntry e = (PowerScrollBookEntry)obj;

                    int y = 96 + (tableIndex++ * 32);

                    if (canDrop)
                        AddButton(35, y + 2, 5602, 5606, 4 + (i * 2), GumpButtonType.Reply, 0);

                    if (canDrop || (canBuy && e.Price > 0))
                    {
                        AddButton(579, y + 2, 2117, 2118, 5 + (i * 2), GumpButtonType.Reply, 0);
                        AddLabel(495, y, 1152, e.Price.ToString("N0"));
                    }

                    

                    AddLabel(103, y, 1149, from.Skills[e.Skill].Name);

                    AddLabel(350, y, 1152, e.SkillValue.ToString());
                }
            }
        }
    }
}
