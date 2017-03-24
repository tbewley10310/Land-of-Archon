using System;
using Server;

namespace Server.Items
{
	public class RawMythicDiamond : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public RawMythicDiamond() : this( 1 )
		{
		}

		[Constructable]
		public RawMythicDiamond( int amount ) : base( 0xF13 )
		{
            Name = "Raw Mythic Diamond";
			Stackable = true;
			Amount = amount;
            Hue = 1153;
		}

        public RawMythicDiamond(Serial serial)
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


    public class RawLegendaryDiamond : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawLegendaryDiamond()
            : this(1)
        {
        }

        [Constructable]
        public RawLegendaryDiamond(int amount)
            : base(0xF13)
        {
            Name = "Raw Legendary Diamond";
            Stackable = true;
            Amount = amount;
            Hue = 1150;
        }

        public RawLegendaryDiamond(Serial serial)
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


    public class RawAncientDiamond : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawAncientDiamond()
            : this(1)
        {
        }

        [Constructable]
        public RawAncientDiamond(int amount)
            : base(0xF13)
        {
            Name = "Raw Ancient Diamond";
            Stackable = true;
            Amount = amount;
            Hue = 1151;
        }

        public RawAncientDiamond(Serial serial)
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