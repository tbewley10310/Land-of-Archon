using System;
using Server.Items;

namespace Server.Items
{
	public class MiniNobleStatueSouth : Item
	{
		[Constructable]
		public MiniNobleStatueSouth() : base( 0x3F19 )
		{
			Weight = 1.0;
			Name = "Mini Noble Statue";
			Movable = true;
		}

		public MiniNobleStatueSouth( Serial serial ) : base( serial )
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