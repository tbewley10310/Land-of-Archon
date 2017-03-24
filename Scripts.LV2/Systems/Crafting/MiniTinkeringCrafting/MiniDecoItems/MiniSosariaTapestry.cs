using System;
using Server.Items;

namespace Server.Items
{
	public class MiniSosariaTapestry : Item
	{
		[Constructable]
		public MiniSosariaTapestry() : base( 0x3F1D )
		{
			Weight = 1.0;
			Name = "Mini Sosaria Tapestry";
			Movable = true;
		}

		public MiniSosariaTapestry( Serial serial ) : base( serial )
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