//Created By AncientTimes
using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a Fire Phoenix Corpse" )]
    public class DonatorFirePhoenix : BaseMount
	{
        [Constructable]
        public DonatorFirePhoenix(): this("-Fire Bird-")
		{
		}

		[Constructable]
        public DonatorFirePhoenix( string name ) : base(name, 243, 0x3E94, AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
		BaseSoundID = 0;
		Hue = 1256;

            SetStr(1500);
            SetDex(700);
            SetInt(500);

            SetHits(2500);
            SetStam(700);

            SetDamage(25, 35);

		SetDamageType( ResistanceType.Physical, 100 );

		SetResistance( ResistanceType.Physical, 75 );
            SetResistance( ResistanceType.Cold, 75 );
            SetResistance( ResistanceType.Fire, 85 );
            SetResistance( ResistanceType.Poison, 75 );
            SetResistance( ResistanceType.Energy, 75 );

		SetSkill( SkillName.MagicResist, 120.0 );
		SetSkill( SkillName.Tactics, 120.0 );
	      SetSkill( SkillName.Wrestling, 120.0 );
            SetSkill( SkillName.Anatomy, 120.0);
            SetSkill( SkillName.Healing, 120.0);
            SetSkill( SkillName.Magery, 120.0);
            SetSkill( SkillName.EvalInt, 120.0 );
	      SetSkill( SkillName.Meditation, 120.0 );


			Fame = 0;
			Karma = 1000;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 0.0;
		}
              public override int GetAngerSound()
		{
			return 0x4FE;
		}

		public override int GetIdleSound()
		{
			return 0x4FD;
		}

		public override int GetAttackSound()
		{
			return 0x4FC;
		}

		public override int GetHurtSound()
		{
			return 0x4FF;
		}

             public override bool CanHeal { get { return true; } }
             public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }
             public override bool HasBreath{ get{ return true; } } // fire breath enabled
             


		public DonatorFirePhoenix( Serial serial ) : base( serial ){
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