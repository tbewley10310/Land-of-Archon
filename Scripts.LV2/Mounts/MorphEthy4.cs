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

	public class MorphEthy4 : EtherealMount
	{


		[Constructable]
		public MorphEthy4()
			: base( 10090, 16020 )
		{
			Name = "Shapeshifting Ethereal Statuette";
		}

		public MorphEthy4( Serial serial )
			: base( serial )
		{
			Name = "Shapeshifting Ethereal Statuette";
		}



	#region ContextMenu
        private class PropsEntry : ContextMenuEntry
        {
            private MorphEthy4 m_Item;
            private Mobile m_Mobile;
          
            public PropsEntry( Mobile from, Item item )
                : base( 6132 ) // uses "Use" entry                 
            {
                m_Item = ( MorphEthy4 )item; 
                m_Mobile = from;         
            }

            public override void OnClick()
            {   
		if ( m_Item.IsChildOf( m_Mobile.Backpack ) )
		{                                                                   //When this menu entry is clicked by the player.. Do the following:

			if ( m_Item.RegularID == 10090 )
			{
				m_Item.RegularID = 11676;
				m_Item.MountedID = 16018;
				m_Mobile.SendMessage( "The Ethereal has morphed into a charger of the fallen!");
				
			}
			else if ( m_Item.RegularID == 11676 )
			{
				m_Item.RegularID = 11670;
				m_Item.MountedID = 16017;
				m_Mobile.SendMessage( "The Ethereal has morphed into a cu sidhe!");
			}
			else if ( m_Item.RegularID == 11670 )
			{
				m_Item.RegularID = 10090;
				m_Item.MountedID = 16020;
				m_Mobile.SendMessage( "The Ethereal has morphed into a hiryu!");
			}
		}
		else m_Mobile.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
            }
        }


        public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
        {                                                                           //We are overriding GetContextMenuEntries because we want to do something to it.
            base.GetContextMenuEntries( from, list );                               //Items and Mobiles may already have context menus on them.. 
            MorphEthy4.GetContextMenuEntries( from, this, list );                 //We want to add another menu entry to what already exists, so call our function that makes the addition
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
