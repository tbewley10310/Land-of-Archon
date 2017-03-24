/********************************************************************************************
**Lait et fromage Crystal/Sna/Cooldev 2003 (laitage.cs,laitage_items.cs et fromage.cs)     **
**le script comprend 1 seau pour traire vache , sheep , chevre . 3 bouteilles de laits    ** 
**et 3 moule plein de fromages (je prefere les bouteilles que les pichets c'est stackable) **
**               http://invisionfree.com/forums/Hyel_dev/index.php                         **
********************************************************************************************/

using System;
using Server;
using Server.Items;
using Server.Prompts;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Items

{
	public class CheeseForm : Item
	{
		
		private int FromAfaire; // 1-sheep 2-chevre 3-vache
		private int FromageQual; //10:nada 11-89:normal 90-99:magique
		private int StadeFermentation; // display  de 0% a 100% pour les impatients
		private bool MoulePlein; // le moule est rempli plus que a dclic dessus pour demarrer
		private bool Fermentation; // le moule est pas en fermentation(false) ou sa fermente (true)
		private bool ContientUnFromton;// moule fermenté vide(false) ou plein (true)
		public int m_FromBonusSkill; // ajout du bonus de skill cooking .
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int m_FromAfaire
		{
			get { return FromAfaire; }
			set { FromAfaire = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int m_FromageQual
		{
			get { return FromageQual; }
			set { FromageQual = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int m_StadeFermentation
		{
			get { return StadeFermentation; }
			set { StadeFermentation = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool m_MoulePlein
		{
			get { return MoulePlein; }
			set { MoulePlein = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool m_Fermentation
		{
			get { return Fermentation; }
			set { Fermentation = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool m_ContientUnFromton
		{
			get { return ContientUnFromton; }
			set { ContientUnFromton = value; }
		}
		
		[Constructable]
		public CheeseForm() : base( 0x0E78 )
		{
			Weight = 10.0;
			Name = "Cheese Form: Empty";
			Hue = 0x481;
		}
		
		public override void OnDoubleClick (Mobile from )
		{
			Container pack = from.Backpack;
			m_FromBonusSkill =( m_FromageQual+((int)(from.Skills[SkillName.Cooking].Value)/5));
			if (! from.InRange( this.GetWorldLocation(), 2 ))
			{
				from.LocalOverheadMessage( MessageType.Regular, 906, 1019045 ); // I can't reach that.
			}
			else
			{
				if ((Fermentation == false) && (MoulePlein == false) && (ContientUnFromton == false))
				{
					from.Target = new OnRempliMouleFromton( this );
					from.SendMessage(0x84C, "Choose the milk bucket for filling the cheese form." );
				}
				else if ((MoulePlein == true) && (Fermentation == false) && (ContientUnFromton == false))
				{
					new FromQuiFermente(this).Start();
					Fermentation = true;
					from.SendMessage("You start the fermentation process.");
					if ( from.CheckSkill( SkillName.Cooking, 0, 100 ) )
						m_StadeFermentation = 5;
					else
						m_StadeFermentation = 0;
				}
				else if ((Fermentation == true) && (ContientUnFromton == false) && (MoulePlein == true))
				{
					this.PublicOverheadMessage( MessageType.Regular, 1151, false, string.Format("Fermentation process: " + StadeFermentation.ToString() + " %" ));
				}
				else if ((Fermentation == false) && (ContientUnFromton == true) && (MoulePlein == true))
				{
					if (m_FromBonusSkill < 10)
					{
						this.PublicOverheadMessage( MessageType.Regular, 1152, false, string.Format("Fermentation failed, the milk is lost." ) );
						m_ContientUnFromton = false;
						m_MoulePlein = false;
						m_FromageQual = 0;
						m_FromAfaire = 0;
						this.Name = "Cheese Form: Empty";
					}
					else if ( (m_FromBonusSkill > 95 ) && Utility.RandomBool() )// magique reward
					{							// m_FromBonusSkill is random 1-100 + cooking/5
						if ( FromAfaire == 1 )
						{
							from.SendMessage(0x84C, "You obtain a wonderful Roquefort from the form." );
							from.AddToBackpack( new FromageDeBrebisMagic() );
							m_ContientUnFromton = false;
							m_MoulePlein = false;
							m_FromageQual = 0;
							m_FromAfaire = 0;
							this.Name = "Cheese Form: Empty";
						}
						else if ( FromAfaire == 2 )
						{
							from.SendMessage(0x84C, "You obtain a wonderful crottin de Chavignol from the form." );
							from.AddToBackpack( new FromageDeChevreMagic() );
							m_ContientUnFromton = false;
							m_MoulePlein = false;
							m_FromageQual = 0;
							m_FromAfaire = 0;
							this.Name = "Cheese Form: Empty";
						}
						else
						{
							from.SendMessage(0x84C, "You obtain a wonderful Maroille from the form." );
							from.AddToBackpack( new FromageDeVacheMagic() );
							m_ContientUnFromton = false;
							m_MoulePlein = false;
							m_FromageQual = 0;
							m_FromAfaire = 0;
							this.Name = "Cheese Form: Empty";
						}
					}
					else // ((m_FromBonusSkill >= 10 )&& (m_FromBonusSkill < 95 ))
					{
						if ( FromAfaire == 1 )
						{
							from.SendMessage(0x84C, "You obtain a wonderful sheep cheese from the form." );
							from.AddToBackpack( new FromageDeBrebis() );
							m_ContientUnFromton = false;
							m_MoulePlein = false;
							m_FromageQual = 0;
							m_FromAfaire = 0;
							this.Name = "Cheese Form: Empty";
						}
						else if ( FromAfaire == 2 )
						{
							from.SendMessage(0x84C, "You obtain a wonderful goat cheese from the form." );
							from.AddToBackpack( new FromageDeChevre() );
							m_ContientUnFromton = false;
							m_MoulePlein = false;
							m_FromageQual = 0;
							m_FromAfaire = 0;
							this.Name = "Cheese Form: Empty";
						}
						else
						{
							from.SendMessage(0x84C, "You obtain a wonderful cow cheese from the form." );
							from.AddToBackpack( new FromageDeVache() );
							m_ContientUnFromton = false;
							m_MoulePlein = false;
							m_FromageQual = 0;
							m_FromAfaire = 0;
							this.Name = "Cheese Form: Empty";
						}
					}
				}
				else
				{
					from.SendMessage(0x84C, "*gasp* A bug!");
				}
			}
		}
		
		public CheeseForm( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 );
			writer.Write( (int) FromAfaire );
			writer.Write( (int) FromageQual );
			writer.Write( (int) StadeFermentation );
			writer.Write( (bool) MoulePlein);
			writer.Write( (bool) Fermentation);
			writer.Write( (bool) ContientUnFromton);
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
					{
						FromAfaire = reader.ReadInt();
						FromageQual = reader.ReadInt();
						StadeFermentation = reader.ReadInt();
						MoulePlein = reader.ReadBool();
						Fermentation = reader.ReadBool();
						ContientUnFromton = reader.ReadBool();
						
						if ( Fermentation == true )
							new FromQuiFermente(this).Start();
						
						break;
					}
			}
		}
	}
	public class OnRempliMouleFromton : Target
	{
		private CheeseForm m_MouleVar;
		MilkBucket m_SautFromage = null;
		
		public OnRempliMouleFromton( CheeseForm m_CheeseForm ) : base( 3, false, TargetFlags.None )
		{
			m_MouleVar = m_CheeseForm;
			
		}
		
		protected override void OnTarget( Mobile from, object o )
		{
			
			if (o is MilkBucket )
			{
				m_SautFromage =(MilkBucket)o;
				if (m_SautFromage.Laitage >= 15)
				{
					m_SautFromage.Laitage = m_SautFromage.Laitage -15;
					
					if (m_SautFromage.m_bestiole == 1 )
					{
						m_SautFromage.Name ="Milk Bucket: " + m_SautFromage.Laitage.ToString() + "/50 liters of sheep milk.";
						m_MouleVar.m_FromAfaire = 1;
						m_MouleVar.Name="Cheese form: Sheep cheese";
						m_MouleVar.m_MoulePlein = true;
					}
					else if (m_SautFromage.m_bestiole == 2 )
					{
						m_SautFromage.Name ="Milk Bucket: " + m_SautFromage.Laitage.ToString() + "/50 liters of goat milk.";
						m_MouleVar.m_FromAfaire = 2;
						m_MouleVar.Name="Cheese form: Goat cheese";
						m_MouleVar.m_MoulePlein = true;
					}
					else if (m_SautFromage.m_bestiole == 3 )
					{
						m_SautFromage.Name ="Milk Bucket: " + m_SautFromage.Laitage.ToString() + "/50 liters of cow milk.";
						m_MouleVar.m_FromAfaire = 3;
						m_MouleVar.Name="Cheese form: Cow cheese";
						m_MouleVar.m_MoulePlein = true;
					}
					else
					{
						from.SendMessage(0x84C, "This isn't a good milk bucket." );
						from.CloseGump( typeof( CheeseFormHelpGump ) );
						from.SendGump( new CheeseFormHelpGump ( from ) );
						
					}
				}
				else
				{
					from.SendMessage(0x84C, "The milk bucket didn't contain enough milk." );
					from.CloseGump( typeof( CheeseFormHelpGump ) );
					from.SendGump( new CheeseFormHelpGump ( from ) );
					
				}
				
				if ( m_SautFromage.Laitage <= 0 )
				{
					m_SautFromage.Laitage = 0;
					m_SautFromage.m_bestiole = 0;
					m_SautFromage.Name = "Milk Bucket: (Empty)";
				}
				
			}
			else
			{
				from.SendMessage(0x84C, "Use a milk bucket with at least 15 liters." );
				from.CloseGump( typeof( CheeseFormHelpGump ) );
				from.SendGump( new CheeseFormHelpGump ( from ) );
			}
		}
	}
}
