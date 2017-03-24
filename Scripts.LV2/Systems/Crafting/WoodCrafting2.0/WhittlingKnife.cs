// Script Name: WhittlingKnife.cs for WoodCrafting 2.0
// Author: Oak (atticus589 wrote original version)
// Servers: RunUO 2.0
// Date: 7/7/2006
// History: 
//  Wood Craft was originally done by atticus589 in February 2005.
//  Modified for RunUO 1.0 by Oak for Sylvan Dreams shard. Stackable driftwood, Fixed spelling, changed item graphics,  different messages, drops, custom items.
//  Modified for RunUO 2.0 by Oak. Removed custom items that required special graphics, changed drop rate, used 2.0 fishing.cs, etc.
using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class WhittlingKnife : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefWoodCarving.CraftSystem; } }

		[Constructable]
		public WhittlingKnife() : base( 0x10E5 )
		{
			Name = "a whittling knife";
			Weight = 1.0;
		}

		[Constructable]
		public WhittlingKnife( int uses ) : base( uses, 0x1028 )
		{
			Weight = 1.0;
			Hue = 1282;
		}

		public WhittlingKnife( Serial serial ) : base( serial )
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