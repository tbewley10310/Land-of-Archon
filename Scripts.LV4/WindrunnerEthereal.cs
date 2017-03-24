#region Header
// **********
// ServUO - Ethereals.cs
// **********
#endregion

#region References
using System;

using Server.Engines.VeteranRewards;
using Server.Items;
using Server.Multis;
using Server.Spells;
#endregion

namespace Server.Mobiles
{
	
	public class EtherealCanineWindrunner : EtherealMount
	{
		public override int EtherealHue { get { return 0; } }
		public override int LabelNumber { get { return 1124685; } } // Windrunner
		
		[Constructable]
		public EtherealCanineWindrunner() : base( 0x9ED5, 0x3ECC  )
		{
		}
		public EtherealCanineWindrunner( Serial serial )
			: base( serial )
		{
		}
		
		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

			writer.Write( (int)0 ); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }
	}
	
}