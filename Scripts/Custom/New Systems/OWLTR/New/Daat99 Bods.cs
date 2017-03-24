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
using Server;
using Server.Items;
using Server.Engines.BulkOrders;
using Server.Misc;

namespace daat99
{
	public class daat99
	{
		public static bool ClaimBods ( Mobile from, Item bod )
		{
			Item reward;
			int gold, fame;

			if ( (bod is SmallBOD && !((SmallBOD)bod).Complete) || (bod is LargeBOD && !((LargeBOD)bod).Complete) )
			{
				from.SendMessage(32, "You have not completed the order yet.");
				return false;
			}

			if ( bod is SmallBOD )
				((SmallBOD)bod).GetRewards( out reward, out gold, out fame );
			else if ( bod is LargeBOD )
				((LargeBOD)bod).GetRewards( out reward, out gold, out fame );
			else
			{
				from.SendMessage(32, "This isn't an acceptable bod");
				return false;
			}
			
			from.SendSound( 0x3D );

			from.SendLocalizedMessage( 1045132 ); // Thank you so much!  Here is a reward for your effort.

			if ( reward != null )
				from.AddToBackpack( reward );

			if ( gold > 1000 )
				from.AddToBackpack( new BankCheck( gold ) );
			else if ( gold > 0 )
				from.AddToBackpack( new Gold( gold ) );
				
			if (OWLTROptionsManager.IsEnabled(OWLTROptionsManager.OPTIONS_ENUM.BOD_GIVE_TOKENS) && gold > 100)
				GiveTokens.RewardTokens(from, (int)(gold/100));

			Titles.AwardFame( from, fame, true );

			bod.Delete();
			return true;
		}
	}
}