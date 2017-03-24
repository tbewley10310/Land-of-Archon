// Scripted by Thor86
using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a hobbit corpse")]
	public class Gollum : BaseCreature
	{
        public static TimeSpan TalkDelay = TimeSpan.FromSeconds(10.0); //the delay between talks is 10 seconds
        public DateTime m_NextTalk;

      //  public override WeaponAbility GetWeaponAbility()
       // {
     //       return Utility.RandomBool() ? WeaponAbility.ConcussionBlow : WeaponAbility.FrenziedWhirlwind; // for diffent weaponabiltys look in WeaponAbility.cs
      //  }
        private static string[] m_Names = new string[]
		{
          "Gollum",
          "Sméagol"
		};

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (DateTime.Now >= m_NextTalk && InRange(m, 4) && InLOS(m)) // check if it's time to talk & mobile in range & in los.
            {
                m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
                switch (Utility.Random(7))
                {
                    case 0: Say("My Precious"); //make it say ...
                        PlaySound(1066); //play giggle sound
                        break;
                    case 1: Say("Precious");
                        PlaySound(1071); //play huh sound
                        break;
                    case 2: Say("We wants it, we needs it. Must have the precious. They stole it from us. Sneaky little hobbitses. Wicked, tricksy, false!");
                        PlaySound(1055); //play clear throat sound
                        break; //
                    case 3: Say("You don't have any friends; nobody likes you!");
                        PlaySound(1074); //play no!! sound
                        break;
                    case 4: Say("You're a liar and a thief. ");
                        PlaySound(1067); //play groan sound
                        break;
                    case 5: Say("LEAVE! NOW! AND NEVER COME BACK!");
                        PlaySound(1073); //play lough sound
                        break;
                    case 6: Say("He wants the precious. Always he is looking for it. And the precious is wanting to go back to him... But we mustn't let him have it.");
                        PlaySound(1094); //play spit sound
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
        public Gollum()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.05, 0.2)    
		{
            // Name = "Gollum";
           // Title = "The Hobbit";
            Name = m_Names[Utility.Random(m_Names.Length)];
            Body = 777;
			Hue = 0;
            BaseSoundID = 357;

			SetStr( 500, 600 );
			SetDex( 150, 250 );
			SetInt( 150, 250 );

            SetHits(5000, 6000);
            SetMana(1000);
            SetStam(202, 350);
	
			SetDamage( 10, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

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
            if (Utility.RandomDouble() < 0.50) 
                c.DropItem(new ArtifactRing()); 
            if (Utility.RandomDouble() < 0.30) 
                c.DropItem(new RAD()); // random artifact deed for the random stat artifacts
        }


        public override void GenerateLoot()
        {
            AddLoot( LootPack.Poor );
            AddLoot( LootPack.Average, 2 ); 
        }

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } } 
		public override int TreasureMapLevel{ get{ return 6; } }
		public override int Meat{ get{ return 3; } }

		public Gollum( Serial serial ) : base( serial )
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