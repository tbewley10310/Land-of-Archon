using System;
using Server.Items;

namespace Server.Items
{
	public class MiniGuillotine : Item
	{
		[Constructable]
		public MiniGuillotine() : base( 0x3F27 )
		{
			Weight = 1.0;
			Name = "Mini Guillotine";
			Movable = true;
		}

		public MiniGuillotine( Serial serial ) : base( serial )
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