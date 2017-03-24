 //////custom container engraving tool/////////////
 ////////scripted by Soldierfortune///////////////
using System;
using Server;
using Server.Multis;
using Server.Targeting;
using Server.Items;
using Server.Prompts;

namespace Server.Items
{
	[FlipableAttribute( 0x0FBF, 0x0FC0 )]
	public class Engraver : Item
	{

		[Constructable]
		public Engraver() : base( 0x0FBF )
		{
		    Name = "Container Engraver";
			Weight = 1.0;
		}
        public Engraver( Serial serial ) : base( serial )
		{
		}
		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 );
		} 
		
		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
		}

        public override void OnDoubleClick( Mobile from )
		{
			if ( from.InRange( this.GetWorldLocation(), 1 ) )
			{
				from.SendMessage( "Select the container you wish to engrave" );
				from.Target = new InternalTarget( this );
			}
			else
			{
				from.SendLocalizedMessage( 500446 ); // That is too far away.
			}
		}
        private class InternalTarget : Target
		{
			private Engraver m_Engraver;
			private BaseContainer m_engtarg;

			public InternalTarget( Engraver engrave ) : base( 1, false, TargetFlags.None )
			{
				m_Engraver = engrave;
			}
            protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is BaseContainer )
				{
					m_engtarg = (BaseContainer)targeted;

					if ( !from.InRange( m_Engraver.GetWorldLocation(), 2 ) || !from.InRange( m_engtarg.GetWorldLocation(), 2 ) )
							from.SendLocalizedMessage( 500446 ); // That is too far away.
					else if ( m_engtarg.Parent == null )
								{
									BaseHouse house = BaseHouse.FindHouseAt( m_engtarg );

									if ( house == null || !house.IsLockedDown( m_engtarg ) )
										from.SendMessage( "Containers must be locked down to engrave them." );

									else if ( !house.IsCoOwner( from ) )
										from.SendLocalizedMessage( 501023 ); // You must be the owner to use this item.

									else
										{
											from.Prompt = new RenameContPrompt( m_engtarg );
											from.SendMessage( "What would you like to engrave on the container ?" );
										}
								}
				}
				else
				{
					from.SendMessage( "You cannot engrave that." );
				}

			}
		}
		
	}
}
namespace Server.Prompts
{
	public class RenameContPrompt : Prompt
	{
		private BaseContainer m_engtarg;

		public RenameContPrompt( BaseContainer rcont )
		{
			m_engtarg = rcont;
		}
		public override void OnResponse( Mobile from, string text )
		{
			m_engtarg.Name = text;
            from.SendMessage( "You have engraved the container." );

		}
	}
}