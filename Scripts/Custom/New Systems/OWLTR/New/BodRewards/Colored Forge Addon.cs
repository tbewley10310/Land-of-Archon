/*
 created by:
     /\            888                   888     .d8888b.   .d8888b.  
____/_ \____       888                   888    d88P  Y88b d88P  Y88b 
\  ___\ \  /       888                   888    888    888 888    888 
 \/ /  \/ /    .d88888  8888b.   8888b.  888888 Y88b. d888 Y88b. d888 
 / /\__/_/\   d88" 888     "88b     "88b 888     "Y888P888  "Y888P888 
/__\ \_____\  888  888 .d888888 .d888888 888           888        888 
    \  /      Y88b 888 888  888 888  888 Y88b.  Y88b  d88P Y88b  d88P 
     \/        "Y88888 "Y888888 "Y888888  "Y888  "Y8888P"   "Y8888P"  
*/

namespace Server.Items
{
	public class ColoredForgeAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new ColoredForgeDeed(); } }

		[Constructable]
		public ColoredForgeAddon() : this ( 0 )
		{
		}
		[Constructable]
		public ColoredForgeAddon( int hue )
		{
			AddComponent( new ForgeComponent( 0xFB1 ), 0, 0, 0 );
			Hue = hue;
		}

		public ColoredForgeAddon( Serial serial ) : base( serial )
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

	public class ColoredForgeDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new ColoredForgeAddon( Hue ); } }
		public override int LabelNumber{ get{ return 1044330; } } // small forge

		[Constructable]
		public ColoredForgeDeed() : this ( 0 )
		{
		}
		
		[Constructable]
		public ColoredForgeDeed( int hue )
		{
			Hue = hue;
		}

		public ColoredForgeDeed( Serial serial ) : base( serial )
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