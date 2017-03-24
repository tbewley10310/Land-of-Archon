// Made by RANCID77 aka EARL...
// I dont care if you use this as a base or modify it...
// Just plz leave this header.. thnx ...
using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0xf9f, 0xf9e )]
	public class SewingShears : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefSewing.CraftSystem; } }

		[Constructable]
		public SewingShears() : base( 0xF9F )
		{
			Weight = 2.0;
			Hue = 1177;
			Name = "Sewing Shears";
		}

		[Constructable]
		public SewingShears( int uses ) : base( uses, 0xF9F )
		{
			Weight = 2.0;
		}

		public SewingShears( Serial serial ) : base( serial )
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