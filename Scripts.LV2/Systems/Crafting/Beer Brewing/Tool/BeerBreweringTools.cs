using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class BeerBreweringTools : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefBeerBrewing.CraftSystem; } }

		[Constructable]
		public BeerBreweringTools() : base( 0xE7F )
		{
			Name = "a Beer Brewers Tools";
			Weight = 2.0;
		}

		[Constructable]
		public BeerBreweringTools( int uses ) : base( uses, 0xE7F )
		{
			Weight = 2.0;
		}

		public BeerBreweringTools( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}
}