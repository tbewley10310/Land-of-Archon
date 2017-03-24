/*
 * Created by GreyWolf79
 * Idea from AnimalCrackers
 * AnimalCrackers idea was made for LadyRhia, updated by Sar Dain
 *
 * Created 7/26/2008
 * Please do not remove the header, leave it intact so that everyone gets credit where due.
 * If you edit this script then please just add into the header what was done...
 * 
*/

using System;
using Server.Network;
using Server.Items;

namespace Server.Mobiles
{
        [CorpseName( "a king unicorn corpse" )]
	public class KingUnicorn : BaseMount
	{
		public override bool AllowMaleRider{ get{ return false; } } // true = male can use, false = female characters only
		public override bool AllowMaleTamer{ get{ return false; } } // true = male can use, false = female characters only

		public override bool InitialInnocent{ get{ return true; } }

		public override TimeSpan MountAbilityDelay { get { return TimeSpan.FromHours( 1.0 ); } }

		public override void OnDisallowedRider( Mobile m )
		{
			m.SendLocalizedMessage( 1042318 ); // The unicorn refuses to allow you to ride it.
		}

		public override bool DoMountAbility( int damage, Mobile attacker )
		{
			if( Rider == null || attacker == null )	//sanity
				return false;

			if( Rider.Poisoned && ((Rider.Hits - damage) < 40) )
			{
				Poison p = Rider.Poison;

				if( p != null )
				{
					int chanceToCure = 10000 + (int)(this.Skills[SkillName.Magery].Value * 75) - ((p.Level + 1) * (Core.AOS ? (p.Level < 4 ? 3300 : 3100) : 1750));
					chanceToCure /= 100;

					if( chanceToCure > Utility.Random( 100 ) )
					{
						if( Rider.CurePoison( this ) )	//TODO: Confirm if mount is the one flagged for curing it or the rider is
						{
							Rider.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, true, "Your mount senses you are in danger and aids you with magic." );
							Rider.FixedParticles( 0x373A, 10, 15, 5012, EffectLayer.Waist );
							Rider.PlaySound( 0x1E0 );	// Cure spell effect.
							Rider.PlaySound( 0xA9 );		// Unicorn's whinny.

							return true;
						}
					}
				}
			}

			return false;
		}

		[Constructable]
		public KingUnicorn() : this( "a king unicorn" )
		{
		}

		[Constructable]
		public KingUnicorn( string name ) : base( name, 0x7A, 0x3EB4, AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x4BC;
            Hue = 2634;  // to make it a specific color (color is Lady Rhia's favorite color) - 2050 is Heavenly Unicorn color. GreyWolf79

            // made stats stronger than those of heavenly/normal unicorns
			SetStr( 405, 505 );
			SetDex( 125, 155 );
			SetInt( 200, 255 );

			SetHits(555, 700);

            SetDamage(36, 42);

            // all resists and skills raised above that of normal unicorns
			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 35, 50 );
			SetResistance( ResistanceType.Cold, 35, 50 );
			SetResistance( ResistanceType.Poison, 65, 75 );
			SetResistance( ResistanceType.Energy, 35, 50 );

			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 70.2, 90.0 );
			SetSkill( SkillName.Meditation, 60.1, 70.0 );
			SetSkill( SkillName.MagicResist, 80.3, 90.0 );
			SetSkill( SkillName.Tactics, 25.1, 30.5 );
			SetSkill( SkillName.Wrestling, 85.5, 97.5 );

			Fame = 10000; // you will gain fame of 10000
			Karma = 10000; // killing will cause you to lose karma (make -10000 to make it so you gain karma)

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 115.2;
		}

		public override void GenerateLoot()
		{
			//AddLoot( LootPack.Rich );
			//AddLoot( LootPack.LowScrolls );
			//AddLoot( LootPack.Potions );
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 8; } } // 8 instead of 10 like normal unicorn since it is more exotic leather
		public override HideType HideType{ get{ return HideType.Barbed; } } // changed to barbed instead of horned (normal unicorn uses horned)
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }
        
        

		public KingUnicorn( Serial serial ) : base( serial )
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
} // end of king unicorn
