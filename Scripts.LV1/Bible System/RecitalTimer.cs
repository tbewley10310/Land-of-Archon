/*
	XML Bible system for ServUO
	Ultima Online Emulator 
	Revised: March 2017
	by Lokai
*/
using System;
using Server.Network;

namespace Server.Custom
{
	/// <summary>
	/// Timer for Book Passage Recital
	/// </summary>
	public class RecitalTimer : Timer
	{
		private Mobile m_Mobile;
		private int m_State, m_Count;
		private WanderingPreacher w;

		private string[] m_Verses;

		public RecitalTimer( Mobile m, string[] verses ) : this( m, verses, verses.Length )
		{
		}

		public RecitalTimer( Mobile m, string[] verses, int count ) : base( TimeSpan.FromSeconds( 2.0 ), TimeSpan.FromSeconds( 7.0 ) )
		{
			m_Mobile = m;
			m_Verses = new string[count];
			m_Verses = verses;
			m_Count = count;
			m_State = 0;
		}

		protected override void OnTick()
		{
			if ( m_Mobile is WanderingPreacher ) w = m_Mobile as WanderingPreacher;
			if ( m_State < m_Count )
				m_Mobile.Say( m_Verses[m_State++] );

			if ( m_State == m_Count )
			{
				Stop();
				w.Preaching = false;
			}
		}
	}
}