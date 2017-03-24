using Server;
using System;
using Server.Items;
using Server.Gumps;

namespace Server.Mobiles
{
	[CorpseName( "a cu sidhe corpse" )]
	public class DonatorCuSidhe : BaseMount
	{
		[Constructable]
		public DonatorCuSidhe() : this( "-Interceptor-" )
		{
		}

		[Constructable]
        public DonatorCuSidhe(string name): base(name, 277, 0x3E91, AIType.AI_Animal, FightMode.Closest, 10, 1, 0.1, 0.175)
		{
			double chance = Utility.RandomDouble() * 2331;

			if ( chance <= 1 )
				Hue = 0x489;
			else if ( chance < 500 )
				Hue = Utility.RandomList( 0x4A7, 0x48D, 0x54E, 0x672, 0x4DE, 0x735, 0x5A5, 0x466 );
			else if ( chance < 50 )
				Hue = Utility.RandomList( 0x4AB, 0x4AC, 0x6F3, 0x497, 0x482, 0x47E, 0x486 );
            else if ( chance < 50 )
                Hue = Utility.RandomList( 0x813, 0x81B, 0x78C, 0x7FB );

			SetStr( 1500 );
			SetDex( 700 );
			SetInt( 500 );

			SetHits( 2500 );
            SetStam(700);

			SetDamage( 25, 35 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Cold, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 75 );
			SetResistance( ResistanceType.Fire, 75 );
			SetResistance( ResistanceType.Cold, 75 );
			SetResistance( ResistanceType.Poison, 75 );
			SetResistance( ResistanceType.Energy, 75 );

			SetSkill( SkillName.Wrestling, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Anatomy, 120.0 );
			SetSkill( SkillName.Healing, 120.0 );

			Fame = 0;  //Guessing here
			Karma = 1000;  //Guessing here

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 0;

			if ( Utility.RandomDouble() < 0.2 )
				PackItem( new TreasureMap( 5, Map.Trammel ) );

			//if ( Utility.RandomDouble() < 0.1 )
				//PackItem( new ParrotItem() );

			PackGold( 500, 800 );

			// TODO 0-2 spellweaving scroll
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosFilthyRich, 5 );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.Race != Race.Elf && from == ControlMaster && from.AccessLevel == AccessLevel.Player )
			{
				Item pads = from.FindItemOnLayer( Layer.Shoes );

				if ( pads is PadsOfTheCuSidhe )
					from.SendLocalizedMessage( 1071981 ); // Your boots allow you to mount the Cu Sidhe.
				else
				{
					from.SendLocalizedMessage( 1072203 ); // Only Elves may use this.
					return;
				}
			}

			base.OnDoubleClick( from );
		}

		public override bool CanHeal{ get{ return true; } }
		public override bool CanHealOwner{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }
		public override bool CanAngerOnTame{ get { return false; } }
		public override bool StatLossAfterTame{ get{ return false; } }
		public override int Hides{ get{ return 10; } }
		public override int Meat{ get{ return 3; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		public DonatorCuSidhe( Serial serial ) : base( serial )
		{
		}

		public override int GetIdleSound() { return 0x577; }
		public override int GetAttackSound() { return 0x576; }
		public override int GetAngerSound() { return 0x578; }
		public override int GetHurtSound() { return 0x576; }
		public override int GetDeathSound() { return 0x579; }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version < 1 && Name == "a Cu Sidhe" )
				Name = "a cu sidhe";
		}
	}
}
