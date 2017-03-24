// Scripted by Thor86

using System;
using Server;

namespace Server.Items
{
    public class ArtifactWeapon2H : DoubleAxe, ITokunoDyable
	{
        //public override int ArtifactRarity{ get{ return 6; } }
        public override int ArtifactRarity { get { return Utility.RandomMinMax(1, 10); } }

	 	public override int InitMinHits{ get{ return 255; } }
	 	public override int InitMaxHits{ get{ return 255; } }

        private static string[] m_Names = new string[]
		{
                  // names based off past expanions
			"Weapon from the Order armory",
	    	"Weapon from the Chaos armory",
            "Weapon crafted during the The Second Age",
            "Weapon crafted during the Renaissance ",
            "Weapon crafted during the Third Dawn",
	    	"Weapon crafted during the Age of Shadows",

                // names based off past npc's
            "Weapon crafted by Lord British",
            "Weapon crafted by Lord Blackthorn",
            "Weapon crafted by Lady Dawn",// She was a great warrior and great follower of Virtue, and her career eventually led to her being crowned Queen,
            "Weapon crafted by Sir Dupre",//Dupre is usually portrayed in official fiction as leading the True Britannians Faction in Felucca,
            "Weapon crafted by Minax",//Minax is an important NPC villain in the history of Ultima. Also called the Dark Mistress, Minax first appeared in the single player game, Ultima II: Revenge of the Enchantress,
            "Weapon crafted by Mondain",//Mondain was an evil sorcerer who heralded the First Age of Darkness in Sosaria. 
            "Weapon crafted by The Avatar", // Avatar from the single player games
            "Weapon crafted by Exodus",//Exodus was the prodigy of Mondain and Minax,
            "Weapon crafted by King Casca", // Yew prosecutor turned King before killed by dawn on easports shards

             // names based on monsters
           "Weapon crafted by a Goblin",
           "Weapon crafted by a Meer",
           "Weapon crafted by a Troll",
           "Weapon crafted by a Ogre",
           "Weapon crafted by a Daemon",
           "Weapon crafted by a Orc",
           "Weapon crafted by a Juka",
           "Weapon crafted by a Liche",
           "Weapon crafted by a Lizardman",
           "Weapon crafted by a Ophidian",
           "Weapon crafted by a Ratman",
           "Weapon crafted by a Terathan",

                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
                        //"add ur extra names here",
           "Weapon from the Ancient Samurai Empire"

		};

        [Constructable]
        public ArtifactWeapon2H()
        {
            Name = m_Names[Utility.Random(m_Names.Length)];
            Hue = Utility.RandomMinMax(5, 3000);
            // Name = "Artifact Two Handed Weapon";
            WeaponAttributes.UseBestSkill = 1;
            Attributes.WeaponDamage = Utility.RandomMinMax(25, 35);
         
     

            // id it shows item as
            switch (Utility.Random(10))
            {
                case 0: ItemID = 3907; break;//battleaxe 2hander
                case 1: ItemID = 3913; break;//axe 2 hander
                case 2: ItemID = 3915; break;//doubleaxe 2 hander
                case 3: ItemID = 5187; break;//twohandedaxe  2hander
                case 4: ItemID = 5177; break;//warhammer 2hander
                case 5: ItemID = 10147; break;//tessen 2hander
                case 6: ItemID = 5123; break;//shortspear 2hander
                case 7: ItemID = 5182; break;//halberd
                case 8: ItemID = 3909; break;//executionersaxe
                case 9: ItemID = 3938; break;//spear

              
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
            //    case 6: Attributes.SpellChanneling = 1; break;
            }
            switch (Utility.Random(10))
            {
                case 0: Attributes.WeaponDamage = Utility.RandomMinMax(10, 50); break;
                case 1: Attributes.WeaponSpeed = Utility.RandomMinMax(10, 20); break;
                case 2: Attributes.SpellDamage = Utility.RandomMinMax(5, 25); break;
                case 3: Attributes.CastRecovery = Utility.RandomMinMax(1, 2); break;
                case 4: Attributes.CastSpeed = Utility.RandomMinMax(1, 2); break;
            }

            switch (Utility.Random(25))
            {

                case 0: WeaponAttributes.SelfRepair = Utility.RandomMinMax(1, 3); break;
                case 1: WeaponAttributes.HitLeechHits = Utility.RandomMinMax(5, 25); break;
                case 2: WeaponAttributes.HitLeechStam = Utility.RandomMinMax(5, 25); break;
                case 3: WeaponAttributes.HitLeechMana = Utility.RandomMinMax(5, 25); break;
                case 4: WeaponAttributes.HitLowerAttack = Utility.RandomMinMax(5, 25); break;
                case 5: WeaponAttributes.HitLowerDefend = Utility.RandomMinMax(5, 25); break;
                case 6: WeaponAttributes.HitMagicArrow = Utility.RandomMinMax(5, 25); break;
                case 7: WeaponAttributes.HitHarm = Utility.RandomMinMax(5, 25); break;
                case 8: WeaponAttributes.HitFireball = Utility.RandomMinMax(5, 25); break;
                case 9: WeaponAttributes.HitLightning = Utility.RandomMinMax(5, 25); break;
                case 10: WeaponAttributes.HitDispel = Utility.RandomMinMax(5, 25); break;
                case 11: WeaponAttributes.HitColdArea = Utility.RandomMinMax(5, 25); break;
                case 12: WeaponAttributes.HitFireArea = Utility.RandomMinMax(5, 25); break;
                case 13: WeaponAttributes.HitPoisonArea = Utility.RandomMinMax(5, 25); break;
                case 14: WeaponAttributes.HitEnergyArea = Utility.RandomMinMax(5, 25); break;
                case 15: WeaponAttributes.HitPhysicalArea = Utility.RandomMinMax(5, 25); break;
                case 16: WeaponAttributes.HitFatigue = Utility.RandomMinMax(5, 25); break;
                case 17: WeaponAttributes.MageWeapon = 1; break;
                case 18: WeaponAttributes.DurabilityBonus = Utility.RandomMinMax(5, 25); break;
                case 19: WeaponAttributes.BloodDrinker = Utility.RandomMinMax(5, 25); break;
                case 20: WeaponAttributes.HitCurse = Utility.RandomMinMax(5, 25); break;
        
              //  case 22: WeaponAttributes.ManaDrain = Utility.RandomMinMax(5, 25); break;
                //case 23: WeaponAttributes.ResistPhysicalBonus = Utility.RandomMinMax(1, 3); break;
                //case 24: WeaponAttributes.ResistFireBonus = Utility.RandomMinMax(1, 3); break;
                //case 25: WeaponAttributes.ResistColdBonus = Utility.RandomMinMax(1, 3); break;
                //case 26: WeaponAttributes.ResistPoisonBonus = Utility.RandomMinMax(1, 3); break;
                //case 27: WeaponAttributes.ResistEnergyBonus = Utility.RandomMinMax(1, 3); break;
            }
            switch (Utility.Random(25))
            {

                case 0: WeaponAttributes.SelfRepair = Utility.RandomMinMax(1, 3); break;
                case 1: WeaponAttributes.HitLeechHits = Utility.RandomMinMax(5, 25); break;
                case 2: WeaponAttributes.HitLeechStam = Utility.RandomMinMax(5, 25); break;
                case 3: WeaponAttributes.HitLeechMana = Utility.RandomMinMax(5, 25); break;
                case 4: WeaponAttributes.HitLowerAttack = Utility.RandomMinMax(5, 25); break;
                case 5: WeaponAttributes.HitLowerDefend = Utility.RandomMinMax(5, 25); break;
                case 6: WeaponAttributes.HitMagicArrow = Utility.RandomMinMax(5, 25); break;
                case 7: WeaponAttributes.HitHarm = Utility.RandomMinMax(5, 25); break;
                case 8: WeaponAttributes.HitFireball = Utility.RandomMinMax(5, 25); break;
                case 9: WeaponAttributes.HitLightning = Utility.RandomMinMax(5, 25); break;
                case 10: WeaponAttributes.HitDispel = Utility.RandomMinMax(5, 25); break;
                case 11: WeaponAttributes.HitColdArea = Utility.RandomMinMax(5, 25); break;
                case 12: WeaponAttributes.HitFireArea = Utility.RandomMinMax(5, 25); break;
                case 13: WeaponAttributes.HitPoisonArea = Utility.RandomMinMax(5, 25); break;
                case 14: WeaponAttributes.HitEnergyArea = Utility.RandomMinMax(5, 25); break;
                case 15: WeaponAttributes.HitPhysicalArea = Utility.RandomMinMax(5, 25); break;
                case 16: WeaponAttributes.HitFatigue = Utility.RandomMinMax(5, 25); break;
                case 17: WeaponAttributes.MageWeapon = 1; break;
                case 18: WeaponAttributes.DurabilityBonus = Utility.RandomMinMax(5, 25); break;
                case 19: WeaponAttributes.BloodDrinker = Utility.RandomMinMax(5, 25); break;
                case 20: WeaponAttributes.HitCurse = Utility.RandomMinMax(5, 25); break;
            
              //  case 22: WeaponAttributes.ManaDrain = Utility.RandomMinMax(5, 25); break;
                //case 23: WeaponAttributes.ResistPhysicalBonus = Utility.RandomMinMax(1, 3); break;
                //case 24: WeaponAttributes.ResistFireBonus = Utility.RandomMinMax(1, 3); break;
                //case 25: WeaponAttributes.ResistColdBonus = Utility.RandomMinMax(1, 3); break;
                //case 26: WeaponAttributes.ResistPoisonBonus = Utility.RandomMinMax(1, 3); break;
                //case 27: WeaponAttributes.ResistEnergyBonus = Utility.RandomMinMax(1, 3); break;
            }
            switch (Utility.Random(70))
            {
                case 0: Slayer = SlayerName.Silver; break;
                case 1: Slayer = SlayerName.OrcSlaying; break;
                case 2: Slayer = SlayerName.TrollSlaughter; break;
                case 3: Slayer = SlayerName.OgreTrashing; break;
                case 4: Slayer = SlayerName.Repond; break;
                case 5: Slayer = SlayerName.DragonSlaying; break;
                case 6: Slayer = SlayerName.Terathan; break;
                case 7: Slayer = SlayerName.SnakesBane; break;
                case 8: Slayer = SlayerName.LizardmanSlaughter; break;
                case 9: Slayer = SlayerName.ReptilianDeath; break;
                case 10: Slayer = SlayerName.DaemonDismissal; break;// <-- not sure if this even works anymore
                case 11: Slayer = SlayerName.GargoylesFoe; break;
                case 12: Slayer = SlayerName.BalronDamnation; break;
                case 13: Slayer = SlayerName.Exorcism; break;
                case 14: Slayer = SlayerName.Ophidian; break;
                case 15: Slayer = SlayerName.SpidersDeath; break;
                case 16: Slayer = SlayerName.ScorpionsBane; break;
                case 17: Slayer = SlayerName.ArachnidDoom; break;
                case 18: Slayer = SlayerName.FlameDousing; break;
                case 19: Slayer = SlayerName.WaterDissipation; break;
                case 20: Slayer = SlayerName.Vacuum; break;
                case 21: Slayer = SlayerName.ElementalHealth; break;
                case 22: Slayer = SlayerName.EarthShatter; break;
                case 23: Slayer = SlayerName.BloodDrinking; break;
                case 24: Slayer = SlayerName.SummerWind; break;
                case 25: Slayer = SlayerName.ElementalBan; break;
                case 26: Slayer = SlayerName.Fey; break;
            }

 // chance of being spellchanneling 
            switch (Utility.Random(4))
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
            public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
		{
			phys = 20;
			fire = 20;
			cold = 20;
			pois = 20;
			nrgy = 20;
            chaos = 0;
            direct = 0;
		}

	 	public ArtifactWeapon2H(Serial serial) : base( serial )
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
