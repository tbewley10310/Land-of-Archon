using System;
using Server.Items;

namespace Server.Items
{
	public class LongPillowDark2 : Item
	{
		[Constructable]
		public LongPillowDark2() : base( 0x13A4 )
		{
			Weight = 1.0;
			Name = "A Pillow";
			Movable = true;
		}

		public LongPillowDark2( Serial serial ) : base( serial )
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