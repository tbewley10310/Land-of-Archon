using System;

namespace Server.Items
{
    public class RitualTableAddon : BaseAddon
    {
        [Constructable]
        public RitualTableAddon()
        {
            this.AddComponent(new AddonComponent(0x4982), 0, 0, 0);
            this.AddComponent(new AddonComponent(0x4983), 0, -1, 0);
            this.AddComponent(new AddonComponent(0x4984), -1, 0, 0);
            this.AddComponent(new AddonComponent(0x4985), -1, -1, 0);
        }

        public RitualTableAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed
        {
            get
            {
                return new RitualTableDeed();
            }
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
    }

    public class RitualTableDeed : BaseAddonDeed
    {
        [Constructable]
        public RitualTableDeed()
        {
            this.Name = "Ritual Table";
        }

        public RitualTableDeed(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddon Addon
        {
            get
            {
                return new RitualTableAddon();
            }
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
    }
}