using System;

namespace Server.Items
{
    public class PumpkinTallAnkh : BaseLight
    {
        [Constructable]
        public PumpkinTallAnkh()
            : base(0x9939)
        {
            //this.Name = "Tall Pumpkin Ankh";
            if (Burnout)
                this.Duration = TimeSpan.FromMinutes(20);
            else
                this.Duration = TimeSpan.Zero;

            this.Burning = false;
            this.Light = LightType.Circle150;
            this.Weight = 1.0;
        }

        public PumpkinTallAnkh(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1096937;
            }
        }// carved pumpkin

        public override int LitItemID
        {
            get
            {
                return 0x993A;
            }
        }
        public override int UnlitItemID
        {
            get
            {
                return 0x9939;
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