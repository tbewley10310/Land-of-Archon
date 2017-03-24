using System;
using Server.Items;

namespace Server.Items
{
	public class MiniRuinedBookcase : Item
	{
		[Constructable]
		public MiniRuinedBookcase() : base( 0x3F22 )
		{
			Weight = 1.0;
			Name = "Mini Ruined Bookcase";
			Movable = true;
		}

		public MiniRuinedBookcase( Serial serial ) : base( serial )
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