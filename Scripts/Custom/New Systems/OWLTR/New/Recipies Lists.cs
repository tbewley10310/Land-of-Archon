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
using System.Collections;
using Server.Engines.Craft;
using Server.Items;

namespace daat99
{
	public class RecipesLists
	{
		#region Resources
		private static CraftResource[] cr_Metal = new CraftResource[13]
		{
			CraftResource.DullCopper,	CraftResource.ShadowIron,	CraftResource.Copper,	CraftResource.Bronze,
			CraftResource.Gold,			CraftResource.Agapite,		CraftResource.Verite,	CraftResource.Valorite,
			CraftResource.Blaze,		CraftResource.Ice,			CraftResource.Toxic,	CraftResource.Electrum,
			CraftResource.Platinum
		};
		private static CraftResource[] cr_Leather = new CraftResource[10]
		{
			CraftResource.SpinedLeather,	CraftResource.HornedLeather,	CraftResource.BarbedLeather,
			CraftResource.PolarLeather,		CraftResource.SyntheticLeather,	CraftResource.BlazeLeather,
			CraftResource.DaemonicLeather,	CraftResource.ShadowLeather,	CraftResource.FrostLeather,
			CraftResource.EtherealLeather
		};
		private static CraftResource[] cr_Scales = new CraftResource[8]
		{
			CraftResource.YellowScales,	CraftResource.BlackScales,	CraftResource.GreenScales,
			CraftResource.WhiteScales,	CraftResource.BlueScales,	CraftResource.CopperScales,
			CraftResource.SilverScales,	CraftResource.GoldScales
		};
		private static CraftResource[] cr_Wood = new CraftResource[11]
		{
			CraftResource.Heartwood,	CraftResource.Bloodwood,	CraftResource.Frostwood,	CraftResource.OakWood,
			CraftResource.AshWood,		CraftResource.YewWood,		CraftResource.Ebony,		CraftResource.Bamboo,
			CraftResource.PurpleHeart,	CraftResource.Redwood,		CraftResource.Petrified
		};

		public static CraftResource[] Metal{ get{ return cr_Metal; } }
		public static CraftResource[] Leather{ get{ return cr_Leather; } }
		public static CraftResource[] Scales{ get{ return cr_Scales; } }
		public static CraftResource[] Wood{ get{ return cr_Wood; } }
		#endregion
		
		#region ArrayLists
		private static ArrayList al_Resources; public static ArrayList Resources{ get { return al_Resources; } }
		
		private static ArrayList al_All; public static ArrayList All{ get { return al_All; } }
		private static ArrayList al_Lvl1; public static ArrayList Lvl1{ get { return al_Lvl1; } }
		private static ArrayList al_Lvl2; public static ArrayList Lvl2{ get { return al_Lvl2; } }
		private static ArrayList al_Lvl3; public static ArrayList Lvl3{ get { return al_Lvl3; } }
		private static ArrayList al_Lvl4; public static ArrayList Lvl4{ get { return al_Lvl4; } }
		private static ArrayList al_Lvl5; public static ArrayList Lvl5{ get { return al_Lvl5; } }
		private static ArrayList al_Lvl6; public static ArrayList Lvl6{ get { return al_Lvl6; } }
		
		private static ArrayList al_TNall; public static ArrayList TNall{ get { return al_TNall; } }
		private static ArrayList al_TN1; public static ArrayList TN1{ get { return al_TN1; } }
		private static ArrayList al_TN2; public static ArrayList TN2{ get { return al_TN2; } }
		private static ArrayList al_TN3; public static ArrayList TN3{ get { return al_TN3; } }
		private static ArrayList al_TN4; public static ArrayList TN4{ get { return al_TN4; } }
		private static ArrayList al_TN5; public static ArrayList TN5{ get { return al_TN5; } }
		private static ArrayList al_TN6; public static ArrayList TN6{ get { return al_TN6; } }


		private static ArrayList al_BSall; public static ArrayList BSall{ get { return al_BSall; } }
		private static ArrayList al_BS1; public static ArrayList BS1{ get { return al_BS1; } }
		private static ArrayList al_BS2; public static ArrayList BS2{ get { return al_BS2; } }
		private static ArrayList al_BS3; public static ArrayList BS3{ get { return al_BS3; } }
		private static ArrayList al_BS4; public static ArrayList BS4{ get { return al_BS4; } }
		private static ArrayList al_BS5; public static ArrayList BS5{ get { return al_BS5; } }
		private static ArrayList al_BS6; public static ArrayList BS6{ get { return al_BS6; } }
		
		private static ArrayList al_TLall; public static ArrayList TLall{ get { return al_TLall; } }
		private static ArrayList al_TL1; public static ArrayList TL1{ get { return al_TL1; } }
		private static ArrayList al_TL2; public static ArrayList TL2{ get { return al_TL2; } }
		private static ArrayList al_TL3; public static ArrayList TL3{ get { return al_TL3; } }
		private static ArrayList al_TL4; public static ArrayList TL4{ get { return al_TL4; } }
		private static ArrayList al_TL5; public static ArrayList TL5{ get { return al_TL5; } }
		private static ArrayList al_TL6; public static ArrayList TL6{ get { return al_TL6; } }
		
		private static ArrayList al_CKall; public static ArrayList CKall{ get { return al_CKall; } }
		private static ArrayList al_CK1; public static ArrayList CK1{ get { return al_CK1; } }
		private static ArrayList al_CK2; public static ArrayList CK2{ get { return al_CK2; } }
		private static ArrayList al_CK3; public static ArrayList CK3{ get { return al_CK3; } }
		private static ArrayList al_CK4; public static ArrayList CK4{ get { return al_CK4; } }
		private static ArrayList al_CK5; public static ArrayList CK5{ get { return al_CK5; } }
		private static ArrayList al_CK6; public static ArrayList CK6{ get { return al_CK6; } }
		
		private static ArrayList al_GBall; public static ArrayList GBall{ get { return al_GBall; } }
		private static ArrayList al_GB1; public static ArrayList GB1{ get { return al_GB1; } }
		private static ArrayList al_GB2; public static ArrayList GB2{ get { return al_GB2; } }
		private static ArrayList al_GB3; public static ArrayList GB3{ get { return al_GB3; } }
		private static ArrayList al_GB4; public static ArrayList GB4{ get { return al_GB4; } }
		private static ArrayList al_GB5; public static ArrayList GB5{ get { return al_GB5; } }
		private static ArrayList al_GB6; public static ArrayList GB6{ get { return al_GB6; } }
		
		private static ArrayList al_ACall; public static ArrayList ACall{ get { return al_ACall; } }
		private static ArrayList al_AC1; public static ArrayList AC1{ get { return al_AC1; } }
		private static ArrayList al_AC2; public static ArrayList AC2{ get { return al_AC2; } }
		private static ArrayList al_AC3; public static ArrayList AC3{ get { return al_AC3; } }
		private static ArrayList al_AC4; public static ArrayList AC4{ get { return al_AC4; } }
		private static ArrayList al_AC5; public static ArrayList AC5{ get { return al_AC5; } }
		private static ArrayList al_AC6; public static ArrayList AC6{ get { return al_AC6; } }
		
		private static ArrayList al_INall; public static ArrayList INall{ get { return al_INall; } }
		private static ArrayList al_IN1; public static ArrayList IN1{ get { return al_IN1; } }
		private static ArrayList al_IN2; public static ArrayList IN2{ get { return al_IN2; } }
		private static ArrayList al_IN3; public static ArrayList IN3{ get { return al_IN3; } }
		private static ArrayList al_IN4; public static ArrayList IN4{ get { return al_IN4; } }
		private static ArrayList al_IN5; public static ArrayList IN5{ get { return al_IN5; } }
		private static ArrayList al_IN6; public static ArrayList IN6{ get { return al_IN6; } }
		
		private static ArrayList al_BFall; public static ArrayList BFall{ get { return al_BFall; } }
		private static ArrayList al_BF1; public static ArrayList BF1{ get { return al_BF1; } }
		private static ArrayList al_BF2; public static ArrayList BF2{ get { return al_BF2; } }
		private static ArrayList al_BF3; public static ArrayList BF3{ get { return al_BF3; } }
		private static ArrayList al_BF4; public static ArrayList BF4{ get { return al_BF4; } }
		private static ArrayList al_BF5; public static ArrayList BF5{ get { return al_BF5; } }
		private static ArrayList al_BF6; public static ArrayList BF6{ get { return al_BF6; } }
		
		private static ArrayList al_MSall; public static ArrayList MSall{ get { return al_MSall; } }
		private static ArrayList al_MS1; public static ArrayList MS1{ get { return al_MS1; } }
		private static ArrayList al_MS2; public static ArrayList MS2{ get { return al_MS2; } }
		private static ArrayList al_MS3; public static ArrayList MS3{ get { return al_MS3; } }
		private static ArrayList al_MS4; public static ArrayList MS4{ get { return al_MS4; } }
		private static ArrayList al_MS5; public static ArrayList MS5{ get { return al_MS5; } }
		private static ArrayList al_MS6; public static ArrayList MS6{ get { return al_MS6; } }
		
		private static ArrayList al_CRall; public static ArrayList CRall{ get { return al_CRall; } }
		private static ArrayList al_CR1; public static ArrayList CR1{ get { return al_CR1; } }
		private static ArrayList al_CR2; public static ArrayList CR2{ get { return al_CR2; } }
		private static ArrayList al_CR3; public static ArrayList CR3{ get { return al_CR3; } }
		private static ArrayList al_CR4; public static ArrayList CR4{ get { return al_CR4; } }
		private static ArrayList al_CR5; public static ArrayList CR5{ get { return al_CR5; } }
		private static ArrayList al_CR6; public static ArrayList CR6{ get { return al_CR6; } }
		
		#endregion

		public static double GetMinSkill( CraftItem citem )
		{
			double ret = 0;
			if( citem.Skills == null || citem.Skills.Count == 0 )
				return ret;

			if( citem.Skills.Count > 1 )
				ret += 10;

			ret += citem.Skills.GetAt(0).MinSkill;
			return ret;
		}

		#region Initialize
		public static void Initialize() 
		{
			al_Resources = new ArrayList();
			int i;
			for(i = 0; i < cr_Metal.Length; i++)	al_Resources.Add(cr_Metal[i]);
			for(i = 0; i < cr_Leather.Length; i++)	al_Resources.Add(cr_Leather[i]);
			for(i = 0; i < cr_Scales.Length; i++)	al_Resources.Add(cr_Scales[i]);
			for(i = 0; i < cr_Wood.Length; i++)		al_Resources.Add(cr_Wood[i]);

			al_All = new ArrayList();
			al_Lvl1 = new ArrayList(); al_Lvl2 = new ArrayList(); al_Lvl3 = new ArrayList();
			al_Lvl4 = new ArrayList(); al_Lvl5 = new ArrayList(); al_Lvl6 = new ArrayList();
			al_TNall = new ArrayList();
			al_TN1 = new ArrayList(); al_TN2 = new ArrayList(); al_TN3 = new ArrayList(); 
			al_TN4 = new ArrayList(); al_TN5 = new ArrayList(); al_TN6 = new ArrayList();
			al_BSall = new ArrayList();
			al_BS1 = new ArrayList(); al_BS2 = new ArrayList(); al_BS3 = new ArrayList(); 
			al_BS4 = new ArrayList(); al_BS5 = new ArrayList(); al_BS6 = new ArrayList();
			al_TLall = new ArrayList();
			al_TL1 = new ArrayList(); al_TL2 = new ArrayList(); al_TL3 = new ArrayList(); 
			al_TL4 = new ArrayList(); al_TL5 = new ArrayList(); al_TL6 = new ArrayList();
			al_CKall = new ArrayList();
			al_CK1 = new ArrayList(); al_CK2 = new ArrayList(); al_CK3 = new ArrayList(); 
			al_CK4 = new ArrayList(); al_CK5 = new ArrayList(); al_CK6 = new ArrayList();
			al_GBall = new ArrayList();
			al_GB1 = new ArrayList(); al_GB2 = new ArrayList(); al_GB3 = new ArrayList(); 
			al_GB4 = new ArrayList(); al_GB5 = new ArrayList(); al_GB6 = new ArrayList();
			al_ACall = new ArrayList();
			al_AC1 = new ArrayList(); al_AC2 = new ArrayList(); al_AC3 = new ArrayList(); 
			al_AC4 = new ArrayList(); al_AC5 = new ArrayList(); al_AC6 = new ArrayList();
			al_INall = new ArrayList();
			al_IN1 = new ArrayList(); al_IN2 = new ArrayList(); al_IN3 = new ArrayList(); 
			al_IN4 = new ArrayList(); al_IN5 = new ArrayList(); al_IN6 = new ArrayList();
			al_BFall = new ArrayList();
			al_BF1 = new ArrayList(); al_BF2 = new ArrayList(); al_BF3 = new ArrayList(); 
			al_BF4 = new ArrayList(); al_BF5 = new ArrayList(); al_BF6 = new ArrayList();
			al_MSall = new ArrayList();
			al_MS1 = new ArrayList(); al_MS2 = new ArrayList(); al_MS3 = new ArrayList(); 
			al_MS4 = new ArrayList(); al_MS5 = new ArrayList(); al_MS6 = new ArrayList();
			al_CRall = new ArrayList();
			al_CR1 = new ArrayList(); al_CR2 = new ArrayList(); al_CR3 = new ArrayList(); 
			al_CR4 = new ArrayList(); al_CR5 = new ArrayList(); al_CR6 = new ArrayList();
			
			IEnumerator myEnum = DefTinkering.CraftSystem.CraftItems.GetEnumerator();
			while( myEnum.MoveNext() )
			{
				CraftItem ci = (CraftItem)myEnum.Current;
				if( ci != null )
				{
					double sort = GetMinSkill( ci );
					if ( !al_TNall.Contains( ci.ItemType ) )
					{
						if( sort < 30.0 ) { al_TN1.Add( ci.ItemType ); al_Lvl1.Add( ci.ItemType ); }
						else if( sort < 50.0 ) { al_TN2.Add( ci.ItemType ); al_Lvl2.Add( ci.ItemType ); }
						else if( sort < 70.0 ) { al_TN3.Add( ci.ItemType ); al_Lvl3.Add( ci.ItemType ); }
						else if( sort < 85.0 ) { al_TN4.Add( ci.ItemType ); al_Lvl4.Add( ci.ItemType ); }
						else if( sort < 95.0 ) { al_TN5.Add( ci.ItemType ); al_Lvl5.Add( ci.ItemType ); }
						else { al_TN6.Add( ci.ItemType ); al_Lvl6.Add( ci.ItemType ); }
						al_TNall.Add( ci.ItemType );
					}
					if ( !al_All.Contains( ci.ItemType ) )
						al_All.Add( ci.ItemType );
				}
			}

			myEnum = DefBlacksmithy.CraftSystem.CraftItems.GetEnumerator();
			while( myEnum.MoveNext() )
			{
				CraftItem ci = (CraftItem)myEnum.Current;
				if( ci != null )
				{
					double sort = GetMinSkill( ci );
					if ( !al_BSall.Contains( ci.ItemType ) )
					{
						if( sort < 30.0 ) { al_BS1.Add( ci.ItemType ); al_Lvl1.Add( ci.ItemType ); }
						else if( sort < 50.0 ) { al_BS2.Add( ci.ItemType ); al_Lvl2.Add( ci.ItemType ); }
						else if( sort < 70.0 ) { al_BS3.Add( ci.ItemType ); al_Lvl3.Add( ci.ItemType ); }
						else if( sort < 85.0 ) { al_BS4.Add( ci.ItemType ); al_Lvl4.Add( ci.ItemType ); }
						else if( sort < 95.0 ) { al_BS5.Add( ci.ItemType ); al_Lvl5.Add( ci.ItemType ); }
						else { al_BS6.Add( ci.ItemType ); al_Lvl6.Add( ci.ItemType ); }
						al_BSall.Add( ci.ItemType );
					}
					if ( !al_All.Contains( ci.ItemType ) )
						al_All.Add( ci.ItemType );
				}
			}

			myEnum = DefTailoring.CraftSystem.CraftItems.GetEnumerator();
			while( myEnum.MoveNext() )
			{
				CraftItem ci = (CraftItem)myEnum.Current;
				if( ci != null )
				{
					if ( !al_TLall.Contains( ci.ItemType ) )
					{
						double sort = GetMinSkill( ci );
						if( sort < 30.0 ) { al_TL1.Add( ci.ItemType ); al_Lvl1.Add( ci.ItemType ); }
						else if( sort < 50.0 ) { al_TL2.Add( ci.ItemType ); al_Lvl2.Add( ci.ItemType ); }
						else if( sort < 70.0 ) { al_TL3.Add( ci.ItemType ); al_Lvl3.Add( ci.ItemType ); }
						else if( sort < 85.0 ) { al_TL4.Add( ci.ItemType ); al_Lvl4.Add( ci.ItemType ); }
						else if( sort < 95.0 ) { al_TL5.Add( ci.ItemType ); al_Lvl5.Add( ci.ItemType ); }
						else { al_TL6.Add( ci.ItemType ); al_Lvl6.Add( ci.ItemType ); }
						al_TLall.Add( ci.ItemType );
					}
					if ( !al_All.Contains( ci.ItemType ) )
						al_All.Add( ci.ItemType );
				}
			}

			myEnum = DefCooking.CraftSystem.CraftItems.GetEnumerator();
			while( myEnum.MoveNext() )
			{
				CraftItem ci = (CraftItem)myEnum.Current;
				if( ci != null )
				{
					if ( !al_CKall.Contains( ci.ItemType ) )
					{
						double sort = GetMinSkill( ci );
						if( sort < 30.0 ) { al_CK1.Add( ci.ItemType ); al_Lvl1.Add( ci.ItemType ); }
						else if( sort < 50.0 ) { al_CK2.Add( ci.ItemType ); al_Lvl2.Add( ci.ItemType ); }
						else if( sort < 70.0 ) { al_CK3.Add( ci.ItemType ); al_Lvl3.Add( ci.ItemType ); }
						else if( sort < 85.0 ) { al_CK4.Add( ci.ItemType ); al_Lvl4.Add( ci.ItemType ); }
						else if( sort < 95.0 ) { al_CK5.Add( ci.ItemType ); al_Lvl5.Add( ci.ItemType ); }
						else { al_CK6.Add( ci.ItemType ); al_Lvl6.Add( ci.ItemType ); }
						al_CKall.Add( ci.ItemType );
					}
					if ( !al_All.Contains( ci.ItemType ) )
						al_All.Add( ci.ItemType );
				}
			}

			myEnum = DefGlassblowing.CraftSystem.CraftItems.GetEnumerator();
			while( myEnum.MoveNext() )
			{
				CraftItem ci = (CraftItem)myEnum.Current;
				if( ci != null )
				{
					if ( !al_GBall.Contains( ci.ItemType ) )
					{
						double sort = GetMinSkill( ci );
						if( sort < 30.0 ) { al_GB1.Add( ci.ItemType ); al_Lvl1.Add( ci.ItemType ); }
						else if( sort < 50.0 ) { al_GB2.Add( ci.ItemType ); al_Lvl2.Add( ci.ItemType ); }
						else if( sort < 70.0 ) { al_GB3.Add( ci.ItemType ); al_Lvl3.Add( ci.ItemType ); }
						else if( sort < 85.0 ) { al_GB4.Add( ci.ItemType ); al_Lvl4.Add( ci.ItemType ); }
						else if( sort < 95.0 ) { al_GB5.Add( ci.ItemType ); al_Lvl5.Add( ci.ItemType ); }
						else { al_GB6.Add( ci.ItemType ); al_Lvl6.Add( ci.ItemType ); }
						al_GBall.Add( ci.ItemType );
					}
					if ( !al_All.Contains( ci.ItemType ) )
						al_All.Add( ci.ItemType );
				}
			}

			myEnum = DefAlchemy.CraftSystem.CraftItems.GetEnumerator();
			while( myEnum.MoveNext() )
			{
				CraftItem ci = (CraftItem)myEnum.Current;
				if( ci != null )
				{
					if ( !al_ACall.Contains( ci.ItemType ) )
					{
						double sort = GetMinSkill( ci );
						if( sort < 30.0 ) { al_AC1.Add( ci.ItemType ); al_Lvl1.Add( ci.ItemType ); }
						else if( sort < 50.0 ) { al_AC2.Add( ci.ItemType ); al_Lvl2.Add( ci.ItemType ); }
						else if( sort < 70.0 ) { al_AC3.Add( ci.ItemType ); al_Lvl3.Add( ci.ItemType ); }
						else if( sort < 85.0 ) { al_AC4.Add( ci.ItemType ); al_Lvl4.Add( ci.ItemType ); }
						else if( sort < 95.0 ) { al_AC5.Add( ci.ItemType ); al_Lvl5.Add( ci.ItemType ); }
						else { al_AC6.Add( ci.ItemType ); al_Lvl6.Add( ci.ItemType ); }
						al_ACall.Add( ci.ItemType );
					}
					if ( !al_All.Contains( ci.ItemType ) )
						al_All.Add( ci.ItemType );
				}
			}

			myEnum = DefInscription.CraftSystem.CraftItems.GetEnumerator();
			while( myEnum.MoveNext() )
			{
				CraftItem ci = (CraftItem)myEnum.Current;
				if( ci != null )
				{
					double sort = GetMinSkill( ci );
					if ( !al_INall.Contains( ci.ItemType ) )
					{
						if( sort < 30.0 ) { al_IN1.Add( ci.ItemType ); al_Lvl1.Add( ci.ItemType ); }
						else if( sort < 50.0 ) { al_IN2.Add( ci.ItemType ); al_Lvl2.Add( ci.ItemType ); }
						else if( sort < 70.0 ) { al_IN3.Add( ci.ItemType ); al_Lvl3.Add( ci.ItemType ); }
						else if( sort < 85.0 ) { al_IN4.Add( ci.ItemType ); al_Lvl4.Add( ci.ItemType ); }
						else if( sort < 95.0 ) { al_IN5.Add( ci.ItemType ); al_Lvl5.Add( ci.ItemType ); }
						else { al_IN6.Add( ci.ItemType ); al_Lvl6.Add( ci.ItemType ); }
						al_INall.Add( ci.ItemType );
					}
					if ( !al_All.Contains( ci.ItemType ) )
						al_All.Add( ci.ItemType );
				}
			}

			myEnum = DefBowFletching.CraftSystem.CraftItems.GetEnumerator();
			while( myEnum.MoveNext() )
			{
				CraftItem ci = (CraftItem)myEnum.Current;
				if( ci != null )
				{
					double sort = GetMinSkill( ci );
					if ( !al_BFall.Contains( ci.ItemType ) )
					{
						if( sort < 30.0 ) { al_BF1.Add( ci.ItemType ); al_Lvl1.Add( ci.ItemType ); }
						else if( sort < 50.0 ) { al_BF2.Add( ci.ItemType ); al_Lvl2.Add( ci.ItemType ); }
						else if( sort < 70.0 ) { al_BF3.Add( ci.ItemType ); al_Lvl3.Add( ci.ItemType ); }
						else if( sort < 85.0 ) { al_BF4.Add( ci.ItemType ); al_Lvl4.Add( ci.ItemType ); }
						else if( sort < 95.0 ) { al_BF5.Add( ci.ItemType ); al_Lvl5.Add( ci.ItemType ); }
						else { al_BF6.Add( ci.ItemType ); al_Lvl6.Add( ci.ItemType ); }
						al_BFall.Add( ci.ItemType );
					}
					if ( !al_All.Contains( ci.ItemType ) )
						al_All.Add( ci.ItemType );
				}
			}

			myEnum = DefMasonry.CraftSystem.CraftItems.GetEnumerator();
			while( myEnum.MoveNext() )
			{
				CraftItem ci = (CraftItem)myEnum.Current;
				if( ci != null )
				{
					double sort = GetMinSkill( ci );
					if ( !al_MSall.Contains( ci.ItemType ) )
					{
						if( sort < 30.0 ) { al_MS1.Add( ci.ItemType ); al_Lvl1.Add( ci.ItemType ); }
						else if( sort < 50.0 ) { al_MS2.Add( ci.ItemType ); al_Lvl2.Add( ci.ItemType ); }
						else if( sort < 70.0 ) { al_MS3.Add( ci.ItemType ); al_Lvl3.Add( ci.ItemType ); }
						else if( sort < 85.0 ) { al_MS4.Add( ci.ItemType ); al_Lvl4.Add( ci.ItemType ); }
						else if( sort < 95.0 ) { al_MS5.Add( ci.ItemType ); al_Lvl5.Add( ci.ItemType ); }
						else { al_MS6.Add( ci.ItemType ); al_Lvl6.Add( ci.ItemType ); }
						al_MSall.Add( ci.ItemType );
					}
					if ( !al_All.Contains( ci.ItemType ) )
						al_All.Add( ci.ItemType );
				}
			}

			myEnum = DefCarpentry.CraftSystem.CraftItems.GetEnumerator();
			while( myEnum.MoveNext() )
			{
				CraftItem ci = (CraftItem)myEnum.Current;
				if( ci != null )
				{
					double sort = GetMinSkill( ci );
					if ( !al_CRall.Contains( ci.ItemType ) )
					{
						if( sort < 30.0 ) { al_CR1.Add( ci.ItemType ); al_Lvl1.Add( ci.ItemType ); }
						else if( sort < 50.0 ) { al_CR2.Add( ci.ItemType ); al_Lvl2.Add( ci.ItemType ); }
						else if( sort < 70.0 ) { al_CR3.Add( ci.ItemType ); al_Lvl3.Add( ci.ItemType ); }
						else if( sort < 85.0 ) { al_CR4.Add( ci.ItemType ); al_Lvl4.Add( ci.ItemType ); }
						else if( sort < 95.0 ) { al_CR5.Add( ci.ItemType ); al_Lvl5.Add( ci.ItemType ); }
						else { al_CR6.Add( ci.ItemType ); al_Lvl6.Add( ci.ItemType ); }
						al_CRall.Add( ci.ItemType );
					}
					if ( !al_All.Contains( ci.ItemType ) )
						al_All.Add( ci.ItemType );
				}
			}
		}
		#endregion
	}
}