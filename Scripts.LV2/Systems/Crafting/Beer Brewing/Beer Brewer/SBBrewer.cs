using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBBeerBrewer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBeerBrewer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
                Add(new GenericBuyInfo(typeof(BeerBreweringTools), 3000, 90, 0xE7F, 0));
                Add(new GenericBuyInfo(typeof(Hop1), 1, 90, 0x1AA2, 0));


			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
                Add(typeof(LongNeckBottleOfBudLight), 20);
                Add(typeof(LongNeckBottleOfBudWiser), 20);
                Add(typeof(LongNeckBottleOfCoolersLite), 20);
                Add(typeof(LongNeckBottleOfCorna), 40);
                Add(typeof(LongNeckBottleOfCornaLite), 40);
                Add(typeof(LongNeckBottleOfMillerLite), 20);
                Add(typeof(LongNeckBottleOfMGD), 20);
                Add(typeof(LongNeckBottleOfWildturkey), 50);
                Add(typeof(BeerKeg), 50);
                Add(typeof(PonyKeg), 60); 
			}
		}
	}
}
