using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0xFB5, 0xFB4 )]
	public class GemHammer : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefGemCraft.CraftSystem; } }
       
		[Constructable]
		public GemHammer() : base( 0xFB5 )
		{
			Layer = Layer.OneHanded;
            Name = "Gem Hammer";
            Hue = 188;
		}

		[Constructable]
		public GemHammer( int uses ) : base( uses, 0xFB5 )
		{
			Layer = Layer.OneHanded;
		}

        public GemHammer(Serial serial)
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
