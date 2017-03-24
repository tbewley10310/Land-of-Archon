using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class SeaSprite : Item
	{
		[Constructable]
		public SeaSprite() : base( 9745 )
		{
			Name = "a sea sprite";			
			Weight = 0.0;
		}


		public override bool IsAccessibleTo( Mobile check )
		{
				return true;
		}


		public SeaSprite( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
				from.SendMessage("The sea sprite looks at you with enormous eyes and softly intones:");
				from.SendMessage("-------------------");
				from.SendMessage("when the breeze has sunk away,");
				from.SendMessage("And ocean scarce is heard to lave,");
				from.SendMessage("For me the sea-nymphs softly play");
				from.SendMessage("Their dulcet shells beneath the wave.");
				from.SendMessage("");
				from.SendMessage("Their dulcet shells! I hear them now;");
				from.SendMessage("Slow swells the strain upon mine ear;");
				from.SendMessage("Now faintly falls---now warbles low,");
				from.SendMessage("'Till rapture melts into a tear.");
				from.SendMessage("-------------------");
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
