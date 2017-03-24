/*
 created by:
	Hammerhand
*/
using Server.Engines.Craft;

namespace Server.Items
{
    public class OakRunicDovetailSaw : RunicDovetailSaw
    {
        public override CraftSystem CraftSystem { get { return DefCarpentry.CraftSystem; } }
        [Constructable]
        public OakRunicDovetailSaw()
            : base(CraftResource.OakWood, 50)
        {
            Name = "Oak Runic Dovetail Saw";
        }
        public OakRunicDovetailSaw(Serial serial) : base(serial) { }

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
    public class AshRunicDovetailSaw : RunicDovetailSaw
    {
        public override CraftSystem CraftSystem { get { return DefCarpentry.CraftSystem; } }
        [Constructable]
        public AshRunicDovetailSaw()
            : base(CraftResource.AshWood, 50)
        {
            Name = "Ash Runic Dovetail Saw";
        }
        public AshRunicDovetailSaw(Serial serial) : base(serial) { }

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
    public class YewRunicDovetailSaw : RunicDovetailSaw
    {
        public override CraftSystem CraftSystem { get { return DefCarpentry.CraftSystem; } }
        [Constructable]
        public YewRunicDovetailSaw()
            : base(CraftResource.YewWood, 50)
        {
            Name = "Yew Runic Dovetail Saw";
        }
        public YewRunicDovetailSaw(Serial serial) : base(serial) { }

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
    public class HeartwoodRunicDovetailSaw : RunicDovetailSaw
    {
        public override CraftSystem CraftSystem { get { return DefCarpentry.CraftSystem; } }
        [Constructable]
        public HeartwoodRunicDovetailSaw()
            : base(CraftResource.Heartwood, 50)
        {
            Name = "Heartwood Runic Dovetail Saw";
        }
        public HeartwoodRunicDovetailSaw(Serial serial) : base(serial) { }

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
    public class BloodwoodRunicDovetailSaw : RunicDovetailSaw
    {
        public override CraftSystem CraftSystem { get { return DefCarpentry.CraftSystem; } }
        [Constructable]
        public BloodwoodRunicDovetailSaw()
            : base(CraftResource.Bloodwood, 50)
        {
            Name = "Bloodwood Runic Dovetail Saw";
        }
        public BloodwoodRunicDovetailSaw(Serial serial) : base(serial) { }

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
    public class FrostwoodRunicDovetailSaw : RunicDovetailSaw
    {
        public override CraftSystem CraftSystem { get { return DefCarpentry.CraftSystem; } }
        [Constructable]
        public FrostwoodRunicDovetailSaw()
            : base(CraftResource.Frostwood, 50)
        {
            Name = "Frostwood Runic Dovetail Saw";
        }
        public FrostwoodRunicDovetailSaw(Serial serial) : base(serial) { }

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
    public class EbonyRunicDovetailSaw : RunicDovetailSaw
    {
        public override CraftSystem CraftSystem { get { return DefCarpentry.CraftSystem; } }
        [Constructable]
        public EbonyRunicDovetailSaw()
            : base(CraftResource.Ebony, 50)
        {
            Name = "Ebony Runic Dovetail Saw";
        }
        public EbonyRunicDovetailSaw(Serial serial) : base(serial) { }

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
    public class BambooRunicDovetailSaw : RunicDovetailSaw
    {
        public override CraftSystem CraftSystem { get { return DefCarpentry.CraftSystem; } }
        [Constructable]
        public BambooRunicDovetailSaw()
            : base(CraftResource.Bamboo, 50)
        {
            Name = "Bamboo Runic Dovetail Saw";
        }
        public BambooRunicDovetailSaw(Serial serial) : base(serial) { }

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
    public class PurpleHeartRunicDovetailSaw : RunicDovetailSaw
    {
        public override CraftSystem CraftSystem { get { return DefCarpentry.CraftSystem; } }
        [Constructable]
        public PurpleHeartRunicDovetailSaw()
            : base(CraftResource.PurpleHeart, 50)
        {
            Name = "PurpleHeart Runic Dovetail Saw";
        }
        public PurpleHeartRunicDovetailSaw(Serial serial) : base(serial) { }

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
    public class RedwoodRunicDovetailSaw : RunicDovetailSaw
    {
        public override CraftSystem CraftSystem { get { return DefCarpentry.CraftSystem; } }
        [Constructable]
        public RedwoodRunicDovetailSaw()
            : base(CraftResource.Redwood, 50)
        {
            Name = "Redwood Runic Dovetail Saw";
        }
        public RedwoodRunicDovetailSaw(Serial serial) : base(serial) { }

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
    public class PetrifiedRunicDovetailSaw : RunicDovetailSaw
    {
        public override CraftSystem CraftSystem { get { return DefCarpentry.CraftSystem; } }
        [Constructable]
        public PetrifiedRunicDovetailSaw()
            : base(CraftResource.Petrified, 50)
        {
            Name = "Petrified Runic Dovetail Saw";
        }
        public PetrifiedRunicDovetailSaw(Serial serial) : base(serial) { }

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