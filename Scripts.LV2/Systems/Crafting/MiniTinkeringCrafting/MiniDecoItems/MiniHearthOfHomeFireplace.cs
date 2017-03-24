using System;
using Server.Items;

namespace Server.Items
{
	public class MiniHearthOfHomeFireplace : Item
	{
		[Constructable]
		public MiniHearthOfHomeFireplace() : base( 0x3F14 )
		{
			Weight = 1.0;
			Name = "Mini Hearth Of Home Fireplace";
			Movable = true;
		}

		public MiniHearthOfHomeFireplace( Serial serial ) : base( serial )
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