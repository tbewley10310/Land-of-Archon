using System;

namespace Server.EventSystem
{
	public class PlayerStats
	{
		private Mobile m_Player;

		public Mobile Player { get { return m_Player; } }

		public PlayerStats( Mobile player )
		{
			m_Player = player;
		}
	}
}