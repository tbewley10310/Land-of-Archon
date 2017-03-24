// Scripted by Thor86
using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a monster corpse")]
	public class RADM : BaseCreature
	{
        public static TimeSpan TalkDelay = TimeSpan.FromSeconds(10.0); //the delay between talks is 10 seconds
        public DateTime m_NextTalk;

      //  public override WeaponAbility GetWeaponAbility()
       // {
     //       return Utility.RandomBool() ? WeaponAbility.ConcussionBlow : WeaponAbility.FrenziedWhirlwind; // for diffent weaponabiltys look in WeaponAbility.cs
      //  }
        private static string[] m_Names = new string[]
		{
          "Dungeon Lord",
          "Har'Lakk",
          "Gravecreeper",
          "Dreadnaut",
          "Bal'lak",
          "Kal'Ger",
          "The Pummeller",
          "The Warmonger",
          "Witchstalker",
          "Pitchburn Devils",
          "Pyromaster",
          "Capashen Knight",
          "Xathrid Necromancer",
          "Young Pyromancer",
          "Tar'Kir"
		};

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (DateTime.Now >= m_NextTalk && InRange(m, 4) && InLOS(m)) // check if it's time to talk & mobile in range & in los.
            {
                m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
                switch (Utility.Random(5))
                {
                    case 0: Say("You Fight like a Mongbat"); //make it say ...
                        PlaySound(1066); //play giggle sound
                        break;
                    case 1: Say("Your a Noob");
                        PlaySound(1071); //play huh sound
                        break;
                    case 2: Say("Go back to Trammel!");
                        PlaySound(1055); //play clear throat sound
                        break; //
                    case 3: Say("You think you can kill me!");
                        PlaySound(1074); //play no!! sound
                        break;
                    case 4: Say("HA HA HA");
                        PlaySound(1067); //play groan sound
                        break;
                };
            }
        }

        public override WeaponAbility GetWeaponAbility() 
        {
            int ability = Utility.Random(3);
            if (ability == 1)
                return WeaponAbility.ConcussionBlow;
            else if (ability == 2)
                return WeaponAbility.BleedAttack;
            else
                return WeaponAbility.FrenziedWhirlwind;
        }
		
		[Constructable]
        public RADM()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.05, 0.2)    
		{
            // Name = "";
           // Title = "The ";
            Name = m_Names[Utility.Random(m_Names.Length)];
            Hue = Utility.RandomDyedHue();
            BaseSoundID = 357;
            switch (Utility.Random(13))
            {
                case 0: Body = 10; break;//summondeamon
                case 1: Body = 38; break;//blackgatedaemon
                case 2: Body = 46; break;//ancietwyrm
                case 3: Body = 76; break;//titan
                case 4: Body = 196; break;//yajuo
                case 5: Body = 199; break;//gauzenyo
                case 6: Body = 285; break;//reaper
                case 7: Body = 314; break; //ravger
                case 8: Body = 746; break; //4armdeamon
                case 9: Body = 752; break; //golem
                case 10: Body = 767; break; //betrayer
                case 11: Body = 796; break; //hordeminnion
                case 12: Body = 764; break; // juka
            }


			SetStr( 700, 800 );
			SetDex( 250, 350 );
			SetInt( 150, 250 );

            SetHits(5000, 6000);
            SetMana(1000);
            SetStam(202, 350);
	
			SetDamage( 10, 25 );

            SetDamageType(ResistanceType.Physical, 40);
            SetDamageType(ResistanceType.Fire, 20);
            SetDamageType(ResistanceType.Poison, 40);

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 60 );

            SetSkill(SkillName.EvalInt, 100.0, 120.0);
			SetSkill( SkillName.Magery, 100.0, 120.0 );
			SetSkill( SkillName.MagicResist, 100.0, 120.0 );
			SetSkill( SkillName.Swords, 100.0, 120.0 );
			SetSkill( SkillName.Tactics, 100.0, 120.0 );
			SetSkill( SkillName.Wrestling, 100.0, 120.0 );

			Fame = 5000;
			Karma = -5000;

            // PackGold(1000, 2500);

            VirtualArmor = 30;
          
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);
            if (Utility.RandomDouble() < 0.30) 
                c.DropItem(new RAD()); // random artifact deed for the random stat artifacts
        }


        public override void GenerateLoot()
        {
            AddLoot( LootPack.Rich );
            AddLoot( LootPack.Average, 2 ); 
        }

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 6; } }
        public override int Meat { get { return 19; } }
        public override int Hides { get { return 20; } }
        public override bool AutoDispel { get { return true; } }
        public override bool HasBreath { get { return true; } }
        public override bool BleedImmune { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Deadly; } }
        public override bool BreathImmune { get { return true; } }
        public override bool Unprovokable { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override Poison HitPoison { get { return Utility.RandomBool() ? Poison.Deadly : Poison.Lethal; } }

		public RADM( Serial serial ) : base( serial )
		{
		}

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