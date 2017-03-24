using System;
using Server.Items;

namespace Server.Items
{
	public class MiniFancyCurtain : Item
	{
		[Constructable]
		public MiniFancyCurtain() : base( 0x3F0F )
		{
			Weight = 1.0;
			Name = "Mini Fancy Curtain";
			Movable = true;
		}

		public MiniFancyCurtain( Serial serial ) : base( serial )
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