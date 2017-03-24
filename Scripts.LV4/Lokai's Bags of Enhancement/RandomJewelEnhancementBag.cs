using System;
using System.Collections;
using Server.Items;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.Accounting;

namespace Server.Custom
{
	public class RandomJewelEnhancementBag : CustomBag
	{
		private Mobile m_BagBoundToPlayer;
		private ArrayList m_Serials;
		private string EnhanceName = "Enhanced by Lokai's Magical Bag of Jewel Enhancement.";
		private string TagName = "HasJewelEnhancementBag";

		[Constructable]
		public RandomJewelEnhancementBag() : base()
		{
			Name = "Lokai's Magical Bag of Jewel Enhancement";
			Weight = 2.0;
			m_Serials = new ArrayList();
		}

		public RandomJewelEnhancementBag( Serial serial ) : base( serial )
		{
		}

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			return OnDragDropInto( from, dropped, new Point3D( 40, 40, 0 ) );
		}
		
		public override bool OnDragDropInto( Mobile m, Item item, Point3D p )
		{
			if ( !( m is PlayerMobile ) )
			{
				return false;
			}
			PlayerMobile from = m as PlayerMobile;

			if ( !CheckHold( from, item, true, true ) )
				return false;

			if ( PlayerBoundToAnotherBag( from ) )
			{
				from.SendMessage("You already have bonded to another {0}", this.Name);
				return false;
			}
			
			if ( m_BagBoundToPlayer != from )
			{
				from.SendMessage("You do not own this {0}", this.Name);
				return false;
			}

			if ( ItemEnhanced(item) )
			{
				from.SendMessage("That item has already been enhanced.");
				return false;
			}

			if ( item is BaseJewel )
			{
				EnhanceJewel( item, EnhanceName );
				from.PlaySound( 0x214 );
				this.AddItem( item );
				m_Serials.Add( item );
				return true;
			}
			else
			{
				from.SendMessage("That item is not a jewel!");
				return false;
			}
		}

		public bool PlayerBoundToAnotherBag( PlayerMobile from )
		{
			Account a = from.Account as Account;
			string tagged = a.Username + this.Serial.Value.ToString();
			if (a.GetTag( TagName ) == tagged )
			{
				return false;
			}
			else if ( a.GetTag( TagName ) != null )
			{
				return true;
			}
			a.SetTag( TagName, tagged );
			from.SendMessage("{0} is now Bonded to you!", this.Name);
			return false;
		}

		public bool ItemEnhanced( Item item )
		{
			foreach ( Item i in m_Serials  )
			{
				if ( i == item )
					return true;
			}
			return false;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
			writer.Write( m_BagBoundToPlayer );
			writer.WriteItemList( m_Serials );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			if ( version > 0 ) m_BagBoundToPlayer = reader.ReadMobile();
			m_Serials = reader.ReadItemList();
		}
	}
}