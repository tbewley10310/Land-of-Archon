/////////////////////////////////////////////////
//                                             //
// Automatically generated by the              //
// AddonGenerator script by Arya               //
//                                             //
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class CozySandstoneFireplaceEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new CozySandstoneFireplaceEastAddonDeed();
			}
		}

		[ Constructable ]
		public CozySandstoneFireplaceEastAddon()
		{
			AddComponent( new AddonComponent( 968 ), 0, 1, 1 );
			AddComponent( new AddonComponent( 1997 ), 0, 1, 21 );
			AddComponent( new AddonComponent( 1301 ), 0, 1, 1 );
			AddComponent( new AddonComponent( 5364 ), 0, 0, 22 );
			AddComponent( new AddonComponent( 3561 ), 0, 0, 2 );
			AddComponent( new AddonComponent( 1301 ), 0, 0, 1 );
			AddComponent( new AddonComponent( 3562 ), 0, 0, 4 );
			AddComponent( new AddonComponent( 1997 ), 0, 0, 21 );
			AddComponent( new AddonComponent( 7128 ), 0, 0, 1 );
			AddComponent( new AddonComponent( 3555 ), 0, 0, 5 );
			AddComponent( new AddonComponent( 1301 ), 0, -1, 1 );
			AddComponent( new AddonComponent( 3555 ), 0, -1, 4 );
			AddComponent( new AddonComponent( 1997 ), 0, -1, 21 );
			AddComponent( new AddonComponent( 3562 ), 0, -1, 4 );
			AddComponent( new AddonComponent( 3561 ), 0, -1, 2 );
			AddComponent( new AddonComponent( 7128 ), 0, -1, 1 );
			AddComponent( new AddonComponent( 968 ), 0, -2, 1 );
			AddComponent( new AddonComponent( 1181 ), 0, -2, 1 );
			AddComponent( new AddonComponent( 969 ), 0, -2, 1 );
			AddComponent( new AddonComponent( 1997 ), 0, -2, 21 );
			AddComponent( new AddonComponent( 969 ), -1, 2, 1 );
			AddComponent( new AddonComponent( 969 ), -1, 1, 1 );
			AddComponent( new AddonComponent( 968 ), 0, -3, 1 );
			AddComponent( new AddonComponent( 2232 ), -1, 3, 1 );
			AddComponent( new AddonComponent( 969 ), -1, -2, 1 );
			AddComponent( new AddonComponent( 970 ), -1, -3, 1 );
			AddComponent( new AddonComponent( 969 ), -1, 0, 1 );
			AddComponent( new AddonComponent( 969 ), -1, -1, 1 );
			AddComponent( new AddonComponent( 5534 ), 1, 2, 3 );
			AddComponent( new AddonComponent( 2557 ), 1, 2, 13 );
			AddComponent( new AddonComponent( 5534 ), 1, -2, 3 );
			AddComponent( new AddonComponent( 2557 ), 1, -2, 13 );
			AddComponent( new AddonComponent( 2231 ), 0, 3, 1 );
			AddComponent( new AddonComponent( 1181 ), 0, 3, 1 );
			AddComponent( new AddonComponent( 7138 ), 0, 3, 0 );
			AddComponent( new AddonComponent( 967 ), 0, 2, 1 );
			AddComponent( new AddonComponent( 1181 ), 0, 2, 1 );
			AddComponent( new AddonComponent( 1997 ), 0, 2, 21 );
			AddonComponent ac;
			ac = new AddonComponent( 2231 );
			AddComponent( ac, 0, 3, 1 );
			ac = new AddonComponent( 1301 );
			AddComponent( ac, 0, -1, 1 );
			ac = new AddonComponent( 5364 );
			AddComponent( ac, 0, 0, 22 );
			ac = new AddonComponent( 3555 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, 0, -1, 4 );
			ac = new AddonComponent( 1997 );
			AddComponent( ac, 0, -1, 21 );
			ac = new AddonComponent( 3561 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, 0, 0, 2 );
			ac = new AddonComponent( 968 );
			AddComponent( ac, 0, -2, 1 );
			ac = new AddonComponent( 970 );
			AddComponent( ac, -1, -3, 1 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, 3, 1 );
			ac = new AddonComponent( 3562 );
			AddComponent( ac, 0, -1, 4 );
			ac = new AddonComponent( 968 );
			AddComponent( ac, 0, -3, 1 );
			ac = new AddonComponent( 969 );
			AddComponent( ac, -1, 2, 1 );
			ac = new AddonComponent( 1301 );
			AddComponent( ac, 0, 0, 1 );
			ac = new AddonComponent( 2232 );
			AddComponent( ac, -1, 3, 1 );
			ac = new AddonComponent( 3562 );
			AddComponent( ac, 0, 0, 4 );
			ac = new AddonComponent( 3561 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, 0, -1, 2 );
			ac = new AddonComponent( 967 );
			AddComponent( ac, 0, 2, 1 );
			ac = new AddonComponent( 969 );
			AddComponent( ac, -1, -2, 1 );
			ac = new AddonComponent( 969 );
			AddComponent( ac, -1, -1, 1 );
			ac = new AddonComponent( 968 );
			AddComponent( ac, 0, 1, 1 );
			ac = new AddonComponent( 969 );
			AddComponent( ac, -1, 0, 1 );
			ac = new AddonComponent( 969 );
			AddComponent( ac, -1, 1, 1 );
			ac = new AddonComponent( 7138 );
			AddComponent( ac, 0, 3, 0 );
			ac = new AddonComponent( 1997 );
			AddComponent( ac, 0, 0, 21 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, -2, 1 );
			ac = new AddonComponent( 1181 );
			AddComponent( ac, 0, 2, 1 );
			ac = new AddonComponent( 969 );
			AddComponent( ac, 0, -2, 1 );
			ac = new AddonComponent( 7128 );
			AddComponent( ac, 0, -1, 1 );
			ac = new AddonComponent( 7128 );
			AddComponent( ac, 0, 0, 1 );
			ac = new AddonComponent( 1997 );
			AddComponent( ac, 0, 1, 21 );
			ac = new AddonComponent( 5534 );
			ac.Hue = 42;
			AddComponent( ac, 1, 2, 3 );
			ac = new AddonComponent( 5534 );
			ac.Hue = 42;
			AddComponent( ac, 1, -2, 3 );
			ac = new AddonComponent( 2557 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, 1, -2, 13 );
			ac = new AddonComponent( 2557 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, 1, 2, 13 );
			ac = new AddonComponent( 3555 );
			ac.Light = LightType.Circle225;
			AddComponent( ac, 0, 0, 5 );
			ac = new AddonComponent( 1301 );
			AddComponent( ac, 0, 1, 1 );
			ac = new AddonComponent( 1997 );
			AddComponent( ac, 0, -2, 21 );
			ac = new AddonComponent( 1997 );
			AddComponent( ac, 0, 2, 21 );

		}

		public CozySandstoneFireplaceEastAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class CozySandstoneFireplaceEastAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new CozySandstoneFireplaceEastAddon();
			}
		}

		[Constructable]
		public CozySandstoneFireplaceEastAddonDeed()
		{
			Name = "CozySandstoneFireplaceEast";
		}

		public CozySandstoneFireplaceEastAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}