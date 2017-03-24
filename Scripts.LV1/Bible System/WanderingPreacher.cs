/*
	XML Bible system for ServUO
	Ultima Online Emulator 
	Revised: March 2017
	by Lokai
*/
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Custom
{
	public class WanderingPreacher : BaseHealer
	{
		private BookOf m_Book;
		private int m_Chapter;
		private int m_FirstVerse;
		private int m_LastVerse;
		private bool m_Random;
		private Topic m_Topic;
		
		private bool m_Preaching;
		private RecitalTimer m_Timer;
		private DateTime m_NextPreach;
		private static TimeSpan PreachDelay = TimeSpan.FromSeconds( 10.0 );
		
		[CommandProperty( AccessLevel.GameMaster )]
		public BookOf Book { 
			get{ return m_Book; } 
			set { 	if ( value <= (BookOf)66 && value > (BookOf)0 ) m_Book = value;
					else m_Book = (BookOf)1;
					InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Chapter { 
			get{ return m_Chapter; } 
			set { 	if ( value <= BibleReader.GetNumChapters( m_Book ) && value > 0 ) m_Chapter = value;
					else m_Chapter = 1;
					InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int FirstVerse { 
			get{ return m_FirstVerse; } 
			set { 	if ( value <= BibleReader.GetNumVerses( m_Book, m_Chapter ) && value > 0 ) m_FirstVerse = value;
					else m_FirstVerse = 1; 
					InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int LastVerse { 
			get{ return m_LastVerse; } 
			set { 	if ( value <= BibleReader.GetNumVerses( m_Book, m_Chapter ) && value >= m_FirstVerse ) m_LastVerse = value;
					else m_LastVerse = m_FirstVerse; 
					InvalidateProperties(); } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool Random { get{ return m_Random; } set { m_Random = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Topic BibleTopic { get{ return m_Topic; } set { m_Topic = value; } }
		
		public bool Preaching { get{ return m_Preaching; } set { m_Preaching = value; } }

		[Constructable]
		public WanderingPreacher()
		{
			Title = "the wandering preacher";
			m_Book = BookOf.John;
			m_Chapter = 3;
			m_FirstVerse = 16;
			m_LastVerse = 17;
			m_NextPreach = DateTime.Now + PreachDelay;
			m_Preaching = false;
		}

		public WanderingPreacher( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			if ( from.AccessLevel >= AccessLevel.GameMaster )
			{
				list.Add( new ContextMenus.ConfigurePreacher( from, this ) );
			}
		}
		
		public void ReadVerse()
		{
			m_Preaching = true;
			Say( "Thus sayeth the Lord:" );
			Say( BibleReader.GetVerse( m_Book, m_Chapter, m_FirstVerse ) );
			m_Preaching = false;
			m_NextPreach = DateTime.Now + PreachDelay;
		}
		
		public void ReadPassage()
		{
			m_Preaching = true;
			Say("Hear the Word of the Lord:");
			m_Timer = new RecitalTimer( this, BibleReader.GetVerses( m_Book, m_Chapter, m_FirstVerse, m_LastVerse ) );
			m_Timer.Start();
			m_NextPreach = DateTime.Now + PreachDelay;
		}
		
		public void ReadTopicalPassage()
		{
			Topic readTopic = BibleTopic;
			m_Preaching = true;
			if (m_Random)
			{
				Array values = Enum.GetValues(typeof(Topic));
				Random random = new Random();
				readTopic = (Topic)values.GetValue(random.Next(values.Length));
			}
			Say( "How about this topic - {0}:", TopicReader.GetTopicName( readTopic ) );
			m_Timer = new RecitalTimer( this, BibleReader.GetRandomTopicVerses( readTopic ) );
			m_Timer.Start();
			m_NextPreach = DateTime.Now + PreachDelay;
		}
		
		public void ReadTopicalPassage( Topic topic )
		{
			m_Preaching = true;
			Say( "A Word from the Lord concerning {0}:", TopicReader.GetTopicName( topic ) );
			m_Timer = new RecitalTimer( this, BibleReader.GetRandomTopicVerses( topic ) );
			m_Timer.Start();
			m_NextPreach = DateTime.Now + PreachDelay;
		}

		// The Wandering Preacher may begin preaching to you if he feels that you need it.
		public void PreachTo( Mobile m )
		{
			if ( m.Criminal || m.Karma < -2499 )
			{
				Say( "Woe to you, you criminals and hypocrites!" );
				ReadPassage();
			}
			else if ( m.Kills >= 1 || m.Karma < 0 )
			{
				ReadVerse();
			}
			else if ( m.Karma > 2499 )
			{
				Say( "Greetings {0}!", m.Female?"Sister":"Brother" );
			}
		}
		
		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m.Alive && !m.Frozen && InRange( m, 4 ) && !InRange( oldLocation, 4 ) && InLOS( m ) )
			{
				if ( this.HealsYoungPlayers && m.Hits < m.HitsMax && m is PlayerMobile && ((PlayerMobile)m).Young )
				{
					OfferHeal( (PlayerMobile) m );
				}
				else if ( !Preaching && DateTime.Now >= m_NextPreach )
				{
					PreachTo( m );
				}
			}
		}

		public override void OfferHeal( PlayerMobile m )
		{
			Direction = GetDirectionTo( m );

			if ( m.CheckYoungHealTime() )
			{
				Say( "Let me annoint thee with oil, my child." );

				m.PlaySound( 0x1F2 );
				m.FixedEffect( 0x376A, 9, 32 );

				m.Hits = m.HitsMax;
			}
			else
			{
				Say( 501228 ); // I can do no more for you at this time.
			}
		}

		public override void OnSpeech( SpeechEventArgs e )
		{
			bool FoundTopic = false;
			int TopicFound = 0;
			string speech = e.Speech.ToLower();
			if ( !Preaching && speech.IndexOf("topic") >= 0 )
			{
				TopicFound = TopicParse.GetMatch( speech );
				if ( TopicFound > 0 ) FoundTopic = true;
				// for ( int x = 0; x < Enum.GetValues(typeof(Topic)).Length; x++ )
				// {
					// if ( speech.IndexOf( TopicReader.GetTopicName( (Topic)x ) ) >= 0 )
					// {
						// FoundTopic = true;
						// TopicFound = x;
						// break;
					// }
				// }
				if ( FoundTopic ) ReadTopicalPassage( (Topic)TopicFound ); else ReadTopicalPassage();
			}
			else if ( !Preaching && speech.IndexOf("verse") >= 0 ) { ReadVerse(); }
			else if ( !Preaching && speech.IndexOf("passage") >= 0 ) { ReadPassage(); }
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int)m_Topic ); //Version 1
			
			writer.Write( (int)m_Book ); // Version 0
			writer.Write( (int)m_Chapter );
			writer.Write( (int)m_FirstVerse );
			writer.Write( (int)m_LastVerse );
			writer.Write( (bool)m_Random );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			
			switch( version )
			{
				case 1: { m_Topic = (Topic)reader.ReadInt(); goto case 0; }
				case 0: {
					m_Book = (BookOf)reader.ReadInt();
					m_Chapter = reader.ReadInt();
					m_FirstVerse = reader.ReadInt();
					m_LastVerse = reader.ReadInt();
					m_Random = reader.ReadBool();
					
					m_NextPreach = DateTime.Now + PreachDelay;
					m_Preaching = false;
					break;
				}
			}
			
		}
	}
}