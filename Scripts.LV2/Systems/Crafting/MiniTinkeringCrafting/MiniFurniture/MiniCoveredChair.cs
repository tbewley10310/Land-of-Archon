using System;
using Server.Items;

namespace Server.Items
{
	public class MiniCoveredChair : Item
	{
		[Constructable]
		public MiniCoveredChair() : base( 0x3F26 )
		{
			Weight = 1.0;
			Name = "Mini Covered Chair";
			Movable = true;
		}

		public MiniCoveredChair( Serial serial ) : base( serial )
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