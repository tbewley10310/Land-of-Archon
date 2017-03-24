// Created by HotShot aka Mule II

using System; 
using Server.Mobiles; 

namespace Server.Items 
{ 
	public class SkillMountRidgeback : EtherealMount 
	{ 
		[Constructable] 
		public SkillMountRidgeback() : base( 0x2615, 0x3E9A ) 
		{ 
			Name = "Ethereal Skill Ridgeback";
			
		} 
                 public override void OnAdded( object parent )
		{
			base.OnAdded( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Swords.Base += 10;
                                from.Skills.Fencing.Base += 10;
                                from.Skills.Magery.Base += 10;
                                from.Skills.Archery.Base += 10;
                                from.Skills.Macing.Base += 10;
                                from.Skills.Wrestling.Base += 10;
                                from.Skills.Anatomy.Base += 10; 
                                from.Skills.Meditation.Base += 10;
                                from.Skills.EvalInt.Base += 10;
			}
		}
		public override void OnRemoved( object parent )
		{
			base.OnRemoved( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Swords.Base -= 10;
                                from.Skills.Fencing.Base -= 10;
                                from.Skills.Magery.Base -= 10;
                                from.Skills.Archery.Base -= 10;
                                from.Skills.Macing.Base -= 10;
                                from.Skills.Wrestling.Base -= 10;
                                from.Skills.Anatomy.Base -= 10;
                                from.Skills.Meditation.Base -= 10;
                                from.Skills.EvalInt.Base -= 10;
			}
			
		}

		public SkillMountRidgeback( Serial serial ) : base( serial ) 
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

			if ( Name != "Ethereal Skill Ridgeback" )
				Name = "Ethereal Skill Ridgeback";
		} 
	}
}