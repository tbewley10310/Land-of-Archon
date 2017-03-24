using System;
using Server;

namespace Server.Items
{
	public class RawMythicRuby : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public RawMythicRuby() : this( 1 )
		{
		}

		[Constructable]
		public RawMythicRuby( int amount ) : base( 0xF13 )
		{
            Name = "Raw Mythic Ruby";
			Stackable = true;
			Amount = amount;
            Hue = 35;
		}

        public RawMythicRuby(Serial serial)
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


    public class RawLegendaryRuby : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawLegendaryRuby()
            : this(1)
        {
        }

        [Constructable]
        public RawLegendaryRuby(int amount)
            : base(0xF13)
        {
            Name = "Raw Legendary Ruby";
            Stackable = true;
            Amount = amount;
            Hue = 233;
        }

        public RawLegendaryRuby(Serial serial)
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


    public class RawAncientRuby : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawAncientRuby()
            : this(1)
        {
        }

        [Constructable]
        public RawAncientRuby(int amount)
            : base(0xF13)
        {
            Name = "Raw Ancient Ruby";
            Stackable = true;
            Amount = amount;
            Hue = 432;
        }

        public RawAncientRuby(Serial serial)
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