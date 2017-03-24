using System;

namespace Server.Items
{

	public class OrcMask : BaseHat
	{
		[Constructable]
		public OrcMask() : this( 0x96C )
		{
		}

		[Constructable]
		public OrcMask( int hue ) : base( 0x141B, hue )
		{
			Weight = 2.0;
                        Movable = false;
			Name = "eine orkische Fratze";
		}

		public override void OnAdded( object parent )
		{
			base.OnAdded( parent );

			if ( parent is Mobile )
				Misc.Titles.AwardKarma( (Mobile)parent, -20, true );
		}

		public OrcMask( Serial serial ) : base( serial )
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

			if ( Hue != 0x96C )
				Hue = 0x96C;
		}
	}

}