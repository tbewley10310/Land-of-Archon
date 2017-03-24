using System;
using Server.Items;

namespace Server.Items
{
	public class PillowDarkRound : Item
	{
		[Constructable]
		public PillowDarkRound() : base( 0x13A7 )
		{
			Weight = 1.0;
			Name = "A Pillow";
			Movable = true;
		}

		public PillowDarkRound( Serial serial ) : base( serial )
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