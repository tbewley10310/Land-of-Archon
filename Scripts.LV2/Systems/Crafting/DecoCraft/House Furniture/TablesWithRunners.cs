using System;

namespace Server.Items
{

	[Furniture]
	public class TableBlueRunnerSouth : Item
	{
		[Constructable]
		public TableBlueRunnerSouth() : base(0x118B)
		{
			Weight = 1.0;
		}

        public TableBlueRunnerSouth(Serial serial)
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
	public class TableBlueRunnerEast : Item
	{
		[Constructable]
		public TableBlueRunnerEast() : base(0x118C)
		{
			Weight = 1.0;
		}

        public TableBlueRunnerEast(Serial serial)
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
	public class TableRedRunnerSouth : Item
	{
		[Constructable]
		public TableRedRunnerSouth() : base(0x118D)
		{
			Weight = 1.0;
		}

        public TableRedRunnerSouth(Serial serial)
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
	public class TableRedRunnerEast : Item
	{
		[Constructable]
		public TableRedRunnerEast() : base(0x118E)
		{
			Weight = 1.0;
		}

        public TableRedRunnerEast(Serial serial)
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
	public class SmallTableBlueRunnerEast : Item
	{
		[Constructable]
		public SmallTableBlueRunnerEast() : base(0x118F)
		{
			Weight = 1.0;
		}

        public SmallTableBlueRunnerEast(Serial serial)
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
    public class SmallTableBlueRunnerSouth : Item
    {
        [Constructable]
        public SmallTableBlueRunnerSouth()
            : base(0x1191)
        {
            Weight = 1.0;
        }

        public SmallTableBlueRunnerSouth(Serial serial)
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