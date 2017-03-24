using System;
using Server.Items;

namespace Server.Items
{
	public class MiniSwordDisplay : Item
	{
		[Constructable]
		public MiniSwordDisplay() : base( 0x3F13 )
		{
			Weight = 1.0;
			Name = "Mini Sword Display";
			Movable = true;
		}

		public MiniSwordDisplay( Serial serial ) : base( serial )
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