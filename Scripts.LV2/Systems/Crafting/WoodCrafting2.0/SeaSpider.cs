using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class SeaSpider : Item
	{
		[Constructable]
		public SeaSpider() : base( 9669 )
		{
			Name = "a quoting sea spider";
			Stackable = false;
			Weight = 30.0;
		}


		public SeaSpider( Serial serial ) : base( serial )
		{
		}
		public override bool IsAccessibleTo( Mobile check )
		{
				return true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage("The sea spider wriggles and spells out the letters W.W. in fine silk upon your palm:");
			from.SendMessage("---------------------------");
			from.SendMessage("A noiseless patient spider, ");
			from.SendMessage("I mark'd where on a little promontory it stood isolated, ");
			from.SendMessage("Mark'd how to explore the vacant vast surrounding, ");
			from.SendMessage("It launch'd forth filament, filament, filament out of itself, ");
			from.SendMessage("Ever unreeling them, ever tirelessly speeding them. ");
			from.SendMessage("");
			from.SendMessage("And you O my soul where you stand, ");
			from.SendMessage("Surrounded, detached, in measureless oceans of space, ");
			from.SendMessage("Ceaselessly musing, venturing, throwing, seeking the spheres to connect them, ");
			from.SendMessage("Till the bridge you will need be form'd, till the ductile anchor hold, ");
			from.SendMessage("Till the gossamer thread you fling catch somewhere, O my soul. ");
			from.SendMessage("---------------------------");
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
