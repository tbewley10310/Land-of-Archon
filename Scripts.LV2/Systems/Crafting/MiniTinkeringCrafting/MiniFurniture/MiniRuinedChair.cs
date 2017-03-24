using System;
using Server.Items;

namespace Server.Items
{
	public class MiniRuinedChair : Item
	{
		[Constructable]
		public MiniRuinedChair() : base( 0x3F24 )
		{
			Weight = 1.0;
			Name = "Mini Ruined Chair";
			Movable = true;
		}

		public MiniRuinedChair( Serial serial ) : base( serial )
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