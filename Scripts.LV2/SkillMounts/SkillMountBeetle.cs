// Created by HotShot aka Mule II

using System; 
using Server.Mobiles; 

namespace Server.Items 
{ 
	public class SkillMountBeetle : EtherealMount 
	{ 
		[Constructable] 
		public SkillMountBeetle() : base( 0x260F, 0x3E97 ) 
		{ 
			Name = "Ethereal Skill Beetle";
			
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

		public SkillMountBeetle( Serial serial ) : base( serial ) 
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

			if ( Name != "Ethereal Skill Beetle" )
				Name = "Ethereal Skill Beetle";
		} 
	}
}