using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
    public class PowerScrollBuyGump : Gump
    {
        private PlayerMobile m_From;
        private PowerScrollBook m_Book;
        private object m_Object;
        private int m_Price;

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 2)
            {
                PlayerVendor pv = m_Book.RootParent as PlayerVendor;

                if (m_Book.Entries.Contains(m_Object) && pv != null)
                {
                    int price = 0;

                    VendorItem vi = pv.GetVendorItem(m_Book);

                    if (vi != null && !vi.IsForSale)
                    {
                        if (m_Object is PowerScrollBookEntry)
                            price = ((PowerScrollBookEntry)m_Object).Price;
                    }

                    if (price != m_Price)
                    {
                        pv.SayTo(m_From, "The price has been been changed. If you like, you may offer to purchase the item again.");
                    }
                    else if (price == 0)
                    {
                        pv.SayTo(m_From, 1062382);
                    }
                    else
                    {
                        Item item = null;

                        if (m_Object is PowerScrollBookEntry)
                            item = ((PowerScrollBookEntry)m_Object).Reconstruct();

                        if (item == null)
                        {
                            m_From.SendMessage("Internal error. The power scroll could not be reconstructed.");
                        }
                        else
                        {
                            pv.Say(m_From.Name);

                            Container pack = m_From.Backpack;

                            if ((pack != null && pack.ConsumeTotal(typeof(Gold), price)) || Banker.Withdraw(m_From, price))
                            {
                                m_Book.Entries.Remove(m_Object);
                                m_Book.InvalidateProperties();

                                pv.HoldGold += price;

                                if (m_From.AddToBackpack(item))
                                    m_From.SendMessage("The power scroll has been placed in your backpack.");
                                else
                                    pv.SayTo(m_From, 503204);

                                if (m_Book.Entries.Count > 0)
                                    m_From.SendGump(new PowerScrollBookGump(m_From, m_Book));
                                else
                                    m_From.SendLocalizedMessage(1062381);
                            }
                            else
                            {
                                pv.SayTo(m_From, 503205);
                                item.Delete();
                            }
                        }
                    }
                }
                else
                {
                    if (pv == null)
                        m_From.SendLocalizedMessage(1062382);
                    else
                        pv.SayTo(m_From, 1062382);
                }
            }
            else
            {
                m_From.SendLocalizedMessage(503207);
            }
        }

        public PowerScrollBuyGump(PlayerMobile from, PowerScrollBook book, object obj, int price)
            : base(100, 200)
        {
            m_From = from;
            m_Book = book;
            m_Object = obj;
            m_Price = price;

            AddPage(0);

            AddBackground(100, 10, 300, 150, 5054);

            AddHtmlLocalized(125, 20, 250, 24, 1019070, false, false);
            AddLabel(125, 45, 0, "a power scroll");
            

            AddHtmlLocalized(125, 70, 250, 24, 1019071, false, false);
            AddLabel(125, 95, 0, price.ToString("N0"));

            AddButton(250, 130, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddHtmlLocalized(282, 130, 100, 24, 1011012, false, false);

            AddButton(120, 130, 4005, 4007, 2, GumpButtonType.Reply, 0);
            AddHtmlLocalized(152, 130, 100, 24, 1011036, false, false);
        }
    }
}
