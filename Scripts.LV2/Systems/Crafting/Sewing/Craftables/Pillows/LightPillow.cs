using System;
using Server.Items;

namespace Server.Items
{
	public class LightPillow : Item
	{
		[Constructable]
		public LightPillow() : base( 0x163C )
		{
			Weight = 1.0;
			Name = "A Pillow";
			Movable = true;
		}

		public LightPillow( Serial serial ) : base( serial )
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