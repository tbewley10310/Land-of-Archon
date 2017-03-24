using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0x185E, 0x185D )]
	public class PyroTechnicKit : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefFirework.CraftSystem; } }

		[Constructable]
		public PyroTechnicKit() : base( 0x185E )
		{
			Name = "Pyro Technic Kit";
			Weight = 2.0;
		}

		[Constructable]
		public PyroTechnicKit( int uses ) : base( uses, 0x185E )
		{
			Weight = 2.0;
		}

		public PyroTechnicKit( Serial serial ) : base( serial )
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