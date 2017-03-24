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
	public class ArmorOfMining : BaseArmor
	{

		public override int AosStrReq{ get{ return 20; } }
		public override int OldStrReq{ get{ return 10; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		public override int InitMinHits{ get{ return 30 + (6*i_SkillBonus); } }
		public override int InitMaxHits{ get{ return 40 + (10*i_SkillBonus); } }
		
		public override int ArmorBase{ get{ return 13 + (4*i_SkillBonus); } }

		private int i_SkillBonus, i_Skill;
		private SkillMod sm_SkillMod;
		private SkillName sn_SkillName;

		[CommandProperty( AccessLevel.GameMaster )]
		public int SkillBonus
		{
			get
			{
				return i_SkillBonus;
			}
			set
			{
				i_SkillBonus = value;
				InvalidateProperties();

				if ( i_SkillBonus == 0 )
				{
					if ( sm_SkillMod != null )
						sm_SkillMod.Remove();

					sm_SkillMod = null;
				}
				else if ( sm_SkillMod == null && Parent is Mobile )
				{
					sm_SkillMod = new DefaultSkillMod( sn_SkillName, true, i_SkillBonus );
					((Mobile)Parent).AddSkillMod( sm_SkillMod );
				}
				else if ( sm_SkillMod != null )
				{
					sm_SkillMod.Value = i_SkillBonus;
				}
			}
		}

		public int Skill { get { return i_Skill; } set { i_Skill = value; InvalidateProperties(); } }

		public override void OnAdded( object parent )
		{
			base.OnAdded( parent );

			if ( i_SkillBonus != 0 && parent is Mobile )
			{
				if ( sm_SkillMod != null )
					sm_SkillMod.Remove();

				sm_SkillMod = new DefaultSkillMod( sn_SkillName, true, i_SkillBonus );
				((Mobile)parent).AddSkillMod( sm_SkillMod );
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public SkillName SkillName { get { return sn_SkillName; } set { sn_SkillName = value; InvalidateProperties(); } }
		
		public override void OnDoubleClick (Mobile from)
		{
			from.SendMessage("skill: {0}", sn_SkillName);
		}

		public override void OnRemoved( object parent )
		{
			base.OnRemoved( parent );

			if ( sm_SkillMod != null )
				sm_SkillMod.Remove();

			sm_SkillMod = null;
		}

		[Constructable]
		public ArmorOfMining( int bonus, int itemID, int skill ) : base( itemID )
		{
			i_SkillBonus = bonus;
			i_Skill = skill;
			
			Weight = 1;
			PhysicalBonus = 2 + Utility.Random((int)(1.6*bonus));
			FireBonus = 4 + Utility.Random((int)(1.6*bonus));
			ColdBonus = 3 + Utility.Random((int)(1.6*bonus));
			PoisonBonus = 3 + Utility.Random((int)(1.6*bonus));
			EnergyBonus = 3 + Utility.Random((int)(1.6*bonus));
			{
                sn_SkillName = SkillName.Mining; 

			}

			string s_Type = "";
			switch (itemID)
			{
				case 5062: default: ItemID = 5062; s_Type = "gloves"; break;
				case 7609: ItemID = 7609; s_Type = "cap"; break;
				case 5068: ItemID = 5068; s_Type = "tunic"; break;
				case 5063: ItemID = 5063; s_Type = "gorget"; break;
				case 5069: ItemID = 5069; s_Type = "arms"; break;
				case 5067: ItemID = 5067; s_Type = "leggings"; break;
			}

			if (i_SkillBonus < 1)
				Name = "Apprentices " + s_Type + " of " + sn_SkillName.ToString();
			else if (i_SkillBonus <= 3)
				Name = "Novices " + s_Type + " of " + sn_SkillName.ToString();
			else
				Name = "Masters " + s_Type + " of " + sn_SkillName.ToString();
			
			this.Hue = CraftResources.GetHue( (CraftResource)Utility.RandomMinMax( (int)CraftResource.DullCopper, (int)CraftResource.Platinum ) );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( i_SkillBonus != 0 )
				list.Add("{0} bonus +{1}", sn_SkillName, i_SkillBonus);
		}

        public ArmorOfMining(Serial serial)
            : base(serial)
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( (int) i_SkillBonus );

			writer.Write( (int) i_Skill );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					i_SkillBonus = reader.ReadInt();
					i_Skill = reader.ReadInt();
					break;
				}

			}

			if ( i_SkillBonus != 0 && Parent is Mobile )
			{
				if ( sm_SkillMod != null )
					sm_SkillMod.Remove();

				sm_SkillMod = new DefaultSkillMod( sn_SkillName, true, i_SkillBonus );
				((Mobile)Parent).AddSkillMod( sm_SkillMod );
			}
		}
	}
}