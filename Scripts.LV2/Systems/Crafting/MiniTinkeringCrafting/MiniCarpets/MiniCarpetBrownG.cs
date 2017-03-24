using System;
using Server.Items;

namespace Server.Items
{
	public class MiniCarpetBrownG : Item
	{
		[Constructable]
		public MiniCarpetBrownG() : base( 0x3F18 )
		{
			Weight = 1.0;
			Name = "Mini Carpet Red Gold";
			Movable = true;
		}

		public MiniCarpetBrownG( Serial serial ) : base( serial )
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