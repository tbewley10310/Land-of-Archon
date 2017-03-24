using System;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;

namespace Server.EventSystem
{
	public abstract class BaseEvent
	{
		#region Private Variables

		private bool m_Enabled;
		private bool m_Started;

		//private Point3D m_StartingLocation;
		//private Map m_StartingMap;
		private EventTimer m_EventTimer;

		#endregion

		#region Public Variables

		public bool Enabled { get { return m_Enabled; } }
		public bool Started { get { return m_Started; } }
		

		/*[CommandProperty( AccessLevel.Administrator )]
		public Point3D StartingLocation { get { return m_StartingLocation; } set { m_StartingLocation = value; } }

		[CommandProperty( AccessLevel.Administrator )]
		public Map StartingMap { get { return m_StartingMap; } set { m_StartingMap = value; } }*/

		public EventTimer EventTimer { get { return m_EventTimer; } set { m_EventTimer = value; } }

		#endregion

		#region Abstract Properties/Methods

		public abstract EventType EventType { get; }
		public abstract string EventName { get; }
		public abstract TimeSpan TimerFrequency { get; }
		
		public abstract Map StartingMap { get; }
		public abstract Point3D StartingLocation { get; }

		protected abstract void OnEnable();
		protected abstract void OnDisable();
		public abstract void OnStart();
		protected abstract void OnStop();
		public abstract void OnTick( int ticks );

		#endregion

		#region Constructor

		public BaseEvent()
		{
		}

		#endregion

		#region Virtual Methods

		public virtual void Enable()
		{
			if ( !m_Enabled )
			{
				m_Enabled = true;

				OnEnable();
			}
		}

		public virtual void Disable()
		{
			if ( m_Enabled )
			{
				m_Enabled = false;

				OnDisable();
			}
		}

		public virtual void Start()
		{
			if ( !m_Started )
			{
				m_Started = true;

				if ( m_EventTimer != null )
					m_EventTimer.Stop();

				if ( TimerFrequency != TimeSpan.Zero )
				{
					m_EventTimer = new EventTimer( this );
					m_EventTimer.Start();
				}

				OnStart();
			}
		}

		public virtual void Stop()
		{
			if ( m_Started )
			{
				m_Started = false;

				if ( m_EventTimer != null )
				{
					m_EventTimer.Stop();
					m_EventTimer = null;
				}

				OnStop();
			}
		}

		public virtual void RefreshPlayer( Mobile from )
		{
			if ( from == null )
				return;

			if ( !from.Alive )
				from.Resurrect();

			Container pack = from.Backpack;
			Item holding = from.Holding;

			if ( holding != null && pack != null )
				pack.DropItem( holding );

			from.RevealingAction();

			from.Poison = null;
			from.StatMods.Clear();

			Factions.Faction.ClearSkillLoss( from );

			from.Hits = from.HitsMax;
			from.Mana = from.ManaMax;
			from.Stam = from.StamMax;

			Targeting.Target.Cancel( from );
			from.MagicDamageAbsorb = 0;
			from.MeleeDamageAbsorb = 0;
			Spells.Second.ProtectionSpell.Registry.Remove( from );
			DefensiveSpell.Nullify( from );
			from.Combatant = null;

			from.Delta( MobileDelta.Noto ); //Update notoriety
		}

		public virtual void Serialize( GenericWriter writer )
		{
			writer.Write( (int)0 ); //version
		}

		public virtual void Deserialize( GenericReader reader )
		{
			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					break;
				}
			}
		}

		#endregion

		#region Public Methods

		public void Announce( int hue, string message, params object[] args )
		{
			World.Broadcast( hue, false, String.Format( "[{0}]: {1}", EventName, message ), args );
		}
		
		public void LocalAnnounce( Point3D p, Map map, int range, int hue, string message, params object[] args )
		{
            IPooledEnumerable eable = map.GetMobilesInRange( p, range );

            foreach (Mobile mobile in eable)
            {
                if (mobile != null && mobile is PlayerMobile)
                {
                    mobile.SendMessage(hue, message, args);                         
                }         
            }
			
			eable.Free();  //get rid of our enumerable.
		}

		public void SpawnGates()
		{
			Action<Point3D> spawnGate = delegate( Point3D loc ) { new EventGate( this ).MoveToWorld( loc, Map.Felucca ); };

			MoongateLocations.Banks.ForEach( spawnGate );
			MoongateLocations.Shrines.ForEach( spawnGate );
		}

		public void DespawnGates()
		{
			List<Item> gates = new List<Item>();

			foreach ( Item i in World.Items.Values )
			{
				if ( i is EventGate )
					gates.Add( i );
			}

			foreach ( Item gate in gates )
				gate.Delete();
		}

		#endregion
	}
}