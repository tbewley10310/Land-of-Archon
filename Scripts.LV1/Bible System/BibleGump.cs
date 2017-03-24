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
	public class BibleGump : CG
	{
		private int m_Book;
		private int m_Chapter;
		private int m_FirstVerse;
		private int m_LastVerse;
		private static Mobile m_GM;
		private static Bible m_Bible;
		private int m_Topic;

		public BibleGump( Mobile GM, Bible bible ) : base( 20, 20 )
		{
			m_GM = GM;
			m_GM.CloseGump( typeof( BibleGump ) );
			m_Bible = bible;
			m_Book = (int)( m_Bible.Book );
			m_Chapter = m_Bible.Chapter;
			m_Topic = (int)( m_Bible.BibleTopic );
			int chapnum = BibleReader.GetNumChapters( m_Book );
			if ( m_Chapter > chapnum ) m_Chapter = chapnum;
			int versnum = BibleReader.GetNumVerses( m_Book, m_Chapter );
			m_FirstVerse = m_Bible.FirstVerse;
			if ( m_FirstVerse > versnum ) m_FirstVerse = versnum;
			m_LastVerse = m_Bible.LastVerse;
			if ( m_LastVerse < m_FirstVerse ) m_LastVerse = m_FirstVerse;
			if ( m_LastVerse > versnum ) m_LastVerse = versnum;
			
			string maxchap = chapnum.ToString();
			string max = versnum.ToString();

			AddPage( 0 );
			AddBackground( 0, 0, 696, 540, 0x13BE );
			AddPage( 1 );
			AddAlphaRegion( 190, 30, 486, 476 );

			string passName = BibleReader.Books[m_Book] + " " + m_Chapter.ToString() + " : " + m_FirstVerse.ToString();
			if ( m_FirstVerse < m_LastVerse ) passName += " - " + m_LastVerse.ToString();
			AddLabel( 200, 7, 500, passName );

			string passage = "";
			for ( int x = m_FirstVerse; x <= m_LastVerse; x++ )
			{
				passage += BibleReader.GetVerse( m_Book, m_Chapter, x );
			}

			AddHtml( 200, 40, 466, 456, passage, true, true );
			AddOKButton( 200, 510, 0, "Accept Changes" );
			
			AddLabel( 15, 30, 0x459, "Book of" );
			AddImageTiled( 15, 50, 160, 20, 0xA40 );
			AddTextEntry( 15, 50, 160, 20, 0x769, 0, BibleReader.Books[m_Book] );
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
			AddPageBkwdButton( 15, 380, 2, "Index" );
			AddPageBkwdButton( 15, 410, 3, "Concordance" );
			
			AddPage( 2 );
			int entry = 1;
			int ymax;
			AddPageBkwdButton( 15, 510, 1, "Back" );
			for ( int x = 0; x < 4; x++ )
			{
				if ( x < 3 ) ymax = 17; else ymax = 15;
				for ( int y = 0; y < ymax; y++ )
				{
					AddResetButton( 15 + ( x * 171 ), 20 + ( y * 25 ), entry + 1, BibleReader.Books[entry++] );
				}
			}
			
			int zlimit = 15;
			entry = 0;
			for ( int x = 0; x < 7; x++ )
			{
				AddPage( 3 + x );
				AddPageBkwdButton( 15, 510, 1, "Back" );
				if ( x > 0 ) AddPageBkwdButton( 345, 510, 2 + x, "Prev Topics" );
				if ( x < 6 ) AddPageFwdButton( 645, 510, 4 + x, "Next Topics" );
				if ( x == 6 ) zlimit = 11;
				for ( int y = 0; y < 3; y++ )
				{
					for ( int z = 0; z < zlimit; z++ )
					{
						AddResetButton( 15 + ( y * 225 ), 20 + ( z * 25 ), entry + 100, BibleReader.ToTitleCase( TopicReader.GetTopicName( (Topic)entry++ ) ) );
					}
				}
			}
		}

		public void AddPageOKButton( int x, int y, int buttonID, string text )
		{
			AddButton( x, y - 1, 4023, 4025, 0, GumpButtonType.Page, buttonID );
			AddHtml( x + 35, y, 240, 20, Color( text, 0x480 ), false, false );
		}

		public void AddResetButton( int x, int y, int buttonID, string text )
		{
			AddButton( x, y - 1, 5541, 5542, buttonID, GumpButtonType.Reply, 0 );
			AddHtml( x + 35, y, 240, 20, Color( text, 0x480 ), false, false );
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			int ibook, ichap, ifver, ilver, chapnum, versnum;
			int topic;
			int m_Choice = info.ButtonID;
			if ( m_Choice > 99 )
			{
				topic = m_Choice - 100; /*
				if ( topic > 250 ) state.Mobile.SendGump( new TopicGumpF( m_GM, m_Bible, topic ) );
				else if ( topic > 200 ) state.Mobile.SendGump( new TopicGumpE( m_GM, m_Bible, topic ) );
				else if ( topic > 150 ) state.Mobile.SendGump( new TopicGumpD( m_GM, m_Bible, topic ) );
				else if ( topic > 100 ) state.Mobile.SendGump( new TopicGumpC( m_GM, m_Bible, topic ) );
				else if ( topic > 50 ) state.Mobile.SendGump( new TopicGumpB( m_GM, m_Bible, topic ) );
				else  state.Mobile.SendGump( new TopicGumpA( m_GM, m_Bible, topic ) );  */
				state.Mobile.SendGump( new TopicGump( m_GM, m_Bible, topic ) ); 
			}
			else if ( m_Choice > 1 && m_Choice < 68 )
			{
				m_Bible.SetPassage( m_Choice - 1, 1, 1, BibleReader.GetNumVerses( m_Choice - 1, 1 ) );
				state.Mobile.SendGump( new BibleGump( m_GM, m_Bible ) );
			}
			else if ( m_Choice == 1 )
			{
				ibook = BibleReader.GetBook( ( info.GetTextEntry( 0 ) ).Text );
				ichap = Utility.ToInt32( ( info.GetTextEntry( 1 ) ).Text );
				ifver = Utility.ToInt32( ( info.GetTextEntry( 2 ) ).Text );
				ilver = Utility.ToInt32( ( info.GetTextEntry( 3 ) ).Text );

				try
				{
					chapnum = BibleReader.GetNumChapters( ibook );
					m_Bible.Book = (BookOf)ibook;
					if ( ichap > chapnum ) m_Bible.Chapter = chapnum;
					else m_Bible.Chapter = ichap;
					versnum = BibleReader.GetNumVerses( ibook, m_Bible.Chapter );
					if (ifver > versnum)
					{
						m_Bible.FirstVerse = versnum;
						m_Bible.LastVerse = versnum;
					}
					else if (ifver > ilver)
					{
						m_Bible.FirstVerse = ifver;
						m_Bible.LastVerse = ifver;
					}
					else if (ilver > versnum)
					{
						m_Bible.FirstVerse = ifver;
						m_Bible.LastVerse = versnum;
					}
					else
					{
						m_Bible.FirstVerse = ifver;
						m_Bible.LastVerse = ilver;
					}
				}
				catch
				{
				}

				state.Mobile.CloseGump( typeof(BibleGump) );
				state.Mobile.SendGump( new BibleGump( m_GM, m_Bible ) );
			}
			else state.Mobile.CloseGump( typeof(BibleGump) );
		}
	}
}