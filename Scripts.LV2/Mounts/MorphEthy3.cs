//By SHAMBAMPOW
using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Items
{

	public class MorphEthy3 : EtherealMount
	{


		[Constructable]
		public MorphEthy3()
			: base( 0x260F, 0x3E97 )
		{
			Name = "Shapeshifting Ethereal Statuette";
		}

		public MorphEthy3( Serial serial )
			: base( serial )
		{
			Name = "Shapeshifting Ethereal Statuette";
		}



	#region ContextMenu
        private class PropsEntry : ContextMenuEntry
        {
            private MorphEthy3 m_Item;
            private Mobile m_Mobile;
          
            public PropsEntry( Mobile from, Item item )
                : base( 6132 ) // uses "Use" entry                 
            {
                m_Item = ( MorphEthy3 )item; 
                m_Mobile = from;         
            }

            public override void OnClick()
            {   
		if ( m_Item.IsChildOf( m_Mobile.Backpack ) )
		{                                                                   //When this menu entry is clicked by the player.. Do the following:

			if ( m_Item.RegularID == 0x260F )
			{
				m_Item.RegularID = 0x2619;
				m_Item.MountedID = 0x3E98;
				m_Mobile.SendMessage( "The Ethereal has morphed into a swamp dragon!");
				
			}
			else if ( m_Item.RegularID == 0x2619 )
			{
				m_Item.RegularID = 9751;
				m_Item.MountedID = 16059;
				m_Mobile.SendMessage( "The Ethereal has morphed into a skeletal steed!");
			}
			else if ( m_Item.RegularID == 9751 )
			{
				m_Item.RegularID = 0x260F;
				m_Item.MountedID = 0x3E97;
				m_Mobile.SendMessage( "The Ethereal has morphed into a beetle!");
			}
		}
		else m_Mobile.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
            }
        }


        public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
        {                                                                           //We are overriding GetContextMenuEntries because we want to do something to it.
            base.GetContextMenuEntries( from, list );                               //Items and Mobiles may already have context menus on them.. 
            MorphEthy3.GetContextMenuEntries( from, this, list );                 //We want to add another menu entry to what already exists, so call our function that makes the addition
        }

        public static void GetContextMenuEntries( Mobile from, Item item, List<ContextMenuEntry> list )
        {
            list.Add( new PropsEntry( from, item ) );                               //Add the context menu we just created to the list of context menus that go with this item
        }
        #endregion




		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

}
