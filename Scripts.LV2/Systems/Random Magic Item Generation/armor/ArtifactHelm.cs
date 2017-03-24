// Scripted by Thor86
using System;
using Server;

namespace Server.Items
{
    public class ArtifactHelm : LeatherCap, ITokunoDyable
	{
        //public override int ArtifactRarity{ get{ return 6; } }
        public override int ArtifactRarity { get { return Utility.RandomMinMax(1, 10); } }

        public override int BasePhysicalResistance { get { return 0; } }
        public override int BaseFireResistance { get { return 0; } }
        public override int BaseColdResistance { get { return 0; } }
        public override int BasePoisonResistance { get { return 0; } }
        public override int BaseEnergyResistance { get { return 0; } }

        public override bool AllowMaleWearer { get { return true; } }
	 	public override int InitMinHits{ get{ return 255; } }
	 	public override int InitMaxHits{ get{ return 255; } }

        private static string[] m_Names = new string[]
		{
             // names based off past expanions
			"Helm from the Order armory",
	    	"Helm from the Chaos armory",
            "Helm crafted during the The Second Age",
            "Helm crafted during the Renaissance ",
            "Helm crafted during the Third Dawn",
	    	"Helm crafted during the Age of Shadows",

              // names based off past npc's
            "Helm crafted by Lord British",
            "Helm crafted by Lord Blackthorn",
            "Helm crafted by Lady Dawn",// She was a great warrior and great follower of Virtue, and her career eventually led to her being crowned Queen,
            "Helm crafted by Sir Dupre",//Dupre is usually portrayed in official fiction as leading the True Britannians Faction in Felucca,
            "Helm crafted by Minax",//Minax is an important NPC villain in the history of Ultima. Also called the Dark Mistress, Minax first appeared in the single player game, Ultima II: Revenge of the Enchantress,
            "Helm crafted by Mondain",//Mondain was an evil sorcerer who heralded the First Age of Darkness in Sosaria. 
            "Helm crafted by The Avatar", // Avatar from the single player games
            "Helm crafted by Exodus",//Exodus was the prodigy of Mondain and Minax,
            "Helm crafted by King Casca", // Yew prosecutor turned King before killed by dawn on easports shards

            // names based on monsters
           "Helm crafted by a Goblin",
           "Helm crafted by a Meer",
           "Helm crafted by a Troll",
           "Helm crafted by a Ogre",
           "Helm crafted by a Daemon",
           "Helm crafted by a Orc",
           "Helm crafted by a Juka",
           "Helm crafted by a Liche",
           "Helm crafted by a Lizardman",
           "Helm crafted by a Ophidian",
           "Helm crafted by a Ratman",
           "Helm crafted by a Terathan",

                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
            "Helm from the Ancient Samurai Empire"
		};

	 	[Constructable]
	 	public ArtifactHelm()
	 	{
           // Name = "Artifact Helm";
            Name = m_Names[Utility.Random(m_Names.Length)];
            Hue = Utility.RandomMinMax(5, 3000);
            // Name = "Artifact Helm";

            // random chance to get diffent resist %
            PhysicalBonus = Utility.RandomMinMax(4, 13);
            FireBonus = Utility.RandomMinMax(4, 13);
            ColdBonus = Utility.RandomMinMax(4, 13);
            PoisonBonus = Utility.RandomMinMax(4, 13);
            EnergyBonus = Utility.RandomMinMax(4, 13);

            // id it shows item as
            switch (Utility.Random(7))
            {
                case 0: ItemID = 0x140E; break;//norse
                case 1: ItemID = 0x1408; break;//close
                case 2: ItemID = 0x1718; break;//wizard
                case 3: ItemID = 0x141B; break;//orc
                case 4: ItemID = 0x1549; break;//trible
                case 5: ItemID = 5138; break;//plate
                case 6: ItemID = 5440; break;//badana
            }

            // random chance to get these stats added to item ,chance of one stat per switch
            switch (Utility.Random(5))
            {
                case 0: Attributes.RegenHits = Utility.RandomMinMax(1, 4); break;
                case 1: Attributes.RegenStam = Utility.RandomMinMax(1, 4); break;
                case 2: Attributes.RegenStam = Utility.RandomMinMax(1, 4); break;
                case 3: Attributes.DefendChance = Utility.RandomMinMax(10, 20); break;
                case 4: Attributes.AttackChance = Utility.RandomMinMax(10, 20); break;
            }
            switch (Utility.Random(6))
            {
                case 0: Attributes.BonusStr = Utility.RandomMinMax(1, 5); break;
                case 1: Attributes.BonusDex = Utility.RandomMinMax(1, 5); break;
                case 2: Attributes.BonusInt = Utility.RandomMinMax(1, 5); break;
                case 3: Attributes.BonusHits = Utility.RandomMinMax(10, 20); break;
                case 4: Attributes.BonusStam = Utility.RandomMinMax(10, 20); break;
                case 5: Attributes.BonusMana = Utility.RandomMinMax(10, 20); break;
            }
                      switch (Utility.Random(8))
                     {
                         case 0: Attributes.WeaponDamage = Utility.RandomMinMax(10, 50); break;
                         case 1: Attributes.WeaponSpeed = Utility.RandomMinMax(10, 20); break;
                         case 2: Attributes.SpellDamage = Utility.RandomMinMax(10, 50); break;
                         case 3: Attributes.CastRecovery = Utility.RandomMinMax(1, 2); break;
                         case 4: Attributes.CastSpeed = Utility.RandomMinMax(1, 2); break;
                     }
               switch ( Utility.Random( 6 )) 
               {
                   case 0: Attributes.LowerManaCost = Utility.RandomMinMax(5, 10); break;
                   case 1: Attributes.LowerRegCost = Utility.RandomMinMax(10, 20); break;
                   case 2: Attributes.ReflectPhysical = Utility.RandomMinMax(5, 20); break;
                   case 3: Attributes.EnhancePotions = Utility.RandomMinMax(10, 20); break;
                   case 4: Attributes.Luck = Utility.RandomMinMax(100, 200); break;
                   case 5: Attributes.NightSight = 1; break;
                }
               switch (Utility.Random(8))
               {
                   case 0: Attributes.WeaponDamage = Utility.RandomMinMax(10, 50); break;
                   case 1: Attributes.WeaponSpeed = Utility.RandomMinMax(10, 20); break;
                   case 2: Attributes.SpellDamage = Utility.RandomMinMax(10, 50); break;
                   case 3: Attributes.CastRecovery = Utility.RandomMinMax(1, 2); break;
                   case 4: Attributes.CastSpeed = Utility.RandomMinMax(1, 2); break;
               }
               //Disadvantages
               // can be brittle 
               switch (Utility.Random(2))
               {
                   case 0: Attributes.Brittle = 1; break;
               }
               // can be cursed 
               switch (Utility.Random(2)) { case 0: LootType = LootType.Cursed; break; }

               // can be unlucky
               switch (Utility.Random(2))
               {
                   case 0: Attributes.Luck = -100; break;
               }
        }
	 	public ArtifactHelm(Serial serial) : base( serial )
	 	{
	 	}
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
