using System;

namespace Server.Items
{
    public class PumpkinTallRotten : Item
    {
        [Constructable]
        public PumpkinTallRotten()
            : base(0x9930)
        {
            //this.Name = "Tall Pumpkin Rotten";
        }

        public PumpkinTallRotten(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1123240;
            }
        }// rotten pumpkin

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