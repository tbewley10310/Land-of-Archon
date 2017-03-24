/*
 created by:
	Hammerhand
*/
using Server.Engines.Craft;

namespace Server.Items
{
    public class OakRunicFletcherTools : RunicFletcherTools
    {
        public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
        [Constructable]
        public OakRunicFletcherTools()
            : base(CraftResource.OakWood, 50)
        {
            Name = "Oak Runic Fletchers Tools";
        }
        public OakRunicFletcherTools(Serial serial) : base(serial) { }

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
    public class AshRunicFletcherTools : RunicFletcherTools
    {
        public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
        [Constructable]
        public AshRunicFletcherTools()
            : base(CraftResource.AshWood, 50)
        {
            Name = "Ash Runic Fletchers Tools";
        }
        public AshRunicFletcherTools(Serial serial) : base(serial) { }

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
    public class YewRunicFletcherTools : RunicFletcherTools
    {
        public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
        [Constructable]
        public YewRunicFletcherTools()
            : base(CraftResource.YewWood, 50)
        {
            Name = "Yew Runic Fletchers Tools";
        }
        public YewRunicFletcherTools(Serial serial) : base(serial) { }

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
    public class HeartwoodRunicFletcherTools : RunicFletcherTools
    {
        public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
        [Constructable]
        public HeartwoodRunicFletcherTools()
            : base(CraftResource.Heartwood, 50)
        {
            Name = "Heartwood Runic Fletchers Tools";
        }
        public HeartwoodRunicFletcherTools(Serial serial) : base(serial) { }

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
    public class BloodwoodRunicFletcherTools : RunicFletcherTools
    {
        public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
        [Constructable]
        public BloodwoodRunicFletcherTools()
            : base(CraftResource.Bloodwood, 50)
        {
            Name = "Bloodwood Runic Fletchers Tools";
        }
        public BloodwoodRunicFletcherTools(Serial serial) : base(serial) { }

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
    public class FrostwoodRunicFletcherTools : RunicFletcherTools
    {
        public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
        [Constructable]
        public FrostwoodRunicFletcherTools()
            : base(CraftResource.Frostwood, 50)
        {
            Name = "Frostwood Runic Fletchers Tools";
        }
        public FrostwoodRunicFletcherTools(Serial serial) : base(serial) { }

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
    public class EbonyRunicFletcherTools : RunicFletcherTools
    {
        public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
        [Constructable]
        public EbonyRunicFletcherTools()
            : base(CraftResource.Ebony, 50)
        {
            Name = "Ebony Runic Fletchers Tools";
        }
        public EbonyRunicFletcherTools(Serial serial) : base(serial) { }

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
    public class BambooRunicFletcherTools : RunicFletcherTools
    {
        public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
        [Constructable]
        public BambooRunicFletcherTools()
            : base(CraftResource.Bamboo, 50)
        {
            Name = "Bamboo Runic Fletchers Tools";
        }
        public BambooRunicFletcherTools(Serial serial) : base(serial) { }

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
    public class PurpleHeartRunicFletcherTools : RunicFletcherTools
    {
        public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
        [Constructable]
        public PurpleHeartRunicFletcherTools()
            : base(CraftResource.PurpleHeart, 50)
        {
            Name = "PurpleHeart Runic Fletchers Tools";
        }
        public PurpleHeartRunicFletcherTools(Serial serial) : base(serial) { }

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
    public class RedwoodRunicFletcherTools : RunicFletcherTools
    {
        public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
        [Constructable]
        public RedwoodRunicFletcherTools()
            : base(CraftResource.Redwood, 50)
        {
            Name = "Redwood Runic Fletchers Tools";
        }
        public RedwoodRunicFletcherTools(Serial serial) : base(serial) { }

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
    public class PetrifiedRunicFletcherTools : RunicFletcherTools
    {
        public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
        [Constructable]
        public PetrifiedRunicFletcherTools()
            : base(CraftResource.Petrified, 50)
        {
            Name = "Petrified Runic Fletchers Tools";
        }
        public PetrifiedRunicFletcherTools(Serial serial) : base(serial) { }

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