using System;
using Server;

namespace Server.Items
{
	public class WhiteWidowTree : Item //add a name before Deed(LayerDeed or HouseJoinDeed)also for the Deed below same name
	{
		[Constructable]
		public WhiteWidowTree() : base(0x9969) // check this number to be sure its for a blank deed 
		{
			Name = "A White Widow Tree";
			Hue =0;
			LootType = LootType.Blessed;
		}

		public WhiteWidowTree(Serial serial) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}
	}
}