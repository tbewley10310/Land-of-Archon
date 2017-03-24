using System;
using Server.Items;

namespace Server.Items
{
	public class MiniRuinedChest : Item
	{
		[Constructable]
		public MiniRuinedChest() : base( 0x3F23 )
		{
			Weight = 1.0;
			Name = "Mini Ruined Chest";
			Movable = true;
		}

		public MiniRuinedChest( Serial serial ) : base( serial )
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