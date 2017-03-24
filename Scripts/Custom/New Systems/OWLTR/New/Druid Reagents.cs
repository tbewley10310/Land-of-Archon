
namespace Server.Items
{
	public class DestroyingAngel : BaseReagent, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }
		
		[Constructable]
		public DestroyingAngel() : this( 1 )
		{
		}

		[Constructable]
		public DestroyingAngel( int amount ) : base( 0xE1F )
		{
			Stackable = true;
			Weight = 0.0;
			Amount = amount;
			Name = "Destroying Angel";
			Hue = 0x290;
		}

		public DestroyingAngel( Serial serial ) : base( serial )
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
	
	public class PetrafiedWood : BaseReagent, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }
		
		[Constructable]
		public PetrafiedWood() : this( 1 )
		{
		}

		[Constructable]
		public PetrafiedWood( int amount ) : base( 0x97A )
		{
			Stackable = true;
			Weight = 0.0;
			Amount = amount;
			Name = "Petrafied Wood";
			Hue = 0x46C;
		}

		public PetrafiedWood( Serial serial ) : base( serial )
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
	
	public class SpringWater : BaseReagent, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }
		
		[Constructable]
		public SpringWater() : this( 1 )
		{
		}

		[Constructable]
		public SpringWater( int amount ) : base( 0xE24 )
		{
			Stackable = true;
			Weight = 0.0;
			Amount = amount;
			Name = "Spring Water";
			Hue = 0x47F;
		}

		public SpringWater( Serial serial ) : base( serial )
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