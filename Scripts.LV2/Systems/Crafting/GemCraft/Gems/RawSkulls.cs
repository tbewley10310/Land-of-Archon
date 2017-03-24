using System;
using Server;

namespace Server.Items
{
	public class RawMythicSkull : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public RawMythicSkull() : this( 1 )
		{
		}

		[Constructable]
		public RawMythicSkull( int amount ) : base( 0xF13 )
		{
            Name = "Raw Mythic Skull";
			Stackable = true;
			Amount = amount;
            Hue = 1154;
		}

        public RawMythicSkull(Serial serial)
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


    public class RawLegendarySkull : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawLegendarySkull()
            : this(1)
        {
        }

        [Constructable]
        public RawLegendarySkull(int amount)
            : base(0xF13)
        {
            Name = "Raw Legendary Skull";
            Stackable = true;
            Amount = amount;
            Hue = 1153;
        }

        public RawLegendarySkull(Serial serial)
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


    public class RawAncientSkull : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawAncientSkull()
            : this(1)
        {
        }

        [Constructable]
        public RawAncientSkull(int amount)
            : base(0xF13)
        {
            Name = "Raw Ancient Skull";
            Stackable = true;
            Amount = amount;
            Hue = 1150;
        }

        public RawAncientSkull(Serial serial)
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