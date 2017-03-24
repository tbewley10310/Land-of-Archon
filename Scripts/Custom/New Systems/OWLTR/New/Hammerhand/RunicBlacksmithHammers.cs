/*
 created by:
	Hammerhand
*/
using Server.Engines.Craft;

namespace Server.Items
{
    public class DullCopperRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public DullCopperRunicHammer()
            : base(CraftResource.DullCopper)
        {
        }
        public DullCopperRunicHammer(Serial serial) : base(serial) { }

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
    public class ShadowIronRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public ShadowIronRunicHammer()
            : base(CraftResource.ShadowIron)
        {
        }
        public ShadowIronRunicHammer(Serial serial) : base(serial) { }

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
    public class CopperRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public CopperRunicHammer()
            : base(CraftResource.Copper)
        {
        }
        public CopperRunicHammer(Serial serial) : base(serial) { }

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
    public class BronzeRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public BronzeRunicHammer()
            : base(CraftResource.Bronze)
        {
        }
        public BronzeRunicHammer(Serial serial) : base(serial) { }

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
    public class GoldRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public GoldRunicHammer()
            : base(CraftResource.Gold)
        {
        }
        public GoldRunicHammer(Serial serial) : base(serial) { }

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
    public class AgapiteRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public AgapiteRunicHammer()
            : base(CraftResource.Agapite)
        {
        }
        public AgapiteRunicHammer(Serial serial) : base(serial) { }

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
    public class VeriteRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public VeriteRunicHammer()
            : base(CraftResource.Verite)
        {
        }
        public VeriteRunicHammer(Serial serial) : base(serial) { }

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
    public class ValoriteRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public ValoriteRunicHammer()
            : base(CraftResource.Valorite)
        {
        }
        public ValoriteRunicHammer(Serial serial) : base(serial) { }

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
    public class BlazeRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public BlazeRunicHammer()
            : base(CraftResource.Blaze)
        {
        }
        public BlazeRunicHammer(Serial serial) : base(serial) { }

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
    public class IceRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public IceRunicHammer()
            : base(CraftResource.Ice)
        {
        }
        public IceRunicHammer(Serial serial) : base(serial) { }

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
    public class ToxicRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public ToxicRunicHammer()
            : base(CraftResource.Toxic)
        {
        }
        public ToxicRunicHammer(Serial serial) : base(serial) { }

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
    public class ElectrumRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public ElectrumRunicHammer()
            : base(CraftResource.Electrum)
        {
        }
        public ElectrumRunicHammer(Serial serial) : base(serial) { }

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
    public class PlatinumRunicHammer : RunicHammer
    {
        public override CraftSystem CraftSystem { get { return DefBlacksmithy.CraftSystem; } }
        [Constructable]
        public PlatinumRunicHammer()
            : base(CraftResource.Platinum)
        {
        }
        public PlatinumRunicHammer(Serial serial) : base(serial) { }

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