using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Solaris.ItemStore;							//for connection to resource store data objects
using Server.Engines.VeteranRewards;

namespace Server.Items
{
    //item derived from BaseResourceKey
    public class RunicToolKey : BaseStoreKey, IRewardItem
    {
        private bool m_IsRewardItem;

        [CommandProperty(AccessLevel.Seer)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }

        public override int DisplayColumns { get { return 3; } }

        public override List<StoreEntry> EntryStructure
        {
            get
            {
                List<StoreEntry> entry = base.EntryStructure;

                entry.Add(new RunicToolEntry(typeof(RunicHammer),CraftResource.DullCopper,"Dull Copper",0,30,-5,0));
                entry.Add(new RunicToolEntry(typeof(RunicHammer),CraftResource.ShadowIron,"Shadow Iron",0,30,-5,0));
                entry.Add(new RunicToolEntry(typeof(RunicHammer),CraftResource.Copper,"Copper",0,30,-5,0));
                entry.Add(new RunicToolEntry(typeof(RunicHammer),CraftResource.Bronze,"Bronze",0,30,-5,0));
                entry.Add(new RunicToolEntry(typeof(RunicHammer),CraftResource.Gold,"Gold",0,30,-5,0));
                entry.Add(new RunicToolEntry(typeof(RunicHammer),CraftResource.Agapite,"Agapite",0,30,-5,0));
                entry.Add(new RunicToolEntry(typeof(RunicHammer),CraftResource.Verite,"Verite",0,30,-5,0));
                entry.Add(new RunicToolEntry(typeof(RunicHammer),CraftResource.Valorite,"Valorite",0,30,-5,0));

                entry.Add(new ColumnSeparationEntry());

                entry.Add(new RunicToolEntry(typeof(RunicSewingKit),CraftResource.SpinedLeather,"Spined",0,30,-5,3));
                entry.Add(new RunicToolEntry(typeof(RunicSewingKit),CraftResource.HornedLeather,"Horned",0,30,-5,3));
                entry.Add(new RunicToolEntry(typeof(RunicSewingKit),CraftResource.BarbedLeather,"Barbed",0,30,-5,3));

                return entry;
            }
        }

        [Constructable]
        public RunicToolKey() : base(0x0)       // hue 65
        {
            ItemID = 0x1EBA;            //square toolkit
            Name = "Runic Tool Box";

            //runic tools withdrawn can have no less than 5 charges on them.
            _Store.MinWithdrawAmount = 5;
        }

        //this loads properties specific to the store, like the gump label, and whether it's a dynamic storage device
        protected override ItemStore GenerateItemStore()
        {
            //load the basic store info
            ItemStore store = base.GenerateItemStore();

            //properties of this storage device
            store.Label = "Runic Tool Storage";

            store.Dynamic = false;
            store.OfferDeeds = true;

            return store;
        }

        //serial constructor
        public RunicToolKey(Serial serial) : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (m_IsRewardItem)
                list.Add(1076217); // 1st Year Veteran Reward
        }

        //events

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0);

            writer.Write((bool)m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_IsRewardItem = reader.ReadBool();
        }
    }
}