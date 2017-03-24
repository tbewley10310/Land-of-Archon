using System;
using Server.Items;

namespace Server.Items
{
	public class MiniStoneFountain : Item
	{
		[Constructable]
		public MiniStoneFountain() : base( 0x3F10 )
		{
			Weight = 1.0;
			Name = "Mini Stone Fountain";
			Movable = true;
		}

		public MiniStoneFountain( Serial serial ) : base( serial )
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