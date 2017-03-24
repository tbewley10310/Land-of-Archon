using System;
using Server;

namespace Server.Items
{
	public class RusticBenchEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new RusticBenchEastDeed(); } }

		public override bool RetainDeedHue{ get{ return true; } }

		[Constructable]
		public RusticBenchEastAddon() : this( 0 )
		{
		}

		[Constructable]
		public RusticBenchEastAddon( int hue )
		{
			AddComponent( new LocalizedAddonComponent( 0xE52, 1023664  ), 0, 1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xE53, 1023664 ), 0, 0, 0 );
			Hue = hue;
		}

		public RusticBenchEastAddon( Serial serial ) : base( serial )
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

	public class RusticBenchEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new RusticBenchEastAddon( this.Hue ); } }
		public override int LabelNumber{ get{ return 1150594; } } // rustic bench (east)

		[Constructable]
		public RusticBenchEastDeed()
		{
		}

		public RusticBenchEastDeed( Serial serial ) : base( serial )
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

	public class RusticBenchSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new RusticBenchSouthDeed(); } }

		public override bool RetainDeedHue{ get{ return true; } }

		[Constructable]
		public RusticBenchSouthAddon() : this( 0 )
		{
		}

		[Constructable]
		public RusticBenchSouthAddon( int hue )
		{
			AddComponent( new LocalizedAddonComponent( 0xE51, 1023664 ), 1, 0, 0 );
			AddComponent( new LocalizedAddonComponent( 0xE50, 1023664 ), 0, 0, 0 );
			Hue = hue;
		}

		public RusticBenchSouthAddon( Serial serial ) : base( serial )
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

	public class RusticBenchSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new RusticBenchSouthAddon( this.Hue ); } }
		public override int LabelNumber{ get{ return 1150593; } } // rustic bench (south)

		[Constructable]
		public RusticBenchSouthDeed()
		{
		}

		public RusticBenchSouthDeed( Serial serial ) : base( serial )
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