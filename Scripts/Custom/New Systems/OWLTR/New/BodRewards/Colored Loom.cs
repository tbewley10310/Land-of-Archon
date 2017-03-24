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
using Server.Multis;

namespace Server.Items
{
	public class ColoredLoomEastAddon : BaseAddon, ILoom, IChopable
	{
		public override BaseAddonDeed Deed{ get{ return new ColoredLoomEastDeed(); } }

		private int m_Phase;

		public int Phase{ get{ return m_Phase; } set{ m_Phase = value + 1; } }

		[Constructable]
		public ColoredLoomEastAddon() : this( 0 )
		{
		}

		[Constructable]
		public ColoredLoomEastAddon( int hue )
		{
			AddComponent( new AddonComponent( 0x1060 ), 0, 0, 0 );
			AddComponent( new AddonComponent( 0x105F ), 0, 1, 0 );
			Hue = hue;
		}

		public ColoredLoomEastAddon( Serial serial ) : base( serial )
		{
		}

		public override void OnChop( Mobile from )
		{
			BaseHouse house = BaseHouse.FindHouseAt( this );

			if ( house != null && house.IsOwner( from ) && house.Addons.Contains( this ) )
			{
				Effects.PlaySound( GetWorldLocation(), Map, 0x3B3 );
				from.SendLocalizedMessage( 500461 ); // You destroy the item.

				if (Deed != null)
					from.AddToBackpack( new ColoredLoomEastDeed( this.Hue ) );

				this.Delete();

				house.Addons.Remove( this );
			}
			else if ( from.AccessLevel > AccessLevel.Player )
			{
				if (Deed != null)
					from.AddToBackpack( new ColoredLoomEastDeed( this.Hue ) );

				this.Delete();
			}
			base.OnChop( from );
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int) m_Phase );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_Phase = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class ColoredLoomEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new ColoredLoomEastAddon( Hue ); } }
		public override int LabelNumber{ get{ return 1044343; } } // ColoredLoom (east)

		[Constructable]
		public ColoredLoomEastDeed() : this ( 0 )
		{
		}

		[Constructable]
		public ColoredLoomEastDeed( int hue )
		{
			Hue = hue;
		}

		public ColoredLoomEastDeed( Serial serial ) : base( serial )
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

	public class ColoredLoomSouthAddon : BaseAddon, ILoom, IChopable
	{
		public override BaseAddonDeed Deed{ get{ return new ColoredLoomSouthDeed(); } }

		private int m_Phase;

		public int Phase{ get{ return m_Phase; } set{ m_Phase = value + 1; } }

		[Constructable]
		public ColoredLoomSouthAddon() : this ( 0 )
		{
		}

		[Constructable]
		public ColoredLoomSouthAddon( int hue )
		{
			AddComponent( new AddonComponent( 0x1061 ), 0, 0, 0 );
			AddComponent( new AddonComponent( 0x1062 ), 1, 0, 0 );
			Hue = hue;
		}

		public ColoredLoomSouthAddon( Serial serial ) : base( serial )
		{
		}

		public override void OnChop( Mobile from )
		{
			BaseHouse house = BaseHouse.FindHouseAt( this );

			if ( house != null && house.IsOwner( from ) && house.Addons.Contains( this ) )
			{
				Effects.PlaySound( GetWorldLocation(), Map, 0x3B3 );
				from.SendLocalizedMessage( 500461 ); // You destroy the item.

				if (Deed != null)
					from.AddToBackpack( new ColoredLoomSouthDeed( this.Hue ) );

				this.Delete();

				house.Addons.Remove( this );
			}
			else if ( from.AccessLevel > AccessLevel.Player )
			{
				if (Deed != null)
					from.AddToBackpack( new ColoredLoomSouthDeed( this.Hue ) );

				this.Delete();
			}
			base.OnChop( from );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int) m_Phase );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_Phase = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class ColoredLoomSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new ColoredLoomSouthAddon( Hue ); } }
		public override int LabelNumber{ get{ return 1044344; } } // ColoredLoom (south)

		[Constructable]
		public ColoredLoomSouthDeed() : this ( 0 )
		{
		}

		[Constructable]
		public ColoredLoomSouthDeed( int hue )
		{
			Hue = hue;
		}

		public ColoredLoomSouthDeed( Serial serial ) : base( serial )
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