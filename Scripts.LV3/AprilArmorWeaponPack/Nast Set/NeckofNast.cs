using System;
using Server.Items;

namespace Server.Items
{
	public class NeckofNast : BaseArmor
	{
		 public override int ArtifactRarity{ get{return 5000; } }
		public override int BasePhysicalResistance{ get{ return 70; } }
		public override int BaseFireResistance{ get{ return 70; } }
		public override int BaseColdResistance{ get{ return 70; } }
		public override int BasePoisonResistance{ get{ return 70; } }
		public override int BaseEnergyResistance{ get{ return 70; } }

		public override int InitMinHits{ get{ return 561; } }
		public override int InitMaxHits{ get{ return 561; } }

		public override int AosStrReq{ get{ return 100; } }
		public override int OldStrReq{ get{ return 40; } }


                public override int AosDexReq{ get{ return 100; } }
		public override int OldDexBonus{ get{ return -2; } }

                public override int AosIntReq{ get{ return 100; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public NeckofNast() : base( 0x1413 )
		{
                    LootType = LootType.Blessed;
                   ArmorAttributes.MageArmor = 1;
                   Name = "Neck of Nast";
                   Hue = 1109;
			Weight = 2.0;
		}

		public NeckofNast( Serial serial ) : base( serial )
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