using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class SeaFrog : Item
	{
		[Constructable]
		public SeaFrog() : base( 8496 )
		{
			Name = "a sea frog";			
			Hue = 1155;
			Stackable = false;
			Weight = 60.0;
		}


		public override bool IsAccessibleTo( Mobile check )
		{
				return true;
		}

		public SeaFrog( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage("---------------------------");
			from.SendMessage("The sea frog swivels its neck and looks up at you with a grin...");
			from.SendMessage("...");
			from.SendMessage(" Frog went a-courtin', and he did ride, Uh-huh,");
			from.SendMessage(" Frog went a-courtin', and he did ride, Uh-huh,");
			from.SendMessage(" Frog went a-courtin', and he did ride.");
			from.SendMessage(" With a sword and a pistol by his side, Uh-huh.");
			from.SendMessage(".....");
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
