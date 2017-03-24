using System;

namespace Server.Items
{
    public class PumpkinTallSpider : BaseLight
    {
        [Constructable]
        public PumpkinTallSpider()
            : base(0x993D)
        {
            //this.Name = "Tall Pumpkin Spider";
            if (Burnout)
                this.Duration = TimeSpan.FromMinutes(20);
            else
                this.Duration = TimeSpan.Zero;

            this.Burning = false;
            this.Light = LightType.Circle150;
            this.Weight = 1.0;
        }

        public override int LabelNumber
        {
            get
            {
                return 1096942;
            }
        }// carved pumpkin

        public PumpkinTallSpider(Serial serial)
            : base(serial)
        {
        }

        public override int LitItemID
        {
            get
            {
                return 0x993E;
            }
        }
        public override int UnlitItemID
        {
            get
            {
                return 0x993D;
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