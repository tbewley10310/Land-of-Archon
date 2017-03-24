using System;
using System.Collections;
using Server.Items;
using Server.Multis;
using Server.Mobiles;
using Server.Network;

namespace Server.Custom
{
	public class CustomBag : Bag
	{
		public void EnhanceWeapon( Item item, string name )
		{
			if ( item is BaseWeapon )
			{
				BaseWeapon weap = item as BaseWeapon;
				int num = Utility.Random( 3, 5 );
				for (int count = 0; count<num; count++)
				{
					int attribute = Utility.RandomMinMax( 1, 25 );
					switch( attribute )
					{
						case (int)CustomWeaponAttributes.LowerStatReq:
						{
							weap.WeaponAttributes.LowerStatReq = Utility.RandomMinMax( 4, 10 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.SelfRepair:
						{
							weap.WeaponAttributes.SelfRepair = Utility.RandomMinMax( 3, 12 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitLeechHits:
						{
							weap.WeaponAttributes.HitLeechHits = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitLeechStam:
						{
							weap.WeaponAttributes.HitLeechStam = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitLeechMana:
						{
							weap.WeaponAttributes.HitLeechMana = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitLowerAttack:
						{
							weap.WeaponAttributes.HitLowerAttack = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitLowerDefend:
						{
							weap.WeaponAttributes.HitLowerDefend = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitMagicArrow:
						{
							weap.WeaponAttributes.HitMagicArrow = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitHarm:
						{
							weap.WeaponAttributes.HitHarm = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitFireball:
						{
							weap.WeaponAttributes.HitFireball = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitLightning:
						{
							weap.WeaponAttributes.HitLightning = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitDispel:
						{
							weap.WeaponAttributes.HitDispel = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitColdArea:
						{
							weap.WeaponAttributes.HitColdArea = Utility.RandomMinMax( 2, 16 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitFireArea:
						{
							weap.WeaponAttributes.HitFireArea = Utility.RandomMinMax( 2, 16 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitPoisonArea:
						{
							weap.WeaponAttributes.HitPoisonArea = Utility.RandomMinMax( 2, 16 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitEnergyArea:
						{
							weap.WeaponAttributes.HitEnergyArea = Utility.RandomMinMax( 2, 16 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.HitPhysicalArea:
						{
							weap.WeaponAttributes.HitPhysicalArea = Utility.RandomMinMax( 2, 16 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.ResistPhysicalBonus:
						{
							weap.WeaponAttributes.ResistPhysicalBonus = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.ResistFireBonus:
						{
							weap.WeaponAttributes.ResistFireBonus = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.ResistColdBonus:
						{
							weap.WeaponAttributes.ResistColdBonus = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.ResistPoisonBonus:
						{
							weap.WeaponAttributes.ResistPoisonBonus = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.ResistEnergyBonus:
						{
							weap.WeaponAttributes.ResistEnergyBonus = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomWeaponAttributes.UseBestSkill:
						{
							weap.WeaponAttributes.UseBestSkill = 1;
							goto case 99;
						}
						case (int)CustomWeaponAttributes.MageWeapon:
						{
							weap.WeaponAttributes.MageWeapon = 1;
							goto case 99;
						}
						case (int)CustomWeaponAttributes.DurabilityBonus:
						{
							weap.WeaponAttributes.DurabilityBonus = Utility.RandomMinMax( 20, 50 );
							goto case 99;
						}
						case 99:
						{
							weap.PropertyList.Add( name );
							break;
						}
						default: break;
					}
				}
			}
		}
	
		public void EnhanceArmor( Item item, string name )
		{
			if ( item is BaseArmor )
			{
				BaseArmor armor = item as BaseArmor;
				int num = Utility.RandomMinMax( 3, 5 );
				for (int count = 0; count<num; count++)
				{
					int attribute = Utility.RandomMinMax( 1, 25 );
					switch( attribute )
					{
						case (int)CustomArmorAttributes.RegenHits:
						{
							armor.Attributes.RegenHits = Utility.RandomMinMax( 5, 25 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.RegenStam:
						{
							armor.Attributes.RegenStam = Utility.RandomMinMax( 5, 25 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.RegenMana:
						{
							armor.Attributes.RegenMana = Utility.RandomMinMax( 5, 25 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.DefendChance:
						{
							armor.Attributes.DefendChance = Utility.RandomMinMax( 5, 40 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.AttackChance:
						{
							armor.Attributes.AttackChance = Utility.RandomMinMax( 5, 40 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusStr:
						{
							armor.Attributes.BonusStr = Utility.RandomMinMax( 2, 20 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusDex:
						{
							armor.Attributes.BonusDex = Utility.RandomMinMax( 2, 20 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusInt:
						{
							armor.Attributes.BonusInt = Utility.RandomMinMax( 2, 20 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusHits:
						{
							armor.Attributes.BonusHits = Utility.RandomMinMax( 5, 50 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusStam:
						{
							armor.Attributes.BonusStam = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusMana:
						{
							armor.Attributes.BonusMana = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.WeaponDamage:
						{
							armor.Attributes.WeaponDamage = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.WeaponSpeed:
						{
							armor.Attributes.WeaponSpeed = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.SpellDamage:
						{
							armor.Attributes.SpellDamage = Utility.RandomMinMax( 10, 40 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.CastRecovery:
						{
							armor.Attributes.CastRecovery = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.CastSpeed:
						{
							armor.Attributes.CastSpeed = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.LowerManaCost:
						{
							armor.Attributes.LowerManaCost = Utility.RandomMinMax( 4, 30 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.LowerRegCost:
						{
							armor.Attributes.LowerRegCost = Utility.RandomMinMax( 10, 25 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.ReflectPhysical:
						{
							armor.Attributes.ReflectPhysical = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.EnhancePotions:
						{
							armor.Attributes.EnhancePotions = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.Luck:
						{
							armor.Attributes.Luck = Utility.RandomMinMax( 10, 200 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.SpellChanneling:
						{
							armor.Attributes.SpellChanneling = 1;
							goto case 99;
						}
						case (int)CustomArmorAttributes.NightSight:
						{
							armor.Attributes.NightSight = 1;
							goto case 99;
						}
						case 99:
						{
							armor.PropertyList.Add( name );
							break;
						}
						default: break;
					}
				}
			}
		}
	
		public void EnhanceJewel( Item item, string name )
		{
			if ( item is BaseJewel )
			{
				BaseJewel jewel = item as BaseJewel;
				int num = Utility.RandomMinMax( 3, 5 );
				for (int count = 0; count<num; count++)
				{
					int attribute = Utility.RandomMinMax( 1, 24 );
					switch( attribute )
					{
						case (int)CustomArmorAttributes.RegenHits:
						{
							jewel.Attributes.RegenHits = Utility.RandomMinMax( 5, 25 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.RegenStam:
						{
							jewel.Attributes.RegenStam = Utility.RandomMinMax( 5, 25 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.RegenMana:
						{
							jewel.Attributes.RegenMana = Utility.RandomMinMax( 5, 25 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.DefendChance:
						{
							jewel.Attributes.DefendChance = Utility.RandomMinMax( 5, 40 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.AttackChance:
						{
							jewel.Attributes.AttackChance = Utility.RandomMinMax( 5, 40 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusStr:
						{
							jewel.Attributes.BonusStr = Utility.RandomMinMax( 2, 20 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusDex:
						{
							jewel.Attributes.BonusDex = Utility.RandomMinMax( 2, 20 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusInt:
						{
							jewel.Attributes.BonusInt = Utility.RandomMinMax( 2, 20 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusHits:
						{
							jewel.Attributes.BonusHits = Utility.RandomMinMax( 5, 50 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusStam:
						{
							jewel.Attributes.BonusStam = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.BonusMana:
						{
							jewel.Attributes.BonusMana = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.WeaponDamage:
						{
							jewel.Attributes.WeaponDamage = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.WeaponSpeed:
						{
							jewel.Attributes.WeaponSpeed = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.SpellDamage:
						{
							jewel.Attributes.SpellDamage = Utility.RandomMinMax( 10, 40 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.CastRecovery:
						{
							jewel.Attributes.CastRecovery = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.CastSpeed:
						{
							jewel.Attributes.CastSpeed = Utility.RandomMinMax( 5, 30 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.LowerManaCost:
						{
							jewel.Attributes.LowerManaCost = Utility.RandomMinMax( 4, 30 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.LowerRegCost:
						{
							jewel.Attributes.LowerRegCost = Utility.RandomMinMax( 10, 25 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.ReflectPhysical:
						{
							jewel.Attributes.ReflectPhysical = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.EnhancePotions:
						{
							jewel.Attributes.EnhancePotions = Utility.RandomMinMax( 10, 50 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.Luck:
						{
							jewel.Attributes.Luck = Utility.RandomMinMax( 10, 200 );
							goto case 99;
						}
						case (int)CustomArmorAttributes.NightSight:
						{
							jewel.Attributes.NightSight = 1;
							goto case 99;
						}
						case 99:
						{
							jewel.PropertyList.Add( name );
							break;
						}
						default: break;
					}
				}
			}
		}

		[Constructable]
		public CustomBag() : base()
		{
			Name = "Custom Bag";
			Weight = 2.0;
		}

		public CustomBag( Serial serial ) : base( serial )
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