/*
 created by:
	Hammerhand
*/
using Server.Engines.Craft;

namespace Server.Items
{
    public class DullCopperRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public DullCopperRunicTinkerTools()
            : base(CraftResource.DullCopper)
        {
            Name = "DullCopper Runic Tinker's Tools";
        }
        public DullCopperRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class ShadowIronRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public ShadowIronRunicTinkerTools()
            : base(CraftResource.ShadowIron)
        {
            Name = "ShadowIron Runic Tinker's Tools";
        }
        public ShadowIronRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class CopperRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public CopperRunicTinkerTools()
            : base(CraftResource.Copper)
        {
            Name = "Copper Runic Tinker's Tools";
        }
        public CopperRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class BronzeRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public BronzeRunicTinkerTools()
            : base(CraftResource.Bronze)
        {
            Name = "Bronze Runic Tinker's Tools";
        }
        public BronzeRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class GoldRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public GoldRunicTinkerTools()
            : base(CraftResource.Gold)
        {
            Name = "Gold Runic Tinker's Tools";
        }
        public GoldRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class AgapiteRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public AgapiteRunicTinkerTools()
            : base(CraftResource.Agapite)
        {
            Name = "Agapite Runic Tinker's Tools";
        }
        public AgapiteRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class VeriteRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public VeriteRunicTinkerTools()
            : base(CraftResource.Verite)
        {
            Name = "Verite Runic Tinker's Tools";
        }
        public VeriteRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class ValoriteRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public ValoriteRunicTinkerTools()
            : base(CraftResource.Valorite)
        {
            Name = "Valorite Runic Tinker's Tools";
        }
        public ValoriteRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class BlazeRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public BlazeRunicTinkerTools()
            : base(CraftResource.Blaze)
        {
            Name = "Blaze Runic Tinker's Tools";
        }
        public BlazeRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class IceRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public IceRunicTinkerTools()
            : base(CraftResource.Ice)
        {
            Name = "Ice Runic Tinker's Tools";
        }
        public IceRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class ToxicRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public ToxicRunicTinkerTools()
            : base(CraftResource.Toxic)
        {
            Name = "Toxic Runic Tinker's Tools";
        }
        public ToxicRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class ElectrumRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public ElectrumRunicTinkerTools()
            : base(CraftResource.Electrum)
        {
            Name = "Electrum Runic Tinker's Tools";
        }
        public ElectrumRunicTinkerTools(Serial serial) : base(serial) { }

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
    public class PlatinumRunicTinkerTools : RunicTinkerTools
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }
        [Constructable]
        public PlatinumRunicTinkerTools()
            : base(CraftResource.Platinum)
        {
            Name = "Platinum Runic Tinker's Tools";
        }
        public PlatinumRunicTinkerTools(Serial serial) : base(serial) { }

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