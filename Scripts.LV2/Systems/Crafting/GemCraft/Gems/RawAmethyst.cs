using System;
using Server;

namespace Server.Items
{
	public class RawMythicAmethyst : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public RawMythicAmethyst() : this( 1 )
		{
		}

		[Constructable]
		public RawMythicAmethyst( int amount ) : base( 0xF13 )
		{
            Name = "Raw Mythic Amethyst";
			Stackable = true;
			Amount = amount;
            Hue = 11;
		}

        public RawMythicAmethyst(Serial serial)
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


    public class RawLegendaryAmethyst : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawLegendaryAmethyst()
            : this(1)
        {
        }

        [Constructable]
        public RawLegendaryAmethyst(int amount)
            : base(0xF13)
        {
            Name = "Raw Legendary Amethyst";
            Stackable = true;
            Amount = amount;
            Hue = 12;
        }

        public RawLegendaryAmethyst(Serial serial)
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


    public class RawAncientAmethyst : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawAncientAmethyst()
            : this(1)
        {
        }

        [Constructable]
        public RawAncientAmethyst(int amount)
            : base(0xF13)
        {
            Name = "Raw Ancient Amethyst";
            Stackable = true;
            Amount = amount;
            Hue = 15;
        }

        public RawAncientAmethyst(Serial serial)
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