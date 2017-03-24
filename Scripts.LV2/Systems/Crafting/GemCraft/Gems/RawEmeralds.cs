using System;
using Server;

namespace Server.Items
{
	public class RawMythicEmerald : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public RawMythicEmerald() : this( 1 )
		{
		}

		[Constructable]
		public RawMythicEmerald( int amount ) : base( 0xF13 )
		{
            Name = "Raw Mythic Emerald";
			Stackable = true;
			Amount = amount;
            Hue = 1267;
		}

        public RawMythicEmerald(Serial serial)
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


    public class RawLegendaryEmerald : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawLegendaryEmerald()
            : this(1)
        {
        }

        [Constructable]
        public RawLegendaryEmerald(int amount)
            : base(0xF13)
        {
            Name = "Raw Legendary Emerald";
            Stackable = true;
            Amount = amount;
            Hue = 1268;
        }

        public RawLegendaryEmerald(Serial serial)
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


    public class RawAncientEmerald : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawAncientEmerald()
            : this(1)
        {
        }

        [Constructable]
        public RawAncientEmerald(int amount)
            : base(0xF13)
        {
            Name = "Raw Ancient Emerald";
            Stackable = true;
            Amount = amount;
            Hue = 76;
        }

        public RawAncientEmerald(Serial serial)
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