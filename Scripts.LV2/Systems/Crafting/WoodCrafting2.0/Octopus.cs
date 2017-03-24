using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class Octopus : Item
	{
		[Constructable]
		public Octopus() : base( 9634 )
		{
			Name = "an Octopus";			
			//Hue = 1155;
			Stackable = false;
			Weight = 60.0;
		}

		public override bool IsAccessibleTo( Mobile check )
		{
				return true;
		}

		public Octopus( Serial serial ) : base( serial )
		{
		}
		public override void OnDoubleClick( Mobile from )
		{
				from.SendMessage("The octopus wriggles in your hand and you can feel the suckers on the bottomside of the eight legs grip you fiercely.");
				from.SendMessage("You see it rear upwards, about to strike down with its razor sharp beak. Quickly, you raise your hand and sing:");
				from.SendMessage("........");
				from.SendMessage("Tell me, O Octopus, I begs");
				from.SendMessage("Is those things arms, or is they legs?");
				from.SendMessage("I marvel at thee, Octopus;");
				from.SendMessage("If I were thou, I'd call me Us.");
				from.SendMessage("..........");
				from.SendMessage("The octopus giggles and relaxes.");
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
