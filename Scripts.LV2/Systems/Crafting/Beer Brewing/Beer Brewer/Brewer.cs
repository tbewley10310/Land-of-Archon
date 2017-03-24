using System; 
using System.Collections.Generic; 
using Server; 

namespace Server.Mobiles 
{ 
	public class Brewer : BaseVendor 
	{
        private static bool m_Talked; // flag to prevent spam 

        string[] kfcsay = new string[] // things to say while greating 
      { 
         "I'm brewing up some fun in a bottle", 
         "Would you like to learn how to brew fun in a bottle?",   
         "Have a nice day",  
    };
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

        public override NpcGuild NpcGuild { get { return NpcGuild.TinkersGuild; } }

		[Constructable]
		public Brewer() : base( "the Beer Brewer" ) 
		{
            SetSkill(SkillName.Cooking, 90.0, 100.0);
            SetSkill(SkillName.TasteID, 75.0, 98.0);
			SetSkill( SkillName.Anatomy, 45.0, 68.0 );
            SetSkill(SkillName.Tinkering, 64.0, 100.0); 
		} 

		public override void InitSBInfo() 
		{
            m_SBInfos.Add(new SBBeerBrewer()); 
		}

		public override void InitOutfit()
		{
            base.InitOutfit();

            AddItem(new Server.Items.Shirt());
            AddItem(new Server.Items.LongPants());
            AddItem(new Server.Items.Boots());
		}

		public Brewer( Serial serial ) : base( serial ) 
		{ 
		}

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
		} 
	} 
}