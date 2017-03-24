using System;
using System.Collections.Generic;
using Server.Items;
using Server.Engines.Craft;
using Server;

namespace daat99
{
	public static class ResourceHelper
	{
		private static readonly int CANT_CRAFT_METAL = 1044268;
		private static readonly int CANT_CRAFT_STONE_GRANITE = 1044526;
		//private static readonly int CANT_CRAFT_STONE_OTHERS = 1044527;
		private static readonly int CANT_CRAFT_WOOD = 1044268;
		private static readonly int CANT_CRAFT_SCALE = 1044268;
		private static readonly int CANT_CRAFT_LEATHER = 1044462;

		private static Dictionary<CraftResource, double> craftResourceMinSkill;
		public static Dictionary<CraftResource, double> CraftResourceMinSkill
		{
			get
			{
				if (craftResourceMinSkill == null)
				{
					craftResourceMinSkill = new Dictionary<CraftResource, double>();
					foreach (ResourceData data in Resources)
					{
						try
						{
							if (!craftResourceMinSkill.ContainsKey(data.CraftResource))
								craftResourceMinSkill.Add(data.CraftResource, data.MinSkill);
						}
						catch { }
					}
				}
				return craftResourceMinSkill;
			}
		}

		public static Type GetDaat99HarvestedType(Type originalType, bool prospected, double skill)
		{
			double MAX_SKILL = 130.0;
			if (skill > MAX_SKILL)
				skill = MAX_SKILL;
			double chance = Utility.RandomMinMax(1, (int)(skill*10))/10.0 + (prospected ? 10 : 0);

			CraftResource originalCraftResource = CraftResources.GetFromType(originalType);
			CraftResource firstCraftResource = GetFirstCraftResourceFromType(originalCraftResource);
			CraftResource resultCraftResource = firstCraftResource;
			if ( Utility.RandomDouble() < 0.3 )
			{
				CraftResource check = GetLastCraftResourceFromType(originalCraftResource);
				double diff = MAX_SKILL/((int)check - (int)firstCraftResource + 1);
				
				for ( ; check > firstCraftResource; check = (CraftResource)((int)check - 1) )
				{
					double minSkill = GetMinSkill(check);
					if ( skill < minSkill )
						continue;
					if (chance > minSkill - diff)
					{
						resultCraftResource = check;
						break;
					}
				}
			}
			CraftResourceInfo info = CraftResources.GetInfo(resultCraftResource);
            if (originalType.IsSubclassOf(typeof(BaseGranite)) && info.ResourceTypes.Length > 2)
                return info.ResourceTypes[2];
			if (info.ResourceTypes.Length > 1)
				return info.ResourceTypes[1];
			return info.ResourceTypes[0];
		}

		private static Dictionary<CraftResource, ResourceData> craftResourceDataList;
		public static Dictionary<CraftResource, ResourceData> CraftResourceDataList
		{
			get
			{
				if (craftResourceDataList == null)
				{
					craftResourceDataList = new Dictionary<CraftResource, ResourceData>();
					foreach (ResourceData data in Resources)
					{
						try 
						{
							if (!craftResourceDataList.ContainsKey(data.CraftResource))
								craftResourceDataList.Add(data.CraftResource, data); 
						}
						catch { }
					}
				}
				return craftResourceDataList;
			}
		}

		public static double GetMinSkill(CraftResource resource)
		{
			if (CraftResourceMinSkill.ContainsKey(resource))
				return CraftResourceMinSkill[resource];
			return 0.0;
		}

		private static List<ResourceData> resources;
		private static List<ResourceData> Resources
		{
			get
			{
				if ( resources == null )
				{
					resources = new List<ResourceData>();
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Iron, 			"Iron", 			typeof(IronIngot), 			typeof(IronOre), 		 00.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.DullCopper, 		"Dull Copper", 		typeof(DullCopperIngot), 	typeof(DullCopperOre), 	 20.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.ShadowIron, 		"Shadow Iron", 		typeof(ShadowIronIngot), 	typeof(ShadowIronOre), 	 30.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Copper, 			"Copper", 			typeof(CopperIngot), 		typeof(CopperOre), 		 40.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Bronze, 			"Bronze", 			typeof(BronzeIngot), 		typeof(BronzeOre), 		 50.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Gold, 			"Gold", 			typeof(GoldIngot), 			typeof(GoldOre), 		 60.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Agapite, 			"Agapite", 			typeof(AgapiteIngot), 		typeof(AgapiteOre), 	 70.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Verite,	 		"Verite", 			typeof(VeriteIngot), 		typeof(VeriteOre), 		 80.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Valorite, 		"Valorite", 		typeof(ValoriteIngot), 		typeof(ValoriteOre), 	 90.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Blaze, 			"Blaze", 			typeof(BlazeIngot), 		typeof(BlazeOre), 		100.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Ice, 				"Ice", 				typeof(IceIngot), 			typeof(IceOre), 		105.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Toxic, 			"Toxic", 			typeof(ToxicIngot), 		typeof(ToxicOre), 		110.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Electrum, 		"Electrum", 		typeof(ElectrumIngot), 		typeof(ElectrumOre), 	115.0, CANT_CRAFT_METAL));
					resources.Add( new ResourceData(CraftResourceType.Metal, 	CraftResource.Platinum, 		"Platinum", 		typeof(PlatinumIngot), 		typeof(PlatinumOre), 	119.0, CANT_CRAFT_METAL));
					
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.RegularWood, 		"Log", 				typeof(Board), 				typeof(Log), 		 	 00.0, CANT_CRAFT_WOOD));
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.OakWood, 			"Oak", 				typeof(OakBoard), 			typeof(OakLog), 	 	 20.0, CANT_CRAFT_WOOD));
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.AshWood, 			"Ash", 				typeof(AshBoard), 			typeof(AshLog), 		 30.0, CANT_CRAFT_WOOD));
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.YewWood, 			"Yew", 				typeof(YewBoard), 			typeof(YewLog), 		 40.0, CANT_CRAFT_WOOD));
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.Heartwood, 		"Heartwood", 		typeof(HeartwoodBoard), 	typeof(HeartwoodLog), 	 50.0, CANT_CRAFT_WOOD));
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.Bloodwood, 		"Bloodwood", 		typeof(BloodwoodBoard), 	typeof(BloodwoodLog), 	 60.0, CANT_CRAFT_WOOD));
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.Frostwood, 		"Frostwood", 		typeof(FrostwoodBoard), 	typeof(FrostwoodLog), 	 70.0, CANT_CRAFT_WOOD));
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.Ebony,	 		"Ebony", 			typeof(EbonyBoard), 		typeof(EbonyLog), 		 80.0, CANT_CRAFT_WOOD));
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.Bamboo, 			"Bamboo", 			typeof(BambooBoard), 		typeof(BambooLog), 		 90.0, CANT_CRAFT_WOOD));
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.PurpleHeart, 		"PurpleHeart", 		typeof(PurpleHeartBoard), 	typeof(PurpleHeartLog), 100.0, CANT_CRAFT_WOOD));
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.Redwood, 			"Redwood", 			typeof(RedwoodBoard), 		typeof(RedwoodLog), 	110.0, CANT_CRAFT_WOOD));
					resources.Add( new ResourceData(CraftResourceType.Wood, 	CraftResource.Petrified, 		"Petrified", 		typeof(PetrifiedBoard), 	typeof(PetrifiedLog), 	119.0, CANT_CRAFT_WOOD));
					
					resources.Add( new ResourceData(CraftResourceType.Leather, 	CraftResource.RegularLeather,	"Regular Leather",	typeof(Leather), 			typeof(Hides), 		 	 00.0, CANT_CRAFT_LEATHER));
					resources.Add( new ResourceData(CraftResourceType.Leather, 	CraftResource.SpinedLeather, 	"Spined Leather", 	typeof(SpinedLeather), 		typeof(SpinedHides), 	 20.0, CANT_CRAFT_LEATHER));
					resources.Add( new ResourceData(CraftResourceType.Leather, 	CraftResource.HornedLeather, 	"Horned Leather", 	typeof(HornedLeather), 		typeof(HornedHides), 	 35.0, CANT_CRAFT_LEATHER));
					resources.Add( new ResourceData(CraftResourceType.Leather, 	CraftResource.BarbedLeather, 	"Barbed Leather", 	typeof(BarbedLeather), 		typeof(BarbedHides), 	 50.0, CANT_CRAFT_LEATHER));
					resources.Add( new ResourceData(CraftResourceType.Leather, 	CraftResource.PolarLeather,  	"Polar Leather", 	typeof(PolarLeather), 		typeof(PolarHides), 	 60.0, CANT_CRAFT_LEATHER));
					resources.Add( new ResourceData(CraftResourceType.Leather, 	CraftResource.SyntheticLeather,	"Synthetic Leather",typeof(SyntheticLeather), 	typeof(SyntheticHides),  70.0, CANT_CRAFT_LEATHER));
					resources.Add( new ResourceData(CraftResourceType.Leather, 	CraftResource.BlazeLeather,	 	"Blaze Leather", 	typeof(BlazeLeather), 		typeof(BlazeHides), 	 80.0, CANT_CRAFT_LEATHER));
					resources.Add( new ResourceData(CraftResourceType.Leather, 	CraftResource.DaemonicLeather,	"Daemonic Leather",	typeof(DaemonicLeather), 	typeof(DaemonicHides), 	 90.0, CANT_CRAFT_LEATHER));
					resources.Add( new ResourceData(CraftResourceType.Leather, 	CraftResource.ShadowLeather, 	"Shadow Leather", 	typeof(ShadowLeather), 		typeof(ShadowHides), 	100.0, CANT_CRAFT_LEATHER));
					resources.Add( new ResourceData(CraftResourceType.Leather, 	CraftResource.FrostLeather,		"Frost Leather", 	typeof(FrostLeather), 		typeof(FrostHides), 	110.0, CANT_CRAFT_LEATHER));
					resources.Add( new ResourceData(CraftResourceType.Leather, 	CraftResource.EtherealLeather,	"Ethereal Leather", typeof(EtherealLeather), 	typeof(EtherealHides), 	119.0, CANT_CRAFT_LEATHER));					
					
					resources.Add( new ResourceData(CraftResourceType.Scales, 	CraftResource.RedScales,		"Red Scales",		typeof(RedScales), 			typeof(RedScales), 	 	 00.0, CANT_CRAFT_SCALE));
					resources.Add( new ResourceData(CraftResourceType.Scales, 	CraftResource.YellowScales,		"Yellow Scales",	typeof(YellowScales), 		typeof(YellowScales),	 00.0, CANT_CRAFT_SCALE));
					resources.Add( new ResourceData(CraftResourceType.Scales, 	CraftResource.BlackScales,		"Black Scales",		typeof(BlackScales), 		typeof(BlackScales),  	 00.0, CANT_CRAFT_SCALE));
					resources.Add( new ResourceData(CraftResourceType.Scales, 	CraftResource.GreenScales,		"Green Scales",		typeof(GreenScales), 		typeof(GreenScales),  	 00.0, CANT_CRAFT_SCALE));
					resources.Add( new ResourceData(CraftResourceType.Scales, 	CraftResource.WhiteScales,		"White Scales",		typeof(WhiteScales), 		typeof(WhiteScales),  	 00.0, CANT_CRAFT_SCALE));
					resources.Add( new ResourceData(CraftResourceType.Scales, 	CraftResource.BlueScales,		"Blue Scales",		typeof(BlueScales), 		typeof(BlueScales),  	 00.0, CANT_CRAFT_SCALE));
					resources.Add( new ResourceData(CraftResourceType.Scales, 	CraftResource.CopperScales,		"Copper Scales",	typeof(CopperScales), 		typeof(CopperScales),  	 00.0, CANT_CRAFT_SCALE));
					resources.Add( new ResourceData(CraftResourceType.Scales, 	CraftResource.SilverScales,		"Silver Scales",	typeof(SilverScales), 		typeof(SilverScales),  	 00.0, CANT_CRAFT_SCALE));
					resources.Add( new ResourceData(CraftResourceType.Scales, 	CraftResource.GoldScales,		"Gold Scales",		typeof(GoldScales), 		typeof(GoldScales),  	 00.0, CANT_CRAFT_SCALE));
					
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Iron, 			"Granite", 			typeof(Granite), 			typeof(Granite), 		 00.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.DullCopper, 		"Dull Copper", 		typeof(DullCopperGranite), 	typeof(DullCopperGranite),20.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.ShadowIron, 		"Shadow Iron", 		typeof(ShadowIronGranite), 	typeof(ShadowIronGranite),30.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Copper, 			"Copper", 			typeof(CopperGranite), 		typeof(CopperGranite), 	 40.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Bronze, 			"Bronze", 			typeof(BronzeGranite), 		typeof(BronzeGranite), 	 50.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Gold, 			"Gold", 			typeof(GoldGranite), 		typeof(GoldGranite), 	 60.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Agapite, 			"Agapite", 			typeof(AgapiteGranite), 	typeof(AgapiteGranite),  70.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Verite,	 		"Verite", 			typeof(VeriteGranite), 		typeof(VeriteGranite), 	 80.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Valorite, 		"Valorite", 		typeof(ValoriteGranite), 	typeof(ValoriteGranite), 90.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Blaze, 			"Blaze", 			typeof(BlazeGranite), 		typeof(BlazeGranite), 	100.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Ice, 				"Ice", 				typeof(IceGranite), 		typeof(IceGranite), 	105.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Toxic, 			"Toxic", 			typeof(ToxicGranite), 		typeof(ToxicGranite), 	110.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Electrum, 		"Electrum", 		typeof(ElectrumGranite), 	typeof(ElectrumGranite),115.0, CANT_CRAFT_STONE_GRANITE));
					resources.Add( new ResourceData(CraftResourceType.None, 	CraftResource.Platinum, 		"Platinum", 		typeof(PlatinumGranite), 	typeof(PlatinumGranite),119.0, CANT_CRAFT_STONE_GRANITE));
				}
				return resources;
			}
		}

		#region AddCraftingResources
		//daat99.ResourceHelper.AddMetalResources(this);
		public static void AddMetalResources(CraftSystem system)
		{
			bool first = true;
			foreach ( ResourceData data in Resources )
			{
				if ( data.ResourceType == CraftResourceType.Metal )
				{
					if ( first )
					{
						system.SetSubRes( data.ItemType, data.Name );
						first = false;
					}
					system.AddSubRes( data.ItemType, data.Name, data.MinSkill, data.CantCraftMessage );
				}
			}
		}
		
		//daat99.ResourceHelper.AddStoneResources(this);
		public static void AddStoneResources(CraftSystem system)
		{	
			bool first = true;
			foreach ( ResourceData data in Resources )
			{
				if ( data.ResourceType == CraftResourceType.None )
				{
					if ( first )
					{
						system.SetSubRes( data.ItemType, data.Name );
						first = false;
					}
					system.AddSubRes( data.ItemType, data.Name, data.MinSkill, data.CantCraftMessage );
				}
			}
		}

		//daat99.ResourceHelper.AddWoodResources(this);
		public static void AddWoodResources(CraftSystem system)
		{
			bool first = true;
			foreach ( ResourceData data in Resources )
			{
				if ( data.ResourceType == CraftResourceType.Wood )
				{
					if ( first )
					{
						system.SetSubRes( data.RawType, data.Name );
						first = false;
					}
					system.AddSubRes( data.RawType, data.Name, data.MinSkill, data.CantCraftMessage );
				}
			}
		}
		
		//daat99.ResourceHelper.AddScaleResources(this);
		public static void AddScaleResources(CraftSystem system)
		{	
			bool first = true;
			foreach ( ResourceData data in Resources )
			{
				if ( data.ResourceType == CraftResourceType.Scales )
				{
					if ( first )
					{
						system.SetSubRes2( data.ItemType, data.Name );
						first = false;
					}
					system.AddSubRes2( data.ItemType, data.Name, data.MinSkill, data.CantCraftMessage );
				}
			}
		}
		
		//daat99.ResourceHelper.AddTailorResources(this);
		public static void AddTailorResources(CraftSystem system)
		{
			bool first = true;
			foreach ( ResourceData data in Resources )
			{
				if ( data.ResourceType == CraftResourceType.Leather )
				{
					if ( first )
					{
						system.SetSubRes( data.ItemType, data.Name );
						first = false;
					}
					system.AddSubRes( data.ItemType, data.Name, data.MinSkill, data.CantCraftMessage );
				}
			}
		}
		#endregion AddCraftingResources

		public class ResourceData
		{
			public static ResourceData EMPTY = new ResourceData(CraftResourceType.None, CraftResource.None, "", null, null, 0.0, 0);
			public CraftResource CraftResource;
			public string Name;
			public double MinSkill;
			public int CantCraftMessage;
			public Type RawType;
			public Type ItemType;
			public CraftResourceType ResourceType;
			public int Level;
			
			public ResourceData( CraftResourceType resourceType, CraftResource craftResource, string name, Type itemType, Type raw, double minSkill, int cantCraftMessage)
			{
				this.ResourceType = resourceType;
				this.CraftResource = craftResource;
				this.Name = name;
				this.RawType = raw;
				this.ItemType = itemType;
				this.MinSkill = minSkill;
				this.CantCraftMessage = cantCraftMessage;
				this.Level = (int)craftResource;
			}
		}

		public static CraftResource GetLastCraftResourceFromType(CraftResource resource)
		{
			switch (CraftResources.GetType(resource))
			{
				case CraftResourceType.Metal:
					return CraftResource.Platinum;
				case CraftResourceType.Leather:
					return CraftResource.EtherealLeather;
				case CraftResourceType.Wood:
					return CraftResource.Petrified;
				case CraftResourceType.Scales:
					return CraftResource.GoldScales;
			}
			return CraftResource.None;
		}

		public static CraftResource GetFirstCraftResourceFromType(CraftResource resource)
		{
			switch (CraftResources.GetType(resource))
			{
				case CraftResourceType.Metal:
					return CraftResource.Iron;
				case CraftResourceType.Leather:
					return CraftResource.RegularLeather;
				case CraftResourceType.Wood:
					return CraftResource.RegularWood;
				case CraftResourceType.Scales:
					return CraftResource.RedScales;
			}
			return CraftResource.None;
		}

		public static Type[][] GetTypesTable()
		{
			return new Type[][]
			{
				//OSI woods
				new Type[]{ typeof( Log ), 				typeof( Board ) },
				new Type[]{ typeof( OakLog ), 			typeof( OakBoard ) },
				new Type[]{ typeof( AshLog ), 			typeof( AshBoard ) },
				new Type[]{ typeof( YewLog ), 			typeof( YewBoard ) },
				new Type[]{ typeof( HeartwoodLog ), 	typeof( HeartwoodBoard ) },
				new Type[]{ typeof( BloodwoodLog ), 	typeof( BloodwoodBoard ) },
				new Type[]{ typeof( FrostwoodLog ), 	typeof( FrostwoodBoard ) },
				//OWLTR custom woods
				new Type[]{ typeof( EbonyLog ), 		typeof( EbonyBoard ) },
				new Type[]{ typeof( BambooLog ), 		typeof( BambooBoard ) },
				new Type[]{ typeof( PurpleHeartLog ), 	typeof( PurpleHeartBoard ) },
				new Type[]{ typeof( RedwoodLog ), 		typeof( RedwoodBoard ) },
				new Type[]{ typeof( PetrifiedLog ), 	typeof( PetrifiedBoard ) },
				//OSI leathers
				new Type[]{ typeof( Leather ), 			typeof( Hides ) },
				new Type[]{ typeof( SpinedLeather ), 	typeof( SpinedHides ) },
				new Type[]{ typeof( HornedLeather ), 	typeof( HornedHides ) },
				new Type[]{ typeof( BarbedLeather ), 	typeof( BarbedHides ) },
				//OWLTR leathers
				new Type[]{ typeof( PolarLeather ), 	typeof( PolarHides ) },
				new Type[]{ typeof( SyntheticLeather ), typeof( SyntheticHides ) },
				new Type[]{ typeof( BlazeLeather ), 	typeof( BlazeHides ) },
				new Type[]{ typeof( DaemonicLeather ), 	typeof( DaemonicHides ) },
				new Type[]{ typeof( ShadowLeather ), 	typeof( ShadowHides ) },
				new Type[]{ typeof( FrostLeather ), 	typeof( FrostHides ) },
				new Type[]{ typeof( EtherealLeather ), 	typeof( EtherealHides ) },
				//OSI other items
				new Type[]{ typeof( BlankMap ), 		typeof( BlankScroll ) },
				new Type[]{ typeof( Cloth ), 			typeof( UncutCloth ) },
				new Type[]{ typeof( CheeseWheel ), 		typeof( CheeseWedge ) },
				new Type[]{ typeof( Pumpkin ), 			typeof( SmallPumpkin ) },
				new Type[]{ typeof( WoodenBowlOfPeas ), typeof( PewterBowlOfPeas ) }
			};
		}
	}
}