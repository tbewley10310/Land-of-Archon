using System;
using Server;

namespace Server.Items
{
	public class RawMythicSapphire : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public RawMythicSapphire() : this( 1 )
		{
		}

		[Constructable]
		public RawMythicSapphire( int amount ) : base( 0xF13 )
		{
            Name = "Raw Mythic Sapphire";
			Stackable = true;
			Amount = amount;
            Hue = 190;
		}

        public RawMythicSapphire(Serial serial)
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


    public class RawLegendarySapphire : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawLegendarySapphire()
            : this(1)
        {
        }

        [Constructable]
        public RawLegendarySapphire(int amount)
            : base(0xF13)
        {
            Name = "Raw Legendary Sapphire";
            Stackable = true;
            Amount = amount;
            Hue = 100;
        }

        public RawLegendarySapphire(Serial serial)
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


    public class RawAncientSapphire : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawAncientSapphire()
            : this(1)
        {
        }

        [Constructable]
        public RawAncientSapphire(int amount)
            : base(0xF13)
        {
            Name = "Raw Ancient Sapphire";
            Stackable = true;
            Amount = amount;
            Hue = 94;
        }

        public RawAncientSapphire(Serial serial)
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