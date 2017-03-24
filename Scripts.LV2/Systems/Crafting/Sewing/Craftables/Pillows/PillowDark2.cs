using System;
using Server.Items;

namespace Server.Items
{
	public class PillowDark2 : Item
	{
		[Constructable]
		public PillowDark2() : base( 0x13AA )
		{
			Weight = 1.0;
			Name = "A Pillow";
			Movable = true;
		}

		public PillowDark2( Serial serial ) : base( serial )
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