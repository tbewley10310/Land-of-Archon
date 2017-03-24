using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class PlainIdol : Item
	{
		[Constructable]
		public PlainIdol() : base( 10312 )
		{
			Name = "an idol";			
			Weight = 0.0;
		}


		public override bool IsAccessibleTo( Mobile check )
		{
				return true;
		}


		public PlainIdol( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			switch( Utility.RandomMinMax( 1, 5 ) )
			{
				case 1:
				from.SendMessage("Why do you click me? You realize that is very irritating. Stop it.");
				break;
				case 2:
				from.SendMessage("You may pray to me if you wish. It won't help but I like it when people do that.");
				break;
				case 3:
				from.SendMessage("I think I'm quite attractive...for an idol.");
				break;
				case 4:
				from.SendMessage("Don't mind me, just idoling away my time here. hehe. That's a joke, you heathen!");
				break;
				case 5:
				from.SendMessage("Bless you my child. May the goodness of the Mother embrace you and keep you safe.");
				break;
			}
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
