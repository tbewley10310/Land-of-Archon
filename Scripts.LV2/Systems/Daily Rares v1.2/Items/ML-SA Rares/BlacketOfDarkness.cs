using System;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Items
{
	[FlipableAttribute( 0xA57, 0xA58, 0xA59 )]
	public class BlanketOfDarkness : Item
	{
		[Constructable]
		public BlanketOfDarkness() : base( 0xA57 )
		{
			Name = "a blanket of darkness";
			Hue = 2949;
			Weight = 5.0;
		}

		public BlanketOfDarkness( Serial serial ) : base( serial )
		{
		}
		
		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1049644, "Daily Rare" );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( this.Parent != null || !this.VerifyMove( from ) )
				return;

			if ( !from.InRange( this, 2 ) )
			{
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
				return;
			}

			if ( this.ItemID == 0xA57 ) // rolled
			{
				Direction dir = PlayerMobile.GetDirection4( from.Location, this.Location );

				if ( dir == Direction.North || dir == Direction.South )
					this.ItemID = 0xA55;
				else
					this.ItemID = 0xA56;
			}
			else // unrolled
			{
				this.ItemID = 0xA57;

			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}