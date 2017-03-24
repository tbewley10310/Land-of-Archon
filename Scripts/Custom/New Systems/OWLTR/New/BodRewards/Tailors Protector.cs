/*
 created by:
     /\            888                   888     .d8888b.   .d8888b.  
____/_ \____       888                   888    d88P  Y88b d88P  Y88b 
\  ___\ \  /       888                   888    888    888 888    888 
 \/ /  \/ /    .d88888  8888b.   8888b.  888888 Y88b. d888 Y88b. d888 
 / /\__/_/\   d88" 888     "88b     "88b 888     "Y888P888  "Y888P888 
/__\ \_____\  888  888 .d888888 .d888888 888           888        888 
    \  /      Y88b 888 888  888 888  888 Y88b.  Y88b  d88P Y88b  d88P 
     \/        "Y88888 "Y888888 "Y888888  "Y888  "Y8888P"   "Y8888P"  
*/

namespace Server.Items
{
	[FlipableAttribute( 0xEC3, 0xEC2 )]
	public class TailorsProtector : BaseKnife, IUsesRemaining
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }

		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 11; } }
		public override int AosMaxDamage{ get{ return 13; } }
		public override int AosSpeed{ get{ return 46; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 13; } }
		public override int OldSpeed{ get{ return 40; } }
		public override float MlSpeed { get { return 2.25f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 50; } }

		private int m_UsesRemaining;
		[CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get { return m_UsesRemaining; }
			set { m_UsesRemaining = value; InvalidateProperties(); }
		}
		public bool ShowUsesRemaining{ get{ return true; } set{} }
		
		[Constructable]
		public TailorsProtector() : base( 0xEC3 )
		{
			Name = "Tailors Protector";
			WeaponAttributes.UseBestSkill = 1;
			Weight = 2.0;
		}

		public override void OnHit( Mobile attacker, IDamageable damageable )
		{
			base.OnHit( attacker, damageable );
			if (attacker.Skills[SkillName.Tailoring].Value >= 100 && Utility.Random((int)attacker.Skills[SkillName.Tailoring].Value - 40) >= 20)
			{
				int damage = Utility.RandomMinMax(10,25);
				
				damageable.Hits -= damage;
				//damageable.SendMessage( 33, "The Tailors Protector skined you and you lost {0} HP.", damage );
				
				attacker.SendMessage( 33, "The Tailors Protector skined your target and delivered {0} extra damage", damage );
				attacker.PlaySound( 0x308 );
			}
		}
		
		public TailorsProtector( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
			
			//version 1
			writer.Write(m_UsesRemaining);
			
			//version 0
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version >= 1 )
				m_UsesRemaining = reader.ReadInt();
			else if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}
}