using System;
using Server.Items;

namespace Server.Items
{
	public class PolarBearSkin : Item
	{
		[Constructable]
		public PolarBearSkin( int amount ) : base( 0x11F7 )
		{
			Weight = 5.0;
			Name = "A Bear Skin";
			Hue = 1150;
			Movable = true;
			Stackable = true;
			Amount = amount;
		}

		public PolarBearSkin( Serial serial ) : base( serial )
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