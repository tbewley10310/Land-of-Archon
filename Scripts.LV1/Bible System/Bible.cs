/*
	XML Bible system for ServUO
	Ultima Online Emulator 
	Revised: March 2017
	by Lokai
*/
using System;
using Server.Custom;
using Server.Items;
using Server.Network;

namespace Server.Custom
{
	public class Bible : Item
	{
		private BookOf m_Book;
		private int m_Chapter;
		private int m_FirstVerse;
		private int m_LastVerse;
		private bool m_Random;
		private Topic m_Topic;
		
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
		
		[Constructable]
		public Bible() : base( 0x2252 )
		{
			LootType = LootType.Blessed;
			Movable = true;
			Hue = 0x297;
			Name = "The Holy Bible";
			m_Book = BookOf.Genesis;
			m_Chapter = 1;
			m_FirstVerse = 1;
			m_LastVerse = 1;
			m_Random = false;
		}

		public Bible( Serial serial ) : base( serial )
		{
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );

			this.LabelTo( from, "Currently set to the Book of {0}, chapter {1}, starting at verse {2}.",
				m_Book.ToString(),m_Chapter.ToString(),m_FirstVerse.ToString() );
		}
		
		public void SetPassage( int[] passage )
		{
			Book = (BookOf)passage[0];
			Chapter = passage[1];
			FirstVerse = passage[2];
			LastVerse = passage[3];
		}
		
		public void SetPassage( int book, int chap, int fvers, int lvers )
		{
			Book = (BookOf)book;
			Chapter = chap;
			FirstVerse = fvers;
			LastVerse = lvers;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendGump( new BibleGump( from, this ) );
			// try
			// {
				// if ( m_Random )
				// {
					// from.Say( BibleReader.GetRandomVerse() );
				// }
				// else
				// {
					// if ( m_FirstVerse == m_LastVerse )
						// from.Say( BibleReader.GetVerse( (int)m_Book, m_Chapter, m_FirstVerse ) );
					// else
						// for (int x=m_FirstVerse; x<=m_LastVerse; x++)
						// {
							// from.Say( BibleReader.GetVerse( (int)m_Book, m_Chapter, x ) );
						// }
				// }
			// }
			// catch ( Exception e )
			// {
				// Console.WriteLine("Unable to recite due to {0}.", e.Message);
			// }
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version #

			writer.Write( (bool)m_Random ); // version 2
			
			writer.Write( (int)m_Book ); // version 1
			writer.Write( (int)m_Chapter );
			writer.Write( (int)m_FirstVerse );
			writer.Write( (int)m_LastVerse );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 2:
				{
					m_Random = reader.ReadBool();
					goto case 1;
				}
				case 1:
				{
					m_Book = (BookOf)( reader.ReadInt() );
					m_Chapter = reader.ReadInt();
					m_FirstVerse = reader.ReadInt();
					m_LastVerse = reader.ReadInt();
					goto case 0;
				}
				case 0:
				{
					break;
				}
				default: break;
			}
		}
	}
}