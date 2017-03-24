/*Scripted by Lady Raven
*/
using System;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a dread nightmare corpse" )]
	public class DreadNightmare : BaseMount
	{
		[Constructable]
		public DreadNightmare() : this( "a dread nightmare" )
		{
		}

		[Constructable]
		public DreadNightmare( string name ) : base( name, 0x74, 0x3EA7, AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0xA8;

			SetStr( 502, 551 );
			SetDex( 89, 123 );
			SetInt( 100, 159 );

			SetHits( 555, 648 );

			SetDamage( 60 );

			SetDamageType( ResistanceType.Physical, 40 );
                        SetDamageType( ResistanceType.Cold,0) ;
			SetDamageType( ResistanceType.Fire, 0 );
			SetDamageType( ResistanceType.Energy, 40 );
                        SetDamageType( ResistanceType.Poison,20) ;


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 20, 40 );
			SetResistance( ResistanceType.Cold, 20, 40 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.EvalInt, 10.4, 50.0 );
			SetSkill( SkillName.Magery, 10.4, 50.0 );
			SetSkill( SkillName.MagicResist, 85.3, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 80.5, 92.5 );
                        SetSkill( SkillName.Anatomy, 0, 13.9 );


			Fame = 14000;
			Karma = 14000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 107.1;

                        switch ( Utility.Random( 1 ) )
			{
			
				case 0:
				{
					BodyValue = 179;
					ItemID = 16055;
					break;

			
					
				}
			}

			PackItem( new SulfurousAsh( Utility.RandomMinMax( 3, 5 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Potions );
		}

		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;

			return base.GetAngerSound();
		}

		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public DreadNightmare( Serial serial ) : base( serial )
		{
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

			if ( BaseSoundID == 0x16A )
				BaseSoundID = 0xA8;
		}
	}
}