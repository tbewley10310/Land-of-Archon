using System;
using Server.Items;

namespace Server.Items
{
	public class RedCurtainEast1 : Item
	{
		[Constructable]
		public RedCurtainEast1() : base( 0x154E )
		{
			Weight = 1.0;
			Name = "An Elegant Curtain";
			Movable = true;
		}

		public RedCurtainEast1( Serial serial ) : base( serial )
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