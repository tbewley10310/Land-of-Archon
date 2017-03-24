using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a charger's corpse" )]
	public class HorseOfTheCavalry : BaseMount
	{
        [Constructable]
        public HorseOfTheCavalry(): this("a horse of the cavalry")
		{
		}

		[Constructable]
        public HorseOfTheCavalry( string name ) : base(name, 0x11C, 0x3E92, AIType.AI_Animal, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			BaseSoundID = 0xA8;

            SetStr(900);
            SetDex(148);
            SetInt(475);
            
            SetHits(999);
            SetStam(135);

            SetDamage(15, 25);

			SetDamageType( ResistanceType.Physical, 100 );
            SetDamageType(ResistanceType.Energy, 100);

			SetResistance( ResistanceType.Physical, 65 );
            SetResistance( ResistanceType.Cold, 65 );
            SetResistance( ResistanceType.Fire, 65 );
            SetResistance( ResistanceType.Poison, 65 );
            SetResistance( ResistanceType.Energy, 65 );

			SetSkill( SkillName.MagicResist, 30.0 );
			SetSkill( SkillName.Tactics, 44.0 );
			SetSkill( SkillName.Wrestling, 44.0 );
            SetSkill( SkillName.Anatomy, 44.0);
            SetSkill( SkillName.Healing, 44.0);

			Fame = -1000;
			Karma = 1000;

			Tamable = true;
			ControlSlots = 5;
			MinTameSkill = 110;
		}

        public override bool CanHeal { get { return true; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public HorseOfTheCavalry( Serial serial ) : base( serial )
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