using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Multis;
using Server.Engines.BulkOrders;
using Server.ContextMenus;

namespace Server.Items
{
	public class RegenBODBook  : Item, ISecurable
	{

		private int m_Deed;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Deed
		{
			get{ return m_Deed; }
			set{ m_Deed = value; InvalidateProperties(); }
		}

		private Timer m_Timer;
		
		private SecureLevel m_Level;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level { get { return m_Level; } set { m_Level = value; } }

		[Constructable]
		public RegenBODBook () : base(0x2259)
		{
			Name = "Regenerating BOD Book";//<----CHANGE NAME
			Hue = 1366;//<----CHANGE HUE
			Weight = 2.0;
			LootType = LootType.Blessed;

			m_Timer = Timer.DelayCall( TimeSpan.FromHours( 1 ), TimeSpan.FromHours( 2 ), new TimerCallback( GiveDeed ) );
		}
		
		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			SetSecureLevelEntry.AddTo( from, this, list );
		}

        public RegenBODBook(Serial serial)
            : base(serial)
		{
		}

		private void GiveDeed()
		{
			m_Deed = Math.Min( 100, m_Deed + 1 );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 2 ) )
			{
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			}
			
			else if ( m_Deed > 0 )
			{
				Item Deed = null;

				switch ( Utility.Random( 6 ) )
				{
					case 0: Deed = new LargeSmithBOD(); break;
					case 1: Deed = new SmallSmithBOD(); break;
					case 2: Deed = new LargeTailorBOD(); break;
					case 3: Deed = new SmallTailorBOD(); break;
                    case 4: Deed = new SmallTamingBOD(); break;
                    case 5: Deed = new LargeTamingBOD(); break;

				}

				int amount = Math.Min( 1, m_Deed );
				Deed.Amount = amount;

				if ( !from.PlaceInBackpack( Deed ) )
				{
					Deed.Delete();
					from.SendLocalizedMessage( 1078837 ); // Your backpack is full! Please make room and try again.
				}
				else
				{
					m_Deed -= amount;
					PublicOverheadMessage( MessageType.Regular, 0x3B2, 503201 ); // You take the item.
				}
			}
			else
				from.SendMessage( "There are no more BOD's available." ); // There are no more BOD's available.
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
			
			writer.WriteEncodedInt( (int) m_Level );

			writer.Write( (int) m_Deed );

			if ( m_Timer != null )
				writer.Write( (DateTime) m_Timer.Next );
			else
				writer.Write( (DateTime) DateTime.Now + TimeSpan.FromHours( 2 ) );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
			
			m_Level = (SecureLevel) reader.ReadEncodedInt();

			m_Deed = reader.ReadInt();

			DateTime next = reader.ReadDateTime();

			if ( next < DateTime.Now )
				next = DateTime.Now;

			m_Timer = Timer.DelayCall( next - DateTime.Now, TimeSpan.FromHours( 2 ), new TimerCallback( GiveDeed ) );
		}
	}

}