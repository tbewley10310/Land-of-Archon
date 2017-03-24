using System;
using Server.Items;
using Server;

namespace Server.Engines.BulkOrders
{
    public enum BulkMaterialType
    {
        None,
        DullCopper,
        ShadowIron,
        Copper,
        Bronze,
        Gold,
        Agapite,
        Verite,
        Valorite,
        Blaze,
        Ice,
        Toxic,
        Electrum,
        Platinum,
        Spined,
        Horned,
        Barbed,
        Polar,
        Synthetic,
        BlazeL,
        Daemonic,
        Shadow,
        Frost,
        Ethereal,
        OakWood,
        AshWood,
        YewWood,
        Heartwood,
        Bloodwood,
        Frostwood,
        Ebony,
        Bamboo,
        PurpleHeart,
        Redwood,
        Petrified
        //daat99 OWLTR end - custom resources
    }

    public enum BulkGenericType
    {
        Iron,
        Cloth,
        Leather,
        RegularWood
    }

    public class BGTClassifier
    {
        public static BulkGenericType Classify(BODType deedType, Type itemType)
        {
            if (deedType == BODType.Tailor)
            {
                if (itemType == null || itemType.IsSubclassOf(typeof(BaseArmor)) || itemType.IsSubclassOf(typeof(BaseShoes)))
                    return BulkGenericType.Leather;

                return BulkGenericType.Cloth;
            }
            else if (deedType == BODType.Fletcher)
            {
                if (itemType == null || itemType.IsSubclassOf(typeof(BaseRanged)))
                    return BulkGenericType.RegularWood;

                return BulkGenericType.RegularWood;
            }
            else if (deedType == BODType.Carpenter)
            {
                if (itemType == null || itemType.IsSubclassOf(typeof(BaseStaff)) || itemType.IsSubclassOf(typeof(BaseShield)))
                    return BulkGenericType.RegularWood;

                return BulkGenericType.RegularWood;
            }
            return BulkGenericType.Iron;
        }
    }
}