//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 2/22/2015 5:45:50 PM
//=================================================

using System;
using Server;

namespace Server.Items
{
	public class MayTheBowBeWithYou : Yumi
	{
		public override int ArtifactRarity{ get{ return 26; } }
		public override int InitMinHits{ get{ return 200; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public MayTheBowBeWithYou()
		{
			Name = "May The Bow Be With You";
			Hue = 1152;
			Attributes.AttackChance = 10;
			Attributes.DefendChance = 10;
			Attributes.WeaponDamage = 50;
			Attributes.SpellDamage = 50;
			Attributes.SpellChanneling = 1;
			Attributes.LowerRegCost = 25;
			Attributes.WeaponSpeed = 10;
			Attributes.RegenHits = 5;
			Attributes.RegenStam = 5;
			Attributes.RegenMana = 5;
			WeaponAttributes.SelfRepair = 3;
			WeaponAttributes.HitLeechStam = 50;
			WeaponAttributes.HitLeechMana = 50;
			WeaponAttributes.HitLeechHits = 50;
			WeaponAttributes.HitFireball = 47;
			WeaponAttributes.HitMagicArrow = 48;
			WeaponAttributes.HitLightning = 50;
			WeaponAttributes.HitHarm = 62;
			WeaponAttributes.DurabilityBonus = 20;
		}

		public MayTheBowBeWithYou( Serial serial ) : base( serial )
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
