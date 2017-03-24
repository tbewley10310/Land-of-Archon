using System;
using System.Collections;
using Server;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Network;

namespace Server.Custom
{
	public class CG : Gump
	{
		private const int LabelHue = 0x480;
		private const int GreenHue = 0x40;
		private const int RedHue = 0x20;

		public CG(int x, int y) : base(x, y)
		{
		}

		public void AddOKButton( int x, int y, int buttonID, string text )
		{
			AddButton( x, y - 1, 4023, 4025, buttonID, GumpButtonType.Reply, 0 );
			AddHtml( x + 35, y, 240, 20, Color( text, GreenHue ), false, false );
		}

		public void AddPageFwdButton( int x, int y, int buttonID, string text )
		{
			AddButton( x, y - 1, 5541, 5542, 0, GumpButtonType.Page, buttonID );
			AddHtml( x - 145, y, 240, 20, Color( text, LabelHue ), false, false );
		}

		public void AddHomePageButton( int x, int y )
		{
			AddButton( x, y - 1, 4005, 4007, 0, GumpButtonType.Page, 1 );
			AddLabel( x + 35, y, LabelHue, "Start Over.");
		}

		public void AddPageBkwdButton( int x, int y, int buttonID, string text )
		{
			AddButton( x, y - 1, 5538, 5539, 0, GumpButtonType.Page, buttonID );
			AddHtml( x + 35, y, 240, 20, Color( text, LabelHue ), false, false );
		}

		public string Center( string text )
		{
			return String.Format( "<CENTER>{0}</CENTER>", text );
		}

		public string Color( string text, int color )
		{
			return String.Format( "<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text );
		}

		public string Bold( string text )
		{
			return String.Format( "<BOLD>{0}</BOLD>", text );
		}

		public string Italic( string text )
		{
			return String.Format( "<ITALIC>{0}</ITALIC>", text );
		}
	}
}
