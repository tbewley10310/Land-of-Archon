using System;
using System.Collections.Generic;
using Server.Engines.Craft;

namespace Server.Engines.BulkOrders
{
    [TypeAlias("Scripts.Engines.BulkOrders.SmallSmithBOD")]
    public class SmallSmithBOD : SmallBOD
    {
        public static double[] m_BlacksmithMaterialChances = new double[]
        {
				//daat99 OWLTR start - custom resources
				0.120, // None
				0.100, // Dull Copper
				0.090, // Shadow Iron
				0.090, // Copper
				0.080, // Bronze
				0.080, // Gold
				0.070, // Agapite
				0.070, // Verite
				0.060, // Valorite
				0.060, // Blaze
				0.050, // Ice
				0.050, // Toxic
				0.040, // Electrum
				0.040  // Platinum
				//daat99 OWLTR end - custom resources
        };
        [Constructable]
        public SmallSmithBOD()
        {
            SmallBulkEntry[] entries;
            bool useMaterials;

            if (useMaterials = Utility.RandomBool())
                entries = SmallBulkEntry.BlacksmithArmor;
            else
                entries = SmallBulkEntry.BlacksmithWeapons;

            if (entries.Length > 0)
            {
                int hue = 0x44E;
                int amountMax = Utility.RandomList(10, 15, 20);

                BulkMaterialType material;

                if (useMaterials)
                    material = GetRandomMaterial(BulkMaterialType.DullCopper, m_BlacksmithMaterialChances);
                else
                    material = BulkMaterialType.None;

                bool reqExceptional = Utility.RandomBool() || (material == BulkMaterialType.None);

                SmallBulkEntry entry = entries[Utility.Random(entries.Length)];

                this.Hue = hue;
                this.AmountMax = amountMax;
                this.Type = entry.Type;
                this.Number = entry.Number;
                this.Graphic = entry.Graphic;
                this.RequireExceptional = reqExceptional;
                this.Material = material;
            }
        }

        public SmallSmithBOD(int amountCur, int amountMax, Type type, int number, int graphic, bool reqExceptional, BulkMaterialType mat)
        {
            this.Hue = 0x44E;
            this.AmountMax = amountMax;
            this.AmountCur = amountCur;
            this.Type = type;
            this.Number = number;
            this.Graphic = graphic;
            this.RequireExceptional = reqExceptional;
            this.Material = mat;
        }

        public SmallSmithBOD(Serial serial)
            : base(serial)
        {
        }

        private SmallSmithBOD(SmallBulkEntry entry, BulkMaterialType material, int amountMax, bool reqExceptional)
        {
            this.Hue = 0x44E;
            this.AmountMax = amountMax;
            this.Type = entry.Type;
            this.Number = entry.Number;
            this.Graphic = entry.Graphic;
            this.RequireExceptional = reqExceptional;
            this.Material = material;
        }

        public static SmallSmithBOD CreateRandomFor(Mobile m)
        {
            SmallBulkEntry[] entries;
            bool useMaterials;

            if (useMaterials = Utility.RandomBool())
                entries = SmallBulkEntry.BlacksmithArmor;
            else
                entries = SmallBulkEntry.BlacksmithWeapons;

            if (entries.Length > 0)
            {
                double theirSkill = m.Skills[SkillName.Blacksmith].Base;
                int amountMax;

                if (theirSkill >= 70.1)
                    amountMax = Utility.RandomList(10, 15, 20, 20);
                else if (theirSkill >= 50.1)
                    amountMax = Utility.RandomList(10, 15, 15, 20);
                else
                    amountMax = Utility.RandomList(10, 10, 15, 20);

                BulkMaterialType material = BulkMaterialType.None;

                if (useMaterials && theirSkill >= 70.1)
                {
                    for (int i = 0; i < 20; ++i)
                    {
                        BulkMaterialType check = GetRandomMaterial(BulkMaterialType.DullCopper, m_BlacksmithMaterialChances);
                        double skillReq = 0.0;

                        switch ( check )
                        {
                            //daat99 OWLTR start - custom resources
                            case BulkMaterialType.DullCopper: skillReq = 52.0; break;
                            case BulkMaterialType.ShadowIron: skillReq = 56.0; break;
                            case BulkMaterialType.Copper: skillReq = 60.0; break;
                            case BulkMaterialType.Bronze: skillReq = 64.0; break;
                            case BulkMaterialType.Gold: skillReq = 68.0; break;
                            case BulkMaterialType.Agapite: skillReq = 72.0; break;
                            case BulkMaterialType.Verite: skillReq = 76.0; break;
                            case BulkMaterialType.Valorite: skillReq = 80.0; break;
                            case BulkMaterialType.Blaze: skillReq = 84.0; break;
                            case BulkMaterialType.Ice: skillReq = 88.0; break;
                            case BulkMaterialType.Toxic: skillReq = 92.0; break;
                            case BulkMaterialType.Electrum: skillReq = 96.0; break;
                            case BulkMaterialType.Platinum: skillReq = 100.0; break;
                            case BulkMaterialType.Spined: skillReq = 64.0; break;
                            case BulkMaterialType.Horned: skillReq = 68.0; break;
                            case BulkMaterialType.Barbed: skillReq = 72.0; break;
                            case BulkMaterialType.Polar: skillReq = 76.0; break;
                            case BulkMaterialType.Synthetic: skillReq = 80.0; break;
                            case BulkMaterialType.BlazeL: skillReq = 84.0; break;
                            case BulkMaterialType.Daemonic: skillReq = 88.0; break;
                            case BulkMaterialType.Shadow: skillReq = 92.0; break;
                            case BulkMaterialType.Frost: skillReq = 96.0; break;
                            case BulkMaterialType.Ethereal: skillReq = 100.0; break;
                            case BulkMaterialType.Heartwood: skillReq = 60.0; break;
                            case BulkMaterialType.Bloodwood: skillReq = 64.0; break;
                            case BulkMaterialType.Frostwood: skillReq = 68.0; break;
                            case BulkMaterialType.OakWood: skillReq = 72.0; break;
                            case BulkMaterialType.AshWood: skillReq = 76.0; break;
                            case BulkMaterialType.YewWood: skillReq = 80.0; break;
                            case BulkMaterialType.Ebony: skillReq = 84.0; break;
                            case BulkMaterialType.Bamboo: skillReq = 88.0; break;
                            case BulkMaterialType.PurpleHeart: skillReq = 92.0; break;
                            case BulkMaterialType.Redwood: skillReq = 96.0; break;
                            case BulkMaterialType.Petrified: skillReq = 100.0; break;
                            //daat99 OWLTR end - custom resources
                        }

                        if (theirSkill >= skillReq)
                        {
                            material = check;
                            break;
                        }
                    }
                }

                double excChance = 0.0;

                if (theirSkill >= 70.1)
                    excChance = (theirSkill + 80.0) / 200.0;

                bool reqExceptional = (excChance > Utility.RandomDouble());

                CraftSystem system = DefBlacksmithy.CraftSystem;

                List<SmallBulkEntry> validEntries = new List<SmallBulkEntry>();

                for (int i = 0; i < entries.Length; ++i)
                {
                    CraftItem item = system.CraftItems.SearchFor(entries[i].Type);

                    if (item != null)
                    {
                        bool allRequiredSkills = true;
                        double chance = item.GetSuccessChance(m, null, system, false, ref allRequiredSkills);

                        if (allRequiredSkills && chance >= 0.0)
                        {
                            if (reqExceptional)
                                chance = item.GetExceptionalChance(system, chance, m);

                            if (chance > 0.0)
                                validEntries.Add(entries[i]);
                        }
                    }
                }

                if (validEntries.Count > 0)
                {
                    SmallBulkEntry entry = validEntries[Utility.Random(validEntries.Count)];
                    return new SmallSmithBOD(entry, material, amountMax, reqExceptional);
                }
            }

            return null;
        }

        public override int ComputeFame()
        {
            return SmithRewardCalculator.Instance.ComputeFame(this);
        }

        public override int ComputeGold()
        {
            return SmithRewardCalculator.Instance.ComputeGold(this);
        }

        public override List<Item> ComputeRewards(bool full)
        {
            List<Item> list = new List<Item>();

            RewardGroup rewardGroup = SmithRewardCalculator.Instance.LookupRewards(SmithRewardCalculator.Instance.ComputePoints(this));

            if (rewardGroup != null)
            {
                if (full)
                {
                    for (int i = 0; i < rewardGroup.Items.Length; ++i)
                    {
                        Item item = rewardGroup.Items[i].Construct();

                        if (item != null)
                            list.Add(item);
                    }
                }
                else
                {
                    RewardItem rewardItem = rewardGroup.AcquireItem();

                    if (rewardItem != null)
                    {
                        Item item = rewardItem.Construct();

                        if (item != null)
                            list.Add(item);
                    }
                }
            }

            return list;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}