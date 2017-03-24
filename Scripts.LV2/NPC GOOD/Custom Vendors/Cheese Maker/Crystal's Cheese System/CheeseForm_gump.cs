// by Alari - template copied from milkbucket gump.

using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class CheeseFormHelpGump : Gump
	{
		private object m_State;
		public CheeseFormHelpGump(Object state) : base(30,30)
		{
			Closable = true;
			Dragable = true;
			
			AddPage(0);
			
			AddBackground( 0, 0, 400, 300, 5054);
			
			Add( new GumpHtml( 10, 10, 380, 280, "<p><b><u>Milking System : The Cheese Form</u></b></p><p>Help : Usage</p><p>1 - Double click the cheese form and target a bucket of milk to fill the cheese form with.<br>You can make cheese from cow, sheep, or goat milk. You need 15 liters of milk to make a wheel of cheese.</p><p>2 - The cheese form is now ready to start fermenting.<br>Double click the cheese form to prepare the milk and start the fermentation process.<br>If the fermentation process is already running, this will give you an update on how close to completion it is.</p><p>3 - Once the cheese is ready, double click on the cheese form to remove the cheese.<br>You have a chance to have made a high-quality cheese. You also have a chance to have failed and not made any cheese at all. A little cooking skill will help avoid poor results.</p><p>If you receive this gump, it is because:</p><p>- The cheese form is full and you tried to fill it.<br>- The milk bucket did not have enough milk.<br>- You have targetted an invalid object.</p><p>Have fun.<br>Crystal 2003<br>Thanks to: SNA, CoolDev et UOT.<br><br>Edited by Alari.</p>", true, true ) );
			
			
		}
		
		public override void OnResponse( Server.Network.NetState sender, RelayInfo info )
		{
			
		}
	}
}
