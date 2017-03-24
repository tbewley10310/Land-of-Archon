// Created by Crow

using System; 
using Server.Mobiles; 

namespace Server.Items 
{ 
	public class SkillMountChimera : EtherealMount 
	{ 
		[Constructable] 
		public SkillMountChimera() : base( 11669, 0x3E90 ) 
		{ 
			Name = "Ethereal Skill Chimera";
			ItemID = 11669;
			
		} 
                 public override void OnAdded( object parent )
		{
			base.OnAdded( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Swords.Base += 20;
                                from.Skills.Fencing.Base += 20;
                                from.Skills.Magery.Base += 20;
                                from.Skills.Archery.Base += 20;
                                from.Skills.Macing.Base += 20;
                                from.Skills.Wrestling.Base += 20;
                                from.Skills.Anatomy.Base += 20; 
                                from.Skills.Meditation.Base += 20;
				from.Skills.Healing.Base += 20;
                                from.Skills.EvalInt.Base += 10;
			}
		}
		public override void OnRemoved( object parent )
		{
			base.OnRemoved( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Swords.Base -= 20;
                                from.Skills.Fencing.Base -= 20;
                                from.Skills.Magery.Base -= 20;
                                from.Skills.Archery.Base -= 20;
                                from.Skills.Macing.Base -= 20;
                                from.Skills.Wrestling.Base -= 20;
                                from.Skills.Anatomy.Base -= 20;
                                from.Skills.Meditation.Base -= 20;
				from.Skills.Healing.Base -= 20;
                                from.Skills.EvalInt.Base -= 10;
			}
			
		}

		public SkillMountChimera( Serial serial ) : base( serial ) 
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

			if ( Name != "Ethereal Chimera Statuette" )
				Name = "Ethereal Chimera Statuette";
		} 
	}
}