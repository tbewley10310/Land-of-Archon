using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a charger's corpse" )]
	public class DonatorHorseOfTheCavalry : BaseMount
	{
        [Constructable]
        public DonatorHorseOfTheCavalry(): this("-Diamond Coat-")
		{
		}

		[Constructable]
        public DonatorHorseOfTheCavalry( string name ) : base(name, 0x11C, 0x3E92, AIType.AI_Animal, FightMode.Closest, 10, 1, 0.175, 0.275)
		{
			BaseSoundID = 0xA8;
            Hue = (1153);
            SetStr(1500);
            SetDex(700);
            SetInt(500);

            SetHits(2500);
            SetStam(700);

            SetDamage(25, 45);

			SetDamageType( ResistanceType.Physical, 100 );
            SetDamageType(ResistanceType.Cold, 50);
            SetDamageType(ResistanceType.Fire, 50);
            SetDamageType(ResistanceType.Poison, 50);
            SetDamageType(ResistanceType.Energy, 50);

			SetResistance( ResistanceType.Physical, 75 );
            SetResistance( ResistanceType.Cold, 75 );
            SetResistance( ResistanceType.Fire, 75 );
            SetResistance( ResistanceType.Poison, 75 );
            SetResistance( ResistanceType.Energy, 75 );

			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 120.0 );
            SetSkill( SkillName.Anatomy, 120.0);
            SetSkill( SkillName.Healing, 120.0);

			Fame = 0;
			Karma = 1000;

			Tamable = true;
			ControlSlots = 5;
			MinTameSkill = 0;
		}

        public override bool CanHeal { get { return true; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public DonatorHorseOfTheCavalry(Serial serial)
            : base(serial)
		{
		}

        public override void OnDoubleClickDead(Mobile from)
        {
            if (!from.Alive)
            {
                from.Resurrect();

                from.PlaySound(0x214);
                from.FixedEffect(0x376A, 10, 16);
            }
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