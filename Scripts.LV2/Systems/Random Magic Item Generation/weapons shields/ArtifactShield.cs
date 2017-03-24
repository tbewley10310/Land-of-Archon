// Scripted by Thor86

using System;
using Server;

namespace Server.Items
{
    public class ArtifactShield : HeaterShield, ITokunoDyable
	{
        //public override int ArtifactRarity{ get{ return 6; } }
        public override int ArtifactRarity { get { return Utility.RandomMinMax(1, 10); } }

	 	public override int InitMinHits{ get{ return 255; } }
	 	public override int InitMaxHits{ get{ return 255; } }

        private static string[] m_Names = new string[]
		{

               // names based off past expanions
			"Shield from the Order armory",
	    	"Shield from the Chaos armory",
            "Shield crafted during the The Second Age",
            "Shield crafted during the Renaissance ",
            "Shield crafted during the Third Dawn",
	    	"Shield crafted during the Age of Shadows",

              // names based on past npc's
            "Shield crafted by Lord British",
            "Shield crafted by Lord Blackthorn",
            "Shield crafted by Lady Dawn",// She was a great warrior and great follower of Virtue, and her career eventually led to her being crowned Queen,
            "Shield crafted by Sir Dupre",//Dupre is usually portrayed in official fiction as leading the True Britannians Faction in Felucca,
            "Shield crafted by Minax",//Minax is an important NPC villain in the history of Ultima. Also called the Dark Mistress, Minax first appeared in the single player game, Ultima II: Revenge of the Enchantress,
            "Shield crafted by Mondain",//Mondain was an evil sorcerer who heralded the First Age of Darkness in Sosaria. 
            "Shield crafted by The Avatar", // Avatar from the single player games
            "Shield crafted by Exodus",//Exodus was the prodigy of Mondain and Minax,
            "Shield crafted by King Casca", // Yew prosecutor turned King before killed by dawn on easports


              // names based on monsters
           "Shield crafted by a Goblin",
           "Shield crafted by a Meer",
           "Shield crafted by a Troll",
           "Shield crafted by a Ogre",
           "Shield crafted by a Daemon",
           "Shield crafted by a Orc",
           "Shield crafted by a Juka",
           "Shield crafted by a Liche",
           "Shield crafted by a Lizardman",
           "Shield crafted by a Ophidian",
           "Shield crafted by a Ratman",
           "Shield crafted by a Terathan",

                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
           "Shield from the Ancient Samurai Empire"

		};

        [Constructable]
        public ArtifactShield()
        {
            Name = m_Names[Utility.Random(m_Names.Length)];
            Hue = Utility.RandomMinMax(5, 3000);
            // Name = "Artifact Shield";

            // random chance to get diffent resist %
            PhysicalBonus = Utility.RandomMinMax(0, 5);
            FireBonus = Utility.RandomMinMax(0, 5);
            ColdBonus = Utility.RandomMinMax(0, 5);
            PoisonBonus = Utility.RandomMinMax(0, 5);
            EnergyBonus = Utility.RandomMinMax(0, 5);

            // id it shows item as
            switch (Utility.Random(6))
            {
                case 0: ItemID = 7032; break;//arcaneshield
                case 1: ItemID = 7028; break;//metalshield
                case 2: ItemID = 7026; break;//bronzeshield
                case 3: ItemID = 7107; break;//chaosshield
                case 4: ItemID = 7108; break;//ordershield
                case 5: ItemID = 7030; break;//heatershield
            }
            // random chance to get these stats added to item ,chance of one stat per switch
            switch (Utility.Random(10))
            {
                case 0: Attributes.RegenHits = Utility.RandomMinMax(1, 4); break;
                case 1: Attributes.RegenStam = Utility.RandomMinMax(1, 4); break;
                case 2: Attributes.RegenStam = Utility.RandomMinMax(1, 4); break;
                case 3: Attributes.DefendChance = Utility.RandomMinMax(10, 20); break;
                case 4: Attributes.AttackChance = Utility.RandomMinMax(10, 20); break;
            }
            switch (Utility.Random(10))
            {
                case 0: Attributes.BonusStr = Utility.RandomMinMax(1, 5); break;
                case 1: Attributes.BonusDex = Utility.RandomMinMax(1, 5); break;
                case 2: Attributes.BonusInt = Utility.RandomMinMax(1, 5); break;
                case 3: Attributes.BonusHits = Utility.RandomMinMax(10, 20); break;
                case 4: Attributes.BonusStam = Utility.RandomMinMax(10, 20); break;
                case 5: Attributes.BonusMana = Utility.RandomMinMax(10, 20); break;
            }
            switch (Utility.Random(10))
            {
                case 0: Attributes.WeaponDamage = Utility.RandomMinMax(10, 50); break;
                case 1: Attributes.WeaponSpeed = Utility.RandomMinMax(10, 20); break;
                case 2: Attributes.SpellDamage = Utility.RandomMinMax(10, 50); break;
                case 3: Attributes.CastRecovery = Utility.RandomMinMax(1, 2); break;
                case 4: Attributes.CastSpeed = Utility.RandomMinMax(1, 2); break;
            }
            switch (Utility.Random(10))
            {
                case 0: Attributes.LowerManaCost = Utility.RandomMinMax(5, 10); break;
                case 1: Attributes.LowerRegCost = Utility.RandomMinMax(10, 20); break;
                case 2: Attributes.ReflectPhysical = Utility.RandomMinMax(5, 20); break;
                case 3: Attributes.EnhancePotions = Utility.RandomMinMax(10, 20); break;
                case 4: Attributes.Luck = Utility.RandomMinMax(100, 200); break;
                case 5: Attributes.NightSight = 1; break;
             //   case 6: Attributes.SpellChanneling = 1; break;
            }
            switch (Utility.Random(10))
            {
                case 0: Attributes.WeaponDamage = Utility.RandomMinMax(10, 50); break;
                case 1: Attributes.WeaponSpeed = Utility.RandomMinMax(10, 20); break;
                case 2: Attributes.SpellDamage = Utility.RandomMinMax(5, 25); break;
                case 3: Attributes.CastRecovery = Utility.RandomMinMax(1, 2); break;
                case 4: Attributes.CastSpeed = Utility.RandomMinMax(1, 2); break;
            }
// chance of being spellchanneling 
            switch (Utility.Random(2))
            {
             case 0: Attributes.SpellChanneling = 1; break;
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

	 	public ArtifactShield(Serial serial) : base( serial )
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
