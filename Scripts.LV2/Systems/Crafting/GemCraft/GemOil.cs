using System;
using Server;

namespace Server.Items
{
	public class GemOil : Item
	{
        public override double DefaultWeight
        {
            get { return 0.1; }
        }
	
        [Constructable]
		public GemOil() : this( 1 )
		{
		}

		[Constructable]
        public GemOil(int amount) : base(0x1A9C)
		{
            Name = "Gem Oil";
            Hue = 903;
            Stackable = true;
            Amount = amount;
		}
      

        public GemOil(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}