using System;
using Server.Items;

namespace Server.Items
{
	public class MiniWoodCoffin : Item
	{
		[Constructable]
		public MiniWoodCoffin() : base( 0x3F0E )
		{
			Weight = 1.0;
			Name = "Mini Wood Coffin";
			Movable = true;
		}

		public MiniWoodCoffin( Serial serial ) : base( serial )
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