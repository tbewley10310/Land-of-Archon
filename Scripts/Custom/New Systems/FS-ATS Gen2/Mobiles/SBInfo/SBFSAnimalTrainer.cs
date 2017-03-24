using System;
using Server.Items;
using System.Collections.Generic;
using Server.Engines.BulkOrders;
using CustomsFramework.Systems.AnimalBODSystem;
//using CustomsFramework.Systems.ShrinkSystem;

namespace Server.Mobiles
{
    public class SBFSAnimalTrainer : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();
        public SBFSAnimalTrainer()
        {
        }

        public override IShopSellInfo SellInfo
        {
            get
            {
                return this.m_SellInfo;
            }
        }
        public override List<GenericBuyInfo> BuyInfo
        {
            get
            {
                return this.m_BuyInfo;
            }
        }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {        
            	#region Shrink System
            	//this.Add(new GenericBuyInfo(typeof(PetLeash), 15000, 5, 0x1374, 0));
            	//this.Add(new GenericBuyInfo(typeof(StrongPetLeash), 30000, 5, 0x1374, 0));
            	#endregion
            	
                //#region FS Taming Craft
                //this.Add(new GenericBuyInfo(typeof(Brush), 100, 20, 0x1373, 0));
                //#endregion
            	
            	#region FS Taming BOD system
            	this.Add(new GenericBuyInfo(typeof(TamingBulkOrderBook), 10000, 20, 0x2259, 0));
            	#endregion
            	
            	#region Animals
                this.Add(new AnimalBuyInfo(1, typeof(Horse), 550, 10, 204, 0));
                this.Add(new AnimalBuyInfo(1, typeof(PackHorse), 631, 10, 291, 0));
                this.Add(new AnimalBuyInfo(1, typeof(PackLlama), 565, 10, 292, 0));
                #endregion
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
            }
        }
    }
}