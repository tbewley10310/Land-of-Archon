using System;
using Server.Items;

namespace Server.Items
{
	public class MiniFullBed : Item
	{
		[Constructable]
		public MiniFullBed() : base( 0x3F1E )
		{
			Weight = 1.0;
			Name = "Mini Full Bed";
			Movable = true;
		}

		public MiniFullBed( Serial serial ) : base( serial )
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