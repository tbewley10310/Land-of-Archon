using System;

namespace Server.EventSystem
{
	public class EventTimer : Timer
	{
		private BaseEvent m_Event;
		private int m_Ticks;

		public EventTimer( BaseEvent e )
			: base( e.TimerFrequency, e.TimerFrequency )
		{
			m_Event = e;
			m_Ticks = 0;
		}

		protected override void OnTick()
		{
			++m_Ticks;

			m_Event.OnTick( m_Ticks );
		}
	}
}