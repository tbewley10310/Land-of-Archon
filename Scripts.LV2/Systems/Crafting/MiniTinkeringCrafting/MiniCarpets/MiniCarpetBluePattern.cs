using System;
using Server.Items;

namespace Server.Items
{
	public class MiniCarpetBluePattern : Item
	{
		[Constructable]
		public MiniCarpetBluePattern() : base( 0x3F0A )
		{
			Weight = 1.0;
			Name = "Mini Carpet Blue Pattern";
			Movable = true;
		}

		public MiniCarpetBluePattern( Serial serial ) : base( serial )
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