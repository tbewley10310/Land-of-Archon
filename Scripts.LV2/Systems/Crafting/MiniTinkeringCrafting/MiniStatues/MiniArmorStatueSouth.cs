using System;
using Server.Items;

namespace Server.Items
{
	public class MiniArmorStatueSouth : Item
	{
		[Constructable]
		public MiniArmorStatueSouth() : base( 0x3F1B )
		{
			Weight = 1.0;
			Name = "Mini Armor Statue";
			Movable = true;
		}

		public MiniArmorStatueSouth( Serial serial ) : base( serial )
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