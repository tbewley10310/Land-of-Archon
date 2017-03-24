using System;
using Server.Items;

namespace Server.Items
{
	public class MiniPearTree : Item
	{
		[Constructable]
		public MiniPearTree() : base( 0x3F16 )
		{
			Weight = 1.0;
			Name = "Mini Pear Tree";
			Movable = true;
		}

		public MiniPearTree( Serial serial ) : base( serial )
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