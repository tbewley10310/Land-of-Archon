using System;
using Server;
using Server.Items;

namespace Server.Misc
{
	public class IndependenceDay2011 : GiftGiver
	{
		public static void Initialize()
		{
			GiftGiving.Register( new IndependenceDay2011() );
		}

		public override DateTime Start{ get{ return new DateTime( 2011, 7, 2 ); } }
		public override DateTime Finish{ get{ return new DateTime( 2011, 7, 12 ); } }

		public override void GiveGift( Mobile mob )
		{
			IndependenceDayBag2011 bag = new IndependenceDayBag2011();

			bag.DropItem( new FireworksBag2011() );
			bag.DropItem( new FountainBag2011() );
			bag.DropItem( new SparklerBag2011() );

			switch ( Utility.Random( 5 ) )
			{      	
				case 0: bag.DropItem(new Cake1()); break;
				case 1: bag.DropItem(new Cake2()); break;
				case 2: bag.DropItem(new Cake3()); break;
				case 3: bag.DropItem(new Cake4()); break;
				case 4: bag.DropItem(new Cake5()); break;
			}



			if ( 0.25 > Utility.RandomDouble() )
			{
				bag.DropItem( new PyroTechnicKit () );
			}

			switch ( GiveGift( mob, bag ) )
			{
				case GiftResult.Backpack:
					mob.SendMessage( 0x482, "A gift has been placed in your backpack." );
					break;
				case GiftResult.BankBox:
					mob.SendMessage( 0x482, "A gift has been placed in your bank box." );
					break;
			}
		}
	}
}
