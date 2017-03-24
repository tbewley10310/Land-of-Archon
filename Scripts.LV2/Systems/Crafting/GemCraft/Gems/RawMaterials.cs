using System;
using Server;

namespace Server.Items
{
	public class RawGlimmeringPiece : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public RawGlimmeringPiece() : this( 1 )
		{
		}

		[Constructable]
		public RawGlimmeringPiece( int amount ) : base( 0xF13 )
		{
            Name = "Raw Glimmering Piece";
			Stackable = true;
			Amount = amount;
            Hue = 933;
		}

        public RawGlimmeringPiece(Serial serial)
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


    public class RawRune : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawRune()
            : this(1)
        {
        }

        [Constructable]
        public RawRune(int amount)
            : base(0x1f14)
        {
            Name = "Raw Rune";
            Stackable = true;
            Amount = amount;
            Hue = 933;
        }

        public RawRune(Serial serial)
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


    public class RawCrystal : Item
    {
        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RawCrystal()
            : this(1)
        {
        }

        [Constructable]
        public RawCrystal(int amount)
            : base(0xF8E)
        {
            Name = "Raw Crystal";
            Stackable = true;
            Amount = amount;
            Hue = 906;
        }

        public RawCrystal(Serial serial)
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