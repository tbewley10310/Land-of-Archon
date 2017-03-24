using System;
using Server;

namespace Server.Items
{
    public class RawMythicTourmaline : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawMythicTourmaline()
            : this(1)
        {
        }

        [Constructable]
        public RawMythicTourmaline(int amount)
            : base(0xF13)
        {
            Name = "Raw Mythic Tourmaline";
            Stackable = true;
            Amount = amount;
            Hue =  1161;
        }

        public RawMythicTourmaline(Serial serial)
            : base(serial)
        {
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


    public class RawLegendaryTourmaline : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawLegendaryTourmaline()
            : this(1)
        {
        }

        [Constructable]
        public RawLegendaryTourmaline(int amount)
            : base(0xF13)
        {
            Name = "Raw Legendary Tourmaline";
            Stackable = true;
            Amount = amount;
            Hue =  53;
        }

        public RawLegendaryTourmaline(Serial serial)
            : base(serial)
        {
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


    public class RawAncientTourmaline : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawAncientTourmaline()
            : this(1)
        {
        }

        [Constructable]
        public RawAncientTourmaline(int amount)
            : base(0xF13)
        {
            Name = "Raw Ancient Tourmaline";
            Stackable = true;
            Amount = amount;
            Hue = 56 ;
        }

        public RawAncientTourmaline(Serial serial)
            : base(serial)
        {
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