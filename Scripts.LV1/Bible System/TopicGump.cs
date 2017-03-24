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
	public class TopicGump : CG
	{
		private int m_Book;
		private int m_Chapter;
		private int m_FirstVerse;
		private int m_LastVerse;
		private static Mobile m_GM;
		private static Bible m_Bible;
		private int m_Topic;

		public TopicGump( Mobile GM, Bible bible, int topic ) : base( 20, 20 )
		{
			m_GM = GM;
			m_GM.CloseGump( typeof( TopicGump ) );
			m_Bible = bible;
			m_Topic = topic;

			m_Book = (int)( m_Bible.Book );
			m_Chapter = m_Bible.Chapter;

			AddPage( 0 );
			AddBackground( 0, 0, 696, 540, 0x13BE );
			
			string str1, str2, str;
			int[,] verses;
			int verselength, topiclength, ymax;
			string verse = "";
			
			verses = TopicReader.GetTopicVerses( (Topic)m_Topic );
			topiclength = verses.GetLength( 0 );
			if ( topiclength < 17 ) ymax = topiclength; else ymax = 16;
			AddLabel( 200, 7, 500, BibleReader.ToTitleCase( TopicReader.GetTopicName( (Topic)m_Topic ) ) );
			AddResetButton( 15, 510, 400, "Home" );
			if ( m_Topic > 0 ) AddBkwdButton( 345, 510, m_Topic - 1, "Prev Topic" );
			if ( m_Topic < 303 ) AddFwdButton( 645, 510, m_Topic + 1, "Next Topic" );
			for ( int y = 0; y < ymax; y++ )
			{
				try
				{
					verse = BibleReader.GetVerse( verses[y,0], verses[y,1], verses[y,2] );
					verselength = verse.Length < 68 ? verse.Length - 8 : 60;
					str1 = BibleReader.Books[ verses[y,0] ] + " " + verses[y,1].ToString() + " : ";
					str2 = verse.Substring( 7, verselength ) + "...";
					str = str1 + str2;
					AddButton( 15, 29 + ( y * 24 ), 5541, 5542, y + 500 + ( m_Topic * 1000), GumpButtonType.Reply, 0 );
					AddHtml( 50, 30 + ( y * 24 ), 635, 20, Color( str, 0x480 ), false, false );
				}
				catch
				{
					break;
				}
			}
		}

		public void AddFwdButton( int x, int y, int buttonID, string text )
		{
			AddButton( x, y - 1, 5541, 5542, buttonID, GumpButtonType.Page, 0 );
			AddHtml( x - 145, y, 240, 20, Color( text, 0x480 ), false, false );
		}

		public void AddBkwdButton( int x, int y, int buttonID, string text )
		{
			AddButton( x, y - 1, 5538, 5539, buttonID, GumpButtonType.Page, 0 );
			AddHtml( x + 35, y, 240, 20, Color( text, 0x480 ), false, false );
		}

		public void AddResetButton( int x, int y, int buttonID, string text )
		{
			AddButton( x, y - 1, 5541, 5542, buttonID, GumpButtonType.Reply, 0 );
			AddHtml( x + 35, y, 240, 20, Color( text, 0x480 ), false, false );
		}
		
		public override void OnResponse( NetState state, RelayInfo info )
		{
			state.Mobile.CloseGump( typeof( TopicGump ) );
			int topic, subtopic;
			int m_Choice = info.ButtonID;
			if ( m_Choice > 499 )
			{
				topic = ( m_Choice - 500 ) / 1000;
				subtopic = ( m_Choice % 1000 ) - 500;
				m_Bible.SetPassage( TopicReader.GetTopicVerse( (Topic)topic, subtopic ) );
				state.Mobile.SendGump( new BibleGump( m_GM, m_Bible ) );
			}
			else if ( m_Choice < 400 )
			{
				state.Mobile.SendGump( new TopicGump( m_GM, m_Bible, m_Choice ) );
			}
			else if ( m_Choice == 400 )
			{
				state.Mobile.SendGump( new BibleGump( m_GM, m_Bible ) );
			}
		}
	}
}