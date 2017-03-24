/*
 created by:
	Hammerhand
*/
using Server.Engines.Craft;

namespace Server.Items
{
    public class SpinedRunicSewingKit : RunicSewingKit
    {
        public override CraftSystem CraftSystem { get { return DefTailoring.CraftSystem; } }
        [Constructable]
        public SpinedRunicSewingKit()
            : base(CraftResource.SpinedLeather)
        {
            Name = "Spined Runic Sewing Kit";
        }
        public SpinedRunicSewingKit(Serial serial) : base(serial) { }

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
    public class HornedRunicSewingKit : RunicSewingKit
    {
        public override CraftSystem CraftSystem { get { return DefTailoring.CraftSystem; } }
        [Constructable]
        public HornedRunicSewingKit()
            : base(CraftResource.HornedLeather)
        {
            Name = "Horned Runic Sewing Kit";
        }
        public HornedRunicSewingKit(Serial serial) : base(serial) { }

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
    public class BarbedRunicSewingKit : RunicSewingKit
    {
        public override CraftSystem CraftSystem { get { return DefTailoring.CraftSystem; } }
        [Constructable]
        public BarbedRunicSewingKit()
            : base(CraftResource.BarbedLeather)
        {
            Name = "Barbed Runic Sewing Kit";
        }
        public BarbedRunicSewingKit(Serial serial) : base(serial) { }

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
    public class PolarRunicSewingKit : RunicSewingKit
    {
        public override CraftSystem CraftSystem { get { return DefTailoring.CraftSystem; } }
        [Constructable]
        public PolarRunicSewingKit()
            : base(CraftResource.PolarLeather)
        {
            Name = "Polar Runic Sewing Kit";
        }
        public PolarRunicSewingKit(Serial serial) : base(serial) { }

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
    public class SyntheticRunicSewingKit : RunicSewingKit
    {
        public override CraftSystem CraftSystem { get { return DefTailoring.CraftSystem; } }
        [Constructable]
        public SyntheticRunicSewingKit()
            : base(CraftResource.SyntheticLeather)
        {
            Name = "Synthetic Runic Sewing Kit";
        }
        public SyntheticRunicSewingKit(Serial serial) : base(serial) { }

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
    public class BlazeRunicSewingKit : RunicSewingKit
    {
        public override CraftSystem CraftSystem { get { return DefTailoring.CraftSystem; } }
        [Constructable]
        public BlazeRunicSewingKit()
            : base(CraftResource.BlazeLeather)
        {
            Name = "Blaze Runic Sewing Kit";
        }
        public BlazeRunicSewingKit(Serial serial) : base(serial) { }

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
    public class DaemonicRunicSewingKit : RunicSewingKit
    {
        public override CraftSystem CraftSystem { get { return DefTailoring.CraftSystem; } }
        [Constructable]
        public DaemonicRunicSewingKit()
            : base(CraftResource.DaemonicLeather)
        {
            Name = "Daemonic Runic Sewing Kit";
        }
        public DaemonicRunicSewingKit(Serial serial) : base(serial) { }

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
    public class ShadowRunicSewingKit : RunicSewingKit
    {
        public override CraftSystem CraftSystem { get { return DefTailoring.CraftSystem; } }
        [Constructable]
        public ShadowRunicSewingKit()
            : base(CraftResource.ShadowLeather)
        {
            Name = "Shadow Runic Sewing Kit";
        }
        public ShadowRunicSewingKit(Serial serial) : base(serial) { }

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
    public class FrostRunicSewingKit : RunicSewingKit
    {
        public override CraftSystem CraftSystem { get { return DefTailoring.CraftSystem; } }
        [Constructable]
        public FrostRunicSewingKit()
            : base(CraftResource.FrostLeather)
        {
            Name = "Frost Runic Sewing Kit";
        }
        public FrostRunicSewingKit(Serial serial) : base(serial) { }

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
    public class EtherealRunicSewingKit : RunicSewingKit
    {
        public override CraftSystem CraftSystem { get { return DefTailoring.CraftSystem; } }
        [Constructable]
        public EtherealRunicSewingKit()
            : base(CraftResource.EtherealLeather)
        {
        }
        public EtherealRunicSewingKit(Serial serial) : base(serial) { }

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