using System;
using Server;

namespace Server.Items
{
	public class VoteToken : Item //add a name before Deed(LayerDeed or HouseJoinDeed)also for the Deed below same name
	{
		[Constructable]
		public VoteToken() : base(0x3194) // check this number to be sure its for a blank deed 
		{
			Name = "Vote Token";
			Hue = 2065;
			LootType = LootType.Blessed;
			Stackable = true;
		}

		public VoteToken(Serial serial) : base( serial )
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