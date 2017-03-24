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
using Server.Targeting;

namespace Server.Items
{
	public class SharpeningBlade : Item
	{
		private int i_Uses;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Uses { get { return i_Uses; } set { i_Uses = value; InvalidateProperties(); } }

		[Constructable] 
		public SharpeningBlade() : this( 50 )
		{
		}

		[Constructable] 
		public SharpeningBlade( int uses ) : base( 4731 ) 
		{ 
			Weight = 1.0;
			i_Uses = uses;
			Name = "Sharpening Blade";
		} 

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1060584, i_Uses.ToString() ); // uses remaining: ~1_val~
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				if ( Uses < 1 )
				{
					Delete();
					from.SendMessage(32, "This have no charges so it's gone!!!");
				}
				from.SendMessage("Which weapon you want to try to enhance?");
				from.Target = new SharpeningBladeTarget(this);
			}
			else
				from.SendMessage("This must be in your backpack to use.");
		}
		
		public void Sharpening(Mobile from, object o)
		{
			if (o is BaseWeapon && ((BaseWeapon)o).IsChildOf(from.Backpack))
			{
				BaseWeapon weap = o as BaseWeapon;
				int i_DI = weap.Attributes.WeaponDamage;
				if (weap.Quality == WeaponQuality.Exceptional)
					i_DI += 15;
				if (i_DI >= 50)
				{
					from.SendMessage("This weapon cannot be enhanced any further");
					return;
				}
				else if (from.Skills[SkillName.Blacksmith].Value < 100.0)
					from.SendMessage(32, "You need atleast 100 blacksmith to enhance weapons");
				else if ( !Deleted )
				{
					int bonus = Utility.Random((int)(from.Skills[SkillName.Blacksmith].Value/10));
					if (bonus > 0)
					{
						if (50 < i_DI + bonus)
							bonus = 50 - i_DI;
						weap.Attributes.WeaponDamage += bonus;
						from.SendMessage(88, "You enhanced the weapon with {0} damange increase", bonus);
					}
					else
						from.SendMessage(32, "You fail to enhance the weapon");
					if (Uses <= 1)
					{
						from.SendMessage(32, "You used up the sharpening blade");
						Delete();
					}
					else
					{
						--Uses;
						from.SendMessage(32, "You have {0} uses left", Uses);
					}
				}
			}
			else
				from.SendMessage(32, "You can only enhance weapons");
		}
				
		public SharpeningBlade( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int) i_Uses );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			i_Uses = reader.ReadInt();
			if ( version == 0 ) { Serial sr_Owner = reader.ReadInt(); }
		}
	}

	public class SharpeningBladeTarget : Target
	{
		private SharpeningBlade sb_Blade;

		public SharpeningBladeTarget(SharpeningBlade blade) : base( 18, false, TargetFlags.None )
		{
			sb_Blade = blade;
		}

		protected override void OnTarget(Mobile from, object targeted)
		{
			if (sb_Blade.Deleted)
				return;

			sb_Blade.Sharpening(from, targeted);
		}
	}
}