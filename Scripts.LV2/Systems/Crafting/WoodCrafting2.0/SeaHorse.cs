using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class SeaHorseStatue : Item
	{
		[Constructable]
		public SeaHorseStatue() : base( 9658 )
		{
			Name = "a Sea Horse statue";			
			//Hue = 1155;
			Stackable = false;
			Weight = 60.0;
		}


		public SeaHorseStatue( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage("The sea horse seems to shimmer in your hand and visions of softly floating tendrils of seaweed come to your mind. Undulating rays of golden light stream down from the surface of the ocean far above. A deep sense of peace pervades your mind.");
		}

		public override bool IsAccessibleTo( Mobile check )
		{
				return true;
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
