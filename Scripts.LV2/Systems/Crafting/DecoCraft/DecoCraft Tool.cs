using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class DecoCraftTool : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefDecoCraft.CraftSystem; } }

		[Constructable]
		public DecoCraftTool() : base( 7866 )
		{
			Weight = 2.0;
			Name = "DecoCraft Tool";
		}

		[Constructable]
        public DecoCraftTool(int uses)
            : base(uses, 7866)
		{
			Weight = 2.0;
            Name = "DecoCraft Tool";
		}

		public DecoCraftTool( Serial serial ) : base( serial )
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