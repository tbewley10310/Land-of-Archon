using System;
using Server.Items;

namespace Server.Items
{
	public class MiniNobleStatueEast : Item
	{
		[Constructable]
		public MiniNobleStatueEast() : base( 0x3F1A )
		{
			Weight = 1.0;
			Name = "Mini Noble Statue";
			Movable = true;
		}

		public MiniNobleStatueEast( Serial serial ) : base( serial )
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