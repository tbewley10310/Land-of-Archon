using System;
using Server;
using Server.Mobiles; //daat99 OWLTR
using Server.Gumps;
using Server.Network;

namespace Server.Engines.BulkOrders
{
    public class SmallBODGump : Gump
    {
        private readonly SmallBOD m_Deed;
        private readonly Mobile m_From;
        public SmallBODGump(Mobile from, SmallBOD deed)
            : base(25, 25)
        {
            this.m_From = from;
            this.m_Deed = deed;

            this.m_From.CloseGump(typeof(LargeBODGump));
            this.m_From.CloseGump(typeof(SmallBODGump));

            this.AddPage(0);

            this.AddBackground(50, 10, 455, 260, 5054);
            this.AddImageTiled(58, 20, 438, 241, 2624);
            this.AddAlphaRegion(58, 20, 438, 241);

            this.AddImage(45, 5, 10460);
            this.AddImage(480, 5, 10460);
            this.AddImage(45, 245, 10460);
            this.AddImage(480, 245, 10460);

            this.AddHtmlLocalized(225, 25, 120, 20, 1045133, 0x7FFF, false, false); // A bulk order

            this.AddHtmlLocalized(75, 48, 250, 20, 1045138, 0x7FFF, false, false); // Amount to make:
            this.AddLabel(275, 48, 1152, deed.AmountMax.ToString());

            this.AddHtmlLocalized(275, 76, 200, 20, 1045153, 0x7FFF, false, false); // Amount finished:
            this.AddHtmlLocalized(75, 72, 120, 20, 1045136, 0x7FFF, false, false); // Item requested:

            this.AddItem(410, 72, deed.Graphic);

            this.AddHtmlLocalized(75, 96, 210, 20, deed.Number, 0x7FFF, false, false);
            this.AddLabel(275, 96, 0x480, deed.AmountCur.ToString());

            if (deed.RequireExceptional || deed.Material != BulkMaterialType.None)
                this.AddHtmlLocalized(75, 120, 200, 20, 1045140, 0x7FFF, false, false); // Special requirements to meet:

            if (deed.RequireExceptional)
                this.AddHtmlLocalized(75, 144, 300, 20, 1045141, 0x7FFF, false, false); // All items must be exceptional.

            if (deed.Material != BulkMaterialType.None)
                //daat99 OWLTR start - custom resources
                AddHtml(75, deed.RequireExceptional ? 168 : 144, 400, 25, "<basefont color=#FF0000>All items must be crafted with " + LargeBODGump.GetMaterialStringFor(deed.Material), false, false);
            //daat99 OWLTR end - custom resources

            this.AddButton(125, 192, 4005, 4007, 2, GumpButtonType.Reply, 0);
            this.AddHtmlLocalized(160, 192, 300, 20, 1045154, 0x7FFF, false, false); // Combine this deed with the item requested.

            this.AddButton(125, 216, 4005, 4007, 1, GumpButtonType.Reply, 0);
            this.AddHtmlLocalized(160, 216, 120, 20, 1011441, 0x7FFF, false, false); // EXIT
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (this.m_Deed.Deleted || !this.m_Deed.IsChildOf(this.m_From.Backpack))
                return;

            if (info.ButtonID == 2) // Combine
            {
                this.m_From.SendGump(new SmallBODGump(this.m_From, this.m_Deed));
                this.m_Deed.BeginCombine(this.m_From);
            }
            //daat99 OWLTR start - bods
            else if (info.ButtonID >= 3)
            {
                bool IsFound = false;
                IPooledEnumerable eable = m_From.GetMobilesInRange(6);
                foreach (Mobile vendor in eable)
                {
                    switch (info.ButtonID)
                    {
                        case 3: IsFound = (vendor is Blacksmith || vendor is Weaponsmith || vendor is Armorer); break;
                        case 4: IsFound = (vendor is Tailor || vendor is Weaver); break;
                        case 5: IsFound = (vendor is Carpenter); break;
                        case 6: IsFound = (vendor is Bowyer); break;
                    }
                    if (IsFound == true)
                        break;
                }
                if (IsFound == false)
                    switch (info.ButtonID)
                    {
                        case 3: m_From.SendMessage("You must be near a Blacksmith, Weaponsmith or Armorer to claim that."); break;
                        case 4: m_From.SendMessage("You must be near a Tailor or Weaver to claim that."); break;
                        case 5: m_From.SendMessage("You must be near a Carpenter to claim that."); break;
                        case 6: m_From.SendMessage("You must be near a Bowyer to claim that."); break;
                    }
                else
                    daat99.daat99.ClaimBods(m_From, m_Deed);
            }
            //daat99 OWLTR end - bods
        }
        //daat99 OWLTR start - REMOVED - make sure nobody calls this!
        /*
        public static int GetMaterialNumberFor( BulkMaterialType material )
        {
            if ( material >= BulkMaterialType.DullCopper && material <= BulkMaterialType.Valorite )
                return 1045142 + (int)(material - BulkMaterialType.DullCopper);
            else if ( material >= BulkMaterialType.Spined && material <= BulkMaterialType.Barbed )
                return 1049348 + (int)(material - BulkMaterialType.Spined);

            return 0;
        }*/
        //daat99 OWLTR end - REMOVED - make sure nobody calls this!
    }
}