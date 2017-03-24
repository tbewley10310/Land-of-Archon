using System;

namespace Server.Items
{
	public class Hop1 : Item/*, ICommodity*/
	{
        //string ICommodity.Description //* commodity isnt exactly neccassary for the time being
        //{
        //    get
        //    {
        //        return String.Format( Amount == 1 ? "{0} Hop1" : "{0} Hop1s", Amount );
        //    }
        //}

		[Constructable]
		public Hop1() : this(1)
		
                {
		}

		[Constructable]
		public Hop1(int amount) : base(0x1AA2)
		{
			Stackable = true;
			Weight = 0.1;
			Amount = amount;
		}

		public Hop1(Serial serial) : base(serial)
		{
		}

        //public override Item Dupe(int amount) //* no real need to be able to dupe it lol
        //{
        //    return base.Dupe(new Hop1(amount), amount);
        //}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}