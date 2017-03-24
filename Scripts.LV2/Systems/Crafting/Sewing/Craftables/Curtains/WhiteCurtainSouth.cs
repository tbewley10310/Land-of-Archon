using System;
using Server.Items;

namespace Server.Items
{
	public class WhiteCurtainSouth : Item
	{
		[Constructable]
		public WhiteCurtainSouth() : base( 0x159F )
		{
			Weight = 1.0;
			Name = "An Elegant Curtain";
			Movable = true;
		}

		public WhiteCurtainSouth( Serial serial ) : base( serial )
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