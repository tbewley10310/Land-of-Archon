using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a llama corpse" )]
	public class DonatorLlama : BaseMount
	{
		[Constructable]
		public DonatorLlama() : this( "a Donator's llama" )
		{
		}

		[Constructable]
		public DonatorLlama( string name ) : base( name, 0xDC, 0x3EA6, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x3F3;

			SetStr( 1500 );
			SetDex( 600 );
			SetInt( 500 );

			SetHits( 2000 );
			SetMana( 500 );
            SetStam( 600 );

			SetDamage( 22, 30 );

			SetDamageType( ResistanceType.Physical, 50 );
            SetDamageType(ResistanceType.Cold, 25);
            SetDamageType(ResistanceType.Fire, 25);

			SetResistance( ResistanceType.Physical, 75 );
			SetResistance( ResistanceType.Fire, 75 );
			SetResistance( ResistanceType.Cold, 75 );
			SetResistance( ResistanceType.Poison, 75 );
			SetResistance( ResistanceType.Energy, 75 );

			SetSkill( SkillName.MagicResist, 110.0 );
			SetSkill( SkillName.Tactics, 110.0 );
			SetSkill( SkillName.Wrestling, 110.0 );

			Fame = 0;
			Karma = 1000;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 0;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public DonatorLlama( Serial serial ) : base( serial )
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
		}
	}
}