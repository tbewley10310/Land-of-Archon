using System;
using Server.Items;

namespace Server.Items
{
	public class MiniGreenTree : Item
	{
		[Constructable]
		public MiniGreenTree() : base( 0x3F07 )
		{
			Weight = 1.0;
			Name = "Mini Apple Tree";
			Movable = true;
		}

		public MiniGreenTree( Serial serial ) : base( serial )
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