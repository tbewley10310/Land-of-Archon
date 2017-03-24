using System;

namespace Server.Items
{
    public class PumpkinTall : Item
    {
        [Constructable]
        public PumpkinTall()
            : base(0x992F)
        {
            //this.Name = "Carveable Pumpkin";
        }

        public PumpkinTall(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1123239;
            }
        }// carvable pumpkin

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