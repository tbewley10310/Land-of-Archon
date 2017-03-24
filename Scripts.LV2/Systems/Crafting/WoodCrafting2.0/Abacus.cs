using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class Abacus : Item
	{
		[Constructable]
		public Abacus() : base( 10551 )
		{
			Name = "an abacus";			
			Weight = 1.0;
		}


		public Abacus( Serial serial ) : base( serial )
		{
		}

		public override bool IsAccessibleTo( Mobile check )
		{
				return true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage("The colored beads shift up and down the wires with bewildering speed.");
			from.SendMessage("The abacus trembles lightly in your hands as it calculates the meaning of existence.");
			from.SendMessage("You peer at the abacus and realize it all adds up to 42.");
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
