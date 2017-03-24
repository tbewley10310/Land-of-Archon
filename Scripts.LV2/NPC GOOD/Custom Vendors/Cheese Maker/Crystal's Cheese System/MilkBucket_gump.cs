using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class LaitageHelpGump : Gump
	{
		private object m_State;
		public LaitageHelpGump(Object state) : base(30,30)
		{
			Closable = true;
			Dragable = true;
			
			AddPage(0);
			
			AddBackground( 0, 0, 400, 300, 5054);
			
			Add( new GumpHtml( 10, 10, 380, 280, "<p><b><u>Milking System : The Bucket</u></b></p><p>Help : Usage</p><p>1 - Double click the empty bucket and target an animal to start milking. Once chosen, you cannot mix milk.<br>You can harvest milk from cows, sheep, or goats.</p><p>2 - The bucket is now ready to be filled with milk.<br>Double click the bucket and target the animal to harvest milk from it.<br>This will tire out the animal, and it can only give so much milk at a time. The animal will need short breaks in the milking process.</p><p>3 - Once full, the bucket can be used to fill cheese forms, bottles, or pitchers.<br>Different types of milk will make different types of cheese. It takes 15 liters of milk to fill a cheese form.</p><p>If you receive this gump, it is because:</p><p>- The bucket is empty and you tried to fill something.<br>- The bucket is full and you tried to fill it.<br>- You have targetted an invalid object.</p><p>Have fun.<br>Crystal 2003<br>Thanks to: SNA, CoolDev et UOT.<br><br>Edited by Alari.</p>", true, true ) );
			
			
		}
		
		public override void OnResponse( Server.Network.NetState sender, RelayInfo info )
		{
			
		}
	}
}

