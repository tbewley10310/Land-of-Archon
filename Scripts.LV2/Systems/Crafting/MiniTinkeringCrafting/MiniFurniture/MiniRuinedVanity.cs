using System;
using Server.Items;

namespace Server.Items
{
	public class MiniRuinedVanity : Item
	{
		[Constructable]
		public MiniRuinedVanity() : base( 0x3F25 )
		{
			Weight = 1.0;
			Name = "Mini Ruined Vanity";
			Movable = true;
		}

		public MiniRuinedVanity( Serial serial ) : base( serial )
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