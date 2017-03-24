using System;

namespace Server.EventSystem
{
	public class EventConfig
	{
		public static Type[] EnabledEvents = new Type[]
		{
			typeof( TownInvasion )
		};
	}
}