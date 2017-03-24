// Created by HotShot aka Mule II

using System; 
using Server.Mobiles; 

namespace Server.Items 
{ 
	public class MageSkillMount : EtherealMount 
	{ 
		[Constructable] 
		public MageSkillMount() : base( 11676, 0x3E92 ) 
		{ 
			Name = "Ethereal Mage Skill Mount Statuette";
			ItemID = 11676;
			
		} 
                 public override void OnAdded( object parent )
		{
			base.OnAdded( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Magery.Base += 10;
				from.Skills.EvalInt.Base += 10;
                                from.Skills.Necromancy.Base += 10;
                                from.Skills.SpiritSpeak.Base += 10;
                                from.Skills.MagicResist.Base += 10;
                                from.Skills.Chivalry.Base += 10; 
                                from.Skills.Focus.Base += 10;
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

		public MageSkillMount( Serial serial ) : base( serial ) 
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