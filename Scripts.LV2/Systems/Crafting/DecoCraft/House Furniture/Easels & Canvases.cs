using System;

namespace Server.Items
{

	[Furniture]
	public class EaselSouth : Item
	{
		[Constructable]
		public EaselSouth() : base(0xF65)
		{
			Weight = 1.0;
		}

        public EaselSouth(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	[Furniture]
	public class EaselEast : Item
	{
		[Constructable]
		public EaselEast() : base(0xF67)
		{
			Weight = 1.0;
		}

        public EaselEast(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	[Furniture]
	public class EaselWithCanvasSouth : Item
	{
		[Constructable]
		public EaselWithCanvasSouth() : base(0xF66)
		{
			Weight = 1.0;
		}

        public EaselWithCanvasSouth(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 4.0 )
				Weight = 1.0;
		}
	}

	[Furniture]
	public class EaselWithCanvasEast : Item
	{
		[Constructable]
		public EaselWithCanvasEast() : base(0xF68)
		{
			Weight = 1.0;
		}

        public EaselWithCanvasEast(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 4.0 )
				Weight = 1.0;
		}
	}

    [Furniture]
    public class RackOfCanvasesSouth : Item
    {
        [Constructable]
        public RackOfCanvasesSouth()
            : base(0xF71)
        {
            Weight = 1.0;
        }

        public RackOfCanvasesSouth(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }
    [Furniture]
    public class RackOfCanvasesEast : Item
    {
        [Constructable]
        public RackOfCanvasesEast()
            : base(0xF73)
        {
            Weight = 1.0;
        }

        public RackOfCanvasesEast(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }
}