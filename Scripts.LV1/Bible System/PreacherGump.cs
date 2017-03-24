/*
	XML Bible system for ServUO
	Ultima Online Emulator 
	Revised: March 2017
	by Lokai
*/
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Custom
{
	public class PreacherGump : CG
	{
		private int m_Book;
		private int m_Chapter;
		private int m_FirstVerse;
		private int m_LastVerse;
		private static Mobile m_GM;
		private static WanderingPreacher m_Preacher;

		public PreacherGump( Mobile GM, WanderingPreacher preacher ) : base( 20, 20 )
		{
			m_GM = GM;
			m_GM.CloseGump( typeof( PreacherGump ) );
			m_Preacher = preacher;
			m_Book = (int)( m_Preacher.Book );
			m_Chapter = m_Preacher.Chapter;
			int chapnum = BibleReader.GetNumChapters( m_Book );
			if ( m_Chapter > chapnum ) m_Chapter = chapnum;
			int versnum = BibleReader.GetNumVerses( m_Book, m_Chapter );
			m_FirstVerse = m_Preacher.FirstVerse;
			if ( m_FirstVerse > versnum ) m_FirstVerse = versnum;
			m_LastVerse = m_Preacher.LastVerse;
			if ( m_LastVerse < m_FirstVerse ) m_LastVerse = m_FirstVerse;
			if ( m_LastVerse > versnum ) m_LastVerse = versnum;
			
			string maxchap = chapnum.ToString();
			string max = versnum.ToString();

			AddPage( 0 );
			AddBackground( 0, 0, 676, 540, 0x13BE );
			AddImageTiled( 190, 30, 286, 205, 0xA40 );
			AddAlphaRegion( 190, 30, 486, 476 );

			string passName = BibleReader.Books[m_Book] + " " + m_Chapter.ToString() + " : " + m_FirstVerse.ToString();
			if ( m_FirstVerse < m_LastVerse ) passName += " - " + m_LastVerse.ToString();
			AddLabel( 200, 7, 2100, passName );

			string passage = "";
			for ( int x = m_FirstVerse; x <= m_LastVerse; x++ )
			{
				passage += BibleReader.GetVerse( m_Book, m_Chapter, x );
			}

			AddHtml( 200, 40, 466, 456, passage, true, true );
			AddOKButton( 200, 510, 0, "Accept Changes" );
			
			AddLabel( 15, 30, 0x459, "Book of" );
			AddImageTiled( 15, 50, 60, 20, 0xA40 );
			AddTextEntry( 15, 50, 60, 20, 0x769, 0, BibleReader.Books[m_Book] );
			AddLabel( 15, 110, 0x459, "Chapter (Max - " + maxchap + ")" );
			AddImageTiled( 15, 130, 60, 20, 0xA40 );
			AddTextEntry( 15, 130, 60, 20, 0x769, 1, m_Chapter.ToString() );
			AddLabel( 15, 190, 0x459, "First Verse (Max - " + max + ")" );
			AddImageTiled( 15, 210, 60, 20, 0xA40 );
			AddTextEntry( 15, 210, 60, 20, 0x769, 2, m_FirstVerse.ToString() );
			AddLabel( 15, 270, 0x459, "Last Verse (Max - " + max + ")" );
			AddImageTiled( 15, 290, 60, 20, 0xA40 );
			AddTextEntry( 15, 290, 60, 20, 0x769, 3, m_LastVerse.ToString() );
			AddResetButton( 15, 350, 1, "Reset Passage" );
		}

		public void AddResetButton( int x, int y, int buttonID, string text )
		{
			AddButton( x, y - 1, 5541, 5542, buttonID, GumpButtonType.Reply, 0 );
			AddHtml( x + 35, y, 240, 20, Color( text, 0x480 ), false, false );
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			int ibook, ichap, ifver, ilver, chapnum, versnum;
			int m_Choice = info.ButtonID;
			if ( m_Choice == 1 )
			{
				ibook = BibleReader.GetBook( ( info.GetTextEntry( 0 ) ).Text );
				ichap = Utility.ToInt32( ( info.GetTextEntry( 1 ) ).Text );
				ifver = Utility.ToInt32( ( info.GetTextEntry( 2 ) ).Text );
				ilver = Utility.ToInt32( ( info.GetTextEntry( 3 ) ).Text );

				try
				{
					chapnum = BibleReader.GetNumChapters( ibook );
					m_Preacher.Book = (BookOf)ibook;
					if ( ichap > chapnum ) m_Preacher.Chapter = chapnum;
					else m_Preacher.Chapter = ichap;
					versnum = BibleReader.GetNumVerses( ibook, m_Preacher.Chapter );
					if (ifver > versnum)
					{
						m_Preacher.FirstVerse = versnum;
						m_Preacher.LastVerse = versnum;
					}
					else if (ifver > ilver)
					{
						m_Preacher.FirstVerse = ifver;
						m_Preacher.LastVerse = ifver;
					}
					else if (ilver > versnum)
					{
						m_Preacher.FirstVerse = ifver;
						m_Preacher.LastVerse = versnum;
					}
					else
					{
						m_Preacher.FirstVerse = ifver;
						m_Preacher.LastVerse = ilver;
					}
				}
				catch
				{
				}

				state.Mobile.CloseGump( typeof(PreacherGump) );
				state.Mobile.SendGump( new PreacherGump( m_GM, m_Preacher ) );
			}
			else state.Mobile.CloseGump( typeof(PreacherGump) );
		}
	}
}