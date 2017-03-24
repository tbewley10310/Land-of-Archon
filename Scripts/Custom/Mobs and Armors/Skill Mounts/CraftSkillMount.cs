// Created by HotShot aka Mule II

using System; 
using Server.Mobiles; 

namespace Server.Items 
{ 
	public class CraftSkillMount : EtherealMount 
	{ 
		[Constructable] 
		public CraftSkillMount() : base( 11676, 0x3E92 ) 
		{ 
			Name = "Ethereal Crafting Skill Mount Statuette";
			ItemID = 11676;
			
		} 
                 public override void OnAdded( object parent )
		{
			base.OnAdded( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Alchemy.Base += 10;
				from.Skills.Inscribe.Base += 10;
                                from.Skills.Tailoring.Base += 10;
                                from.Skills.Blacksmith.Base += 10;
                                from.Skills.Tinkering.Base += 10;
                                from.Skills.Carpentry.Base += 10; 
                                from.Skills.Cooking.Base += 10;
			}
		}
		public override void OnRemoved( object parent )
		{
			base.OnRemoved( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Alchemy.Base -= 10;
				from.Skills.Inscribe.Base -= 10;
                                from.Skills.Tailoring.Base -= 10;
                                from.Skills.Blacksmith.Base -= 10;
                                from.Skills.Tinkering.Base -= 10;
                                from.Skills.Carpentry.Base -= 10; 
                                from.Skills.Cooking.Base -= 10;
			}
			
		}

		public CraftSkillMount( Serial serial ) : base( serial ) 
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

			if ( Name != "Ethereal Horse Statuette" )
				Name = "Ethereal Horse Statuette";
		} 
	}
}