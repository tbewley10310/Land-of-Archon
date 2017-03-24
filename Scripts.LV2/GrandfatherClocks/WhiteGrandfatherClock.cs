using System;
using Server;

namespace Server.Items
{

	[Flipable( 0x48D4, 0x48D8 )]
	public class WhiteGrandfatherClock : Clock
	{
		[Constructable]
		public WhiteGrandfatherClock() : base( 0x44DD )
		{
		}

		public WhiteGrandfatherClock( Serial serial ) : base( serial )
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