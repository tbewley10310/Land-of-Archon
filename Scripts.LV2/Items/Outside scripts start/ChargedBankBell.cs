#region About This Script - Do Not Remove This Header
/*
Chargable Bank Bell Edited By (A.A.R) [v2.0 02.23.2009]
 
Brief Description:

There Are Many Versions Of This Bank Bell Hanging Around
The RunUO Forums. This Version Is Seemingly An Original
Idea, But It Is NOT My Own Idea. The Only Addition I Made
Was Adding The Ability For Players To Recharge The Already 
Charged Up Bank Bell Using Translocation Powder. The Code 
For This Script Was A Collaborated Effort By A Few People.
 
Acknowledgements:

A Special Thanks To The Following People Who Have Helped
Me Make These Scripts Possible! Without Them, This System
Would Not Have Been As Cool As It Is. Thank You Guys!

Morxeton (For My C# Inspiration), and JamzeMcC!
*/
#endregion About This Script - Do Not Remove This Header

using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.ContextMenus;
using Server.Network;
using Server.Regions;
using Server.Spells;
using Server.Spells.Ninjitsu;

namespace Server.Items
{
    public class ChargableBankBell : Item, TranslocationItem
    {

     #region Declares Charge/Recharge To Work Within This Script

        private int m_Charges;
        private int m_Recharges;

     #endregion Declares Charge/Recharge To Work Within This Script

     #region Defines How Charge/Recharge Works For The Bank Bell

        [CommandProperty(AccessLevel.GameMaster)]
        public int Charges
        {
            get { return m_Charges; }
            set
            {
                if (value > this.MaxCharges)
                    m_Charges = this.MaxCharges;
                else if (value < 0)
                    m_Charges = 0;
                else
                    m_Charges = value;

                InvalidateProperties();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Recharges
        {
            get { return m_Recharges; }
            set
            {
                if (value > this.MaxRecharges)
                    m_Recharges = this.MaxRecharges;
                else if (value < 0)
                    m_Recharges = 0;
                else
                    m_Recharges = value;

                InvalidateProperties();
            }
        }

     #endregion Defines How Charge/Recharge Works For The Bank Bell

     #region Defines Maxium Charges/Recharges For This Bank Bell

        [CommandProperty(AccessLevel.GameMaster)]
        public int MaxCharges { get { return 10; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MaxRecharges { get { return 255; } }

      #endregion Defines Maxium Charges/Recharges For This Bank Bell

        public string TranslocationItemName { get { return "Bank Access Bell"; } }

        [Constructable]
        public ChargableBankBell(): base(0x1C12)
        {
            Name = "Bank Bell";
            Hue = Utility.RandomList(1194, 1153, 1176, 1157, 1161, 1174, 1173);
            Weight = 3;

            LootType = LootType.Cursed;

     #region Declares Initial The Charges Will The Item Will Have

            m_Charges = 10;

     #endregion Declares Initial The Charges Will The Item Will Have

        }

     #region Puts The Object Property List 'Charges: {0}' On Item

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (m_Charges > 0)
                list.Add("Charges: {0}", m_Charges.ToString());
            else
                list.Add("No Charges");
        }

     #endregion Puts The Object Property List 'Charges: {0}' On Item

        public override void OnDoubleClick(Mobile from)
        {
            PlayerMobile pm = from as PlayerMobile;

            if (!IsChildOf(from.Backpack))
            {
                from.SendMessage("This item must be in your pack before you are able to use it");
            }
            else
            {

     #region If Charge Is Less Than OR Equal To '0' Box Wont Open

                if (Charges <= 0)
                {
                    from.SendMessage("You need to recharge this before you are able to use it again!");
                }

     #endregion If Charge Is Less Than OR Equal To '0' Box Wont Open

                else
                {
                    BankBox box = from.BankBox;
                    if (box != null)
                        box.Open();

     #region This Decreases The Number Of Charges After Using Item

                    Charges--;

     #endregion This Decreases The Number Of Charges After Using Item

                }
            }
        }
                               
        public ChargableBankBell(Serial serial): base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1); // version

     #region Remember To Serialize/Deserialize The Charge/Recharge

            writer.WriteEncodedInt((int)m_Recharges);
            writer.WriteEncodedInt((int)m_Charges);       

     #endregion Remember To Serialize/Deserialize The Charge/Recharge

        }
     
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

     #region Remember To Serialize/Deserialize The Charge/Recharge

            switch (version)
            {
                case 1:
                    {
                        m_Recharges = reader.ReadEncodedInt();
                        goto case 0;
                    }
                case 0:
                    {
                        m_Charges = Math.Min(reader.ReadEncodedInt(), MaxCharges);
                        break;
                    }

     #endregion Remember To Serialize/Deserialize The Charge/Recharge

            }
        }
    }
}