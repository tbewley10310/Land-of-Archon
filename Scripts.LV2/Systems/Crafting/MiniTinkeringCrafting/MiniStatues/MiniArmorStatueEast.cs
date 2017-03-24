using System;
using Server.Items;

namespace Server.Items
{
	public class MiniArmorStatueEast : Item
	{
		[Constructable]
		public MiniArmorStatueEast() : base( 0x3F1C )
		{
			Weight = 1.0;
			Name = "Mini Armor Statue";
			Movable = true;
		}

		public MiniArmorStatueEast( Serial serial ) : base( serial )
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