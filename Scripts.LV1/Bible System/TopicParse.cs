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
	public static class TopicParse
	{
		public static int GetMatch( string speech )
		{
			char[] delimiterChars = { ' ', ',', '.' };
	        string[] words = speech.Split(delimiterChars);
			string topics = String.Copy( AllTopicWords );

	        foreach (string s in words)
	        {
	            if ( topics.IndexOf( s ) > 0 )
				{
					switch( topics.IndexOf( s ) )
					{
						case 0: return 0;
						case 15: { return (int)( Topic.ABOMINATION_OF_DESOLATION ); }
						case 26: { return (int)( Topic.ADOPTION ); }
						case 35: { return (int)( Topic.ADULTERY ); }
						case 44: { return (int)( Topic.SPIRITUAL_ADULTERY ); }
						case 63: { return (int)( Topic.ALCOHOL ); }
						case 71: case 84: { return (int)( Topic.ANGEL_OF_THE_LORD ); }
						case 89: { return (int)( Topic.ANGELS ); }
						case 96: { return (int)( Topic.CHERUBIM ); }
						case 105: { return (int)( Topic.HORSES ); }
						case 112: { return (int)( Topic.SERAPHIM ); }
						case 121: { return (int)( Topic.SEVEN_ANGELS ); }
						case 134: case 146: { return (int)( Topic.TWENTY_FOUR_ELDERS ); }
						case 153: { return (int)( Topic.ANGER ); }
						case 159: { return (int)( Topic.ANOINTING ); }
						case 169: { return (int)( Topic.ANTICHRIST ); }
						case 180: { return (int)( Topic.APOSTASY ); }
						case 189: { return (int)( Topic.FALSE_PROPHETS ); }
						case 204: { return (int)( Topic.FALSE_TEACHERS ); }
						case 219: { return (int)( Topic.APOSTLE ); }
						case 227: { return (int)( Topic.ARMAGEDDON ); }
						case 238: { return (int)( Topic.ARMOR_OF_GOD ); }
						case 251: { return (int)( Topic.ATONEMENT ); }
						case 261: { return (int)( Topic.BABYLON ); }
						case 269: { return (int)( Topic.BAPTISM ); }
						case 277: case 282: { return (int)( Topic.HOLY_SPIRIT_BAPTISM ); }
						case 297: { return (int)( Topic.WATER_BAPTISM ); }
						case 311: { return (int)( Topic.BEAST ); }
						case 317: { return (int)( Topic.BELIEVE ); }
						case 325: { return (int)( Topic.BIBLE_STUDY ); }
						case 337: { return (int)( Topic.BIRTHRIGHT_PROMISES ); }
						case 357: { return (int)( Topic.BLASPHEME ); }
						case 367: { return (int)( Topic.BLESSINGS_AND_CURSES ); }
						case 388: { return (int)( Topic.BLESSINGS ); }
						case 398: { return (int)( Topic.CURSES ); }
						case 405: { return (int)( Topic.BLINDED ); }
						case 413: { return (int)( Topic.BLOOD_OF_CHRIST ); }
						case 429: case 438: { return (int)( Topic.BLOOD_OF_FLESH ); }
						case 444: { return (int)( Topic.BOOK_OF_LIFE ); }
						case 457: { return (int)( Topic.BORN_AGAIN ); }
						case 468: case 475: { return (int)( Topic.HEBREW_CALENDAR ); }
						case 484: { return (int)( Topic.CALLED ); }
						case 491: case 499: { return (int)( Topic.CAPITAL_PUNISHMENT ); }
						case 510: { return (int)( Topic.CARNAL_CHARACTER ); }
						case 527: { return (int)( Topic.CHILDREARING ); }
						case 540: { return (int)( Topic.DISCIPLINE ); }
						case 551: { return (int)( Topic.CHILDREN ); }
						case 560: { return (int)( Topic.CHILDREN_OF_GOD ); }
						case 576: { return (int)( Topic.CHOSEN ); }
						case 583: { return (int)( Topic.CHRISTIAN ); }
						case 593: { return (int)( Topic.CHURCH ); }
						case 600: { return (int)( Topic.CHURCH_NAME ); }
						case 612: case 619: { return (int)( Topic.CHURCH_STRUCTURE ); }
						case 629: { return (int)( Topic.CIRCUMCISION ); }
						case 642: case 652: { return (int)( Topic.CLEAN_AND_UNCLEAN_MEAT ); }
						case 665: { return (int)( Topic.COMMANDMENTS ); }
						case 678: { return (int)( Topic.COMMITMENT ); }
						case 689: { return (int)( Topic.COMPASSION ); }
						case 700: { return (int)( Topic.CONVERSION ); }
						case 711: { return (int)( Topic.CORRECTION ); }
						case 722: { return (int)( Topic.COUNSEL ); }
						case 730: { return (int)( Topic.COURAGE ); }
						case 738: { return (int)( Topic.COVENANT ); }
						case 747: { return (int)( Topic.NEW_COVENANT ); }
						case 760: { return (int)( Topic.OLD_COVENANT ); }
						case 773: { return (int)( Topic.COVET ); }
						case 779: { return (int)( Topic.CREATION ); }
						case 788: { return (int)( Topic.CROSS ); }
						case 794: { return (int)( Topic.DAY_OF_THE_LORD ); }
						case 810: { return (int)( Topic.DEACONS ); }
						case 818: { return (int)( Topic.DEATH ); }
						case 824: { return (int)( Topic.DEBT ); }
						case 829: { return (int)( Topic.DECEIVE ); }
						case 837: { return (int)( Topic.DELIVERANCE ); }
						case 849: { return (int)( Topic.DEMONS ); }
						case 856: { return (int)( Topic.PUNISHMENT ); }
						case 867: { return (int)( Topic.DEPRESSION ); }
						case 878: { return (int)( Topic.DISCIPLE ); }
						case 887: { return (int)( Topic.DISFELLOWSHIP ); }
						case 901: { return (int)( Topic.DIVISION ); }
						case 910: { return (int)( Topic.DIVORCE ); }
						case 918: { return (int)( Topic.DOCTRINE ); }
						case 927: case 937: { return (int)( Topic.DRESS_AND_GROOMING ); }
						case 946: { return (int)( Topic.ELDERS ); }
						case 953: { return (int)( Topic.ELIJAH ); }
						case 960: { return (int)( Topic.ENDURANCE ); }
						case 970: { return (int)( Topic.ENEMY ); }
						case 976: { return (int)( Topic.IMMORTALITY ); }
						case 988: { return (int)( Topic.EVANGELISM ); }
						case 999: { return (int)( Topic.EVIL ); }
						case 1004: { return (int)( Topic.FAITH ); }
						case 1010: { return (int)( Topic.FAITHFUL ); }
						case 1019: { return (int)( Topic.FALSE_CHRIST ); }
						case 1032: { return (int)( Topic.FAMINE ); }
						case 1039: { return (int)( Topic.FASTING ); }
						case 1047: { return (int)( Topic.FATHER ); }
						case 1054: { return (int)( Topic.FEAR ); }
						case 1059: { return (int)( Topic.FEAR_OF_GOD ); }
						case 1071: { return (int)( Topic.FEAST ); }
						case 1077: { return (int)( Topic.FIRSTBORN ); }
						case 1087: { return (int)( Topic.FIRSTFRUITS ); }
						case 1099: case 1104: { return (int)( Topic.FOOT_WASHING ); }
						case 1112: { return (int)( Topic.FOREKNEW ); }
						case 1121: { return (int)( Topic.FOREVER ); }
						case 1129: { return (int)( Topic.FORGIVENESS ); }
						case 1141: { return (int)( Topic.FORSAKE ); }
						case 1149: { return (int)( Topic.FRIENDSHIP ); }
						case 1160: { return (int)( Topic.GLORY ); }
						case 1166: { return (int)( Topic.GLUTTONY ); }
						case 1175: { return (int)( Topic.GOD ); }
						case 1179: { return (int)( Topic.MAJESTY_OF_CHRIST ); }
						case 1197: { return (int)( Topic.GOSPEL ); }
						case 1204: { return (int)( Topic.GOSSIP ); }
						case 1211: { return (int)( Topic.GOVERNMENT_OF_GOD ); }
						case 1229: { return (int)( Topic.GOVERNMENT_OF_MAN ); }
						case 1247: { return (int)( Topic.GRACE ); }
						case 1253: { return (int)( Topic.HARVEST ); }
						case 1261: { return (int)( Topic.HEALING ); }
						case 1269: { return (int)( Topic.HEALTH ); }
						case 1276: { return (int)( Topic.HEART ); }
						case 1282: { return (int)( Topic.HEAVEN ); }
						case 1289: case 1298: { return (int)( Topic.HEAVENLY_SIGNS ); }
						case 1304: { return (int)( Topic.HEIRS ); }
						case 1310: { return (int)( Topic.GEHENNA ); }
						case 1318: { return (int)( Topic.HADES ); }
						case 1324: { return (int)( Topic.SHEOL ); }
						case 1330: { return (int)( Topic.HOLIDAYS ); }
						case 1339: { return (int)( Topic.HOLY ); }
						case 1344: { return (int)( Topic.HOLY_SPIRIT ); }
						case 1356: { return (int)( Topic.INDWELLING ); }
						case 1367: { return (int)( Topic.INSPIRATION ); }
						case 1379: { return (int)( Topic.HOMOSEXUALITY ); }
						case 1393: { return (int)( Topic.HONESTY ); }
						case 1401: { return (int)( Topic.HOPE ); }
						case 1406: { return (int)( Topic.HOSPITALITY ); }
						case 1418: { return (int)( Topic.HUMILITY ); }
						case 1427: { return (int)( Topic.IDOLATRY ); }
						case 1436: { return (int)( Topic.ISRAEL ); }
						case 1443: { return (int)( Topic.CHRIST_OF_ISRAEL ); }
						case 1460: { return (int)( Topic.CREATOR ); }
						case 1468: { return (int)( Topic.MELCHIZEDEK ); }
						case 1480: { return (int)( Topic.MESSIAH ); }
						case 1488: { return (int)( Topic.PREEXISTENCE ); }
						case 1501: { return (int)( Topic.PROPHESIES_OF_MESSIAH ); }
						case 1523: { return (int)( Topic.RESURRECTION_OF_MESSIAH ); }
						case 1547: { return (int)( Topic.RETURN_OF_MESSIAH ); }
						case 1565: { return (int)( Topic.SAVIOR ); }
						case 1572: { return (int)( Topic.JOY ); }
						case 1576: { return (int)( Topic.JUBILEE ); }
						case 1584: { return (int)( Topic.JUDAH ); }
						case 1590: { return (int)( Topic.JUDGMENT_OF_GOD ); }
						case 1606: { return (int)( Topic.JUDGMENT_OF_MAN ); }
						case 1622: { return (int)( Topic.JURY_DUTY ); }
						case 1632: { return (int)( Topic.JUSTICE ); }
						case 1640: { return (int)( Topic.JUSTIFICATION ); }
						case 1654: { return (int)( Topic.KILL ); }
						case 1659: { return (int)( Topic.KINDNESS ); }
						case 1668: { return (int)( Topic.KING ); }
						case 1673: { return (int)( Topic.KINGDOM_OF_GOD ); }
						case 1688: { return (int)( Topic.KNOWLEDGE ); }
						case 1698: { return (int)( Topic.LABOR ); }
						case 1704: { return (int)( Topic.LAST_DAYS ); }
						case 1714: { return (int)( Topic.LAW ); }
						case 1718: { return (int)( Topic.LAYING_ON_OF_HANDS ); }
						case 1737: { return (int)( Topic.CONSECRATION ); }
						case 1750: { return (int)( Topic.HEALING_TOUCH ); }
						case 1764: { return (int)( Topic.LEADERSHIP ); }
						case 1775: { return (int)( Topic.LETHARGY ); }
						case 1784: { return (int)( Topic.LEVI ); }
						case 1789: { return (int)( Topic.LIE ); }
						case 1793: { return (int)( Topic.LIVING_WATER ); }
						case 1806: { return (int)( Topic.LONGSUFFERING ); }
						case 1820: { return (int)( Topic.LOVE ); }
						case 1825: { return (int)( Topic.LUST ); }
						case 1830: { return (int)( Topic.MAN ); }
						case 1834: { return (int)( Topic.NATURE_OF_MAN ); }
						case 1848: { return (int)( Topic.MARRIAGE ); }
						case 1857: { return (int)( Topic.HUSBAND ); }
						case 1865: { return (int)( Topic.WIFE ); }
						case 1870: { return (int)( Topic.MARRIAGE_OF_THE_LAMB ); }
						case 1891: { return (int)( Topic.BRIDE_OF_CHRIST ); }
						case 1907: { return (int)( Topic.MARTYRDOM ); }
						case 1917: { return (int)( Topic.MEDICINE ); }
						case 1926: { return (int)( Topic.MEDITATION ); }
						case 1937: { return (int)( Topic.MERCY ); }
						case 1943: { return (int)( Topic.MILITARY_SERVICE ); }
						case 1960: { return (int)( Topic.MILLENNIUM ); }
						case 1971: { return (int)( Topic.MINISTRY ); }
						case 1980: { return (int)( Topic.MODESTY ); }
						case 1988: { return (int)( Topic.MONEY ); }
						case 1994: { return (int)( Topic.MOTHER ); }
						case 2001: { return (int)( Topic.MUSIC ); }
						case 2007: { return (int)( Topic.MUSIC_IN_WORSHIP ); }
						case 2024: { return (int)( Topic.NATIONS ); }
						case 2032: { return (int)( Topic.NEW_HEAVENS_AND_NEW_EARTH ); }
						case 2058: { return (int)( Topic.NEW_MOONS ); }
						case 2068: case 2085: { return (int)( Topic.NIGHT_TO_BE_MUCH_OBSERVED ); }
						case 2094: { return (int)( Topic.OATHS ); }
						case 2100: { return (int)( Topic.OBEDIENCE ); }
						case 2110: { return (int)( Topic.OFFERINGS ); }
						case 2120: { return (int)( Topic.OVERCOMING ); }
						case 2131: { return (int)( Topic.PASSOVER ); }
						case 2140: { return (int)( Topic.PATIENCE ); }
						case 2149: { return (int)( Topic.PEACE ); }
						case 2155: { return (int)( Topic.PENTECOST ); }
						case 2165: { return (int)( Topic.PERSECUTION ); }
						case 2177: { return (int)( Topic.PHYSICIAN ); }
						case 2187: case 2196: { return (int)( Topic.PLACE_OF_SAFETY ); }
						case 2203: { return (int)( Topic.POLITICS ); }
						case 2212: { return (int)( Topic.POOR ); }
						case 2217: { return (int)( Topic.PRAYER ); }
						case 2224: { return (int)( Topic.PREDESTINED ); }
						case 2236: { return (int)( Topic.PREJUDICE ); }
						case 2246: { return (int)( Topic.PRIDE ); }
						case 2252: { return (int)( Topic.PRIEST ); }
						case 2259: case 2263: { return (int)( Topic.THE_PROMISE ); }
						case 2271: { return (int)( Topic.PROPHECY ); }
						case 2280: { return (int)( Topic.PROPHETS ); }
						case 2289: { return (int)( Topic.REBELLION ); }
						case 2299: { return (int)( Topic.RECONCILIATION ); }
						case 2314: { return (int)( Topic.REDEMPTION ); }
						case 2325: { return (int)( Topic.REJOICE ); }
						case 2333: { return (int)( Topic.REPENTANCE ); }
						case 2344: { return (int)( Topic.RESURRECTION ); }
						case 2357: { return (int)( Topic.REWARD ); }
						case 2364: { return (int)( Topic.RIGHTEOUSNESS ); }
						case 2378: { return (int)( Topic.SABBATH ); }
						case 2386: { return (int)( Topic.PREPARATION_FOR_SABBATH ); }
						case 2410: { return (int)( Topic.VIOLATION_OF_SABBATH ); }
						case 2431: { return (int)( Topic.SACRIFICES ); }
						case 2442: { return (int)( Topic.SPIRITUAL_SACRIFICES ); }
						case 2463: { return (int)( Topic.SAINT ); }
						case 2469: { return (int)( Topic.SALVATION ); }
						case 2479: { return (int)( Topic.SANCTIFICATION ); }
						case 2494: { return (int)( Topic.SATAN ); }
						case 2500: { return (int)( Topic.SATANIC_PROPHESIES ); }
						case 2519: { return (int)( Topic.PROTECTION_FROM_SATAN ); }
						case 2541: { return (int)( Topic.SCEPTER_PROMISES ); }
						case 2558: { return (int)( Topic.SCRIPTURE ); }
						case 2568: { return (int)( Topic.LAKE_OF_FIRE ); }
						case 2581: { return (int)( Topic.SELF ); }
						case 2586: { return (int)( Topic.SELF_CONTROL ); }
						case 2599: { return (int)( Topic.SERVANT ); }
						case 2607: { return (int)( Topic.SEXUALITY_IN_MARRIAGE ); }
						case 2629: { return (int)( Topic.SHEPHERD ); }
						case 2638: { return (int)( Topic.SICKNESS ); }
						case 2647: case 2657: { return (int)( Topic.SIGNS_AND_WONDERS ); }
						case 2665: { return (int)( Topic.MIRACLES ); }
						case 2674: { return (int)( Topic.SIGNS ); }
						case 2680: { return (int)( Topic.SIN ); }
						case 2684: { return (int)( Topic.UNPARDONABLE_SIN ); }
						case 2701: { return (int)( Topic.SLAVE ); }
						case 2707: { return (int)( Topic.SORROW ); }
						case 2714: { return (int)( Topic.SOUL ); }
						case 2719: { return (int)( Topic.SPEECH ); }
						case 2726: { return (int)( Topic.SPIRIT_IN_MAN ); }
						case 2740: { return (int)( Topic.SPIRITUAL_GIFTS ); }
						case 2756: case 2769: { return (int)( Topic.STATUTES_AND_JUDGMENTS ); }
						case 2779: { return (int)( Topic.STEAL ); }
						case 2785: { return (int)( Topic.STEWARDSHIP ); }
						case 2797: { return (int)( Topic.SUFFERING ); }
						case 2807: { return (int)( Topic.SWEAR ); }
						case 2813: { return (int)( Topic.TABERNACLE ); }
						case 2824: { return (int)( Topic.SPIRITUAL_TABERNACLE ); }
						case 2845: case 2854: { return (int)( Topic.FEAST_OF_TABERNACLES ); }
						case 2866: { return (int)( Topic.TAXES ); }
						case 2872: { return (int)( Topic.TEACH ); }
						case 2878: { return (int)( Topic.TEMPLE ); }
						case 2885: { return (int)( Topic.SPIRITUAL_TEMPLE ); }
						case 2902: { return (int)( Topic.THANKFULNESS ); }
						case 2915: { return (int)( Topic.THRONE ); }
						case 2922: { return (int)( Topic.TIME ); }
						case 2927: { return (int)( Topic.TITHES ); }
						case 2934: { return (int)( Topic.FIRST_TITHES ); }
						case 2947: { return (int)( Topic.SECOND_TITHES ); }
						case 2961: { return (int)( Topic.THIRD_TITHES ); }
						case 2974: { return (int)( Topic.TONGUES ); }
						case 2982: { return (int)( Topic.TREE_OF_LIFE ); }
						case 2995: { return (int)( Topic.TRIALS ); }
						case 3002: case 3012: { return (int)( Topic.THE_GREAT_TRIBULATION ); }
						case 3024: case 3031: { return (int)( Topic.JACOBS_TROUBLE ); }
						case 3039: { return (int)( Topic.THREE_AND_A_HALF_YEARS ); }
						case 3062: case 3075: { return (int)( Topic.TIMES_OF_THE_GENTILES ); }
						case 3084: case 3093: { return (int)( Topic.FEAST_OF_TRUMPETS ); }
						case 3102: { return (int)( Topic.TRUTH ); }
						case 3108: { return (int)( Topic.FEAST_OF_UNLEAVENEDBREAD ); }
						case 3133: { return (int)( Topic.VANITY ); }
						case 3140: { return (int)( Topic.WAR ); }
						case 3144: { return (int)( Topic.SPIRITUAL_WAR ); }
						case 3158: { return (int)( Topic.WEATHER ); }
						case 3166: case 3182: { return (int)( Topic.WHITE_THRONE_OF_JUDGMENT ); }
						case 3191: { return (int)( Topic.WIDOW ); }
						case 3197: { return (int)( Topic.WISDOM ); }
						case 3204: { return (int)( Topic.WITCHCRAFT ); }
						case 3215: { return (int)( Topic.WOMAN ); }
						case 3221: { return (int)( Topic.HARLOT ); }
						case 3228: { return (int)( Topic.VIRGIN ); }
						case 3235: { return (int)( Topic.WORKS ); }
						case 3241: { return (int)( Topic.WORKS_OF_GOD ); }
						case 3254: { return (int)( Topic.WORRY ); }
						case 3260: { return (int)( Topic.WORSHIP ); }
						case 3268: { return (int)( Topic.YOUTH ); }
						case 3274: { return (int)( Topic.ZEAL ); }
						case 3279: { return (int)( Topic.ZION ); }
					}
				}
	        }
			return -1;
		}
		
		public const string AllTopicWords = 
			@"______________abomination_adoption_adultery_spiritual_adultery_alcohol_angel_of_the_lord_angels_cherubim_horses_seraphim_seven_angels_twenty_four_elders_anger_anointing_antichrist_apostasy_false_prophets_false_teachers_apostle_armageddon_armor_of_god_atonement_babylon_baptism_holy_spirit_baptism_water_baptism_beast_believe_bible_study_birthright_promises_blaspheme_blessings_and_curses_blessings_curses_blinded_blood_of_christ_blood_of_flesh_book_of_life_born_again_hebrew_calendar_called_capital_punishment_carnal_character_childrearing_discipline_children_children_of_god_chosen_christian_church_church_name_church_structure_circumcision_clean_and_unclean_meat_commandments_commitment_compassion_conversion_correction_counsel_courage_covenant_new_covenant_old_covenant_covet_creation_cross_day_of_the_lord_deacons_death_debt_deceive_deliverance_demons_punishment_depression_disciple_disfellowship_division_divorce_doctrine_dress_and_grooming_elders_elijah_endurance_enemy_immortality_evangelism_evil_faith_faithful_false_christ_famine_fasting_father_fear_fear_of_god_feast_firstborn_firstfruits_foot_washing_foreknew_forever_forgiveness_forsake_friendship_glory_gluttony_god_majesty_of_christ_gospel_gossip_government_of_god_government_of_man_grace_harvest_healing_health_heart_heaven_heavenly_signs_heirs_gehenna_hades_sheol_holidays_holy_holy_spirit_indwelling_inspiration_homosexuality_honesty_hope_hospitality_humility_idolatry_israel_christ_of_israel_creator_melchizedek_messiah_preexistence_prophesies_of_messiah_resurrection_of_messiah_return_of_messiah_savior_joy_jubilee_judah_judgment_of_god_judgment_of_man_jury_duty_justice_justification_kill_kindness_king_kingdom_of_god_knowledge_labor_last_days_law_laying_on_of_hands_consecration_healing_touch_leadership_lethargy_levi_lie_living_water_longsuffering_love_lust_man_nature_of_man_marriage_husband_wife_marriage_of_the_lamb_bride_of_christ_martyrdom_medicine_meditation_mercy_military_service_millennium_ministry_modesty_money_mother_music_music_in_worship_nations_new_heavens_and_new_earth_new_moons_night_to_be_much_observed_oaths_obedience_offerings_overcoming_passover_patience_peace_pentecost_persecution_physician_place_of_safety_politics_poor_prayer_predestined_prejudice_pride_priest_the_promise_prophecy_prophets_rebellion_reconciliation_redemption_rejoice_repentance_resurrection_reward_righteousness_sabbath_preparation_for_sabbath_violation_of_sabbath_sacrifices_spiritual_sacrifices_saint_salvation_sanctification_satan_satanic_prophesies_protection_from_satan_scepter_promises_scripture_lake_of_fire_self_self_control_servant_sexuality_in_marriage_shepherd_sickness_signs_and_wonders_miracles_signs_sin_unpardonable_sin_slave_sorrow_soul_speech_spirit_in_man_spiritual_gifts_statutes_and_judgments_steal_stewardship_suffering_swear_tabernacle_spiritual_tabernacle_feast_of_tabernacles_taxes_teach_temple_spiritual_temple_thankfulness_throne_time_tithes_first_tithes_second_tithes_third_tithes_tongues_tree_of_life_trials_the_great_tribulation_jacobs_trouble_three_and_a_half_years_times_of_the_gentiles_feast_of_trumpets_truth_feast_of_unleavenedbread_vanity_war_spiritual_war_weather_white_throne_of_judgment_widow_wisdom_witchcraft_woman_harlot_virgin_works_works_of_god_worry_worship_youth_zeal_zion";
		
	
	}
}
