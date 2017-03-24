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

namespace Server.Items
{
	[FlipableAttribute( 0xf9f, 0xf9e )]
	public class ColoredScissors : Scissors, IUsesRemaining
	{
		private int m_UsesRemaining;
		private bool m_ShowUsesRemaining;

		[CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining { get { return m_UsesRemaining; } set { m_UsesRemaining = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public bool ShowUsesRemaining { get { return m_ShowUsesRemaining; } set { m_ShowUsesRemaining = value; InvalidateProperties(); } }
		
		[Constructable]
		public ColoredScissors() : this( 0, 50 )
		{
		}
		
		[Constructable]
		public ColoredScissors( int hue, int uses )
		{
			Weight = 1.0;
			Hue = hue;
			ItemID = 0xF9F;
			UsesRemaining = uses;
			ShowUsesRemaining = true;
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1060584, m_UsesRemaining.ToString() ); // uses remaining: ~1_val~
		}

		public ColoredScissors( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int) m_UsesRemaining );
			writer.Write( (bool) m_ShowUsesRemaining );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch (version)
			{
				case 1:
				{
					m_UsesRemaining = reader.ReadInt();
					m_ShowUsesRemaining = reader.ReadBool();
					break;
				}
				case 0:
				{
					m_UsesRemaining = 50;
					m_ShowUsesRemaining = true;
					break;
				}
			}
		}
	}
}