// Script Name: DriftWood.cs for WoodCrafting 2.0
// Author: Oak (atticus589 wrote original version)
// Servers: RunUO 2.0
// Date: 7/7/2006
// History: 
//  Wood Craft was originally done by atticus589 in February 2005.
//  Modified for RunUO 1.0 by Oak for Sylvan Dreams shard. Stackable driftwood, Fixed spelling, changed item graphics,  different messages, drops, custom items.
//  Modified for RunUO 2.0 by Oak. Removed custom items that required special graphics, changed drop rate, used 2.0 fishing.cs, etc.
using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{

	public class DriftWood : Item
	{

		[Constructable]
		public DriftWood() : this( 1 )
		{
		}


	[Constructable]
		public DriftWood(int amount) : base( 3947 )
		{
			Name = "Drift Wood";			
			Hue = 1145;
			Stackable = true;
			Weight = 2.0;
			Amount = amount; 
		}

		public DriftWood( Serial serial ) : base( serial )
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
