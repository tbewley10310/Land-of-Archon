using System;
using Server;

namespace Server.Items
{
	public class RawMythicCrust : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public RawMythicCrust() : this( 1 )
		{
		}

		[Constructable]
        public RawMythicCrust(int amount)
            : base(0xF2D)
		{
            Name = "Raw Mythic Crust";
			Stackable = true;
			Amount = amount;
            Hue = 91;
		}

        public RawMythicCrust(Serial serial)
            : base(serial)
		{
		}

		

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}


    public class RawLegendaryCrust : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawLegendaryCrust()
            : this(1)
        {
        }

        [Constructable]
        public RawLegendaryCrust(int amount)
            : base(0xF2D)
        {
            Name = "Raw Legendary Crust";
            Stackable = true;
            Amount = amount;
            Hue = 437;
        }

        public RawLegendaryCrust(Serial serial)
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


    public class RawAncientCrust : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawAncientCrust()
            : this(1)
        {
        }

        [Constructable]
        public RawAncientCrust(int amount)
            : base(0xF2D)
        {
            Name = "Raw Ancient Crust";
            Stackable = true;
            Amount = amount;
            Hue = 672;
        }

        public RawAncientCrust(Serial serial)
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