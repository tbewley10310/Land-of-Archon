using System;
using Server.Items;

namespace Server.Items
{
	public class MiniRuinedArmoire : Item
	{
		[Constructable]
		public MiniRuinedArmoire() : base( 0x3F21 )
		{
			Weight = 1.0;
			Name = "Mini Ruined Armoire";
			Movable = true;
		}

		public MiniRuinedArmoire( Serial serial ) : base( serial )
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