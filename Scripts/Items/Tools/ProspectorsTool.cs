using System;
using Server;
using Server.Targeting;
using Server.Engines.Harvest;
using daat99;

namespace Server.Items
{
    public class ProspectorsTool : BaseBashing, IUsesRemaining
    {
        private int m_UsesRemaining;
        [Constructable]
        public ProspectorsTool()
            : base(0xFB4)
        {
            this.Weight = 9.0;
            this.UsesRemaining = 50;
        }

        public ProspectorsTool(Serial serial)
            : base(serial)
        {
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int UsesRemaining
        {
            get
            {
                return this.m_UsesRemaining;
            }
            set
            {
                this.m_UsesRemaining = value;
                this.InvalidateProperties();
            }
        }
        public bool ShowUsesRemaining
        {
            get
            {
                return true;
            }
            set
            {
            }
        }
        public override int LabelNumber
        {
            get
            {
                return 1049065;
            }
        }// prospector's tool
        public override WeaponAbility PrimaryAbility
        {
            get
            {
                return WeaponAbility.CrushingBlow;
            }
        }
        public override WeaponAbility SecondaryAbility
        {
            get
            {
                return WeaponAbility.ShadowStrike;
            }
        }
        public override int AosStrengthReq
        {
            get
            {
                return 40;
            }
        }
        public override int AosMinDamage
        {
            get
            {
                return 13;
            }
        }
        public override int AosMaxDamage
        {
            get
            {
                return 15;
            }
        }
        public override int AosSpeed
        {
            get
            {
                return 33;
            }
        }
        public override int OldStrengthReq
        {
            get
            {
                return 10;
            }
        }
        public override int OldMinDamage
        {
            get
            {
                return 6;
            }
        }
        public override int OldMaxDamage
        {
            get
            {
                return 8;
            }
        }
        public override int OldSpeed
        {
            get
            {
                return 33;
            }
        }
        public override void OnDoubleClick(Mobile from)
        {
            if (this.IsChildOf(from.Backpack) || this.Parent == from)
                from.Target = new InternalTarget(this);
            else
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
        }

        public void Prospect(Mobile from, object toProspect)
        {
            if (!this.IsChildOf(from.Backpack) && this.Parent != from)
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                return;
            }

            HarvestSystem system = Mining.System;

            int tileID;
            Map map;
            Point3D loc;

            if (!system.GetHarvestDetails(from, this, toProspect, out tileID, out map, out loc))
            {
                from.SendLocalizedMessage(1049048); // You cannot use your prospector tool on that.
                return;
            }

            HarvestDefinition def = system.GetDefinition(tileID);

            if (def == null || def.Veins.Length <= 1)
            {
                from.SendLocalizedMessage(1049048); // You cannot use your prospector tool on that.
                return;
            }

            HarvestBank bank = def.GetBank(map, loc.X, loc.Y);

            if (bank == null)
            {
                from.SendLocalizedMessage(1049048); // You cannot use your prospector tool on that.
                return;
            }

            HarvestVein vein = bank.Vein, defaultVein = bank.DefaultVein;

            if (vein == null || defaultVein == null)
            {
                from.SendLocalizedMessage(1049048); // You cannot use your prospector tool on that.
                return;
            }
            //daat99 OWLTR start - prospected sticks
            else if (vein != defaultVein || (OWLTROptionsManager.IsEnabled(OWLTROptionsManager.OPTIONS_ENUM.DAAT99_MINING) && (bank.Vein).IsProspected))
            //daat99 OWLTR end - prospected sticks
            {
                from.SendLocalizedMessage(1049049); // That ore looks to be prospected already.
                return;
            }

            int veinIndex = Array.IndexOf(def.Veins, vein);

            if (veinIndex < 0)
            {
                from.SendLocalizedMessage(1049048); // You cannot use your prospector tool on that.
            }
            //daat99 OWLTR start - prospecting
            else if (!OWLTROptionsManager.IsEnabled(OWLTROptionsManager.OPTIONS_ENUM.DAAT99_MINING))
            {
                if (veinIndex >= (def.Veins.Length - 1))
                {
                    from.SendMessage("You cannot improve Platinum ore through prospecting."); // You cannot improve valorite ore through prospecting.
                }
                else
                {
                    bank.Vein = def.Veins[veinIndex + 1];
                    //from.SendLocalizedMessage( 1049050 + veinIndex );
                    switch (veinIndex)
                    {
                        case 0: from.SendLocalizedMessage(1049050); break;//Dull Copper
                        case 1: from.SendLocalizedMessage(1049051); break;//Shadow Iron
                        case 2: from.SendLocalizedMessage(1049052); break;//Copper
                        case 3: from.SendLocalizedMessage(1049053); break;//Bronze
                        case 4: from.SendLocalizedMessage(1049054); break;//Gold
                        case 5: from.SendLocalizedMessage(1049055); break;//Agapite
                        case 6: from.SendLocalizedMessage(1049056); break;//Verite
                        case 7: from.SendLocalizedMessage(1049057); break;//Valorite
                        case 8: from.SendMessage("You sift through the ore and find blaze ore can be mined there"); break;
                        case 9: from.SendMessage("You sift through the ore and find ice ore can be mined there"); break;
                        case 10: from.SendMessage("You sift through the ore and find toxic ore can be mined there"); break;
                        case 11: from.SendMessage("You sift through the ore and find electrum ore can be mined there"); break;
                        case 12: from.SendMessage("You sift through the ore and find platinum ore can be mined there"); break;
                    }

                    --UsesRemaining;

                    if (UsesRemaining <= 0)
                    {
                        from.SendLocalizedMessage(1049062); // You have used up your prospector's tool.
                        Delete();
                    }
                }
            }
            else
            {
                (bank.Vein).IsProspected = true;
                from.SendMessage("You sift through the ore increasing your chances to find better ores");
                //daat99 OWLTR end - prospecting

                --this.UsesRemaining;

                if (this.UsesRemaining <= 0)
                {
                    from.SendLocalizedMessage(1049062); // You have used up your prospector's tool.
                    this.Delete();
                }
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
            writer.Write((int)this.m_UsesRemaining);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch ( version )
            {
                case 1:
                    {
                        this.m_UsesRemaining = reader.ReadInt();
                        break;
                    }
                case 0:
                    {
                        this.m_UsesRemaining = 50;
                        break;
                    }
            }
        }

        private class InternalTarget : Target
        {
            private readonly ProspectorsTool m_Tool;
            public InternalTarget(ProspectorsTool tool)
                : base(2, true, TargetFlags.None)
            {
                this.m_Tool = tool;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                this.m_Tool.Prospect(from, targeted);
            }
        }
    }
}