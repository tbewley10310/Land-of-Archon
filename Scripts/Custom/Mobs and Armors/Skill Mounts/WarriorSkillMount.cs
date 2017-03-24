// Created by HotShot aka Mule II

using System; 
using Server.Mobiles; 

namespace Server.Items 
{ 
	public class WarriorSkillMount : EtherealMount 
	{ 
		[Constructable] 
		public WarriorSkillMount() : base( 11676, 0x3E92 ) 
		{ 
			Name = "Ethereal Warrior Skill Mount Statuette";
			ItemID = 11676;
			
		} 
                 public override void OnAdded( object parent )
		{
			base.OnAdded( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Swords.Base += 10;
				from.Skills.Tactics.Base += 10;
                                from.Skills.Fencing.Base += 10;
                                from.Skills.Archery.Base += 10;
                                from.Skills.Macing.Base += 10;
                                from.Skills.Wrestling.Base += 10; 
                                from.Skills.Parry.Base += 10;
			}
		}
		public override void OnRemoved( object parent )
		{
			base.OnRemoved( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Swords.Base -= 10;
				from.Skills.Tactics.Base += 10;
                                from.Skills.Fencing.Base -= 10;
                                from.Skills.Archery.Base -= 10;
                                from.Skills.Macing.Base -= 10;
                                from.Skills.Wrestling.Base -= 10;
                                from.Skills.Parry.Base -= 10;
			}
			
		}

		public WarriorSkillMount( Serial serial ) : base( serial ) 
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

			if ( Name != "Ethereal Charger of the Fallen Statuette" )
				Name = "Ethereal Charger of the Fallen Statuette";
		} 
	}
}