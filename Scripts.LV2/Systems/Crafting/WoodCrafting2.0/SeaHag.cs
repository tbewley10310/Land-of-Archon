using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class SeaHag : Item
	{
		[Constructable]
		public SeaHag() : base( 10092 )
		{
			Name = "a spooky sea hag";
			Stackable = false;
			Weight = 30.0;
		}


		public SeaHag( Serial serial ) : base( serial )
		{
		}
		public override bool IsAccessibleTo( Mobile check )
		{
				return true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage("---------------------------");
			from.SendMessage("As you touch the rough statue, the odor of rotting seaweed fills your nostrils.");
			from.SendMessage("The tangled locks of the Sea Hag stir as if alive and her eyes blaze into yours..");
			from.SendMessage(".......");
			from.SendMessage("Come away, O human child!"); 
			from.SendMessage("To the waters and the wild"); 
			from.SendMessage("With a faery, hand in hand,"); 
			from.SendMessage("For the world's more full of weeping than you can understand. ");
			from.SendMessage("---------------------------");
			from.SendMessage("You feel an yawning void of despair deep inside, and drop the statue hastily.");
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
