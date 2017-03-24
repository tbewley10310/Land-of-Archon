using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a charger's corpse" )]
	public class TrueChargerOfTheFallen : BaseMount
	{
        [Constructable]
        public TrueChargerOfTheFallen(): this("a true Charger of the fallen")
		{
		}

		[Constructable]
        public TrueChargerOfTheFallen( string name ) : base(name, 0x11C, 0x3E92, AIType.AI_Animal, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			BaseSoundID = 0xA8;

            SetStr(950);
            SetDex(148);
            SetInt(675);

            SetHits(1100);
            SetStam(135);

            SetDamage(29, 33);

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 75 );
            SetResistance( ResistanceType.Cold, 75 );
            SetResistance( ResistanceType.Fire, 75 );
            SetResistance( ResistanceType.Poison, 75 );
            SetResistance( ResistanceType.Energy, 75 );

			SetSkill( SkillName.MagicResist, 30.0 );
			SetSkill( SkillName.Tactics, 44.0 );
			SetSkill( SkillName.Wrestling, 44.0 );
            SetSkill( SkillName.Anatomy, 44.0);
            SetSkill( SkillName.Healing, 44.0);

			Fame = -1000;
			Karma = 1000;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 120;
		}

        public override bool CanHeal { get { return true; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public TrueChargerOfTheFallen( Serial serial ) : base( serial )
		{
		}

        public override void OnDoubleClickDead(Mobile from)
        {
            if (!from.Alive)
            {
                from.SendMessage("Dont Die Again!");
                from.Resurrect();

                from.PlaySound(0x214);
                from.FixedEffect(0x376A, 10, 16);
            }
            else
            {
                if (from == this.ControlMaster)
                {
                }
                else
                    from.SendMessage("That is not your horse!");
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