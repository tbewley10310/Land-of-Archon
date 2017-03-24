using System;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;

namespace Server.EventSystem
{
	public class EventCore
	{
		#region Variables

		public static List<BaseEvent> Events;

		#endregion

		#region Initialize

		public static void Initialize()
		{
			//Hook Serialize/Deserialize
			if ( EventPersistance.Instance == null )
				new EventPersistance();

			if ( Events == null )
				Events = CreateEvents();

			//Register EventSinks
			EventSink.ServerStarted += new ServerStartedEventHandler( EventSink_ServerStarted );

			//Commands.CommandSystem.Register( "MonsterBash", AccessLevel.GameMaster, new Commands.CommandEventHandler( MonsterBash_OnCommand ) );
			//Commands.CommandSystem.Register( "StartMonsterBash", AccessLevel.GameMaster, new Commands.CommandEventHandler( StartMonsterBash_OnCommand ) );
			Commands.CommandSystem.Register( "TownInvasion", AccessLevel.GameMaster, new Commands.CommandEventHandler( TownInvasion_OnCommand ) );
			Commands.CommandSystem.Register( "StartTownInvasion", AccessLevel.GameMaster, new Commands.CommandEventHandler( StartTownInvasion_OnCommand ) );
		}

		#endregion

		#region OnCommand

		/*private static void MonsterBash_OnCommand( Commands.CommandEventArgs e )
		{
			e.Mobile.SendGump( new EventPropertiesGump( e.Mobile, FindEvent( EventType.MonsterBash ) ) );
		}

		private static void StartMonsterBash_OnCommand( Commands.CommandEventArgs e )
		{
			FindEvent( EventType.MonsterBash ).Start();
		}*/
		
		private static void TownInvasion_OnCommand( Commands.CommandEventArgs e )
		{
			e.Mobile.SendGump( new EventPropertiesGump( e.Mobile, FindEvent( EventType.TownInvasion ) ) );
		}

		private static void StartTownInvasion_OnCommand( Commands.CommandEventArgs e )
		{
			FindEvent( EventType.TownInvasion ).Start();
		}

		#endregion

		#region EventSinks

		private static void EventSink_ServerStarted()
		{
			/*Timer.DelayCall( TimeSpan.FromSeconds( 0.0 ), delegate
			{
				//Load Event Data
				BaseEvent e = FindEvent( EventType.MonsterBash );

				if ( e != null )
					e.Start();
			} );*/
		}

		#endregion

		#region Private Methods

		private static List<BaseEvent> CreateEvents()
		{
			List<BaseEvent> events = new List<BaseEvent>();

			for ( int i = 0; i < EventConfig.EnabledEvents.Length; ++i )
			{
				object e = Activator.CreateInstance( EventConfig.EnabledEvents[i] );

				if ( e != null && e is BaseEvent )
					events.Add( e as BaseEvent );
			}

			return events;
		}

		#endregion

		#region Public Methods

		public static BaseEvent FindEvent( EventType e )
		{
			foreach ( BaseEvent b in Events )
			{
				if ( b.EventType == e )
					return b;
			}

			return null;
		}

		public static void Serialize( GenericWriter writer )
		{
			writer.Write( (int)0 ); //version

			writer.Write( Events.Count );

			Events.ForEach( delegate( BaseEvent e )
			{
				writer.Write( e.GetType().ToString() );
				e.Serialize( writer );
			} );
		}

		public static void Deserialize( GenericReader reader )
		{
			int version = reader.ReadInt();

			if ( Events != null )
				Events.Clear();

			Events = new List<BaseEvent>();

			//Load events from configuration
			List<Type> fromConfig = new List<Type>( EventConfig.EnabledEvents );

			int count = reader.ReadInt();

			for ( int i = 0; i < count; ++i )
			{
				string strType = reader.ReadString();

				Type rType = ScriptCompiler.FindTypeByFullName( strType, true );

				if ( rType != null )
				{
					object type = Activator.CreateInstance( rType );

					if ( type != null && type is BaseEvent )
					{
						( (BaseEvent)type ).Deserialize( reader );

						//Only add it if it's in the config file
						if ( fromConfig.Contains( rType ) )
							Events.Add( type as BaseEvent );
					}
				}
			}

			//Enable Registered BaseEvents
			Events.ForEach( delegate( BaseEvent e ) { e.Enable(); } );
		}

		#endregion
	}
}