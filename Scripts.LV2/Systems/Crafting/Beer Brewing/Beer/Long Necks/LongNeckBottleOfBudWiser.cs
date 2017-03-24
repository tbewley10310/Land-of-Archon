using System; 
using Server; 
using Server.Network; 
using Server.Targeting; 
using System.Collections; 
using Server.Mobiles; 

namespace Server.Items 
{ 
   	public class LongNeckBottleOfBudWiser : BaseBeverage 
   	{ 
    
      		public override int MaxQuantity{ get{ return 10; } } 
      		public override bool Fillable{ get{ return false; } } 

		public override int ComputeItemID() 
      		{ 
         		if ( !IsEmpty ) 
         		{ 
            			return 0x99B; 
         		} 

         		return 0; 
      		} 

      		[Constructable] 
      		public LongNeckBottleOfBudWiser() : base() 
      		{  
         		Weight = 1.0; 
            		Hue = 37;
         		Name = "a Long Neck Bottle Of Bud Wiser";   
         		Quantity = 10;
         		ItemID = 0x99B;  
         		LootType = LootType.Blessed; 
      		} 

      		public LongNeckBottleOfBudWiser( Serial serial ) : base( serial ) 
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