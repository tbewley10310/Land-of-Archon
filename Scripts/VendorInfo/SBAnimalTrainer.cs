using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class SBAnimalTrainer : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();
        public SBAnimalTrainer()
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
                this.Add(new AnimalBuyInfo(1, typeof(Cat), 132, 10, 201, 0));
                this.Add(new AnimalBuyInfo(1, typeof(Dog), 170, 10, 217, 0));
                this.Add(new AnimalBuyInfo(1, typeof(Horse), 550, 10, 204, 0));
                this.Add(new AnimalBuyInfo(1, typeof(PackHorse), 631, 10, 291, 0));
                this.Add(new AnimalBuyInfo(1, typeof(PackLlama), 565, 10, 292, 0));
                this.Add(new AnimalBuyInfo(1, typeof(Rabbit), 106, 10, 205, 0));

                if (!Core.AOS)
                {
                    this.Add(new AnimalBuyInfo(1, typeof(Eagle), 402, 10, 5, 0));
                    this.Add(new AnimalBuyInfo(1, typeof(BrownBear), 855, 10, 167, 0));
                    this.Add(new AnimalBuyInfo(1, typeof(GrizzlyBear), 1767, 10, 212, 0));
                    this.Add(new AnimalBuyInfo(1, typeof(Panther), 1271, 10, 214, 0));
                    this.Add(new AnimalBuyInfo(1, typeof(TimberWolf), 768, 10, 225, 0));
                    this.Add(new AnimalBuyInfo(1, typeof(Rat), 107, 10, 238, 0));
                }

				// FS ATS Edit Start
				if ( FSATS.EnableTamingCraft == true )
					Add( new AnimalBuyInfo( 1, typeof( Brush ), 72, 10, 0x1373, 0 ) );

				if ( FSATS.EnableTamingCraft == false )
				{
					Add( new AnimalBuyInfo( 1, typeof( PetShrinkPotion ), 16, 10, 0xE26, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( PetLeash ), 1456, 10, 0x1374, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( HitchingPostEastDeed ), 1456, 10, 0x14F0, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( HitchingPostSouthDeed ), 1456, 10, 0x14F0, 0 ) );
				}

				if ( FSATS.EnableTamingBODs == false && FSATS.EnableBioEngineer == false )
				{
					Add( new AnimalBuyInfo( 1, typeof( BioTool ), 72, 10, 0x1373, 1175 ) );
					Add( new AnimalBuyInfo( 1, typeof( BioEnginerBook ), 10001, 10, 4084, 0 ) );
				}
				// FS ATS Edit Ends
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