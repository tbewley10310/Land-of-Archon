using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class Shark : Item
	{
		[Constructable]
		public Shark() : base( 8443 ) 
		{
			Name = "a small shark";
			Stackable = false;
			Weight = 60.0;
		}


		public Shark( Serial serial ) : base( serial )
		{
		}
		public override bool IsAccessibleTo( Mobile check )
		{
				return true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage("---------------------------");
			from.SendMessage("The shark statue seems to writhe in your hands and a voracious, unthinking hunger fills your mind. Your eyes stare relentlessly outward, seeking prey.");
			from.SendMessage("....");
			from.SendMessage("....after awhile you drop the statue and shiver as cold waves ripple down your spine.");
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
