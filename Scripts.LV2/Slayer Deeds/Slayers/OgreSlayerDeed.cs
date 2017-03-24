using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Targeting;
using Server;

namespace Server.Items
{
	public class OgreSlayerTarget : Target
	{
		private OgreSlayerDeed m_Deed;

		public OgreSlayerTarget( OgreSlayerDeed deed ) : base( 1, false, TargetFlags.None )
		{
			m_Deed = deed;
		}

		protected override void OnTarget( Mobile from, object target )
		{
			if ( target is BaseWeapon )
			{
				Item item = (Item)target;

				if ( ((BaseWeapon)item).Slayer == SlayerName.OgreTrashing || ((BaseWeapon)item).Slayer2 == SlayerName.OgreTrashing )
				{
					from.SendMessage( "That already is an ogre slayer!");
				}
				else
				{
					if( item.RootParent != from )
					{
						from.SendMessage( "You cannot put ogre slayer on that there!" );
					}
					else
					{
						if( ((BaseWeapon)item).Slayer != SlayerName.None && ((BaseWeapon)item).Slayer2 != SlayerName.None )
						{
							from.SendMessage( "Your weapon already has two slayers! One must be removed first." );
						}
						
						if( ((BaseWeapon)item).Slayer == SlayerName.None )
						{
							((BaseWeapon)item).Slayer = SlayerName.OgreTrashing;
							from.SendMessage( "Your weapon magically becomes an ogre slayer..." );
							m_Deed.Delete();
						}
						else if( ((BaseWeapon)item).Slayer2 == SlayerName.None )
						{
							((BaseWeapon)item).Slayer2 = SlayerName.OgreTrashing;
							from.SendMessage( "Your weapon magically becomes an ogre slayer..." );
							m_Deed.Delete();
						}
					}
				}
			}
			else if ( target is Spellbook )
			{
				Item item = (Item)target;

				if ( ((Spellbook)item).Slayer == SlayerName.OgreTrashing || ((Spellbook)item).Slayer2 == SlayerName.OgreTrashing )
				{
					from.SendMessage( "That already is an ogre slayer!");
				}
				else
				{
					if( item.RootParent != from )
					{
						from.SendMessage( "You cannot put ogre slayer on that there!" );
					}
					else
					{
						if( ((Spellbook)item).Slayer != SlayerName.None && ((Spellbook)item).Slayer2 != SlayerName.None )
						{
							from.SendMessage( "Your spellbook already has two slayers! One must be removed first." );
						}
						
						if( ((Spellbook)item).Slayer == SlayerName.None )
						{
							((Spellbook)item).Slayer = SlayerName.OgreTrashing;
							from.SendMessage( "Your spellbook magically becomes an ogre slayer..." );
							m_Deed.Delete();
						}
						else if( ((Spellbook)item).Slayer2 == SlayerName.None )
						{
							((Spellbook)item).Slayer2 = SlayerName.OgreTrashing;
							from.SendMessage( "Your spellbook magically becomes an ogre slayer..." );
							m_Deed.Delete();
						}
					}
				}
			}
			else
			{
				from.SendMessage( "That cannot be made into an ogre slayer." );
			}
		}
	}

	public class OgreSlayerDeed : Item
	{
		[Constructable]
		public OgreSlayerDeed() : base( 0x14F0 )
		{
			Weight = 1.0;
			Name = "Ogre Slayer deed";
			LootType = LootType.Blessed;
			Hue = 1175;
		}

		public OgreSlayerDeed( Serial serial ) : base( serial )
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
			LootType = LootType.Blessed;

			int version = reader.ReadInt();
		}

		public override bool DisplayLootType{ get{ return false; } }

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				 from.SendLocalizedMessage( 1042001 );
			}
			else
			{
				from.SendMessage("What item would you like to change into an ogre slayer?");
				from.Target = new OgreSlayerTarget( this );
			 }
		}	
	}
}


