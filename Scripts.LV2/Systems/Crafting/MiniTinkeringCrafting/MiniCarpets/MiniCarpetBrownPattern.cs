using System;
using Server.Items;

namespace Server.Items
{
	public class MiniCarpetBrownPattern : Item
	{
		[Constructable]
		public MiniCarpetBrownPattern() : base( 0x3F17 )
		{
			Weight = 1.0;
			Name = "Mini Carpet Brown Pattern";
			Movable = true;
		}

		public MiniCarpetBrownPattern( Serial serial ) : base( serial )
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