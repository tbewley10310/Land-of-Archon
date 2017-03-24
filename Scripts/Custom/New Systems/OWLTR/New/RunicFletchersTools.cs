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
using Server.Engines.Craft;
using System; 

namespace Server.Items 
{ 
	[FlipableAttribute( 0x1022, 0x1023 )] 
	public class RunicFletcherTools : BaseRunicTool 
	{ 
		public override CraftSystem CraftSystem{ get{ return DefBowFletching.CraftSystem; } } 

		public override int LabelNumber 
		{ 
			get 
			{ 
				int index = CraftResources.GetIndex( Resource ); 

				if ( index >= 301 && index <= 311 ) 
					return 1042598 + index; 

				return 1044166;
			} 
		} 

		public override void AddNameProperties( ObjectPropertyList list ) 
		{ 
			base.AddNameProperties( list ); 

			int index = CraftResources.GetIndex( Resource ); 

			if ( index >= 301 && index <= 311 ) 
				return; 

			if ( !CraftResources.IsStandard( Resource ) ) 
			{ 
				int num = CraftResources.GetLocalizationNumber( Resource ); 

				if ( num > 0 ) 
					list.Add( num ); 
				else 
					list.Add( CraftResources.GetName( Resource ) ); 
			} 
		} 

		[Constructable] 
		public RunicFletcherTools( CraftResource resource ) : base( resource, 0x1022 ) 
		{ 
			Weight = 2.0;
			Hue = CraftResources.GetHue( resource );
		} 

		[Constructable] 
		public RunicFletcherTools( CraftResource resource, int uses ) : base( resource, uses, 0x1022 ) 
		{ 
			Weight = 2.0;
			Hue = CraftResources.GetHue( resource );
		} 

		public RunicFletcherTools( Serial serial ) : base( serial ) 
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

		//daat99 OWTLR start - runic storage
		public override Type GetCraftableType()
		{
			switch (Resource)
			{
				case CraftResource.OakWood:
					return typeof(OakRunicFletcherTools);
				case CraftResource.AshWood:
					return typeof(AshRunicFletcherTools);
				case CraftResource.YewWood:
					return typeof(YewRunicFletcherTools);
				case CraftResource.Heartwood:
					return typeof(HeartwoodRunicFletcherTools);
				case CraftResource.Bloodwood:
					return typeof(BloodwoodRunicFletcherTools);
				case CraftResource.Frostwood:
					return typeof(FrostwoodRunicFletcherTools);
				case CraftResource.Ebony:
					return typeof(EbonyRunicFletcherTools);
				case CraftResource.Bamboo:
					return typeof(BambooRunicFletcherTools);
				case CraftResource.PurpleHeart:
					return typeof(PurpleHeartRunicFletcherTools);
				case CraftResource.Redwood:
					return typeof(RedwoodRunicFletcherTools);
				case CraftResource.Petrified:
					return typeof(PetrifiedRunicFletcherTools);
				default:
					return null;
			}
		}
		//daat99 OWLTR end - runic storage
	} 
}