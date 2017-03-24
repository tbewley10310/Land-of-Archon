using System;
using Server.Items;

namespace Server.Items
{
	[Flipable]
	public class GargishWornExplorerArms : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 200; } }
		public override int InitMaxHits{ get{ return 240; } }

		public override int AosStrReq{ get{ return 20; } }
		public override int OldStrReq{ get{ return 15; } }

		public override int ArmorBase{ get{ return 13; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }
		
		public override Race RequiredRace{ get { return Race.Gargoyle; } }
		
		public override bool CanBeWornByGargoyles{ get{ return true; } }


		[Constructable]
		public GargishWornExplorerArms() : base( 0x0302 )
		{
            Name = "Worn Explorer Arms";
            Hue = 1366;
            Attributes.LowerRegCost = 15;
            Attributes.LowerManaCost = 5;
            Attributes.BonusHits = 5;
            Attributes.Luck = 25;
            Attributes.ReflectPhysical = 5;
            Attributes.SpellDamage = 5;
            LootType = LootType.Cursed;
            Weight = 2.0;
		}

        public GargishWornExplorerArms(Serial serial)
            : base(serial)
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

			if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}
}