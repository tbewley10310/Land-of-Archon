using System;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Regions;
using Server.Misc;

using Server.Commands;

namespace Server.EventSystem
{	
	public class TownInvasion : BaseEvent
	{
		public static TimeSpan m_TIEventRate = TimeSpan.FromHours( 6.0 );
		
		#region Private Variables

		private int m_MinSpawnZ;
		private int m_MaxSpawnZ;
		private int m_LastMsg;

		private bool m_Broadcast = true;
		private bool m_FinalStage;

		private Point3D m_Top = new Point3D(4394, 1058, 30);
		private Point3D m_Bottom = new Point3D(4481, 1173, 0);
		private Map m_SpawnMap = Map.Felucca;

		private List<Mobile> m_Spawned;

		private TownMonsterType m_TownMonsterType = TownMonsterType.OrcsandRatmen;
		private TownChampionType m_TownChampionType = TownChampionType.Barracoon;
		
		private double m_ParagonChance = 0.05;
		private bool m_AlwaysMurderer = false;
		private bool m_IsRunning;
		
		private DateTime m_TimeNextScheduledEvent = DateTime.MinValue;
		private DateTime m_TimeLastEvent = DateTime.MinValue;
		
		private string m_TownInvaded = "Moonglow";
		
		#endregion

		#region Public Variables

		[CommandProperty( AccessLevel.Administrator )]
		public int MinSpawnZ { get { return m_MinSpawnZ; } set { m_MinSpawnZ = value; } }

		[CommandProperty( AccessLevel.Administrator )]
		public int MaxSpawnZ { get { return m_MaxSpawnZ; } set { m_MaxSpawnZ = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool Broadcast { get { return m_Broadcast; } set { m_Broadcast = value; } }

		[CommandProperty( AccessLevel.Administrator )]
		public Point3D Top { get { return m_Top; } set { m_Top = value; } }

		[CommandProperty( AccessLevel.Administrator )]
		public Point3D Bottom { get { return m_Bottom; } set { m_Bottom = value; } }
		
		[CommandProperty( AccessLevel.Administrator )]
		public Map SpawnMap { get { return m_SpawnMap; } set { m_SpawnMap = value; } }

		public List<Mobile> Spawned { get { return m_Spawned; } set { m_Spawned = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public TownMonsterType TownMonsterType { get { return m_TownMonsterType; } set { m_TownMonsterType = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public TownChampionType TownChampionType { get { return m_TownChampionType; } set { m_TownChampionType = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public double ParagonChance { get { return m_ParagonChance; } set { m_ParagonChance = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool AlwaysMurderer { get { return m_AlwaysMurderer; } set { m_AlwaysMurderer = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsRunning { get { return m_IsRunning; } set { m_IsRunning = value; } }
		
		[CommandProperty( AccessLevel.GameMaster, true )]
		public DateTime TimeNextScheduledEvent { get { return m_TimeNextScheduledEvent; } set { m_TimeNextScheduledEvent = value; } }
		
		[CommandProperty( AccessLevel.GameMaster, true )]
		public DateTime TimeLastEvent { get { return m_TimeLastEvent; } set { m_TimeLastEvent = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan TIEventRate { get { return m_TIEventRate; } set { m_TIEventRate = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public string TownInvaded { get { return m_TownInvaded; } set { m_TownInvaded = value; } }

		#endregion

		#region Property Overrides

		public override EventType EventType { get { return EventType.TownInvasion; } }
		public override string EventName { get { return "Town Invasion"; } }
		public override TimeSpan TimerFrequency { get { return TimeSpan.FromSeconds( 1.0 ); } }
		
		public override Map StartingMap { get { return Map.Felucca; } }
		public override Point3D StartingLocation { get { return new Point3D(6804, 2233, 0); } }

		#endregion

		#region Constructor

		public TownInvasion()
		{
			m_Spawned = new List<Mobile>();
		}

		#endregion

		#region Method Overrides

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{

		}

		public override void OnStart()
		{
			if( !this.IsRunning )
			{
				switch( Utility.Random(7) )
				{
                    case 0:  //Britain Doesn't Get Invaded Anymore
                    {
                        this.Top = new Point3D(1426, 1554, 30);
                        this.Bottom = new Point3D(1490, 1735, 0);
                        this.MinSpawnZ = 0;
                        this.MaxSpawnZ = 31;
                        this.SpawnMap = Map.Felucca;
                        this.TownInvaded = "Britain";
                        this.TownMonsterType = TownMonsterType.OrcsandRatmen;
                        this.TownChampionType = TownChampionType.Barracoon;
						
                        break;
                    }
                    case 1:  //Britain Doesn't Get Invaded Anymore
                    {
                        this.Top = new Point3D(1426, 1554, 30);
                        this.Bottom = new Point3D(1490, 1735, 0);
                        this.MinSpawnZ = 0;
                        this.MaxSpawnZ = 31;
                        this.SpawnMap = Map.Trammel;
                        this.TownInvaded = "Britain";
                        this.TownMonsterType = TownMonsterType.OrcsandRatmen;
                        this.TownChampionType = TownChampionType.Barracoon;

                        break;
                    }
					case 2:  //Moonglow
					{
						this.Top = new Point3D(4394, 1058, 30);
						this.Bottom = new Point3D(4481, 1173, 0);
						this.MinSpawnZ = 0;
						this.MaxSpawnZ = 31;
						this.SpawnMap = Map.Felucca;
						this.TownInvaded = "Moonglow";
						this.TownMonsterType = TownMonsterType.Abyss;
						this.TownChampionType = TownChampionType.Rikktor;
						
						break;
					}
					case 3:  //Minoc
					{
						this.Top = new Point3D(2443, 420, 15);
						this.Bottom = new Point3D(2520, 539, 0);
						this.MinSpawnZ = 0;
						this.MaxSpawnZ = 16;
						this.SpawnMap = Map.Felucca;
						this.TownInvaded = "Minoc";
						this.TownMonsterType = TownMonsterType.OreElementals;
						this.TownChampionType = TownChampionType.LordOaks;
						
						break;
					}
					case 4:  //Delucia
					{
						this.Top = new Point3D(5171, 3980, 41);
						this.Bottom = new Point3D(5300, 4040, 39);
						this.MinSpawnZ = 39;
						this.MaxSpawnZ = 42;
						this.SpawnMap = Map.Felucca;
						this.TownInvaded = "Delucia";
						this.TownMonsterType = TownMonsterType.Ophidian;
						this.TownChampionType = TownChampionType.Mephitis;
						
						break;
					}
					case 5:  //Ocllo
					{
						this.Top = new Point3D(3617, 2482, 0);
						this.Bottom = new Point3D(3712, 2630, 20);
						this.MinSpawnZ = 0;
						this.MaxSpawnZ = 21;
						this.SpawnMap = Map.Felucca;
						this.TownInvaded = "Ocllo";
						this.TownMonsterType = TownMonsterType.Elementals;
						this.TownChampionType = TownChampionType.Semidar;
						
						break;
					}
					case 6:  //Skara Brae
					{
						this.Top = new Point3D(577, 2131, -90);
						this.Bottom = new Point3D(634, 2234, -90);
						this.MinSpawnZ = 0;
						this.MaxSpawnZ = 1;
						this.SpawnMap = Map.Felucca;
						this.TownInvaded = "Skara Brae";
						this.TownMonsterType = TownMonsterType.Humanoid;
						this.TownChampionType = TownChampionType.Serado;
						
						break;
					}
					case 7:  //Yew
					{
						this.Top = new Point3D(457, 913, 30);
						this.Bottom = new Point3D(662, 1117, 0);
						this.MinSpawnZ = 0;
						this.MaxSpawnZ = 0;
						this.SpawnMap = Map.Felucca;
						this.TownInvaded = "Yew";
						this.TownMonsterType = TownMonsterType.OrcsandRatmen;
						this.TownChampionType = TownChampionType.Barracoon;
						
						break;
					}
				}
				
				foreach ( Region r in Region.Regions )
				{ 
					if ( r is GuardedRegion && r.Name == this.TownInvaded ) 
					{ 
						((GuardedRegion)r).Disabled = true; 
					} 
				}
		
				Spawn();
				this.m_TimeLastEvent = DateTime.Now;
				this.m_TimeNextScheduledEvent = DateTime.Now + TIEventRate;
				
				//World.Broadcast( 0x35, true, "{0} is being invaded!  The guards have fled! Help save it's citzens!", this.m_TownInvaded);
				string bc = this.m_TownInvaded + " is being invaded!  The guards have fled! Help save it's citizens!";
				Server.Mobiles.InvasionAnnouncer.SetAnnouncement( bc );
				this.IsRunning = true;
			}
		}

		protected override void OnStop()
		{
			Despawn();
			
			foreach ( Region r in Region.Regions )
         	{ 
            	if ( r is GuardedRegion && r.Name == this.TownInvaded  ) 
            	{ 
               		((GuardedRegion)r).Disabled = false; 
            	} 
         	}
			
			Server.Mobiles.InvasionAnnouncer.DeleteAnnouncements();
			this.IsRunning = false;  //it's not running anymore
		}

		public override void OnTick( int ticks )
		{
			int count = 0;

			for ( int i = 0; i < m_Spawned.Count; ++i )
				if ( m_Spawned[i] != null && !m_Spawned[i].Deleted && m_Spawned[i].Alive )
					++count;

			if ( !m_FinalStage ) //Monsters
			{
				if ( count == 0 ) //All monsters have been slayed
					SpawnChamp();
			}
			else //Champion
			{
				if ( count == 0 ) //Champion is dead
				{
					if ( m_Broadcast )
						Announce( 1161, "The city of {0} has been saved and the guards have returned to their posts.  The citizens of {1} thank you!", m_TownInvaded, m_TownInvaded );

					Stop();
				}
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)3 ); //version
			
			//v 3
			writer.Write( m_Spawned, true );
			
			// v 2
			writer.Write( m_IsRunning );
			
			// v 1
			writer.Write( m_ParagonChance );
			writer.Write( m_AlwaysMurderer );
			writer.Write( m_TimeNextScheduledEvent );
			writer.Write( m_TimeLastEvent );
			writer.Write( m_TIEventRate );

			// v 0
			writer.Write( m_MinSpawnZ );
			writer.Write( m_MaxSpawnZ );

			writer.Write( m_Broadcast );

			writer.Write( m_Top );
			writer.Write( m_Bottom );
			writer.Write( m_SpawnMap );

			writer.WriteEncodedInt( (int)m_TownMonsterType );
			writer.WriteEncodedInt( (int)m_TownChampionType );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 3:
				{
					m_Spawned = reader.ReadStrongMobileList();
					goto case 2;
				}
				case 2:
				{
					m_IsRunning = reader.ReadBool();
					goto case 1;
				}
				case 1:
				{
					m_ParagonChance = reader.ReadDouble(); 
					m_AlwaysMurderer = reader.ReadBool();
					m_TimeNextScheduledEvent = reader.ReadDateTime();
					m_TimeLastEvent = reader.ReadDateTime();
					m_TIEventRate = reader.ReadTimeSpan();
					goto case 0;
				}
				case 0:
				{
					m_MinSpawnZ = reader.ReadInt();
					m_MaxSpawnZ = reader.ReadInt();

					m_Broadcast = reader.ReadBool();

					m_Top = reader.ReadPoint3D();
					m_Bottom = reader.ReadPoint3D();
					m_SpawnMap = reader.ReadMap();

					m_TownMonsterType = (TownMonsterType)reader.ReadEncodedInt();
					m_TownChampionType = (TownChampionType)reader.ReadEncodedInt();


					break;
				}
			}
			
			OnStop();
			m_IsRunning = false;
			//m_Spawned = new List<Mobile>();
		}

		#endregion

		#region Private Methods

		private void Spawn()
		{
			Despawn();

			MonsterTownSpawnEntry[] entries = null;

			switch ( m_TownMonsterType )
			{
				default:
				case TownMonsterType.Abyss: entries = MonsterTownSpawnEntry.Abyss; break;
				case TownMonsterType.Arachnid: entries = MonsterTownSpawnEntry.Arachnid; break;
				case TownMonsterType.DragonKind: entries = MonsterTownSpawnEntry.DragonKind; break;
				case TownMonsterType.Elementals: entries = MonsterTownSpawnEntry.Elementals; break;
				case TownMonsterType.Humanoid: entries = MonsterTownSpawnEntry.Humanoid; break;
				case TownMonsterType.Ophidian: entries = MonsterTownSpawnEntry.Ophidian; break;
				case TownMonsterType.OrcsandRatmen: entries = MonsterTownSpawnEntry.OrcsandRatmen; break;
				case TownMonsterType.OreElementals: entries = MonsterTownSpawnEntry.OreElementals; break;
				case TownMonsterType.Snakes: entries = MonsterTownSpawnEntry.Snakes; break;
				case TownMonsterType.Undead: entries = MonsterTownSpawnEntry.Undead; break;
			}

			for ( int i = 0; i < entries.Length; ++i )
				for ( int count = 0; count < entries[i].Amount; ++count )
					AddMonster( entries[i].Monster );
		}

		private void Despawn()
		{
			foreach ( Mobile m in m_Spawned )
				if ( m != null && !m.Deleted )
					m.Delete();

			m_Spawned.Clear();

			m_FinalStage = false;
		}

		private Point3D FindSpawnLocation()
		{
			int x, y, z;

			do
			{
				x = Utility.Random( m_Top.X, ( m_Bottom.X - m_Top.X ) );
				y = Utility.Random( m_Top.Y, ( m_Bottom.Y - m_Top.Y ) );
				z = SpawnMap.GetAverageZ( x, y );
			}
			while ( !SpawnMap.CanSpawnMobile( x, y, z ) );

			return new Point3D( x, y, z );
		}

		private void AddMonster( Type type )
		{
			object monster = Activator.CreateInstance( type );

			if ( monster != null && monster is Mobile )
			{
				Point3D location = FindSpawnLocation();

				Mobile from = (Mobile)monster;

				if ( m_FinalStage )
				{
					Announce( 1161, "{0} has come to take over {1}!  Please save it's citizens!", from.Name, m_TownInvaded );

					//TODO: Pack Goodies
				}

				from.MoveToWorld( location, SpawnMap );

				if ( from is BaseCreature )
				{
					( (BaseCreature)from ).Tamable = false;
					
					if ( !(from is BaseChampion) && !(from is Harrower) && !(from is BaseVendor) && !(from is BaseEscortable) && !(from is Clone) )
					{
						//if( Utility.RandomDouble() < m_ParagonChance )
							//( (BaseCreature)from ).IsParagon = true;
							
						if( m_AlwaysMurderer )
							( (BaseCreature)from ).Kills = 6;
					}
				}

				m_Spawned.Add( from );
			}
		}

		public void SpawnChamp()
		{
			Despawn();

			m_FinalStage = true;

			switch ( m_TownChampionType )
			{
				default:
				case TownChampionType.Barracoon: AddMonster( typeof( Barracoon ) ); break;
				case TownChampionType.Harrower: AddMonster( typeof( Harrower ) ); break;
				case TownChampionType.LordOaks: AddMonster( typeof( LordOaks ) ); break;
				case TownChampionType.Mephitis: AddMonster( typeof( Mephitis ) ); break;
				case TownChampionType.Neira: AddMonster( typeof( Neira ) ); break;
				case TownChampionType.Rikktor: AddMonster( typeof( Rikktor ) ); break;
				case TownChampionType.Semidar: AddMonster( typeof( Semidar ) ); break;
				case TownChampionType.Serado: AddMonster( typeof( Serado ) ); break;
			}
		}

		#endregion
	}
	
	public class TIWorldTimer : Timer
	{
		public static void Initialize()
		{
			new TIWorldTimer().Start();
		}
		
		public TIWorldTimer() : base( TownInvasion.m_TIEventRate, TownInvasion.m_TIEventRate )
		{
			Priority = TimerPriority.OneMinute;
		}
		
		protected override void OnTick()
		{
			BaseEvent evnt = Server.EventSystem.EventCore.FindEvent( EventType.TownInvasion );
			
			if( evnt != null )  //don't run a new one if one is running already.
			{
				evnt.Start();
			}
		}
	}
}