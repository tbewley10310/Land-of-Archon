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

Created from runuo distro scripts by daat99.
Added help syntax acording to what I know just in case anyone use this as a base for new script.
Thanx for Snuggles for giving me the sentances and the name (my grammer is real bad lol).
Thanx for ArteGordon, Victor and Haazen for tech support in runuo forums.
Thanx for County Line Staff that helped me test it.
No scripts other the the distro scripts were used in any way in creating this file.
*/
using System;
using Server.Items;
using System.Collections.Generic; // needed for List<Item>
using daat99;

namespace Server.Mobiles
{
	[CorpseName( "a crafting union leader corpse" )]
	public class MasterOfTheArts : BaseCreature //make it use the creature files/settings
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 10.0 ); //the delay between talks is 10 seconds
		public DateTime m_NextTalk;

		public override int GetIdleSound()
		{
			return 573; //play carpentry sound
		}

		public override int GetDeathSound()
		{
			return 1060; //play death sound
		}

		public override int GetAttackSound()
		{
			return 42; // play blacksmith sound
		}

		public override int GetHurtSound()
		{
			if (this.Hits > 1000) 
			{
				return 1076; //play hurt sound
			}
			else if (this.Hits > 500)
			{
				return 1078; //play hurt sound
			}
			else if (this.Hits > 100)
			{
				return 1081; //play hurt sound
			}
			else 
			{
				return 1080; //play hurt sound
			}
		}

		public override int GetAngerSound()
		{
			return 42; //play blacksmith sound
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 4 ) && InLOS( m ) ) // check if it's time to talk & mobile in range & in los.
			{
				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 7 ))
				{
					case 0: Say("So you really think that crafting is important to ye."); //make it say ...
						PlaySound(1066); //play giggle sound
						break;
					case 1: Say("So you really think you can beat me, I am very crafty you know."); 
						PlaySound(1071); //play huh sound
						break;	
					case 2: Say("Only the wise can receive these scrolls of knowledge to excel."); 
						PlaySound(1055); //play clear throat sound
						break; //
					case 3: Say("I shall not give you these scrolls easily."); 
						PlaySound(1074); //play no!! sound
						break;
					case 4: Say("Leave me be, I am waiting for the Master of the Power. You are a pain in my side."); 
						PlaySound(1067); //play groan sound
						break;
					case 5: Say("I shall treat thee like I do with the others under me, Ha ha."); 
						PlaySound(1073); //play lough sound
						break;
					case 6: Say("Not only your might is a neccesity to wield these scrolls of knowledge, but your mind is also required from thee."); 
						PlaySound(1094); //play spit sound
						break;
				};
			}
		}
		
		public override WeaponAbility GetWeaponAbility() // add it random special ability, bleed, mortal strike or armor ignore
		{
			int ability = Utility.Random(3);
			if (ability == 1)
				return WeaponAbility.MortalStrike;
			else if (ability == 2)
				return WeaponAbility.BleedAttack;
			else
				return WeaponAbility.ArmorIgnore;
		}
		
		//base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		//The 10 is range perception, the 1 is fight range, 0.1 is active speed, 0.4 is passive speed. set the 10 to like 5 and see what happens.
		private int i_PsCount;
		public int PsCount{ get{ return i_PsCount; } set { i_PsCount = value; InvalidateProperties(); } }
		private bool i_ChampionSpawn;
		public bool ChampionSpawn{ get{ return i_ChampionSpawn; } set { i_ChampionSpawn = value; InvalidateProperties(); } }

		[Constructable]
		public MasterOfTheArts() : this ( false )
		{
		}

		[Constructable]
		public MasterOfTheArts( bool i_ChampionSpawn ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a master of the arts"; //the name players will see
			Body = 185; //how it look like in game
			BaseSoundID = 42; //what sound he makes (I still have problems with sound :(

			ChampionSpawn = i_ChampionSpawn; //set if it spawn with champ spawn or normal spawn

			SetStr( 401, 420 ); //set stats
			SetDex( 81, 90 );
			SetInt( 201, 220 );

			SetHits( 1500, 1700 ); //set hp

			SetDamage( 50, 60 ); //set how much damage ~

			SetDamageType( ResistanceType.Physical, 50 ); //which damage type it does
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 60, 80 ); //what resists it have
			SetResistance( ResistanceType.Fire, 55, 70 );
			SetResistance( ResistanceType.Cold, 55, 70 );
			SetResistance( ResistanceType.Poison, 55, 70 );
			SetResistance( ResistanceType.Energy, 55, 70 );

			SetSkill( SkillName.Anatomy, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Macing, 120.0 );

			Fame = 30000; //its fame/karma
			Karma = -30000;
            
			VirtualArmor = 50;

			PlateChest chest = new PlateChest(); //add its armor and set its hue and not movable so it won't be on loot
			chest.Hue = 503;
			chest.Movable = false;
			AddItem( chest );
			
			PlateArms arms = new PlateArms();
			arms.Hue = 503;
			arms.Movable = false;
			AddItem( arms );
			
			PlateGloves gloves = new PlateGloves();
			gloves.Hue = 503;
			gloves.Movable = false;
			AddItem( gloves );
			
			PlateGorget gorget = new PlateGorget();
			gorget.Hue = 503;
			gorget.Movable = false;
			AddItem( gorget );
			
			PlateLegs legs = new PlateLegs();
			legs.Hue = 503;
			legs.Movable = false;
			AddItem( legs );
			
			WarHammer weapon = new WarHammer(); //add its weapon and set its hue and not movable so it won't be on loot
			weapon.Name = "Crafting Union Leader's Hammer";
			weapon.Hue = 503;
			weapon.Movable = false;
			AddItem( weapon );
			
			FurBoots boots = new FurBoots(); //add its boots and set its hue and not movable so it won't be on loot
			boots.Hue = 503;
			boots.Movable = false;
			AddItem( boots );

			Item hair = new Item( 8251 );  //add its hair and set its hue and not movable so it won't be on loot
			hair.Hue = 503; 
			hair.Layer = Layer.Hair; 
			hair.Movable = false; 
			AddItem( hair );

			AddItem( new Gold( 500, 1000 ));
			if ( Utility.Random(25) == 1 )
				AddItem( new PersonalStatueDeed() );

			new Mule(99.1, true).Rider = this; //make it ride on mule
		}
		
		public void GiveCraftPowerScroll() //Generate power scroll routine and add to pack
		{
			List<Mobile> toGive = new List<Mobile>(); //no idea :(

			List<AggressorInfo> list = Aggressors; //I think it add list players that attacked it
			for ( int i = 0; i < list.Count; ++i )
			{
				AggressorInfo info = list[i];

				if ( info.Attacker.Player && info.Attacker.Alive && (DateTime.Now - info.LastCombatTime) < TimeSpan.FromSeconds( 30.0 ) && !toGive.Contains( info.Attacker ) )
					toGive.Add( info.Attacker );
			}

			list = Aggressed; //I think it add list of players it attacked
			for ( int i = 0; i < list.Count; ++i )
			{
				AggressorInfo info = list[i];

				if ( info.Defender.Player && info.Defender.Alive && (DateTime.Now - info.LastCombatTime) < TimeSpan.FromSeconds( 30.0 ) && !toGive.Contains( info.Defender ) )
					toGive.Add( info.Defender );
			}
			if ( toGive.Count == 0 )//if nobody attacked it and it didn't attack anybody then break operation and no ps MUAH
				return;

			// Randomize //absolutly no idea
			for ( int i = 0; i < toGive.Count; ++i )
			{
				int rand = Utility.Random( toGive.Count );
				Mobile hold = toGive[i];
				toGive[i] = toGive[rand];
				toGive[rand] = hold;
			}

			PsCount = ChampionSpawn ? 5 : 2; //set how many ps to give if it spawned using champ spawn or normal spawn
			for ( int i = 0; i < PsCount; ++i ) 
			{
				Mobile m = (Mobile)toGive[i % toGive.Count];
				int level;
				double random = Utility.RandomDouble();
				if ( 0.25 >= random ) // select the level of the ps
					level = 120;
				else if ( 0.55 >= random )
					level = 115;
				else
					level = 110;
			
				if ( OWLTROptionsManager.IsEnabled(OWLTROptionsManager.OPTIONS_ENUM.RECIPE_CRAFT) )
					m.AddToBackpack( new ResourceRecipe() );
				
				switch ( Utility.Random( 13 )) // select which skill to use in the ps
				{ 
					case 0: m.AddToBackpack( new PowerScroll( SkillName.Blacksmith, level ) ); break; // give blacksmith ps acording to the ps level we selected before
					case 1: m.AddToBackpack( new PowerScroll( SkillName.Tailoring, level ) ); break;  
					case 2: m.AddToBackpack( new PowerScroll( SkillName.Tinkering, level ) ); break; 
					case 3: m.AddToBackpack( new PowerScroll( SkillName.Mining, level ) ); break;  
					case 4: m.AddToBackpack( new PowerScroll( SkillName.Carpentry, level ) ); break;  
					case 5: m.AddToBackpack( new PowerScroll( SkillName.Alchemy, level ) ); break; 
					case 6: m.AddToBackpack( new PowerScroll( SkillName.Fletching, level ) ); break; 
					case 7: m.AddToBackpack( new PowerScroll( SkillName.Inscribe, level ) ); break;  
					case 8: m.AddToBackpack( new PowerScroll( SkillName.Cooking, level ) ); break;  
					case 9: m.AddToBackpack( new PowerScroll( SkillName.Cartography, level ) ); break;  
					case 10: m.AddToBackpack( new PowerScroll( SkillName.Lumberjacking, level ) ); break; 
					case 11: m.AddToBackpack( new PowerScroll( SkillName.Lockpicking, level ) ); break; 
					case 12: m.AddToBackpack( new PowerScroll( SkillName.Fishing, level ) ); break; 
				} 		
				m.SendLocalizedMessage( 1049524 ); // You have received a scroll of power!
				if (Utility.Random(5) == 2) //Select random number between 0-4 and if it's 2 continue
				{
					switch ( Utility.Random( 47 )) //select random number between 0-46
					{
						case 0: m.AddToBackpack( new RunicFletcherTools( CraftResource.Heartwood, 10 ) ); break; // pine runic fletcher tool with 10 charges
						case 1: m.AddToBackpack( new RunicFletcherTools( CraftResource.Bloodwood, 10 ) ); break;
						case 2: m.AddToBackpack( new RunicFletcherTools( CraftResource.Frostwood, 10 ) ); break;
						case 3: m.AddToBackpack( new RunicFletcherTools( CraftResource.OakWood, 10 ) ); break;
						case 4: m.AddToBackpack( new RunicFletcherTools( CraftResource.AshWood, 10 ) ); break;
						case 5: m.AddToBackpack( new RunicFletcherTools( CraftResource.YewWood, 10 ) ); break;
						case 6: m.AddToBackpack( new RunicFletcherTools( CraftResource.Ebony, 10 ) ); break;
						case 7: m.AddToBackpack( new RunicFletcherTools( CraftResource.Bamboo, 10 ) ); break;
						case 8: m.AddToBackpack( new RunicFletcherTools( CraftResource.PurpleHeart, 10 ) ); break;
						case 9: m.AddToBackpack( new RunicFletcherTools( CraftResource.Redwood, 10 ) ); break;
						case 10: m.AddToBackpack( new RunicFletcherTools( CraftResource.Petrified, 10 ) ); break;
						case 11: m.AddToBackpack( new RunicHammer( CraftResource.DullCopper, 10 ) ); break; // Dull Copper runic hamemr with 10 charges
						case 12: m.AddToBackpack( new RunicHammer( CraftResource.ShadowIron, 10 ) ); break;
						case 13: m.AddToBackpack( new RunicHammer( CraftResource.Copper, 10 ) ); break;
						case 14: m.AddToBackpack( new RunicHammer( CraftResource.Bronze, 10 ) ); break;
						case 15: m.AddToBackpack( new RunicHammer( CraftResource.Gold, 10 ) ); break;
						case 16: m.AddToBackpack( new RunicHammer( CraftResource.Agapite, 10 ) ); break;
						case 17: m.AddToBackpack( new RunicHammer( CraftResource.Verite, 10 ) ); break;
						case 18: m.AddToBackpack( new RunicHammer( CraftResource.Valorite, 10 ) ); break;
						case 19: m.AddToBackpack( new RunicHammer( CraftResource.Blaze, 10 ) ); break;
						case 20: m.AddToBackpack( new RunicHammer( CraftResource.Ice, 10 ) ); break;
						case 21: m.AddToBackpack( new RunicHammer( CraftResource.Toxic, 10 ) ); break;
						case 22: m.AddToBackpack( new RunicHammer( CraftResource.Electrum, 10 ) ); break;
						case 23: m.AddToBackpack( new RunicHammer( CraftResource.Platinum, 10 ) ); break;
						case 24: m.AddToBackpack( new RunicSewingKit( CraftResource.SpinedLeather, 10 ) ); break; // Spined Leather runic sewing kit with 10 charges
						case 25: m.AddToBackpack( new RunicSewingKit( CraftResource.HornedLeather, 10 ) ); break;
						case 26: m.AddToBackpack( new RunicSewingKit( CraftResource.BarbedLeather, 10 ) ); break;
						case 27: m.AddToBackpack( new RunicSewingKit( CraftResource.PolarLeather, 10 ) ); break;
						case 28: m.AddToBackpack( new RunicSewingKit( CraftResource.SyntheticLeather, 10 ) ); break;
						case 29: m.AddToBackpack( new RunicSewingKit( CraftResource.BlazeLeather, 10 ) ); break;
						case 30: m.AddToBackpack( new RunicSewingKit( CraftResource.DaemonicLeather, 10 ) ); break;
						case 31: m.AddToBackpack( new RunicSewingKit( CraftResource.ShadowLeather, 10 ) ); break;
						case 32: m.AddToBackpack( new RunicSewingKit( CraftResource.FrostLeather, 10 ) ); break;
						case 33: m.AddToBackpack( new RunicSewingKit( CraftResource.EtherealLeather, 10 ) ); break;
						case 34: m.AddToBackpack( new RunicTinkerTools( CraftResource.DullCopper, 10 ) ); break; // Dull Copper runic hamemr with 10 charges
						case 35: m.AddToBackpack( new RunicTinkerTools( CraftResource.ShadowIron, 10 ) ); break;
						case 36: m.AddToBackpack( new RunicTinkerTools( CraftResource.Copper, 10 ) ); break;
						case 37: m.AddToBackpack( new RunicTinkerTools( CraftResource.Bronze, 10 ) ); break;
						case 38: m.AddToBackpack( new RunicTinkerTools( CraftResource.Gold, 10 ) ); break;
						case 39: m.AddToBackpack( new RunicTinkerTools( CraftResource.Agapite, 10 ) ); break;
						case 40: m.AddToBackpack( new RunicTinkerTools( CraftResource.Verite, 10 ) ); break;
						case 41: m.AddToBackpack( new RunicTinkerTools( CraftResource.Valorite, 10 ) ); break;
						case 42: m.AddToBackpack( new RunicTinkerTools( CraftResource.Blaze, 10 ) ); break;
						case 43: m.AddToBackpack( new RunicTinkerTools( CraftResource.Ice, 10 ) ); break;
						case 44: m.AddToBackpack( new RunicTinkerTools( CraftResource.Toxic, 10 ) ); break;
						case 45: m.AddToBackpack( new RunicTinkerTools( CraftResource.Electrum, 10 ) ); break;
						case 46: m.AddToBackpack( new RunicTinkerTools( CraftResource.Platinum, 10 ) ); break;
						
					}
					m.SendMessage( "You have recieved a runic tool."); 
				}
			}
		}

		public override bool OnBeforeDeath( ) //what happens before it dies
		{
			GiveCraftPowerScroll(); //call the generate ps routine

			switch (Utility.Random(30)) //select random number between 0-29
			{
				case 0: PackItem( new GargoylesAxe()); break;
				case 1: PackItem( new GargoylesPickaxe()); break;
				case 2: PackItem( new GargoylesKnife()); break;
				case 3: PackItem( new GargoylesKnife()); break;
				case 4: PackItem( new ProspectorsTool()); break;
				case 5: PackItem( new LumberjackingProspectorsTool()); break;
			}
			if (ChampionSpawn == false) //if it wasn't spawned as part of champ spawn then don't add gold.
				return true;

			Map map = this.Map; //set variable map to hold the current map

			if ( map != null ) //if the map isn't null (anti crash check) coontinue
			{
				for ( int x = -8; x <= 8; ++x ) //for 8x8 location
				{
					for ( int y = -8; y <= 8; ++y )
					{
						double dist = Math.Sqrt(x*x+y*y);

						if ( dist <= 8 )
							new GoldTimer( map, X + x, Y + y ).Start(); //spawn gold on timers
					}
				}
			}
			return true;
		}
		
		public override bool BardImmune{ get{ return true; } } //make it bardimmune: unpeaceable\unprovokable\undiscorded
		public override bool AutoDispel{ get{ return true; } } //make it auto dispel summons
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } } //make it immmune to lethal poison

		public override bool AlwaysMurderer{ get{ return true; } } //make the npc red
		
		public override void GenerateLoot() //add normal loot
		{
			AddLoot( LootPack.UltraRich ); // set the loot type to ultra rich
		}

		public MasterOfTheArts( Serial serial ) : base( serial ) // no idea what this does
		{
		}

		public override void Serialize( GenericWriter writer ) // this save the info on the mob so it won't be deleted all the time
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader ) // this load the info on the mob so it won't be deleted all the time
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		private class GoldTimer : Timer
		{
			private Map m_Map;
			private int m_X, m_Y;

			public GoldTimer( Map map, int x, int y ) : base( TimeSpan.FromSeconds( Utility.RandomDouble() * 10.0 ) )
			{
				m_Map = map;
				m_X = x;
				m_Y = y;
			}

			protected override void OnTick()
			{
				int z = m_Map.GetAverageZ( m_X, m_Y );
				bool canFit = m_Map.CanFit( m_X, m_Y, z, 6, false, false );

				for ( int i = -3; !canFit && i <= 3; ++i )
				{
					canFit = m_Map.CanFit( m_X, m_Y, z + i, 6, false, false );

					if ( canFit )
						z += i;
				}

				if ( !canFit )
					return;

				Gold g = new Gold( 500, 1000 );
				
				g.MoveToWorld( new Point3D( m_X, m_Y, z ), m_Map );

				if ( 0.5 >= Utility.RandomDouble() )
				{
					switch ( Utility.Random( 3 ) )
					{
						case 0: // Fire column
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 5052 );
							Effects.PlaySound( g, g.Map, 0x208 );

							break;
						}
						case 1: // Explosion
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36BD, 20, 10, 5044 );
							Effects.PlaySound( g, g.Map, 0x307 );

							break;
						}
						case 2: // Ball of fire
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36FE, 10, 10, 5052 );

							break;
						}
					}
				}
			}
		}
	}
}