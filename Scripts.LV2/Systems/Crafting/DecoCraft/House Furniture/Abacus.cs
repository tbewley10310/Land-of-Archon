using System;
using Server;

namespace Server.Items
{
	public class AbacusEast : Item
	{
		[Constructable]
		public AbacusEast() : base( 0x2936 )
		{
			Name = "Abacus";
		}

        public AbacusEast(Serial serial)
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
    public class AbacusSouth : Item
    {
        [Constructable]
        public AbacusSouth()
            : base(0x2937)
        {
            Name = "Abacus";
        }

        public AbacusSouth(Serial serial)
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