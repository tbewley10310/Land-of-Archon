#region Header
// File:		InstantEthereal.cs
// Original Code : snicker7 of RunUO
// Editor:		Zero 
// Created:		11/25/2013 @ 19:33
// Edited:		------------------   
#endregion

//Donation Item : Instant Cast Ethereal Mounts for Players, inclues all current working Mounts / MountIDs. 


using System;
using System.Collections;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles {
	public class InstantEthereal : EtherealMount {
		public enum EtherealTypes {
			Horse,
			Llama,
			Ostard,
			OstardDesert,
			OstardFrenzied,
			Ridgeback,
			Unicorn,
			Beetle,
			Kirin,
			SwampDragon,
			SkeletalHorse,
			Hiryu,
			ChargerOfTheFallen,
			Chimera,
			CuSidhe,
			PolarBear,
            Tiger,
            ArmoredBoura
			
		}

		public struct EtherealInfo {
			public int RegularID;
			public int MountedID;
			public EtherealInfo(int id, int mid) { RegularID=id; MountedID=mid; }
		}

		private static EtherealInfo[] EthyItemTypes = new EtherealInfo[] {
			new EtherealInfo(0x20DD, 0x3EAA),	//Horse
			new EtherealInfo(0x20F6, 0x3EAB),	//Llama
			new EtherealInfo(0x2135, 0x3EAC),	//Ostard
			new EtherealInfo(8501, 16035),		//DesertOstard
			new EtherealInfo(8502, 16036),		//FrenziedOstard
			new EtherealInfo(0x2615, 0x3E9A),	//Ridgeback
			new EtherealInfo(0x25CE, 0x3E9B),	//Unicorn
			new EtherealInfo(0x260F, 0x3E97),	//Beetle
			new EtherealInfo(0x25A0, 0x3E9C),	//Kirin
			new EtherealInfo(0x2619, 0x3E98),	//SwampDragon
			new EtherealInfo(9751, 16059),		//SkeletalMount
			new EtherealInfo(10090, 16020),		//Hiryu
			new EtherealInfo(11676, 16018),		//ChargerOfTheFallen
			new EtherealInfo(11669, 16016),		//Chimera
			new EtherealInfo(11670, 16017),		//CuSidhe
			new EtherealInfo(8417, 16069),		//PolarBear
            new EtherealInfo(0x9844, 16071),    //Tiger
            new EtherealInfo(0x46F8, 16070)     //ArmoredBoura
			
		};
		
		[CommandProperty( AccessLevel.Player )]
		public EtherealTypes EthyType
		{
			get{return m_EthyType;}
			set{
				if((int)value>EthyItemTypes.Length)
					return;
				m_EthyType = value;
				MountedID = EthyItemTypes[(int)value].MountedID;
				RegularID = EthyItemTypes[(int)value].RegularID;
			}
		}
		
		public override string DefaultName { get { return "An Instant Ethereal Mount"; } }
		public override int FollowerSlots{ get{ return 0; } }
		
		private EtherealTypes m_EthyType;
		
		[Constructable]
		public InstantEthereal() : this( EtherealTypes.Horse ) {}
		[Constructable]
		public InstantEthereal( EtherealTypes type ) : base(0,0) {
			EthyType = type;
			LootType = LootType.Blessed;
			Hue = 0;
            
		}
        public InstantEthereal(Serial serial) : base(serial) { }
		
		public override void OnDoubleClick( Mobile from ) {
			     if ( from.Mounted )
					from.SendLocalizedMessage( 1005583 ); // Please dismount first.
				    else if ( from.HasTrade )
					from.SendLocalizedMessage( 1042317, "", 0x41 ); // You may not ride at this time
				    else if ( Multis.DesignContext.Check( from ) ){
					if ( !this.Deleted && this.Rider == null && this.IsChildOf( from.Backpack ) ){
						Rider = from;
						if(MountedID==16051)
							Rider.CanSwim=true;
					}
				}
			
		}

		public override void Serialize( GenericWriter writer ) {
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( (int) m_EthyType );
		}
		public override void Deserialize( GenericReader reader ) {
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_EthyType = (EtherealTypes)reader.ReadInt();
		}
	}
	
	public class DPEthVirtual : EtherealMount {
		public DPEthVirtual(int id, int mid) : base( id, mid ) {}
		public DPEthVirtual( Serial serial ) : base( serial ) {}
		public override void Serialize( GenericWriter writer ) {
			base.Serialize( writer );
		}
		public override void Deserialize( GenericReader reader ) {
			base.Deserialize( reader ); Delete();
		}
	}
}