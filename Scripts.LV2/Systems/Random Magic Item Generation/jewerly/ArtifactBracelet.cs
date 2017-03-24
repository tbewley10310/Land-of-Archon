// Scripted by Thor86

using System;
using Server;

namespace Server.Items
{
    public class ArtifactBracelet : GoldBracelet, ITokunoDyable
	{
      //  public override bool AllowMaleWearer { get { return true; } }
		//public override int ArtifactRarity{ get{ return 6; } }
        public override int ArtifactRarity { get { return Utility.RandomMinMax(1, 10); } }
    /*
        public override int BasePhysicalResistance { get { return 0; } }
        public override int BaseFireResistance { get { return 0; } }
        public override int BaseColdResistance { get { return 0; } }
        public override int BasePoisonResistance { get { return 0; } }
        public override int BaseEnergyResistance { get { return 0; } }
        */
	 	public override int InitMinHits{ get{ return 255; } }
	 	public override int InitMaxHits{ get{ return 255; } }

        private static string[] m_Names = new string[]
		{

               // names based off past expanions
			"Bracelet from the Order armory",
	    	"Bracelet from the Chaos armory",
            "Bracelet crafted during the The Second Age",
            "Bracelet crafted during the Renaissance ",
            "Bracelet crafted during the Third Dawn",
	    	"Bracelet crafted during the Age of Shadows",

              // names based on past npc's
            "Bracelet crafted by Lord British",
            "Bracelet crafted by Lord Blackthorn",
            "Bracelet crafted by Lady Dawn",// She was a great warrior and great follower of Virtue, and her career eventually led to her being crowned Queen,
            "Bracelet crafted by Sir Dupre",//Dupre is usually portrayed in official fiction as leading the True Britannians Faction in Felucca,
            "Bracelet crafted by Minax",//Minax is an important NPC villain in the history of Ultima. Also called the Dark Mistress, Minax first appeared in the single player game, Ultima II: Revenge of the Enchantress,
            "Bracelet crafted by Mondain",//Mondain was an evil sorcerer who heralded the First Age of Darkness in Sosaria. 
            "Bracelet crafted by The Avatar", // Avatar from the single player games
            "Bracelet crafted by Exodus",//Exodus was the prodigy of Mondain and Minax,
            "Bracelet crafted by King Casca", // Yew prosecutor turned King before killed by dawn on easports


              // names based on monsters
           "Bracelet crafted by a Goblin",
           "Bracelet crafted by a Meer",
           "Bracelet crafted by a Troll",
           "Bracelet crafted by a Ogre",
           "Bracelet crafted by a Daemon",
           "Bracelet crafted by a Orc",
           "Bracelet crafted by a Juka",
           "Bracelet crafted by a Liche",
           "Bracelet crafted by a Lizardman",
           "Bracelet crafted by a Ophidian",
           "Bracelet crafted by a Ratman",
           "Bracelet crafted by a Terathan",

                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
           "Bracelet from the Ancient Samurai Empire"

		};

        [Constructable]
        public ArtifactBracelet()
        {
            Name = m_Names[Utility.Random(m_Names.Length)];
            Hue = Utility.RandomMinMax(5, 3000);
            // Name = "Artifact Bracelet";

            // random chance to get diffent resist %
            Resistances.Physical = Utility.RandomMinMax(0, 5);
            Resistances.Fire = Utility.RandomMinMax(0, 5);
            Resistances.Cold = Utility.RandomMinMax(0, 5);
            Resistances.Poison = Utility.RandomMinMax(0, 5);
            Resistances.Energy = Utility.RandomMinMax(0, 5);
          
            // id it shows item as
            switch (Utility.Random(2))
            {
                case 0: ItemID = 4230; break;//gold
                case 1: ItemID = 7942; break;// silver
            }
            // random chance to get these stats added to item ,chance of one stat per switch
            switch (Utility.Random(20))
            {
                case 0: Attributes.RegenHits = Utility.RandomMinMax(1, 4); break;
                case 1: Attributes.RegenStam = Utility.RandomMinMax(1, 4); break;
                case 2: Attributes.RegenStam = Utility.RandomMinMax(1, 4); break;
                case 3: Attributes.DefendChance = Utility.RandomMinMax(10, 20); break;
                case 4: Attributes.AttackChance = Utility.RandomMinMax(10, 20); break;
            }
            switch (Utility.Random(20))
            {
                case 0: Attributes.BonusStr = Utility.RandomMinMax(1, 5); break;
                case 1: Attributes.BonusDex = Utility.RandomMinMax(1, 5); break;
                case 2: Attributes.BonusInt = Utility.RandomMinMax(1, 5); break;
                case 3: Attributes.BonusHits = Utility.RandomMinMax(10, 20); break;
                case 4: Attributes.BonusStam = Utility.RandomMinMax(10, 20); break;
                case 5: Attributes.BonusMana = Utility.RandomMinMax(10, 20); break;
            }
            switch (Utility.Random(20))
            {
                case 0: Attributes.WeaponDamage = Utility.RandomMinMax(10, 25); break;
                case 1: Attributes.WeaponSpeed = Utility.RandomMinMax(10, 20); break;
                case 2: Attributes.SpellDamage = Utility.RandomMinMax(10, 50); break;
                case 3: Attributes.CastRecovery = Utility.RandomMinMax(1, 2); break;
                case 4: Attributes.CastSpeed = Utility.RandomMinMax(1, 2); break;
            }
            switch (Utility.Random(20))
            {
                case 0: Attributes.LowerManaCost = Utility.RandomMinMax(5, 10); break;
                case 1: Attributes.LowerRegCost = Utility.RandomMinMax(10, 20); break;
                case 2: Attributes.ReflectPhysical = Utility.RandomMinMax(5, 20); break;
                case 3: Attributes.EnhancePotions = Utility.RandomMinMax(10, 20); break;
                case 4: Attributes.Luck = Utility.RandomMinMax(100, 200); break;
                case 5: Attributes.NightSight = 1; break;
            //    case 6: Attributes.SpellChanneling = 1; break;
            }
            switch (Utility.Random(20))
            {
                case 0: Attributes.WeaponDamage = Utility.RandomMinMax(10, 25); break;
                case 1: Attributes.WeaponSpeed = Utility.RandomMinMax(10, 20); break;
                case 2: Attributes.SpellDamage = Utility.RandomMinMax(5, 25); break;
                case 3: Attributes.CastRecovery = Utility.RandomMinMax(1, 2); break;
                case 4: Attributes.CastSpeed = Utility.RandomMinMax(1, 2); break;
            }


            // this will add 1 of these to every shoe sandal or boot
            switch (Utility.Random(21))
            {
                case 0: Attributes.WeaponDamage = Utility.RandomMinMax(10, 25); break;
                case 1: Attributes.WeaponSpeed = Utility.RandomMinMax(10, 20); break;
                case 2: Attributes.SpellDamage = Utility.RandomMinMax(5, 25); break;
                case 3: Attributes.CastRecovery = Utility.RandomMinMax(1, 2); break;
                case 4: Attributes.CastSpeed = Utility.RandomMinMax(1, 2); break;
                case 5: Attributes.LowerManaCost = Utility.RandomMinMax(5, 10); break;
                case 6: Attributes.LowerRegCost = Utility.RandomMinMax(10, 20); break;
                case 7: Attributes.ReflectPhysical = Utility.RandomMinMax(5, 20); break;
                case 8: Attributes.EnhancePotions = Utility.RandomMinMax(10, 20); break;
                case 9: Attributes.Luck = Utility.RandomMinMax(100, 200); break;
                case 10: Attributes.BonusStr = Utility.RandomMinMax(1, 5); break;
                case 11: Attributes.BonusDex = Utility.RandomMinMax(1, 5); break;
                case 12: Attributes.BonusInt = Utility.RandomMinMax(1, 5); break;
                case 13: Attributes.BonusHits = Utility.RandomMinMax(10, 20); break;
                case 14: Attributes.BonusStam = Utility.RandomMinMax(10, 20); break;
                case 15: Attributes.BonusMana = Utility.RandomMinMax(10, 20); break;
                case 16: Attributes.RegenHits = Utility.RandomMinMax(1, 4); break;
                case 17: Attributes.RegenStam = Utility.RandomMinMax(1, 4); break;
                case 18: Attributes.RegenStam = Utility.RandomMinMax(1, 4); break;
                case 19: Attributes.DefendChance = Utility.RandomMinMax(10, 20); break;
                case 20: Attributes.AttackChance = Utility.RandomMinMax(10, 20); break;
            }
// random skill bonus
                      switch ( Utility.Random( 54 ))
            {
            case 0: SkillBonuses.SetValues( 0, SkillName.Alchemy, 5.0 ); break;
            case 1: SkillBonuses.SetValues( 0, SkillName.Anatomy, 5.0 ); break;
            case 2: SkillBonuses.SetValues( 0, SkillName.AnimalLore, 5.0 ); break;
            case 3: SkillBonuses.SetValues( 0, SkillName.ItemID, 5.0 ); break;
            case 4: SkillBonuses.SetValues( 0, SkillName.ArmsLore, 5.0 ); break;
            case 5: SkillBonuses.SetValues( 0, SkillName.Parry, 5.0 ); break;
            case 6: SkillBonuses.SetValues( 0, SkillName.Begging, 5.0 ); break;
            case 7: SkillBonuses.SetValues( 0, SkillName.Blacksmith, 5.0 ); break;
            case 8: SkillBonuses.SetValues( 0, SkillName.Fletching, 5.0 ); break;
            case 9: SkillBonuses.SetValues( 0, SkillName.Peacemaking, 5.0 ); break;
            case 10: SkillBonuses.SetValues( 0, SkillName.Camping, 5.0 ); break;
            case 11: SkillBonuses.SetValues( 0, SkillName.Carpentry, 5.0 ); break;
            case 12: SkillBonuses.SetValues( 0, SkillName.Cartography, 5.0 ); break;
            case 13: SkillBonuses.SetValues( 0, SkillName.Cooking, 5.0 ); break;
            case 14: SkillBonuses.SetValues( 0, SkillName.DetectHidden, 5.0 ); break;
            case 15: SkillBonuses.SetValues( 0, SkillName.Discordance, 5.0 ); break;
            case 16: SkillBonuses.SetValues( 0, SkillName.EvalInt, 5.0 ); break;
            case 17: SkillBonuses.SetValues( 0, SkillName.Healing, 5.0 ); break;
            case 18: SkillBonuses.SetValues( 0, SkillName.Fishing, 5.0 ); break;
            case 19: SkillBonuses.SetValues( 0, SkillName.Forensics, 5.0 ); break;
            case 20: SkillBonuses.SetValues(0, SkillName.Herding, 5.0); break;// lol has anyone ever used this skill before 
            case 21: SkillBonuses.SetValues( 0, SkillName.Hiding, 5.0 ); break;
            case 22: SkillBonuses.SetValues( 0, SkillName.Provocation, 5.0 ); break;
            case 23: SkillBonuses.SetValues( 0, SkillName.Inscribe, 5.0 ); break;
            case 24: SkillBonuses.SetValues( 0, SkillName.Lockpicking, 5.0 ); break;
            case 25: SkillBonuses.SetValues( 0, SkillName.Magery, 5.0 ); break;
            case 26: SkillBonuses.SetValues( 0, SkillName.MagicResist, 5.0 ); break;
            case 27: SkillBonuses.SetValues( 0, SkillName.Tactics, 5.0 ); break;
            case 28: SkillBonuses.SetValues( 0, SkillName.Snooping, 5.0 ); break;
            case 29: SkillBonuses.SetValues( 0, SkillName.Musicianship, 5.0 ); break;
            case 30: SkillBonuses.SetValues( 0, SkillName.Poisoning, 5.0 ); break;
            case 31: SkillBonuses.SetValues( 0, SkillName.Archery, 5.0 ); break;
            case 32: SkillBonuses.SetValues( 0, SkillName.SpiritSpeak, 5.0 ); break;
            case 33: SkillBonuses.SetValues( 0, SkillName.Stealing, 5.0 ); break;
            case 34: SkillBonuses.SetValues( 0, SkillName.Tailoring, 5.0 ); break;
            case 35: SkillBonuses.SetValues( 0, SkillName.AnimalTaming, 5.0 ); break;
            case 36: SkillBonuses.SetValues(0, SkillName.TasteID, 5.0); break;
            case 37: SkillBonuses.SetValues( 0, SkillName.Tinkering, 5.0 ); break;
            case 38: SkillBonuses.SetValues( 0, SkillName.Tracking, 5.0 ); break;
            case 39: SkillBonuses.SetValues( 0, SkillName.Veterinary, 5.0 ); break;
            case 40: SkillBonuses.SetValues( 0, SkillName.Swords, 5.0 ); break;
            case 41: SkillBonuses.SetValues( 0, SkillName.Macing, 5.0 ); break;
            case 42: SkillBonuses.SetValues( 0, SkillName.Fencing, 5.0 ); break;
            case 43: SkillBonuses.SetValues( 0, SkillName.Wrestling, 5.0 ); break;
            case 44: SkillBonuses.SetValues( 0, SkillName.Lumberjacking, 5.0 ); break;
            case 45: SkillBonuses.SetValues( 0, SkillName.Mining, 5.0 ); break;
            case 46: SkillBonuses.SetValues( 0, SkillName.Meditation, 5.0 ); break;
            case 47: SkillBonuses.SetValues( 0, SkillName.Stealth, 5.0 ); break;
            case 48: SkillBonuses.SetValues( 0, SkillName.RemoveTrap, 5.0 ); break;
            case 49: SkillBonuses.SetValues( 0, SkillName.Necromancy, 5.0 ); break;
            case 50: SkillBonuses.SetValues( 0, SkillName.Focus, 5.0 ); break;
            case 51: SkillBonuses.SetValues( 0, SkillName.Chivalry, 5.0 ); break;
            case 52: SkillBonuses.SetValues( 0, SkillName.Bushido, 5.0 ); break;
            case 53: SkillBonuses.SetValues( 0, SkillName.Ninjitsu, 5.0 ); break;
        }
// END random skill bonus
     //Disadvantages
                      // LRC BONUS
                      switch (Utility.Random(2))
                      {
                          case 0: Attributes.LowerRegCost = Utility.RandomMinMax(10, 25); break;
                      }
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

	 	public ArtifactBracelet(Serial serial) : base( serial )
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

