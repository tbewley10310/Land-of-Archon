using System;
using Server;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Items
{	
	
	public class HitchingPostEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new HitchingPostEastDeed(); } }

		[Constructable]
		public HitchingPostEastAddon()
		{
			new HitchingPost( );
		}

		public HitchingPostEastAddon( Serial serial ) : base( serial )
		{
		}

		#region Serialization
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
		#endregion
	}

	public class HitchingPostEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new HitchingPostEastAddon(); } }

		[Constructable]
		public HitchingPostEastDeed()
		{
			Name="Hitching Post (east)";
		}

		public HitchingPostEastDeed( Serial serial ) : base( serial )
		{
		}

		#region Serialization
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
		#endregion
	}

	
	public class HitchingPostSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new HitchingPostSouthDeed(); } }

		[Constructable]
		public HitchingPostSouthAddon()
		{
			new HitchingPost( );
		}

		public HitchingPostSouthAddon( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( 53, "ERROR: Addon no longer in use. A new addon deed has been added to your backpack" );
			
			from.AddToBackpack( new NewHitchingPostSouthDeed() );
		}

		#region Serialization
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
		#endregion
	}

	public class HitchingPostSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new HitchingPostSouthAddon(); } }

		[Constructable]
		public HitchingPostSouthDeed()
		{
			Name="Hitching Post (south)";
		}

		public HitchingPostSouthDeed( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( 53, "ERROR: Addon no longer in use. A new addon deed has been added to your backpack" );
			
			from.AddToBackpack( new NewHitchingPostEastDeed() );
		}

		#region Serialization
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
		#endregion
	}
}