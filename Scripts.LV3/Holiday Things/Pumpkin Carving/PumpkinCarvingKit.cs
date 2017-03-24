using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
    [Flipable(0x992D, 0x992E)]
	public class PumpkinCarvingKit : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefPumpkinCarve.CraftSystem; } }

		[Constructable]
		public PumpkinCarvingKit() : base( 0x992D )
		{
            this.Weight = 1.0;
            this.Hue = 0x3CC;
            this.Name = "Jack O' Lantern Carving Kit";
		}

		[Constructable]
        public PumpkinCarvingKit(int uses)
            : base(uses, 0x992D)
		{
			this.Weight = 1.0;
		}

        public PumpkinCarvingKit(Serial serial)
            : base(serial)
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
