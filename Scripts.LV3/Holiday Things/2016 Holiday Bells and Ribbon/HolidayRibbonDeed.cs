using System;
using Server.Gumps;
using Server.Multis;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
    public class HolidayRibbonAddon : Item, IDyable, IAddon
    {
        [Constructable]
        public HolidayRibbonAddon()
            : this(Utility.RandomDyedHue())
        {
        }

        [Constructable]
        public HolidayRibbonAddon(int hue)
            : base(0x9DC1)
        {
            this.Hue = hue;
            this.Movable = false;
        }

        public HolidayRibbonAddon(Serial serial)
            : base(serial)
        {
        }

        public Item Deed
        {
            get
            {
                return new HolidayRibbonDeed(this.Hue);
            }
        }
        public bool CouldFit(IPoint3D p, Map map)
        {
            if (!map.CanFit(p.X, p.Y, p.Z, this.ItemData.Height))
                return false;

            if (this.ItemID == 0x9DC1)
                return BaseAddon.IsWall(p.X, p.Y - 1, p.Z, map); // North wall
            else
                return BaseAddon.IsWall(p.X - 1, p.Y, p.Z, map); // West wall
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

            Timer.DelayCall(TimeSpan.Zero, new TimerCallback(FixMovingCrate));
        }

        public override void OnDoubleClick(Mobile from)
        {
            BaseHouse house = BaseHouse.FindHouseAt(this);

            if (house != null && house.IsCoOwner(from))
            {
                if (from.InRange(this.GetWorldLocation(), 3))
                {
                    from.CloseGump(typeof(HolidayRibbonAddonGump));
                    from.SendGump(new HolidayRibbonAddonGump(from, this));
                }
                else
                {
                    from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
                }
            }
        }

        public virtual bool Dye(Mobile from, DyeTub sender)
        {
            if (this.Deleted)
                return false;

            BaseHouse house = BaseHouse.FindHouseAt(this);

            if (house != null && house.IsCoOwner(from))
            {
                if (from.InRange(this.GetWorldLocation(), 1))
                {
                    this.Hue = sender.DyedHue;
                    return true;
                }
                else
                {
                    from.SendLocalizedMessage(500295); // You are too far away to do that.
                    return false;
                }
            }
            else 
            {
                return false;
            }
        }

        private void FixMovingCrate()
        {
            if (this.Deleted)
                return;

            if (this.Movable || this.IsLockedDown)
            {
                Item deed = this.Deed;

                if (this.Parent is Item)
                {
                    ((Item)this.Parent).AddItem(deed);
                    deed.Location = this.Location;
                }
                else
                {
                    deed.MoveToWorld(this.Location, this.Map);
                }

                this.Delete();
            }
        }

        private class HolidayRibbonAddonGump : Gump
        {
            private readonly Mobile m_From;
            private readonly HolidayRibbonAddon m_Addon;
            public HolidayRibbonAddonGump(Mobile from, HolidayRibbonAddon addon)
                : base(150, 50)
            {
                this.m_From = from;
                this.m_Addon = addon;

                this.AddPage(0);

                this.AddBackground(0, 0, 220, 170, 0x13BE);
                this.AddBackground(10, 10, 200, 150, 0xBB8);
                this.AddHtmlLocalized(20, 30, 180, 60, 1062839, false, false); // Do you wish to re-deed this decoration?
                this.AddHtmlLocalized(55, 100, 160, 25, 1011011, false, false); // CONTINUE
                this.AddButton(20, 100, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0);
                this.AddHtmlLocalized(55, 125, 160, 25, 1011012, false, false); // CANCEL
                this.AddButton(20, 125, 0xFA5, 0xFA7, 0, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (this.m_Addon.Deleted)
                    return;

                if (info.ButtonID == 1)
                {
                    if (this.m_From.InRange(this.m_Addon.GetWorldLocation(), 3))
                    {
                        this.m_From.AddToBackpack(this.m_Addon.Deed);
                        this.m_Addon.Delete();
                    }
                    else
                    {
                        this.m_From.SendLocalizedMessage(500295); // You are too far away to do that.
                    }
                }
            }
        }
    }

    [Flipable(0x14F0, 0x14EF)]
    public class HolidayRibbonDeed : Item
    {
        [Constructable]
        public HolidayRibbonDeed()
            : this(0)
        {
        }

        [Constructable]
        public HolidayRibbonDeed(int hue)
            : base(0x14F0)
        {
            this.Hue = hue;
            this.Weight = 1.0;
            this.LootType = LootType.Blessed;
        }

        public HolidayRibbonDeed(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1124409;
            }
        }// Holiday Ribbon
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
            if (this.IsChildOf(from.Backpack))
            {
                BaseHouse house = BaseHouse.FindHouseAt(from);

                if (house != null && house.IsCoOwner(from))
                {
                    from.SendLocalizedMessage(1062838); // Where would you like to place this decoration?
                    from.BeginTarget(-1, true, TargetFlags.None, new TargetStateCallback(Placement_OnTarget), null);
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

        public void Placement_OnTarget(Mobile from, object targeted, object state)
        {
            IPoint3D p = targeted as IPoint3D;

            if (p == null)
                return;

            Point3D loc = new Point3D(p);

            BaseHouse house = BaseHouse.FindHouseAt(loc, from.Map, 16);

            if (house != null && house.IsCoOwner(from))
            {
                bool northWall = BaseAddon.IsWall(loc.X, loc.Y - 1, loc.Z, from.Map);
                bool westWall = BaseAddon.IsWall(loc.X - 1, loc.Y, loc.Z, from.Map);

                if (northWall && westWall)
                    from.SendGump(new HolidayRibbonDeedGump(from, loc, this));
                else
                    this.PlaceAddon(from, loc, northWall, westWall);
            }
            else
            {
                from.SendLocalizedMessage(1042036); // That location is not in your house.
            }
        }

        private void PlaceAddon(Mobile from, Point3D loc, bool northWall, bool westWall)
        {
            if (this.Deleted)
                return;

            BaseHouse house = BaseHouse.FindHouseAt(loc, from.Map, 16);

            if (house == null || !house.IsCoOwner(from))
            {
                from.SendLocalizedMessage(1042036); // That location is not in your house.
                return;
            }

            int itemID = 0;

            if (northWall)
                itemID = 0x9DC1;
            else if (westWall)
                itemID = 0x9DC2;
            else
                from.SendLocalizedMessage(1049781); // This decoration must be placed next to a wall.

            if (itemID > 0)
            {
                Item addon = new HolidayRibbonAddon(this.Hue);

                addon.ItemID = itemID;
                addon.MoveToWorld(loc, from.Map);

                house.Addons.Add(addon);
                this.Delete();
            }
        }

        private class HolidayRibbonDeedGump : Gump
        {
            private readonly Mobile m_From;
            private readonly Point3D m_Loc;
            private readonly HolidayRibbonDeed m_Deed;
            public HolidayRibbonDeedGump(Mobile from, Point3D loc, HolidayRibbonDeed deed)
                : base(150, 50)
            {
                this.m_From = from;
                this.m_Loc = loc;
                this.m_Deed = deed;

                this.AddBackground(0, 0, 300, 150, 0xA28);

                this.AddPage(0);

                this.AddItem(90, 30, 0x2375);
                this.AddItem(180, 30, 0x2374);
                this.AddButton(50, 35, 0x868, 0x869, 1, GumpButtonType.Reply, 0);
                this.AddButton(145, 35, 0x868, 0x869, 2, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (this.m_Deed.Deleted)
                    return;

                switch( info.ButtonID )
                {
                    case 1:
                        this.m_Deed.PlaceAddon(this.m_From, this.m_Loc, false, true);
                        break;
                    case 2:
                        this.m_Deed.PlaceAddon(this.m_From, this.m_Loc, true, false);
                        break;
                }
            }
        }
    }
}