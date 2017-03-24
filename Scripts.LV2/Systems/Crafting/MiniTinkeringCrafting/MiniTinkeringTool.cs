// Made by RANCID77 aka EARL...
// I dont care if you use this as a base or modify it...
// Just plz leave this header.. thnx ...
using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0x1EB8, 0x1EB9 )]
	public class MiniTinkeringTool : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefMiniTinkering.CraftSystem; } }

		[Constructable]
		public MiniTinkeringTool() : base( 0x1EB8 )
		{
			Weight = 2.0;
			Hue = 32;
			Name = "Mini Tinkering Tool";
		}

		[Constructable]
		public  MiniTinkeringTool( int uses ) : base( uses, 0x1EB8 )
		{
			Weight = 2.0;
		}

		public MiniTinkeringTool( Serial serial ) : base( serial )
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