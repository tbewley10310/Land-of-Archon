using System;
using Server.Items;

namespace Server.Items
{
	public class MiniIronMaiden : Item
	{
		[Constructable]
		public MiniIronMaiden() : base( 0x3F15 )
		{
			Weight = 1.0;
			Name = "Mini Iron Maiden";
			Movable = true;
		}

		public MiniIronMaiden( Serial serial ) : base( serial )
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