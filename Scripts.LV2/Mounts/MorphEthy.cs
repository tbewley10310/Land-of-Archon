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

	public class MorphEthy : EtherealMount
	{


		[Constructable]
		public MorphEthy()
			: base( 0x20F6, 0x3EAB )
		{
			Name = "Shapeshifting Ethereal Statuette";
		}

		public MorphEthy( Serial serial )
			: base( serial )
		{
			Name = "Shapeshifting Ethereal Statuette";
		}



	#region ContextMenu
        private class PropsEntry : ContextMenuEntry
        {
            private MorphEthy m_Item;
            private Mobile m_Mobile;
          
            public PropsEntry( Mobile from, Item item )
                : base( 6132 ) // uses "Use" entry                 
            {
                m_Item = ( MorphEthy )item; 
                m_Mobile = from;         
            }

            public override void OnClick()
            {   
		if ( m_Item.IsChildOf( m_Mobile.Backpack ) )
		{                                                                   //When this menu entry is clicked by the player.. Do the following:

			if ( m_Item.RegularID == 8438 )
			{
				m_Item.RegularID = 8413;
				m_Item.MountedID = 16042;
				m_Mobile.SendMessage( "The Ethereal has morphed into a horse!");
				
			}
			else if ( m_Item.RegularID == 8413 )
			{
				m_Item.RegularID = 8501;
				m_Item.MountedID = 16044;
				m_Mobile.SendMessage( "The Ethereal has morphed into an ostard!");
			}
			else if ( m_Item.RegularID == 8501 )
			{
				m_Item.RegularID = 8438;
				m_Item.MountedID = 16043;
				m_Mobile.SendMessage( "The Ethereal has morphed into a llama!");
			}
		}
		else m_Mobile.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
            }
        }


        public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
        {                                                                           //We are overriding GetContextMenuEntries because we want to do something to it.
            base.GetContextMenuEntries( from, list );                               //Items and Mobiles may already have context menus on them.. 
            MorphEthy.GetContextMenuEntries( from, this, list );                 //We want to add another menu entry to what already exists, so call our function that makes the addition
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

			if( Name == "an ethereal horse" )
				Name = null;

			if( ItemID == 0x2124 )
				ItemID = 0x20DD;
		}
	}

}
