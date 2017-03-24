//Created by Dudus
using System;
using Server;
using Server.Items;


namespace Server.Items
{
              public class StolenNecklace: GoldNecklace
{
              
              [Constructable]
              public StolenNecklace()
{

                          Weight = 3;
                          Name = "Stolen Necklace";
                          Hue = 1161;
              
              Attributes.AttackChance = 25;
              Attributes.BonusDex = 20;
              Attributes.BonusInt = 20;
              Attributes.CastRecovery = 4;
              Attributes.CastSpeed = 4;
	      Attributes.BonusHits = 10;
              Attributes.BonusMana = 10;
	      Attributes.BonusStam = 10;	
              Attributes.DefendChance = 25;
              Attributes.SpellDamage = 15;
              Attributes.BonusStr = 25;
                  }
              public StolenNecklace( Serial serial ) : base( serial )
                      {
                      }
              
              public override void Serialize( GenericWriter writer )
                      {
                          base.Serialize( writer );
                          writer.Write( (int) 0 );
                      }
              
              public override void Deserialize(GenericReader reader)
                      {
                          base.Deserialize( reader );
                          int version = reader.ReadInt();
                      }
                  }
              }
