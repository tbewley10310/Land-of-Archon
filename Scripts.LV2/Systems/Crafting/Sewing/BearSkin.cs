using System;
using Server.Items;

namespace Server.Items
{
	public class BearSkin : Item
	{
		[Constructable]
		public BearSkin( int amount ) : base( 0x11F7 )
		{
			Weight = 5.0;
			Name = "A Bear Skin";
			Movable = true;
			Stackable = true;
			Amount = amount;
		}

		public BearSkin( Serial serial ) : base( serial )
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