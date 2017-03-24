using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a unicorn queen's corpse" )]
	public class DonatorUnicornQueen : BaseMount
	{
        [Constructable]
        public DonatorUnicornQueen(): this("-Unicorn Queen-")
		{
		}

		[Constructable]
        public DonatorUnicornQueen( string name ) : base(name, 0x7A, 0x3EB4, AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			BaseSoundID = 0x4BC;
	    Hue = 1268;
            SetStr(1500);
            SetDex(700);
            SetInt(500);

            SetHits(2500);
            SetStam(700);
            SetMana(500);

            SetDamage(25, 35);

			SetDamageType( ResistanceType.Physical, 100 );

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
            SetSkill( SkillName.Magery, 120.0 );
            SetSkill( SkillName.Meditation, 120.0 );
            SetSkill( SkillName.EvalInt, 120.0 );
            SetSkill( SkillName.Healing, 120.0 );



			Fame = 0;
			Karma = 1000;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 0;
		}

        public override bool CanHeal { get { return true; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }
        public override Poison PoisonImmune{ get{ return Poison.Deadly; } }

        public DonatorUnicornQueen(Serial serial)
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