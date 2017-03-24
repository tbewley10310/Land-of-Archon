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
using System;
using Server.Targeting;
using Server.Engines.Harvest;


namespace Server.Items
{
	public class LumberjackingProspectorsTool : BaseAxe
	{
		public override int LabelNumber{ get{ return 1049065; } } // prospector's tool

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

		public override int AosStrengthReq{ get{ return 20; } }
		public override int AosMinDamage{ get{ return 13; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 41; } }

		public override int OldStrengthReq{ get{ return 15; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 17; } }
		public override int OldSpeed{ get{ return 40; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		[Constructable]
		public LumberjackingProspectorsTool() : base( 0xF44 )
		{
			Weight = 9.0;
			ShowUsesRemaining = true;
			UsesRemaining = 100;
		}

		public LumberjackingProspectorsTool( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) || Parent == from )
				from.Target = new InternalTarget( this );
			else
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
		}

		public void Prospect( Mobile from, object toProspect )
		{
			if ( !IsChildOf( from.Backpack ) && Parent != from )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
				return;
			}

			HarvestSystem system = Lumberjacking.System;

			int tileID;
			Map map;
			Point3D loc;

			if ( !system.GetHarvestDetails( from, this, toProspect, out tileID, out map, out loc ) )
			{
				from.SendLocalizedMessage( 1049048 ); // You cannot use your prospector tool on that.
				return;
			}

			HarvestDefinition def = system.GetDefinition( tileID );

			if ( def == null || def.Veins.Length <= 1 )
			{
				from.SendLocalizedMessage( 1049048 ); // You cannot use your prospector tool on that.
				return;
			}

			HarvestBank bank = def.GetBank( map, loc.X, loc.Y );

			if ( bank == null )
			{
				from.SendLocalizedMessage( 1049048 ); // You cannot use your prospector tool on that.
				return;
			}

			HarvestVein vein = bank.Vein, defaultVein = bank.DefaultVein;

			if ( vein == null || defaultVein == null )
			{
				from.SendLocalizedMessage( 1049048 ); // You cannot use your prospector tool on that.
				return;
			}
            else if (vein != defaultVein)
            {
                from.SendLocalizedMessage(1049049); // That ore looks to be prospected already.
                return;
            }

			int veinIndex = Array.IndexOf( def.Veins, vein );

			if ( veinIndex < 0 )
			{
				from.SendLocalizedMessage( 1049048 ); // You cannot use your prospector tool on that.
			}
            else if (veinIndex >= (def.Veins.Length - 1))
			{
				if ( veinIndex >= (def.Veins.Length - 1) )
				{
					from.SendMessage( "You cannot improve frostwood through prospecting." );
				}
				else
				{
					bank.Vein = def.Veins[veinIndex + 1];
					switch ( veinIndex )
					{
						case 0: from.SendMessage( "You sift through the tree and find oak wood can be lumberjacked there" ); break;//Pine
						case 1: from.SendMessage( "You sift through the tree and find ash wood can be lumberjacked there" ); break;//Ash
						case 2: from.SendMessage( "You sift through the tree and find yew wood can be lumberjacked there" ); break;//Mohogany
						case 3: from.SendMessage( "You sift through the tree and find heartwood wood can be lumberjacked there" ); break;//Yew
						case 4: from.SendMessage( "You sift through the tree and find bloodwood can be lumberjacked there" ); break;//Oak
						case 5: from.SendMessage( "You sift through the tree and find frostwood wood can be lumberjacked there" ); break;//Zircote
					}

					--UsesRemaining;

					if ( UsesRemaining <= 0 )
					{
						from.SendLocalizedMessage( 1049062 ); // You have used up your prospector's tool.
						Delete();
					}
				}
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			
			if (version == 0)
				UsesRemaining = reader.ReadInt();

			ShowUsesRemaining = true;
		}

		private class InternalTarget : Target
		{
			private LumberjackingProspectorsTool m_Tool;

			public InternalTarget( LumberjackingProspectorsTool tool ) : base( 2, true, TargetFlags.None )
			{
				m_Tool = tool;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				m_Tool.Prospect( from, targeted );
			}
		}
	}
}
