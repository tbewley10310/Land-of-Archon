using System;
using Server.Items;

namespace Server.Items
{
	public class MiniVanityEast : Item
	{
		[Constructable]
		public MiniVanityEast() : base( 0x3F1F )
		{
			Weight = 1.0;
			Name = "Mini Vanity";
			Movable = true;
		}

		public MiniVanityEast( Serial serial ) : base( serial )
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
}