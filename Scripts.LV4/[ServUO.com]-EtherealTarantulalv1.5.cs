
//Lagatha & Neshobas  
//Shazzy and Vorspire Lots of input Thanks :) and a base to go from 
// Thanks ZeroDowned for the  delete on compile fix 
//Thanks HammerHand for new cliloc # 
// **********
//#endregion

#region References
using System;

using Server.Engines.VeteranRewards;
using Server.Items;
using Server.Multis;
using Server.Spells;
#endregion

namespace Server.Mobiles
{

 
public class EtherealTarantula : EtherealMount
 {
 [Constructable]
 public EtherealTarantula ()
 :  base(0x9DD6, 0x3ECA)
 { }
 
 public EtherealTarantula (Serial serial)
 : base(serial)
 { }
 
 public override int LabelNumber { get { return 1157081; } } // Ethereal Tarantula Statuette
 public override void Serialize(GenericWriter writer)
 {
 base.Serialize(writer);
 
  writer.Write((int)0); // version
 }
 
 public override void Deserialize(GenericReader reader)
 {
 base.Deserialize(reader);
 
 int version = reader.ReadInt();
 
 if (version <= 1 && Hue != 0)
 {
 Hue = 0;
 }
 }
 }
 
 public class EtherealLasher : EtherealMount
 {
  [Constructable] 
 public EtherealLasher() 
 : base( 0x9E35 , 0x3ECB )
 { }
 
 public EtherealLasher(Serial serial)
 : base(serial)
 { }
 
 public override int LabelNumber { get { return  1157214; } } // Ethereal Lasher Statuette
 public override void Serialize(GenericWriter writer)
 {
 base.Serialize(writer);
 
  writer.Write((int)0); // version
 }
 
 public override void Deserialize(GenericReader reader)
 {
 base.Deserialize(reader);
 
 int version = reader.ReadInt();
 
 if (version <= 1 && Hue != 0)
 {
 Hue = 0;
 }
 }
 }
 }
 

