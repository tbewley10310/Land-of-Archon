using System;
using Server.Items;

namespace Server.Items
{
	public class MiniSwordAxeDisplay : Item
	{
		[Constructable]
		public MiniSwordAxeDisplay() : base( 0x3F12 )
		{
			Weight = 1.0;
			Name = "Mini Sword And Axe Display";
			Movable = true;
		}

		public MiniSwordAxeDisplay( Serial serial ) : base( serial )
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