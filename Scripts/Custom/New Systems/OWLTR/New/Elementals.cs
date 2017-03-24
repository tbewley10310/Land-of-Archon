/*
 created by:
     /\            888                   888     .d8888b.   .d8888b.  
____/_ \____       888                   888    d88P  Y88b d88P  Y88b 
\  ___\ \  /       888                   888    888    888 888    888 
 \/ /  \/ /    .d88888  8888b.   8888b.  888888 Y88b. d888 Y88b. d888 
 / /\__/_/\   d88" 888     "88b     "88b 888     "Y888P888  "Y888P888 
/__\ \_____\  888  888 .d888888 .d888888 888           888        888 
    \  /      Y88b 888 888  888 888  888 Y88b.  Y88b  d88P Y88b  d88P 
     \/        "Y88888 "Y888888 "Y888888  "Y888  "Y8888P"   "Y8888P"  
*/
using Server.Items;
using daat99;

namespace Server.Mobiles
{
	[CorpseName( "an elemental corpse" )]
	public class Elementals : BaseCreature
	{
		private int i_Resource, i_Multiple;
		private bool b_Tinker = false;

		public Elementals(int Resource) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			i_Resource = Resource;
			
			if (i_Resource >= 301)
			{
				Name = "a wood elemental";
				Body = 301;
				i_Multiple = i_Resource - 300;
			}
			else if (i_Resource >= 101)
			{
				Name = "a leather elemental";
				Body = 101;
				i_Multiple = i_Resource - 99;
			}
			else 
				i_Multiple = i_Resource - 1;

			BaseSoundID = 268;
			 
			switch (i_Resource)
			{
				case 1: default: Name = "an ore elemental"; Body = 14; break;
				case 2: Name = "a dull copper ore elemental"; Hue = 0x973; Body = 110; break;
				case 3: Name = "a shadow iron ore elemental"; Hue = 0x966; Body = 111; break;
				case 4: Name = "a copper ore elemental"; Hue = 0x96D; Body = 109; break;
				case 5: Name = "a bronze ore elemental"; Hue = 0x972; Body = 108; break;
				case 6: Name = "a gold ore elemental"; Hue = 0x8A5; Body = 166; break;
				case 7: Name = "an agapite ore elemental"; Hue = 0x979; Body = 107; break;
				case 8: Name = "a verite ore elemental"; Hue = 0x89F; Body = 113; break;
				case 9: Name = "a valorite ore elemental"; Hue = 0x8AB; Body = 112; break;
				case 10: Name = "a blaze ore elemental"; Hue = 1161; Body = 113; break;
				case 11: Name = "an ice ore elemental"; Hue = 1152; Body = 161; break;
				case 12: Name = "a toxic ore elemental"; Hue = 1272; Body = 111; break;
				case 13: Name = "an electrum ore elemental"; Hue = 1278; Body = 112; break;
				case 14: Name = "a platinum ore elemental"; Hue = 1153; Body = 108; break;
				case 101: Name = "a leather elemental"; break;
				case 102: Name = "a spined leather elemental"; Hue = 0x8ac; break;
				case 103: Name = "a horned leather elemental"; Hue = 0x845; break;
				case 104: Name = "a barbed leather elemental"; Hue = 0x1C1; break;
				case 105: Name = "a polar leather elemental"; Hue = 1150; break;
				case 106: Name = "a synthetic leather elemental"; Hue = 1023; break;
				case 107: Name = "a blaze leather elemental"; Hue = 1260; break;
				case 108: Name = "a daemonic leather elemental"; Hue = 32; break;
				case 109: Name = "a shadow leather elemental"; Hue = 0x966; break;
				case 110: Name = "a frost leather elemental"; Hue = 93; break;
				case 111: Name = "an ethereal leather elemental"; Hue = 1159; break;
				case 301: Name = "a Wood elemental"; break;
                case 302: Name = "an Oak wood elemental"; Hue = 1281; break;
                case 303: Name = "an Ash wood elemental"; Hue = 488; break;
                case 304: Name = "a Yew wood elemental"; Hue = 2313; break;
				case 305: Name = "a Heartwood wood elemental"; Hue = 1262; break;
				case 306: Name = "a Bloodwood wood elemental"; Hue = 1194; break;
				case 307: Name = "a Frostwood wood elemental"; Hue = 1266; break;
				case 308: Name = "an ebony wood elemental"; Hue = 1457; break;
				case 309: Name = "a bamboo wood elemental"; Hue = 1719; break;
				case 310: Name = "a purple heart wood elemental"; Hue = 114; break;
				case 311: Name = "a redwood wood elemental"; Hue = 37; break;
				case 312: Name = "a petrified wood elemental"; Hue = 1153; break;
			}
			
			SetStr( 150 + (i_Multiple*10), 200 + (i_Multiple*10) );
			SetDex( 100 + (i_Multiple*10), 120 + (i_Multiple*10) );
			SetInt( 50 + (i_Multiple*10), 60 + (i_Multiple*10) );

			SetHits( 100 + (i_Multiple*10), 120 + (i_Multiple*10) );

			SetDamage( 5 + (i_Multiple*5), 10 + (i_Multiple*5) );

			SetDamageType( ResistanceType.Physical, 10 + (i_Multiple*5) );
			SetDamageType( ResistanceType.Poison, 5 + (i_Multiple*5) );
			SetDamageType( ResistanceType.Fire, 5 + (i_Multiple*5) );
			SetDamageType( ResistanceType.Cold, 5 + (i_Multiple*5) );
			SetDamageType( ResistanceType.Energy, 5 + (i_Multiple*5) );

			SetResistance( ResistanceType.Physical, 10 + (i_Multiple*5), 20 + (i_Multiple*5) );
			SetResistance( ResistanceType.Fire, 5 + (i_Multiple*5), 10 + (i_Multiple*5) );
			SetResistance( ResistanceType.Cold, 5 + (i_Multiple*5), 10 + (i_Multiple*5) );
			SetResistance( ResistanceType.Poison, 5 + (i_Multiple*5), 10 + (i_Multiple*5) );
			SetResistance( ResistanceType.Energy, 5 + (i_Multiple*5), 10 + (i_Multiple*5) );

			SetSkill( SkillName.MagicResist, 10.0 + (i_Multiple*5) );
			SetSkill( SkillName.Tactics, 50.0 + (i_Multiple*5) );
			SetSkill( SkillName.Wrestling, 50.0 + (i_Multiple*5) );

			Fame = 500 + (i_Multiple*500);
			Karma = -500 - (i_Multiple*500);

			VirtualArmor = 5 + (i_Multiple*5);
			
			//PackMagicItems( 0 + (i_Multiple*1), 1 + (i_Multiple*5) );

			if ( OWLTROptionsManager.IsEnabled(OWLTROptionsManager.OPTIONS_ENUM.RECIPE_CRAFT) )
					PackItem( new ResourceRecipe() );

			if ( i_Resource >= 1 && i_Resource < 101 )
			{
				if ( !Core.AOS && !OWLTROptionsManager.IsEnabled(OWLTROptionsManager.OPTIONS_ENUM.CRAFT_RUNIC_JEWELRY) && Utility.Random(10) == 1 )
					b_Tinker = true;
				else if (Utility.Random(4) == 1)
					b_Tinker = true;
			}

			switch (i_Resource)
			{
				case 1: { PackItem( new IronOre( 25 )); break; }
				case 2: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.DullCopper, 5 ) ); else PackItem( new RunicHammer( CraftResource.DullCopper, 5 )); PackItem( new DullCopperOre( 25 )); break; }
				case 3: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.ShadowIron, 5 ) ); else PackItem( new RunicHammer( CraftResource.ShadowIron, 5 )); PackItem( new ShadowIronOre( 25 )); break; }
				case 4: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.Copper, 5 ) ); else PackItem( new RunicHammer( CraftResource.Copper, 5 )); PackItem( new CopperOre( 25 )); break; }
				case 5: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.Bronze, 5 ) ); else PackItem( new RunicHammer( CraftResource.Bronze, 5 )); PackItem( new BronzeOre( 25 )); break; }
				case 6: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.Gold, 5 ) ); else PackItem( new RunicHammer( CraftResource.Gold, 5 )); PackItem( new GoldOre( 25 )); break; }
				case 7: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.Agapite, 5 ) ); else PackItem( new RunicHammer( CraftResource.Agapite, 5 )); PackItem( new AgapiteOre( 25 )); break; }
				case 8: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.Verite, 5 ) ); else PackItem( new RunicHammer( CraftResource.Verite, 5 )); PackItem( new VeriteOre( 25 )); break; }
				case 9: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.Valorite, 5 ) ); else PackItem( new RunicHammer( CraftResource.Valorite, 5 )); PackItem( new ValoriteOre( 25 )); break; }
				case 10: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.Blaze, 5 ) ); else PackItem( new RunicHammer( CraftResource.Blaze, 5 )); PackItem( new BlazeOre( 25 )); break; }
				case 11: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.Ice, 5 ) ); else PackItem( new RunicHammer( CraftResource.Ice, 5 )); PackItem( new IceOre( 25 )); break; }
				case 12: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.Toxic, 5 ) ); else PackItem( new RunicHammer( CraftResource.Toxic, 5 )); PackItem( new ToxicOre( 25 )); break; }
				case 13: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.Electrum, 5 ) ); else PackItem( new RunicHammer( CraftResource.Electrum, 5 )); PackItem( new ElectrumOre( 25 )); break; }
				case 14: { if (b_Tinker == true) PackItem( new RunicTinkerTools( CraftResource.Platinum, 5 ) ); else PackItem( new RunicHammer( CraftResource.Platinum, 5 )); PackItem( new PlatinumOre( 25 )); break; }
				case 102: { PackItem( new RunicSewingKit( CraftResource.SpinedLeather, 5 )); break; }
				case 103: { PackItem( new RunicSewingKit( CraftResource.HornedLeather, 5 )); break; }
				case 104: { PackItem( new RunicSewingKit( CraftResource.BarbedLeather, 5 )); break; }
				case 105: { PackItem( new RunicSewingKit( CraftResource.PolarLeather, 5 )); break; }
				case 106: { PackItem( new RunicSewingKit( CraftResource.SyntheticLeather, 5 )); break; }
				case 107: { PackItem( new RunicSewingKit( CraftResource.BlazeLeather, 5 )); break; }
				case 108: { PackItem( new RunicSewingKit( CraftResource.DaemonicLeather, 5 )); break; }
				case 109: { PackItem( new RunicSewingKit( CraftResource.ShadowLeather, 5 )); break; }
				case 110: { PackItem( new RunicSewingKit( CraftResource.FrostLeather, 5 )); break; }
				case 111: { PackItem( new RunicSewingKit( CraftResource.EtherealLeather, 5 )); break; }
				case 301: { PackItem( new Log( 50 )); break; }
                case 302: { PackItem( new RunicFletcherTools( CraftResource.OakWood, 5)); PackItem(new OakLog(50)); break; }
                case 303: { PackItem( new RunicFletcherTools( CraftResource.AshWood, 5)); PackItem(new AshLog(50)); break; }
                case 304: { PackItem( new RunicFletcherTools( CraftResource.YewWood, 5)); PackItem(new YewLog(50)); break; }
				case 305: { PackItem( new RunicFletcherTools( CraftResource.Heartwood, 5 )); PackItem( new HeartwoodLog( 50 )); break; }
				case 306: { PackItem( new RunicFletcherTools( CraftResource.Bloodwood, 5 )); PackItem( new BloodwoodLog( 50 )); break; }
				case 307: { PackItem( new RunicFletcherTools( CraftResource.Frostwood, 5 )); PackItem( new FrostwoodLog( 50 )); break; }
				case 308: { PackItem( new RunicFletcherTools( CraftResource.Ebony, 5 )); PackItem( new EbonyLog( 50 )); break; }
				case 309: { PackItem( new RunicFletcherTools( CraftResource.Bamboo, 5 )); PackItem( new BambooLog( 50 )); break; }
				case 310: { PackItem( new RunicFletcherTools( CraftResource.PurpleHeart, 5 )); PackItem( new PurpleHeartLog( 50 )); break; }
				case 311: { PackItem( new RunicFletcherTools( CraftResource.Redwood, 5 )); PackItem( new RedwoodLog( 50 )); break; }
				case 312: { PackItem( new RunicFletcherTools( CraftResource.Petrified, 5 )); PackItem( new PetrifiedLog( 50 )); break; }
			}
		}

		public override int Hides{ get{ if (i_Resource >= 101 && i_Resource < 201) return 50; else return 0; } }

		public override HideType HideType
		{ 
			get
			{ 
				switch (i_Resource)
				{
					case 102: { return HideType.Spined; }
					case 103: { return HideType.Horned; }
					case 104: { return HideType.Barbed; }
					case 105: { return HideType.Polar; }
					case 106: { return HideType.Synthetic; }
					case 107: { return HideType.BlazeL; }
					case 108: { return HideType.Daemonic; }
					case 109: { return HideType.Shadow; }
					case 110: { return HideType.Frost; }
					case 111: { return HideType.Ethereal; }
					default: { return HideType.Regular; }
				}
			} 
		}

		public override int Scales{ get{ if (i_Resource >= 101 && i_Resource < 201) return 50; else return 0; } }

		public override ScaleType ScaleType
		{ 
			get
			{ 
				switch (i_Resource)
				{
					case 103: case 104: { return ScaleType.Yellow; }
					case 105: { return ScaleType.Black; }
					case 106: { return ScaleType.Green; }
					case 107: { return ScaleType.White; }
					case 108: { return ScaleType.Blue; }
					case 109: { return ScaleType.Copper; }
					case 110: { return ScaleType.Silver; }
					case 111: { return ScaleType.Gold; }
					default: { return ScaleType.Red; }
				}
			} 
		}
		
		public override bool AutoDispel{ get{ return true; } }

		public Elementals( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}