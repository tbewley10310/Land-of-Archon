using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ancient hellhound corpse" )]
    public class RidableAncientHellHound : BaseMount
	{
        [Constructable]
        public RidableAncientHellHound()
            : this("an ancient hellhound")
        {
        }

		[Constructable]
        public RidableAncientHellHound(string name)
            : base(name, 0x42D, 0x3EC9, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
		{
            //Body = 1069;
            //ItemID = 16073;
			BaseSoundID = 229;

            SetStr( 1402, 1402);
            SetDex( 243, 322);
            SetInt( 1079, 1079);

			SetHits( 2050, 2200 );

			SetDamage( 20, 30 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Fire, 80 );

			SetResistance( ResistanceType.Physical, 56, 56 );
			SetResistance( ResistanceType.Fire, 83, 83 );
			SetResistance( ResistanceType.Cold, 40, 40 );
			SetResistance( ResistanceType.Poison, 75, 75 );
			SetResistance( ResistanceType.Energy, 67, 67 );

			SetSkill( SkillName.MagicResist, 105.1, 115.0 );
			SetSkill( SkillName.Anatomy, 105.1, 128.0 );
			SetSkill( SkillName.Tactics, 102.1, 120.0 );
			SetSkill( SkillName.Wrestling, 111.1, 119.0 );
			
			Fame = 24000;
			Karma = -24000;
            Tamable = true;
            ControlSlots = 5;
            MinTameSkill = 105;
		}

        public override FoodType FavoriteFood { get { return FoodType.Meat; } }

        public RidableAncientHellHound(Serial serial)
            : base(serial)
        {
        }

		public override bool BardImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override int TreasureMapLevel { get { return 5; } }
		public override int Meat { get { return 16; } }
		public override int Hides { get { return 20; } }
		public override HideType HideType { get { return HideType.Horned; } }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
