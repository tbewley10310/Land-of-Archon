using System;
using Server.Items;

namespace Server.Items
{
	public class RedCurtainEast3 : Item
	{
		[Constructable]
		public RedCurtainEast3() : base( 0x1557 )
		{
			Weight = 1.0;
			Name = "An Elegant Curtain";
			Movable = true;
		}

		public RedCurtainEast3( Serial serial ) : base( serial )
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