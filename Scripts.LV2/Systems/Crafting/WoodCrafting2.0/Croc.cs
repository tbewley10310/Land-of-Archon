using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class Croc : Item
	{
		[Constructable]
		public Croc() : base( 8497 )
		{
			Name = "a baby crocodile";
			Stackable = false;
			Weight = 30.0;
		}


		public Croc( Serial serial ) : base( serial )
		{
		}
		public override bool IsAccessibleTo( Mobile check )
		{
				return true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage("---------------------------");
			from.SendMessage("The baby crocodile twists his scaly neck and stares up at you with an impudent grin:");
			from.SendMessage(".......");
			from.SendMessage("How doth the little crocodile,");
			from.SendMessage("Improve his shining tail,");
			from.SendMessage("And pour the waters of the Nile");
			from.SendMessage("On every golden scale.");
			from.SendMessage("How cheerfully he seems to grin,");
			from.SendMessage("How neatly spreads his claws,");
			from.SendMessage("And welcomes little fishes in,");
			from.SendMessage("With gently smiling jaws.");
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
