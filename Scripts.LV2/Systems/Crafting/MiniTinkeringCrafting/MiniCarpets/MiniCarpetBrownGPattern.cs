using System;
using Server.Items;

namespace Server.Items
{
	public class MiniCarpetBrownGPattern : Item
	{
		[Constructable]
		public MiniCarpetBrownGPattern() : base( 0x3F11 )
		{
			Weight = 1.0;
			Name = "Mini Carpet Brown Gold Pattern";
			Movable = true;
		}

		public MiniCarpetBrownGPattern( Serial serial ) : base( serial )
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