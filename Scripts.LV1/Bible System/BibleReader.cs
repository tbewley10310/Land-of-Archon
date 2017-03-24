/*
	XML Bible system for ServUO
	Ultima Online Emulator 
	Revised: March 2017
	by Lokai
*/
using System;
using System.IO;
using System.Xml;
using System.Collections;
using Server;

namespace Server.Custom
{
	public enum BookOf
	{
		// Old Testament
		Genesis = 1,Exodus,Leviticus,Numbers,Deuteronomy,Joshua,Judges,Ruth,
		FirstSamuel,SecondSamuel,FirstKings,SecondKings,FirstChronicles,
		SecondChronicles,Ezra,Nehemiah,Esther,Job,Psalms,Proverbs,Ecclesiastes,
		SongofSongs,Isaiah,Jeremiah,Lamentations,Ezekiel,Daniel,Hosea,Joel,Amos,
		Obadiah,Jonah,Micah,Nahum,Habakkuk,Zephaniah,Haggai,Zechariah,Malachi,
		// New Testament
		Matthew,Mark,Luke,John,Acts,Romans,FirstCorinthians,SecondCorinthians,Galatians,
		Ephesians,Philippians,Colossians,FirstThessalonians,SecondThessalonians,
		FirstTimothy,SecondTimothy,Titus,Philemon,Hebrews,James,FirstPeter,SecondPeter,
		FirstJohn,SecondJohn,ThirdJohn,Jude,Revelation
	}
	
	public class BibleReader
	{
		private static int[] m_ChapterLength = new int[] { 0,
			50, 40, 27, 36, 34, 24, 21, 4, 31, 24, 22,
			25, 29, 36, 10, 13, 10, 42, 150, 31, 12, 8,
			66, 52, 5, 48, 12, 14, 3, 9, 1, 4, 7,
			3, 3, 3, 2, 14, 4, 28, 16, 24, 21, 28,
			16, 16, 13, 6, 6, 4, 4, 5, 3, 6, 4,
			3, 1, 13, 5, 5, 3, 5, 1, 1, 1, 22 };
		
		public static int[] ChapterLength
		{
			get { return m_ChapterLength; }
		}
		
		private static string[] m_Books = new string[] { "",
			// Old Testament
			"Genesis","Exodus","Leviticus","Numbers","Deuteronomy","Joshua","Judges","Ruth",
			"First Samuel","Second Samuel","First Kings","Second Kings","First Chronicles",
			"Second Chronicles","Ezra","Nehemiah","Esther","Job","Psalms","Proverbs","Ecclesiastes",
			"Song of Songs","Isaiah","Jeremiah","Lamentations","Ezekiel","Daniel","Hosea","Joel","Amos",
			"Obadiah","Jonah","Micah","Nahum","Habakkuk","Zephaniah","Haggai","Zechariah","Malachi",
			// New Testament
			"Matthew","Mark","Luke","John","Acts","Romans","First Corinthians","Second Corinthians","Galatians",
			"Ephesians","Philippians","Colossians","First Thessalonians","Second Thessalonians",
			"First Timothy","Second Timothy","Titus","Philemon","Hebrews","James","First Peter","Second Peter",
			"First John","Second John","Third John","Jude","Revelation" };
		
		public static string[] Books
		{
			get { return m_Books; }
		}
		
		private string[] m_Verses;

		public string[] Verses{ get{ return m_Verses; } }

		public BibleReader( XmlElement xml )
		{
			m_Verses = xml.InnerText.Split( '|' );
		}

		public static BibleReader GetBibleReader( int bookchap )
		{
			return (BibleReader)m_Table[bookchap];
		}

		public static string[] GetVerses( int bookchap )
		{
			return ((BibleReader)m_Table[bookchap]).Verses;
		}

		public static int GetNumVerses( int bookchap )
		{
			return GetVerses( bookchap ).Length - 1;
		}

		public static string[] GetVerses( BookOf book, int chap )
		{
			int x = ((int)book * 1000) + chap;
			return GetVerses( x );
		}

		public static string[] GetVerses( int book, int chap )
		{
			int x = (book * 1000) + chap;
			return GetVerses( x );
		}

		public static int GetNumVerses( BookOf book, int chap )
		{
			int x = ((int)book * 1000) + chap;
			return GetNumVerses( x );
		}

		public static int GetNumVerses( int book, int chap )
		{
			int x = (book * 1000) + chap;
			return GetNumVerses( x );
		}

		public static int GetNumChapters( BookOf book )
		{
			return ChapterLength[(int)book];
		}

		public static int GetNumChapters( int book )
		{
			return ChapterLength[book];
		}

		public static string GetVerse( BookOf book, int chap, int vers )
		{
			int x = ((int)book * 1000) + chap;
			BibleReader bible = GetBibleReader( x );
			if ( bible != null )
				return bible.Verses[vers - 1];
			else
				return "No verse found with that reference.";
		}

		public static string GetVerse( int book, int chap, int vers )
		{
			int x = (book * 1000) + chap;
			BibleReader bible = GetBibleReader( x );
			if ( bible != null )
				return bible.Verses[vers - 1];
			else
				return "No verse found with that reference.";
		}

		public static string[] GetVerses( BookOf book, int chap, int fvers, int lvers )
		{
			int y = 0;
			string[] output;
			try
			{
				output = new string[(lvers - fvers) + 1];
				for ( int x = fvers; x <= lvers; x++ ) output[y++] = GetVerse( (int)book, chap, x );
				return output;
			}
			catch { output = new string[] { "No verses found with that reference." }; return output; }
		}

		public static string[] GetVerses( int book, int chap, int fvers, int lvers )
		{
			int y = 0;
			string[] output;
			try
			{
				output = new string[(lvers - fvers) + 1];
				for ( int x = fvers; x <= lvers; x++ ) output[y++] = GetVerse( book, chap, x );
				return output;
			}
			catch { output = new string[] { "No verses found with that reference." }; return output; }
		}

		public static string[] GetRandomTopicVerses( Topic topic )
		{
			int y = 0;
			string[] output;
			int[] verses = TopicReader.RandomTopicVerse( topic );
			try
			{
				output = new string[(verses[3] - verses[2]) + 1];
				for ( int x = verses[2]; x <= verses[3]; x++ ) output[y++] = GetVerse( verses[0], verses[1], x );
				return output;
			}
			catch { output = new string[] { "No verses found with that reference." }; return output; }
		}

		public static string GetRandomVerse()
		{
			string verse = "";
			int book = Utility.Random(66) + 1;
			int chap = Utility.Random( GetNumChapters( book ) ) + 1;
			int vers = Utility.Random( GetNumVerses( book, chap ) ) + 1;
			verse += Books[book] + " " + chap.ToString() + ":" + vers.ToString();
			verse += " " + GetVerse( book, chap, vers++ );
			while ( ( ( verse.Length - verse.LastIndexOf(",") ) < 3
					|| ( verse.Length - verse.LastIndexOf("?") ) < 3
					|| ( verse.Length - verse.LastIndexOf(":") ) < 3 )
					&& vers <= GetNumVerses( book, chap ) )
			{
				verse += GetVerse( book, chap, vers );
			}

			return verse;
		}

		private static Hashtable m_Table;

		public static void Initialize()
		{
			m_Table = new Hashtable( CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default );

			string filePath = Path.Combine( Core.BaseDirectory, "Data/Books/bible.xml" );

			if ( !File.Exists( filePath ) )
			{
				Console.WriteLine( "Bible: File not found." );
				return;
			}

			try
			{
				Read( filePath );
				Console.WriteLine( "Bible read successfully." );
			}
			catch ( Exception e )
			{
				Console.WriteLine( "Warning: Exception caught reading bible:" );
				Console.WriteLine( e );
			}
		}

		private static void Read( string filePath )
		{
			XmlDocument doc = new XmlDocument();
			doc.Load( filePath );

			XmlElement root = doc["XMLBIBLE"];

			foreach ( XmlElement bookElement in root.GetElementsByTagName( "BIBLEBOOK" ) )
			{
				int book = Convert.ToInt32( bookElement.GetAttribute( "bnumber" ) );

				if ( book == 0 )
					continue;

				foreach ( XmlElement chapElement in bookElement.GetElementsByTagName( "CHAPTER" ) )
				{
					int chap = Convert.ToInt32( chapElement.GetAttribute( "cnumber" ) );

					if ( chap == 0 )
						continue;

					int bookchap = (book * 1000) + chap;
					try
					{
						BibleReader reader = new BibleReader( chapElement );

						m_Table[bookchap] = reader;
					}
					catch
					{
					}
				}
			}
		}
		
		public static string ToTitleCase( string input )
		{
			return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase( input );
		}
		
		public static int GetBook( string instring )
		{
			string input = instring.ToLower();
			if ( input.Contains("enesi") ) return 1;
			else if ( input.Contains("xodu") ) return 2;
			else if ( input.Contains("evitic") ) return 3;
			else if ( input.Contains("umbers") ) return 4;
			else if ( input.Contains("uteron") ) return 5;
			else if ( input.Contains("joshu") ) return 6;
			else if ( input.Contains("udge") ) return 7;
			else if ( input.Contains("ruth") ) return 8;
			else if ( input.Contains("st sam") ) return 9;
			else if ( input.Contains("nd sam") ) return 10;
			else if ( input.Contains("st k") ) return 11;
			else if ( input.Contains("ings") ) return 12;
			else if ( input.Contains("st chr") ) return 13;
			else if ( input.Contains("ronicl") ) return 14;
			else if ( input.Contains("zra") ) return 15;
			else if ( input.Contains("ehemi") ) return 16;
			else if ( input.Contains("sthe") ) return 17;
			else if ( input.Contains("ob") ) return 18;
			else if ( input.Contains("salm") ) return 19;
			else if ( input.Contains("rover") ) return 20;
			else if ( input.Contains("clesi") ) return 21;
			else if ( input.Contains("ong") ) return 22;
			else if ( input.Contains("sai") ) return 23;
			else if ( input.Contains("eremi") ) return 24;
			else if ( input.Contains("ament") ) return 25;
			else if ( input.Contains("zek") ) return 26;
			else if ( input.Contains("anie") ) return 27;
			else if ( input.Contains("osea") ) return 28;
			else if ( input.Contains("oel") ) return 29;
			else if ( input.Contains("mos") ) return 30;
			else if ( input.Contains("badi") ) return 31;
			else if ( input.Contains("onah") ) return 32;
			else if ( input.Contains("icah") ) return 33;
			else if ( input.Contains("ahum") ) return 34;
			else if ( input.Contains("abak") ) return 35;
			else if ( input.Contains("ephan") ) return 36;
			else if ( input.Contains("ag") ) return 37;
			else if ( input.Contains("aria") ) return 38;
			else if ( input.Contains("alac") ) return 39;
			else if ( input.Contains("mat") ) return 40;
			else if ( input.Contains("mar") ) return 41;
			else if ( input.Contains("uke") ) return 42;
			else if ( input.Contains("cts") ) return 44;
			else if ( input.Contains("oman") ) return 45;
			else if ( input.Contains("st cor") ) return 46;
			else if ( input.Contains("inthia") ) return 47;
			else if ( input.Contains("alat") ) return 48;
			else if ( input.Contains("esian") ) return 49;
			else if ( input.Contains("ilip") ) return 50;
			else if ( input.Contains("olos") ) return 51;
			else if ( input.Contains("st th") ) return 52;
			else if ( input.Contains("salon") ) return 53;
			else if ( input.Contains("st t") ) return 54;
			else if ( input.Contains("moth") ) return 55;
			else if ( input.Contains("itus") ) return 56;
			else if ( input.Contains("ilem") ) return 57;
			else if ( input.Contains("ebre") ) return 58;
			else if ( input.Contains("ames") ) return 59;
			else if ( input.Contains("st pe") ) return 60;
			else if ( input.Contains("eter") ) return 61;
			else if ( input.Contains("st jo") ) return 62;
			else if ( input.Contains("nd jo") ) return 63;
			else if ( input.Contains("rd jo") ) return 64;
			else if ( input.Contains("john") ) return 43;
			else if ( input.Contains("ude") ) return 65;
			else return 66;
		}
	}
	
	public enum Topic
	{
		ABOMINATION_OF_DESOLATION,ADOPTION,ADULTERY,SPIRITUAL_ADULTERY,ALCOHOL,ANGEL_OF_THE_LORD,ANGELS,
		CHERUBIM,HORSES,SERAPHIM,SEVEN_ANGELS,TWENTY_FOUR_ELDERS,ANGER,ANOINTING,ANTICHRIST,APOSTASY,
		FALSE_PROPHETS,FALSE_TEACHERS,APOSTLE,ARMAGEDDON,ARMOR_OF_GOD,ATONEMENT,BABYLON,BAPTISM,HOLY_SPIRIT_BAPTISM
		,WATER_BAPTISM,BEAST,BELIEVE,BIBLE_STUDY,BIRTHRIGHT_PROMISES,BLASPHEME,BLESSINGS_AND_CURSES,BLESSINGS,
		CURSES,BLINDED,BLOOD_OF_CHRIST,BLOOD_OF_FLESH,BOOK_OF_LIFE,BORN_AGAIN,HEBREW_CALENDAR,CALLED,
		CAPITAL_PUNISHMENT,CARNAL_CHARACTER,CHILDREARING,DISCIPLINE,CHILDREN,CHILDREN_OF_GOD,CHOSEN,CHRISTIAN,
		CHURCH,CHURCH_NAME,CHURCH_STRUCTURE,CIRCUMCISION,CLEAN_AND_UNCLEAN_MEAT,COMMANDMENTS,COMMITMENT,COMPASSION,
		CONVERSION,CORRECTION,COUNSEL,COURAGE,COVENANT,NEW_COVENANT,OLD_COVENANT,COVET,CREATION,CROSS,
		DAY_OF_THE_LORD,DEACONS,DEATH,DEBT,DECEIVE,DELIVERANCE,DEMONS,PUNISHMENT,DEPRESSION,DISCIPLE,DISFELLOWSHIP,
		DIVISION,DIVORCE,DOCTRINE,DRESS_AND_GROOMING,ELDERS,ELIJAH,ENDURANCE,ENEMY,IMMORTALITY,EVANGELISM,EVIL,
		FAITH,FAITHFUL,FALSE_CHRIST,FAMINE,FASTING,FATHER,FEAR,FEAR_OF_GOD,FEAST,FIRSTBORN,FIRSTFRUITS,
		FOOT_WASHING,FOREKNEW,FOREVER,FORGIVENESS,FORSAKE,FRIENDSHIP,GLORY,GLUTTONY,GOD,MAJESTY_OF_CHRIST,GOSPEL,
		GOSSIP,GOVERNMENT_OF_GOD,GOVERNMENT_OF_MAN,GRACE,HARVEST,HEALING,HEALTH,HEART,HEAVEN,HEAVENLY_SIGNS,HEIRS,
		GEHENNA,HADES,SHEOL,HOLIDAYS,HOLY,HOLY_SPIRIT,INDWELLING,INSPIRATION,HOMOSEXUALITY,HONESTY,HOPE,
		HOSPITALITY,HUMILITY,IDOLATRY,ISRAEL,CHRIST_OF_ISRAEL,CREATOR,MELCHIZEDEK,MESSIAH,PREEXISTENCE,
		PROPHESIES_OF_MESSIAH,RESURRECTION_OF_MESSIAH,RETURN_OF_MESSIAH,SAVIOR,JOY,JUBILEE,JUDAH,JUDGMENT_OF_GOD,
		JUDGMENT_OF_MAN,JURY_DUTY,JUSTICE,JUSTIFICATION,KILL,KINDNESS,KING,KINGDOM_OF_GOD,KNOWLEDGE,LABOR,LAST_DAYS,
		LAW,LAYING_ON_OF_HANDS,CONSECRATION,HEALING_TOUCH,LEADERSHIP,LETHARGY,LEVI,LIE,LIVING_WATER,LONGSUFFERING,
		LOVE,LUST,MAN,NATURE_OF_MAN,MARRIAGE,HUSBAND,WIFE,MARRIAGE_OF_THE_LAMB,BRIDE_OF_CHRIST,MARTYRDOM,MEDICINE,
		MEDITATION,MERCY,MILITARY_SERVICE,MILLENNIUM,MINISTRY,MODESTY,MONEY,MOTHER,MUSIC,MUSIC_IN_WORSHIP,NATIONS,
		NEW_HEAVENS_AND_NEW_EARTH,NEW_MOONS,NIGHT_TO_BE_MUCH_OBSERVED,OATHS,OBEDIENCE,OFFERINGS,OVERCOMING,
		PASSOVER,PATIENCE,PEACE,PENTECOST,PERSECUTION,PHYSICIAN,PLACE_OF_SAFETY,POLITICS,POOR,PRAYER,PREDESTINED,
		PREJUDICE,PRIDE,PRIEST,THE_PROMISE,PROPHECY,PROPHETS,REBELLION,RECONCILIATION,REDEMPTION,REJOICE,
		REPENTANCE,RESURRECTION,REWARD,RIGHTEOUSNESS,SABBATH,PREPARATION_FOR_SABBATH,VIOLATION_OF_SABBATH,
		SACRIFICES,SPIRITUAL_SACRIFICES,SAINT,SALVATION,SANCTIFICATION,SATAN,SATANIC_PROPHESIES,
		PROTECTION_FROM_SATAN,SCEPTER_PROMISES,SCRIPTURE,LAKE_OF_FIRE,SELF,SELF_CONTROL,SERVANT,
		SEXUALITY_IN_MARRIAGE,SHEPHERD,SICKNESS,SIGNS_AND_WONDERS,MIRACLES,SIGNS,SIN,UNPARDONABLE_SIN,SLAVE,
		SORROW,SOUL,SPEECH,SPIRIT_IN_MAN,SPIRITUAL_GIFTS,STATUTES_AND_JUDGMENTS,STEAL,STEWARDSHIP,SUFFERING,SWEAR,
		TABERNACLE,SPIRITUAL_TABERNACLE,FEAST_OF_TABERNACLES,TAXES,TEACH,TEMPLE,SPIRITUAL_TEMPLE,THANKFULNESS,
		THRONE,TIME,TITHES,FIRST_TITHES,SECOND_TITHES,THIRD_TITHES,TONGUES,TREE_OF_LIFE,TRIALS,
		THE_GREAT_TRIBULATION,JACOBS_TROUBLE,THREE_AND_A_HALF_YEARS,TIMES_OF_THE_GENTILES,FEAST_OF_TRUMPETS,
		TRUTH,FEAST_OF_UNLEAVENEDBREAD,VANITY,WAR,SPIRITUAL_WAR,WEATHER,WHITE_THRONE_OF_JUDGMENT,WIDOW,WISDOM,
		WITCHCRAFT,WOMAN,HARLOT,VIRGIN,WORKS,WORKS_OF_GOD,WORRY,WORSHIP,YOUTH,ZEAL,ZION
	}
}