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
using Server.Mobiles;

namespace Server.Items
{
	[FlipableAttribute( 0x13F6, 0x13F7 )]
	public class MastersKnife : BaseKnife, IUsesRemaining
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

		public override int AosStrengthReq{ get{ return 5; } }
		public override int AosMinDamage{ get{ return 9; } }
		public override int AosMaxDamage{ get{ return 11; } }
		public override int AosSpeed{ get{ return 49; } }

		public override int OldStrengthReq{ get{ return 5; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 14; } }
		public override int OldSpeed{ get{ return 40; } }
        	public override float MlSpeed { get { return 2.25f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 40; } }

		private int m_UsesRemaining;
		private bool m_ShowUsesRemaining;

		[CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get { return m_UsesRemaining; }
			set { m_UsesRemaining = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool ShowUsesRemaining
		{
			get { return m_ShowUsesRemaining; }
			set { m_ShowUsesRemaining = value; InvalidateProperties(); }
		}

		[Constructable]
		public MastersKnife() : this( 50 )
		{
		}

		[Constructable]
		public MastersKnife( int uses ) : base( 0x13F6 )
		{
			Weight = 1.0;
			Hue = 0x973;
			UsesRemaining = uses;
			ShowUsesRemaining = true;
			Name = "Masters Knife";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.Target = new MastersKnifeTarget( this );
			from.SendMessage( "Which corpse you want to carve?" ); 					
		}
		
		private class MastersKnifeTarget : Target 
		{ 
			private MastersKnife m_Knife;

			public MastersKnifeTarget( MastersKnife knife ) : base( 15, false, TargetFlags.None )
			{
				m_Knife = knife;
			}
			
			protected override void OnTarget( Mobile from, object target ) 
			{ 
				if ( target is Corpse ) 
				{	
					Corpse c = (Corpse)target; 
					if (c.Owner is BaseCreature)
					{
						if (c.Carved == false)
						{
							Map map = from.Map;
							if ( map == null )
								return;
							int hides = (int)(((BaseCreature)c.Owner).Hides * 1.2);

							if (m_Knife != null)
							{
								if (((BaseCreature)c.Owner).HideType == HideType.Regular )
									c.DropItem( new Hides( hides ) );
								else if (((BaseCreature)c.Owner).HideType == HideType.Spined )
									c.DropItem( new SpinedHides( hides ) );
								else if (((BaseCreature)c.Owner).HideType == HideType.Horned )
									c.DropItem( new HornedHides( hides ) );
								else if (((BaseCreature)c.Owner).HideType == HideType.Barbed )
									c.DropItem( new BarbedHides( hides ) );
								else if (((BaseCreature)c.Owner).HideType == HideType.Polar )
									c.DropItem( new PolarHides( hides ) );
								else if (((BaseCreature)c.Owner).HideType == HideType.Synthetic )
									c.DropItem( new SyntheticHides( hides ) );
								else if (((BaseCreature)c.Owner).HideType == HideType.BlazeL )
									c.DropItem( new BlazeHides( hides ) );
								else if (((BaseCreature)c.Owner).HideType == HideType.Daemonic )
									c.DropItem( new DaemonicHides( hides ) );
								else if (((BaseCreature)c.Owner).HideType == HideType.Shadow )
									c.DropItem( new ShadowHides( hides ) );
								else if (((BaseCreature)c.Owner).HideType == HideType.Frost )
									c.DropItem( new FrostHides( hides ) );
								else if (((BaseCreature)c.Owner).HideType == HideType.Ethereal )
									c.DropItem( new EtherealHides( hides ) );
								c.Carved = true;
								
								if (m_Knife.UsesRemaining > 1)
									m_Knife.UsesRemaining--; 
								else
								{
									m_Knife.Delete();
									from.SendMessage("You used up your masters knife");
								}
							}
						}
						else
							from.SendMessage("You see nothing useful to carve from the corpse.");
					}
				}
			}
		}
		public MastersKnife( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			
			writer.Write( (bool) m_ShowUsesRemaining );

			writer.Write( (int) m_UsesRemaining );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			m_ShowUsesRemaining = reader.ReadBool();
			m_UsesRemaining = reader.ReadInt();
			if ( m_UsesRemaining < 1 )
				m_UsesRemaining = 50;
		}
	}
}