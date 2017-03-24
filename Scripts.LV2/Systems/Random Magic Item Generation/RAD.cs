// Scripted by Thor86
using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{

	public class RAD : Item
	{

		[Constructable]
		public RAD() : this( null )
		{
		}

		[Constructable]
		public RAD ( string name ) : base ( 5358 )
		{
			Name = "Random Artifact Deed";
			Hue = 2626;
		}

		public RAD ( Serial serial ) : base ( serial )
		{
		}

      		public override void OnDoubleClick( Mobile from ) 
      		{
			if ( !IsChildOf( from.Backpack ) )
			{
                from.SendLocalizedMessage(1042001);
            }
            else
            {
                switch (Utility.Random(16))
                {
                    case 0: from.AddToBackpack(new ArtifactArm()); break;
                    case 1: from.AddToBackpack(new ArtifactChest()); break;
                    case 2: from.AddToBackpack(new ArtifactGlove()); break;
                    case 3: from.AddToBackpack(new ArtifactHelm()); break;
                    case 4: from.AddToBackpack(new ArtifactLegging()); break;
                    case 5: from.AddToBackpack(new ArtifactNeck()); break;
                    case 6: from.AddToBackpack(new ArtifactCape()); break;
                    case 7: from.AddToBackpack(new ArtifactHalfApron()); break;
                    case 8: from.AddToBackpack(new ArtifactRobe()); break;
                    case 9: from.AddToBackpack(new ArtifactShoes()); break;
                    case 10: from.AddToBackpack(new ArtifactBracelet()); break;
                    case 11: from.AddToBackpack(new ArtifactEarring()); break;
                    case 12: from.AddToBackpack(new ArtifactRing()); break;
                    case 13: from.AddToBackpack(new ArtifactShield()); break;
                    case 14: from.AddToBackpack(new ArtifactWeapon1H()); break;
                    case 15: from.AddToBackpack(new ArtifactWeapon2H()); break;
               }
                this.Delete();
			}

		}

		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}