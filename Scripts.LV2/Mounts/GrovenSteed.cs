using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a groven corpse" )]
	public class GrovenSteed : BaseMount
	{
        [Constructable]
        public GrovenSteed(): this("Groven Steed")
		{
		}

		[Constructable]
        public GrovenSteed( string name ) : base(name, 0x11C, 0x3E92, AIType.AI_Animal, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			BaseSoundID = 0xA8;

            SetStr(150,900);
            SetDex(100, 160);
            SetInt(120, 475);
            Hue = 1910;
            SetHits(150, 999);
            SetStam(100, 190);

            SetDamage(12, 21);

			SetDamageType( ResistanceType.Physical, 100 );
            SetDamageType(ResistanceType.Energy, 100);

			SetResistance( ResistanceType.Physical, 65 );
            SetResistance( ResistanceType.Cold, 65 );
            SetResistance( ResistanceType.Fire, 65 );
            SetResistance( ResistanceType.Poison, 65 );
            SetResistance( ResistanceType.Energy, 65 );

			SetSkill( SkillName.MagicResist, 30.0, 125.0 );
			SetSkill( SkillName.Tactics, 44.0, 125.0 );
			SetSkill( SkillName.Wrestling, 44.0, 125.0 );
            SetSkill( SkillName.Anatomy, 44.0, 125.0);
            SetSkill( SkillName.Healing, 44.0, 125.0);

			Fame = -1000;
			Karma = 1000;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 105;
		}

        public override bool CanHeal { get { return true; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public GrovenSteed( Serial serial ) : base( serial )
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