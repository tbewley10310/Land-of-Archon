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
	public class GargoylesKnife : BaseKnife, IUsesRemaining
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

		private static int[] m_Offsets = new int[]
			{
				-1, -1,
				-1,  0,
				-1,  1,
				0, -1,
				0,  1,
				1, -1,
				1,  0,
				1,  1
			};

		[Constructable]
		public GargoylesKnife() : this( Utility.RandomMinMax( 101, 125 ) )
		{
		}

		[Constructable]
		public GargoylesKnife( int uses ) : base( 0x13F6 )
		{
			Weight = 1.0;
			//Hue = 0x973; //removed in RunUO
			UsesRemaining = uses;
			ShowUsesRemaining = true;
			Name = "Gargoyles Knife";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.Target = new GargoylesKnifeTarget( this );
			from.SendMessage( "Which corpse you want to carve?" ); 					
		}
		
		private class GargoylesKnifeTarget : Target 
		{ 
			private GargoylesKnife m_Knife;

			public GargoylesKnifeTarget( GargoylesKnife knife ) : base( 15, false, TargetFlags.None )
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
						if (c.Carved == false && ((BaseCreature)c.Owner).Hides != 0)
						{
							Map map = from.Map;
							if ( map == null )
								return;
							BaseCreature spawned = null;
							if (((BaseCreature)c.Owner).HideType == HideType.Regular)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(4))
									{
										case 0: spawned = new Elementals(102); break;
										case 1: spawned = new Elementals(103); break;
										case 2: spawned = new Elementals(104); break;
										case 3: spawned = new Elementals(105); break;
									}
								}
								switch(Utility.Random(4))
								{
									case 0: c.AddItem( new SpinedHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new HornedHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new BarbedHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new PolarHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Spined)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(5))
									{
										case 0: spawned = new Elementals(103); break;
										case 1: spawned = new Elementals(104); break;
										case 2: spawned = new Elementals(105); break;
										case 3: spawned = new Elementals(106); break;
										case 4: spawned = new Elementals(107); break;
									}
								}
								switch(Utility.Random(5))
								{
									case 0: c.AddItem( new HornedHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new BarbedHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new PolarHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new SyntheticHides(((BaseCreature)c.Owner).Hides)); break;
									case 4: c.AddItem( new BlazeHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Horned)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(6))
									{
										case 0: spawned = new Elementals(104); break;
										case 1: spawned = new Elementals(105); break;
										case 2: spawned = new Elementals(106); break;
										case 3: spawned = new Elementals(107); break;
										case 4: spawned = new Elementals(108); break;
										case 5: spawned = new Elementals(109); break;
									}
								}
								switch(Utility.Random(6))
								{
									case 0: c.AddItem( new BarbedHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new PolarHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new SyntheticHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new BlazeHides(((BaseCreature)c.Owner).Hides)); break;
									case 4: c.AddItem( new DaemonicHides(((BaseCreature)c.Owner).Hides)); break;
									case 5: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Barbed)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(7))
									{
										case 0: spawned = new Elementals(105); break;
										case 1: spawned = new Elementals(106); break;
										case 2: spawned = new Elementals(107); break;
										case 3: spawned = new Elementals(108); break;
										case 4: spawned = new Elementals(109); break;
										case 5: spawned = new Elementals(110); break;
										case 6: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(7))
								{
									case 0: c.AddItem( new PolarHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new SyntheticHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new BlazeHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new DaemonicHides(((BaseCreature)c.Owner).Hides)); break;
									case 4: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
									case 5: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 6: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Polar)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(6))
									{
										case 0: spawned = new Elementals(106); break;
										case 1: spawned = new Elementals(107); break;
										case 2: spawned = new Elementals(108); break;
										case 3: spawned = new Elementals(109); break;
										case 4: spawned = new Elementals(110); break;
										case 5: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(6))
								{
									case 0: c.AddItem( new SyntheticHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new BlazeHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new DaemonicHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
									case 4: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 5: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Synthetic)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(5))
									{
										case 0: spawned = new Elementals(107); break;
										case 1: spawned = new Elementals(108); break;
										case 2: spawned = new Elementals(109); break;
										case 3: spawned = new Elementals(110); break;
										case 4: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(5))
								{
									case 0: c.AddItem( new BlazeHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new DaemonicHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 4: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.BlazeL)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(4))
									{
										case 0: spawned = new Elementals(108); break;
										case 1: spawned = new Elementals(109); break;
										case 2: spawned = new Elementals(110); break;
										case 3: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(4))
								{
									case 0: c.AddItem( new DaemonicHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 3: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Daemonic)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(3))
									{
										case 0: spawned = new Elementals(109); break;
										case 1: spawned = new Elementals(110); break;
										case 2: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(3))
								{
									case 0: c.AddItem( new ShadowHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 2: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType == HideType.Shadow)
							{
								if (0.1 > Utility.RandomDouble())
								{
									switch(Utility.Random(2))
									{
										case 0: spawned = new Elementals(110); break;
										case 1: spawned = new Elementals(111); break;
									}
								}
								switch(Utility.Random(2))
								{
									case 0: c.AddItem( new FrostHides(((BaseCreature)c.Owner).Hides)); break;
									case 1: c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides)); break;
								}
							}
							else if (((BaseCreature)c.Owner).HideType >= HideType.Frost)
							{
								if (0.1 > Utility.RandomDouble())
									spawned = new Elementals(111);
								c.AddItem( new EtherealHides(((BaseCreature)c.Owner).Hides));
							}
							else
							{
								from.SendMessage("You can't use gargoyles knife on that.");
								from.PlaySound(1066); //play giggle sound
								return;
							}
							c.Carved = true;
							if (m_Knife != null)
							{
								if (m_Knife.UsesRemaining > 1)
									m_Knife.UsesRemaining--; 
								else
								{
									m_Knife.Delete();
									from.SendMessage("You used up your gargoyles knife");
								}
							}
							if ( spawned != null )
							{
								from.SendMessage("When you used your gargoyles knife on the corpse a leather elemental came to defend it.");
								from.PlaySound(1098); //play m_yell

								int offset = Utility.Random( 8 ) * 2;
								for ( int i = 0; i < m_Offsets.Length; i += 2 )
								{
									int x = from.X + m_Offsets[(offset + i) % m_Offsets.Length];
									int y = from.Y + m_Offsets[(offset + i + 1) % m_Offsets.Length];
									if ( map.CanSpawnMobile( x, y, from.Z ) )
									{
										spawned.MoveToWorld( new Point3D( x, y, from.Z ), map );
										spawned.Combatant = from;
										return;
									}
									else
									{
										int z = map.GetAverageZ( x, y );

										if ( map.CanSpawnMobile( x, y, z ) )
										{
											spawned.MoveToWorld( new Point3D( x, y, z ), map );
											spawned.Combatant = from;
											return;
										}
									}
								}
								try 
								{
									spawned.MoveToWorld( from.Location, from.Map );
									spawned.Combatant = from;
								}
								catch
								{
								}
							}
							else
							{
								from.SendMessage("Nothing happened when you used your gargoyles knife on the corpse.");
								if (from.BodyValue == 401)
									from.PlaySound(787); // play f_cry
								else if (from.BodyValue == 400)
									from.PlaySound(1058); //play m_cry
							}
						}
						else
							from.SendMessage("You see nothing useful to carve from the corpse.");
					}
				}
			}
		}
		public GargoylesKnife( Serial serial ) : base( serial )
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
				m_UsesRemaining = 150;
		}
	}
}