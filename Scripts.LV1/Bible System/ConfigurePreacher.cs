/*
	XML Bible system for ServUO
	Ultima Online Emulator 
	Revised: March 2017
	by Lokai
*/
using System;
using Server.Items;
using Server.Custom;

namespace Server.ContextMenus
{
	public class ConfigurePreacher : ContextMenuEntry
	{
		private Mobile m_From;
		private WanderingPreacher m_Preacher;

		public ConfigurePreacher( Mobile from, WanderingPreacher preacher ) : base( 2132 )
		{
			m_From = from;
			m_Preacher = preacher;
		}

		public override void OnClick()
		{
			if ( m_From != null )
				m_From.SendGump( new PreacherGump( m_From, m_Preacher ) );
		}
	}
}