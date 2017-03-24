using System;
using Server.Items;

namespace Server.Items
{
	public class MiniCarpetBrownFancy : Item
	{
		[Constructable]
		public MiniCarpetBrownFancy() : base( 0x3F0D )
		{
			Weight = 1.0;
			Name = "Mini Carpet Brown Fancy";
			Movable = true;
		}

		public MiniCarpetBrownFancy( Serial serial ) : base( serial )
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