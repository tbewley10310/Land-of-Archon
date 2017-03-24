using System;
using Server;

namespace Server.Items
{
	public class DecoHedge1 : Item
	{
		[Constructable]
		public DecoHedge1() : base( 3215 )
		{
			Name = "hedge";
		}

		public DecoHedge1( Serial serial ) : base( serial )
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
    public class DecoHedge2 : Item
    {
        [Constructable]
        public DecoHedge2()
            : base(3216)
        {
            Name = "hedge";
        }

        public DecoHedge2(Serial serial)
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
    public class TallUntrimmedDecoHedge1 : Item
    {
        [Constructable]
        public TallUntrimmedDecoHedge1()
            : base(3512)
        {
            Name = "Untrimmed hedge";
        }

        public TallUntrimmedDecoHedge1(Serial serial)
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
    public class TallUntrimmedDecoHedge2 : Item
    {
        [Constructable]
        public TallUntrimmedDecoHedge2()
            : base(3513)
        {
            Name = "Untrimmed hedge";
        }

        public TallUntrimmedDecoHedge2(Serial serial)
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
    public class UntrimmedDecoHedge1 : Item
    {
        [Constructable]
        public UntrimmedDecoHedge1()
            : base(3217)
        {
            Name = "Untrimmed hedge";
        }

        public UntrimmedDecoHedge1(Serial serial)
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
    public class UntrimmedDecoHedge2 : Item
    {
        [Constructable]
        public UntrimmedDecoHedge2()
            : base(3218)
        {
            Name = "Untrimmed hedge";
        }

        public UntrimmedDecoHedge2(Serial serial)
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