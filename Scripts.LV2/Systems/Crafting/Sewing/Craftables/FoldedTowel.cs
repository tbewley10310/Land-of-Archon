using System;
using Server.Items;

namespace Server.Items
{
	public class FoldedTowel : Item
	{
		[Constructable]
		public FoldedTowel() : base( 0x1914 )
		{
			Weight = 1.0;
			Name = "A Folded Towel";
			Movable = true;
		}

		public FoldedTowel( Serial serial ) : base( serial )
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