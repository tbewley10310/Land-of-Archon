//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 2/22/2015 3:02:41 PM
//=================================================

using System;
using Server;

namespace Server.Items
{
	public class NewbieLegs : LeatherLegs
	{

		[Constructable]
		public NewbieLegs()
		{
			Name = "Newbie Legs";
			Hue = 1910;
			LootType = LootType.Newbied;
			Attributes.DefendChance = 5;
			Attributes.BonusMana = 5;
			Attributes.BonusStam = 5;
			Attributes.BonusHits = 5;
			Attributes.Luck = 100;
			Attributes.WeaponDamage = 20;
			Attributes.SpellDamage = 20;
			Attributes.LowerRegCost = 10;
			MaxHitPoints = 200;
			HitPoints = 200;
			PhysicalBonus = 8;
			FireBonus = 6;
			ColdBonus = 7;
			PoisonBonus = 7;
			EnergyBonus = 7;
		}

		public NewbieLegs( Serial serial ) : base( serial )
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
