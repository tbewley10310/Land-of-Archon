using System;
using Server.Items;

namespace Server.Items
{
	public class MiniVanitySouth : Item
	{
		[Constructable]
		public MiniVanitySouth() : base( 0x3F20 )
		{
			Weight = 1.0;
			Name = "Mini Vanity";
			Movable = true;
		}

		public MiniVanitySouth( Serial serial ) : base( serial )
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