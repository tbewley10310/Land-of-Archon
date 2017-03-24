// Created by HotShot aka Mule II

using System; 
using Server.Mobiles; 

namespace Server.Items 
{ 
	public class RogueSkillMount : EtherealMount 
	{ 
		[Constructable] 
		public RogueSkillMount() : base( 11676, 0x3E92 ) 
		{ 
			Name = "Ethereal Rogue Skill Mount Statuette";
			ItemID = 11676;
			
		} 
                 public override void OnAdded( object parent )
		{
			base.OnAdded( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Hiding.Base += 10;
				from.Skills.Stealth.Base += 10;
                                from.Skills.Stealing.Base += 10;
                                from.Skills.Snooping.Base += 10;
                                from.Skills.Lockpicking.Base += 10;
                                from.Skills.DetectHidden.Base += 10; 
                                from.Skills.RemoveTrap.Base += 10;
			}
		}
		public override void OnRemoved( object parent )
		{
			base.OnRemoved( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Hiding.Base -= 10;
				from.Skills.Stealth.Base -= 10;
                                from.Skills.Stealing.Base -= 10;
                                from.Skills.Snooping.Base -= 10;
                                from.Skills.Lockpicking.Base -= 10;
                                from.Skills.DetectHidden.Base -= 10; 
                                from.Skills.RemoveTrap.Base -= 10;
			}
			
		}

		public RogueSkillMount( Serial serial ) : base( serial ) 
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

			if ( Name != "Ethereal Cu Sidhe Statuette" )
				Name = "Ethereal Cu Sidhe Statuette";
		} 
	}
}