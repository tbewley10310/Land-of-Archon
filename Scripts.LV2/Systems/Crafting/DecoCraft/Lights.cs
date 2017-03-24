using System;
using Server;

namespace Server.Items
{
	public class LampPostLit : Item
	{
		[Constructable]
		public LampPostLit() : base( 2850 )
		{
			Name = "lamp post";
			Light = LightType.Circle300;
		}

		public LampPostLit( Serial serial ) : base( serial )
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
    public class LampPostUnlit : Item
    {
        [Constructable]
        public LampPostUnlit()
            : base(2851)
        {
            Name = "lamp post";
        }

        public LampPostUnlit(Serial serial)
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
    public class FancyLampPostLit : Item
    {
        [Constructable]
        public FancyLampPostLit()
            : base(2852)
        {
            Name = "Fancy lamp post";
            Light = LightType.Circle300;
        }

        public FancyLampPostLit(Serial serial)
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
    public class FancyLampPostUnlit : Item
    {
        [Constructable]
        public FancyLampPostUnlit()
            : base(2853)
        {
            Name = "Fancy lamp post";
        }

        public FancyLampPostUnlit(Serial serial)
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
    public class DecoBrazier : Item
    {
        [Constructable]
        public DecoBrazier()
            : base(0xE31)
        {
            Name = "DecoBrazier";
            Light = LightType.Circle225;
        }

        public DecoBrazier(Serial serial)
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
    public class TallDecoBrazier : Item
    {
        [Constructable]
        public TallDecoBrazier()
            : base(0x19AA)
        {
            Name = "TallBrazier";
            Light = LightType.Circle300;
        }

        public TallDecoBrazier(Serial serial)
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