//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 2/22/2015 3:02:41 PM
//=================================================

using System;
using Server;

namespace Server.Items
{
	public class WelcomeShroud : HoodedShroudOfShadows
	{

		[Constructable]
		public WelcomeShroud()
		{
			Name = "The Grove: A New Beginning";
			Hue = 1910;
			LootType = LootType.Blessed;
			Attributes.LowerRegCost = 100;
			Attributes.SpellDamage = 50;
			Attributes.WeaponDamage = 50;
			Attributes.Luck = 250;
		}

		public WelcomeShroud( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

	}
}
