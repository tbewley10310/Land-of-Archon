using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Gumps
{
	public class SampleDNAGump : Gump
	{
		private EmptyDNAVial m_Vial;

		public SampleDNAGump( EmptyDNAVial vial ) : base( 25, 25 )
		{
			m_Vial = vial;

			Closable=true;
			Disposable=true;
			Dragable=true;
			Resizable=false;
			AddPage(0);
			AddBackground(37, 45, 252, 137, 5120);
			AddLabel(54, 46, 1160, @"Select The DNA you wish to extract");
			AddButton(50, 75, 4005, 4006, 1, GumpButtonType.Reply, 0);
			AddButton(50, 100, 4005, 4006, 2, GumpButtonType.Reply, 0);
			AddButton(50, 125, 4005, 4006, 3, GumpButtonType.Reply, 0);
			AddButton(50, 150, 4005, 4006, 4, GumpButtonType.Reply, 0);
			AddLabel(85, 75, 1149, @"Prowess");
			AddLabel(85, 100, 1149, @"Environment");
			AddLabel(85, 125, 1149, @"Mental");
			AddLabel(85, 150, 1149, @"Mimic");

		}
      		public override void OnResponse( NetState state, RelayInfo info ) 
      		{ 
			Mobile from = state.Mobile; 

			if ( from == null )
				return;

        		if ( info.ButtonID == 1 ) // Prowess
         		{ 
				from.SendMessage( "What creature would you like to sample dna from." );
           			from.Target = new ProwessTarget( from, m_Vial );
			}

        		if ( info.ButtonID == 2 ) // Environement
         		{ 
				from.SendMessage( "What creature would you like to sample dna from." );
           			from.Target = new EnvironementTarget( from, m_Vial );
			}

        		if ( info.ButtonID == 3 ) // Mental
         		{ 
				from.SendMessage( "What creature would you like to sample dna from." );
           			from.Target = new MentalTarget( from, m_Vial );
			}

        		if ( info.ButtonID == 4 ) // Minic
         		{ 
				from.SendMessage( "What creature would you like to sample dna from." );
           			from.Target = new MimicTarget( from, m_Vial );
			}
		}
	}

  	public class ProwessTarget : Target 
      	{
		private Mobile m_From;
		private EmptyDNAVial m_Vial;

         	public ProwessTarget( Mobile from, EmptyDNAVial vial ) : base ( 10, false, TargetFlags.None ) 
         	{ 
			m_From = from;
			m_Vial = vial;
         	} 
          
         	protected override void OnTarget( Mobile from, object target ) 
         	{
			if ( target is BaseChampion )
			{
				from.SendMessage( "You cannot extract DNA from a champion." );
			}
			else if ( target is BaseVendor )
			{
				from.SendMessage( "You cannot extract DNA from a vendor." );
			}
			else if ( target is PlayerVendor )
			{
				from.SendMessage( "You cannot extract DNA from a vendor." );
			}
			else if ( target is DemonKnight || target is AbysmalHorror || target is DarknightCreeper || target is FleshRenderer || target is ShadowKnight || target is Impaler )
			{
				from.SendMessage( "You cannot extract DNA from a doom boss." );
			}
			else if ( target is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)target;
				if ( !from.InRange( ((Mobile)bc).Location, 1 ) )
				{	
					from.SendMessage( "You are to far away to do that." );
				}
				else if ( bc.Blessed != false )
				{
					from.SendMessage( "They cannot be harmed." );
				}
				else if ( bc.BodyValue == 400 || bc.BodyValue == 401 )
				{
					from.SendMessage( "You cannot extract DNA from a human. " );
				}
				else if ( bc.Controlled != true )
				{
					int qua = bc.Str + bc.HitsMax + bc.PhysicalResistance + bc.DamageMin + bc.DamageMax + bc.VirtualArmor;

					int chance = qua;

					if ( chance <= 500 )
						chance = 499;

					if ( Utility.Random( chance ) < 500 )
					{
						DNAItem dna = new DNAItem();
						dna.DNAName = bc.Name;
						dna.DNAStr = bc.Str;
						dna.DNAHits = bc.HitsMax;
						dna.DNAPhysicalResist = bc.PhysicalResistance;
						dna.DNADamageMin = bc.DamageMin;
						dna.DNADamageMax = bc.DamageMax;
						dna.DNAArmor = bc.VirtualArmor;
						dna.DNAType = DNAType.Prowess;
						dna.DNAAnatomy = bc.Skills[SkillName.Anatomy].Base;
						dna.DNAWrestling = bc.Skills[SkillName.Wrestling].Base;
						dna.DNATactics = bc.Skills[SkillName.Tactics].Base;

						if ( qua <= 200 )
						{
							dna.DNAQuality = DNAQuality.VeryLow;
						}
						else if ( qua <= 350 )
						{
							dna.DNAQuality = DNAQuality.Low;
						}
						else if ( qua <= 450 )
						{
							dna.DNAQuality = DNAQuality.BelowAverage;
						}
						else if ( qua <= 600 )
						{
							dna.DNAQuality = DNAQuality.Average;
						}
						else if ( qua <= 900 )
						{
							dna.DNAQuality = DNAQuality.AboveAverage;
						}
						else if ( qua <= 2000 )
						{
							dna.DNAQuality = DNAQuality.High;
						}
						else if ( qua <= 4500 || qua >= 4500 )
						{
							dna.DNAQuality = DNAQuality.VeryHigh;
						}

						from.AddToBackpack( dna );

						from.PlaySound( 0x240 );

						switch ( Utility.Random( 3 ) )
						{
							case 0:
							bc.Combatant = from;
							from.Combatant = bc;
							from.SendMessage( "You successfully sample the creatures dna, but anger the creature in the progress." );
							bc.Emote( "You have angered the creature" );
							break;

							case 1:
							from.SendMessage( "You successfully sample the creatures dna, but the tramua of the sample was to great for the creature." );
							bc.Kill();

							if ( bc.Corpse != null )
								bc.Corpse.Delete();

							break;

							case 2:
							from.SendMessage( "You successfully sample the creatures dna." );
							break;
						}

						if ( m_Vial.Amount >= 1 )
						{
							m_Vial.Amount -= 1;
							
							if ( m_Vial.Amount == 0 )
								m_Vial.Delete();
						}
					}
					else
					{
						switch ( Utility.Random( 2 ) )
						{
							case 0:
							from.SendMessage( "You fail to sample this creatures dna." );
							bc.Combatant = from;
							from.Combatant = bc;
							bc.Emote( "You have angered the creature" );

							if ( Utility.Random( 100 ) < 35 )
							{
								if ( m_Vial.Amount >= 1 )
								{
									m_Vial.Amount -= 1;
							
									if ( m_Vial.Amount == 0 )
										m_Vial.Delete();
								}

								from.PlaySound( Utility.RandomList( 62, 63 ) );
								from.SendMessage( "The vial has broken." );
							}

							break;

							case 1:
							from.SendMessage( "You fail to sample this creatures dna." );
							from.SendMessage( "The creature has died due to the tramua from the dna sample." );
							bc.Kill();

							if ( bc.Corpse != null )
								bc.Corpse.Delete();

							if ( Utility.Random( 100 ) < 35 )
							{
								if ( m_Vial.Amount >= 1 )
								{
									m_Vial.Amount -= 1;
							
									if ( m_Vial.Amount == 0 )
										m_Vial.Delete();
								}

								from.PlaySound( Utility.RandomList( 62, 63 ) );
								from.SendMessage( "The vial has broken." );
							}

							break;
						}
					}
				}
				else
				{
					from.SendMessage( "You cannot sample dna from a tamed creature." );
				}
			}
				
		}
	}

  	public class EnvironementTarget : Target 
      	{
		private Mobile m_From;
		private EmptyDNAVial m_Vial;

         	public EnvironementTarget( Mobile from, EmptyDNAVial vial ) : base ( 10, false, TargetFlags.None ) 
         	{ 
			m_From = from;
			m_Vial = vial;
         	} 
          
         	protected override void OnTarget( Mobile from, object target ) 
         	{
			if ( target is BaseChampion )
			{
				from.SendMessage( "You cannot extract DNA from a champion." );
			}
			else if ( target is BaseVendor )
			{
				from.SendMessage( "You cannot extract DNA from a vendor." );
			}
			else if ( target is PlayerVendor )
			{
				from.SendMessage( "You cannot extract DNA from a vendor." );
			}
			else if ( target is DemonKnight || target is AbysmalHorror || target is DarknightCreeper || target is FleshRenderer || target is ShadowKnight || target is Impaler )
			{
				from.SendMessage( "You cannot extract DNA from a doom boss." );
			}
			else if ( target is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)target;
				if ( !from.InRange( ((Mobile)bc).Location, 1 ) )
				{	
					from.SendMessage( "You are to far away to do that." );
				}
				else if ( bc.Blessed != false )
				{
					from.SendMessage( "They cannot be harmed." );
				}
				else if ( bc.BodyValue == 400 || bc.BodyValue == 401 )
				{
					from.SendMessage( "You cannot extract DNA from a human. " );
				}
				else if ( bc.Controlled != true )
				{
					int qua = bc.Dex + bc.StamMax + bc.FireResistance + bc.ColdResistance;

					int chance = qua;

					if ( chance <= 100 )
						chance = 99;

					if ( Utility.Random( chance ) < 100 )
					{
						DNAItem dna = new DNAItem();
						dna.DNAName = bc.Name;
						dna.DNADex = bc.Dex;
						dna.DNAStam = bc.StamMax;
						dna.DNAFireResist = bc.FireResistance;
						dna.DNAColdResist = bc.ColdResistance;
						dna.DNAType = DNAType.Environment;
						dna.DNAMagicResist = bc.Skills[SkillName.MagicResist].Base;
						dna.DNAPoisoning = bc.Skills[SkillName.Poisoning].Base;

						if ( qua <= 50 )
						{
							dna.DNAQuality = DNAQuality.VeryLow;
						}
						else if ( qua <= 100 )
						{
							dna.DNAQuality = DNAQuality.Low;
						}
						else if ( qua <= 150 )
						{
							dna.DNAQuality = DNAQuality.BelowAverage;
						}
						else if ( qua <= 200 )
						{
							dna.DNAQuality = DNAQuality.Average;
						}
						else if ( qua <= 300 )
						{
							dna.DNAQuality = DNAQuality.AboveAverage;
						}
						else if ( qua <= 400 )
						{
							dna.DNAQuality = DNAQuality.High;
						}
						else if ( qua <= 500 || qua >= 500 )
						{
							dna.DNAQuality = DNAQuality.VeryHigh;
						}

						from.AddToBackpack( dna );

						from.PlaySound( 0x240 );

						switch ( Utility.Random( 3 ) )
						{
							case 0:
							bc.Combatant = from;
							from.Combatant = bc;
							from.SendMessage( "You successfully sample the creatures dna, but anger the creature in the progress." );
							bc.Emote( "You have angered the creature" );
							break;

							case 1:
							from.SendMessage( "You successfully sample the creatures dna, but the tramua of the sample was to great for the creature." );
							bc.Kill();

							if ( bc.Corpse != null )
								bc.Corpse.Delete();

							break;

							case 2:
							from.SendMessage( "You successfully sample the creatures dna." );
							break;
						}

						if ( m_Vial.Amount >= 1 )
						{
							m_Vial.Amount -= 1;
							
							if ( m_Vial.Amount == 0 )
								m_Vial.Delete();
						}
					}
					else
					{
						switch ( Utility.Random( 2 ) )
						{
							case 0:
							from.SendMessage( "You fail to sample this creatures dna." );
							bc.Combatant = from;
							from.Combatant = bc;
							bc.Emote( "You have angered the creature" );

							if ( Utility.Random( 100 ) < 35 )
							{
								if ( m_Vial.Amount >= 1 )
								{
									m_Vial.Amount -= 1;
							
									if ( m_Vial.Amount == 0 )
										m_Vial.Delete();
								}

								from.PlaySound( Utility.RandomList( 62, 63 ) );
								from.SendMessage( "The vial has broken." );
							}

							break;

							case 1:
							from.SendMessage( "You fail to sample this creatures dna." );
							from.SendMessage( "The creature has died due to the tramua from the dna sample." );
							bc.Kill();

							if ( bc.Corpse != null )
								bc.Corpse.Delete();

							if ( Utility.Random( 100 ) < 35 )
							{
								if ( m_Vial.Amount >= 1 )
								{
									m_Vial.Amount -= 1;
							
									if ( m_Vial.Amount == 0 )
										m_Vial.Delete();
								}

								from.PlaySound( Utility.RandomList( 62, 63 ) );
								from.SendMessage( "The vial has broken." );
							}

							break;
						}
					}
				}
				else
				{
					from.SendMessage( "You cannot sample dna from a tamed creature." );
				}
			}
		}
	}

  	public class MentalTarget : Target 
      	{
		private Mobile m_From;
		private EmptyDNAVial m_Vial;

         	public MentalTarget( Mobile from, EmptyDNAVial vial ) : base ( 10, false, TargetFlags.None ) 
         	{ 
			m_From = from;
			m_Vial = vial;
         	} 
          
         	protected override void OnTarget( Mobile from, object target ) 
         	{
			if ( target is BaseChampion )
			{
				from.SendMessage( "You cannot extract DNA from a champion." );
			}
			else if ( target is BaseVendor )
			{
				from.SendMessage( "You cannot extract DNA from a vendor." );
			}
			else if ( target is PlayerVendor )
			{
				from.SendMessage( "You cannot extract DNA from a vendor." );
			}
			else if ( target is DemonKnight || target is AbysmalHorror || target is DarknightCreeper || target is FleshRenderer || target is ShadowKnight || target is Impaler )
			{
				from.SendMessage( "You cannot extract DNA from a doom boss." );
			}
			else if ( target is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)target;
				if ( !from.InRange( ((Mobile)bc).Location, 1 ) )
				{	
					from.SendMessage( "You are to far away to do that." );
				}
				else if ( bc.Blessed != false )
				{
					from.SendMessage( "They cannot be harmed." );
				}
				else if ( bc.BodyValue == 400 || bc.BodyValue == 401 )
				{
					from.SendMessage( "You cannot extract DNA from a human. " );
				}
				else if ( bc.Controlled != true )
				{
					int qua = bc.Int + bc.ManaMax + bc.EnergyResistance + bc.PoisonResistance;

					int chance = qua;

					if ( chance <= 200 )
						chance = 199;

					if ( Utility.Random( chance ) < 200 )
					{
						DNAItem dna = new DNAItem();
						dna.DNAName = bc.Name;
						dna.DNAInt = bc.Int;
						dna.DNAMana = bc.ManaMax;
						dna.DNAEnergyResist = bc.EnergyResistance;
						dna.DNAPoisonResist = bc.PoisonResistance;
						dna.DNAType = DNAType.Mental;
						dna.DNAMagery = bc.Skills[SkillName.Magery].Base;
						dna.DNAEvalInt = bc.Skills[SkillName.EvalInt].Base;
						dna.DNAMeditation = bc.Skills[SkillName.Meditation].Base;

						if ( qua <= 100 )
						{
							dna.DNAQuality = DNAQuality.VeryLow;
						}
						else if ( qua <= 150 )
						{
							dna.DNAQuality = DNAQuality.Low;
						}
						else if ( qua <= 200 )
						{
							dna.DNAQuality = DNAQuality.BelowAverage;
						}
						else if ( qua <= 300 )
						{
							dna.DNAQuality = DNAQuality.Average;
						}
						else if ( qua <= 600 )
						{
							dna.DNAQuality = DNAQuality.AboveAverage;
						}
						else if ( qua <= 1500 )
						{
							dna.DNAQuality = DNAQuality.High;
						}
						else if ( qua <= 3500 || qua >= 3500 )
						{
							dna.DNAQuality = DNAQuality.VeryHigh;
						}

						from.AddToBackpack( dna );

						from.PlaySound( 0x240 );

						switch ( Utility.Random( 3 ) )
						{
							case 0:
							bc.Combatant = from;
							from.Combatant = bc;
							from.SendMessage( "You successfully sample the creatures dna, but anger the creature in the progress." );
							bc.Emote( "You have angered the creature" );
							break;

							case 1:
							from.SendMessage( "You successfully sample the creatures dna, but the tramua of the sample was to great for the creature." );
							bc.Kill();

							if ( bc.Corpse != null )
								bc.Corpse.Delete();

							break;

							case 2:
							from.SendMessage( "You successfully sample the creatures dna." );
							break;
						}

						if ( m_Vial.Amount >= 1 )
						{
							m_Vial.Amount -= 1;
							
							if ( m_Vial.Amount == 0 )
								m_Vial.Delete();
						}
					}
					else
					{
						switch ( Utility.Random( 2 ) )
						{
							case 0:
							from.SendMessage( "You fail to sample this creatures dna." );
							bc.Combatant = from;
							from.Combatant = bc;
							bc.Emote( "You have angered the creature" );

							if ( Utility.Random( 100 ) < 35 )
							{
								if ( m_Vial.Amount >= 1 )
								{
									m_Vial.Amount -= 1;
							
									if ( m_Vial.Amount == 0 )
										m_Vial.Delete();
								}

								from.PlaySound( Utility.RandomList( 62, 63 ) );
								from.SendMessage( "The vial has broken." );
							}

							break;

							case 1:
							from.SendMessage( "You fail to sample this creatures dna." );
							from.SendMessage( "The creature has died due to the tramua from the dna sample." );
							bc.Kill();

							if ( bc.Corpse != null )
								bc.Corpse.Delete();

							if ( Utility.Random( 100 ) < 35 )
							{
								if ( m_Vial.Amount >= 1 )
								{
									m_Vial.Amount -= 1;
							
									if ( m_Vial.Amount == 0 )
										m_Vial.Delete();
								}

								from.PlaySound( Utility.RandomList( 62, 63 ) );
								from.SendMessage( "The vial has broken." );
							}

							break;
						}
					}
				}
				else
				{
					from.SendMessage( "You cannot sample dna from a tamed creature." );
				}
			}
		}
	}

  	public class MimicTarget : Target 
      	{
		private Mobile m_From;
		private EmptyDNAVial m_Vial;

         	public MimicTarget( Mobile from, EmptyDNAVial vial ) : base ( 10, false, TargetFlags.None ) 
         	{ 
			m_From = from;
			m_Vial = vial;
         	} 
          
         	protected override void OnTarget( Mobile from, object target ) 
         	{
			if ( target is BaseChampion )
			{
				from.SendMessage( "You cannot extract DNA from a champion." );
			}
			else if ( target is BaseVendor )
			{
				from.SendMessage( "You cannot extract DNA from a vendor." );
			}
			else if ( target is PlayerVendor )
			{
				from.SendMessage( "You cannot extract DNA from a vendor." );
			}
			else if ( target is DemonKnight || target is AbysmalHorror || target is DarknightCreeper || target is FleshRenderer || target is ShadowKnight || target is Impaler )
			{
				from.SendMessage( "You cannot extract DNA from a doom boss." );
			}
			else if ( target is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)target;
				if ( !from.InRange( ((Mobile)bc).Location, 1 ) )
				{	
					from.SendMessage( "You are to far away to do that." );
				}
				else if ( bc.Blessed != false )
				{
					from.SendMessage( "They cannot be harmed." );
				}
				else if ( bc.BodyValue == 400 || bc.BodyValue == 401 )
				{
					from.SendMessage( "You cannot extract DNA from a human. " );
				}
				else if ( bc.Controlled != true )
				{
					DNAItem dna = new DNAItem();
					dna.DNAName = bc.Name;
					dna.DNAType = DNAType.Mimic;
					dna.DNABodyValue = bc.BodyValue;
					dna.DNASoundID = bc.BaseSoundID;

					if ( bc is BaseMount )
					{
						BaseMount bm = (BaseMount)bc;
						dna.MountID = bm.ItemID;
					}

					if ( Utility.Random( 100 ) < 15 )
					{
						switch ( Utility.Random( 3 ) )
						{
							case 0:
							dna.DNABluntAttack = true;
							break;

							case 1:
							dna.DNAHealAttack = true;
							break;

							case 2:
							dna.DNAPoisonAttack = true;
							break;
						}
					}

					if ( Utility.Random( 100 ) < 15 )
					{
						switch ( Utility.Random( 5 ) )
						{
							case 0:
							dna.DNATrialByFire = true;
							break;

							case 1:
							dna.DNAIceBlast = true;
							break;

							case 2:
							dna.DNACometAttack = true;
							break;

							case 3:
							dna.DNACallOfNature = true;
							break;

							case 4:
							dna.DNAAcidRain = true;
							break;
						}
					}

					from.AddToBackpack( dna );

					from.PlaySound( 0x240 );

					switch ( Utility.Random( 3 ) )
					{
						case 0:
						bc.Combatant = from;
						from.Combatant = bc;
						from.SendMessage( "You successfully sample the creatures dna, but anger the creature in the progress." );
						bc.Emote( "You have angered the creature" );
						break;

						case 1:
						from.SendMessage( "You successfully sample the creatures dna, but the tramua of the sample was to great for the creature." );
						bc.Kill();

						if ( bc.Corpse != null )
							bc.Corpse.Delete();

						break;

						case 2:
						from.SendMessage( "You successfully sample the creatures dna." );
						break;
					}

					if ( m_Vial.Amount >= 1 )
					{
						m_Vial.Amount -= 1;
						
						if ( m_Vial.Amount == 0 )
							m_Vial.Delete();
					}
				}
				else
				{
					switch ( Utility.Random( 2 ) )
					{
						case 0:
						from.SendMessage( "You fail to sample this creatures dna." );
						bc.Combatant = from;
						from.Combatant = bc;
						bc.Emote( "You have angered the creature" );

						if ( Utility.Random( 100 ) < 35 )
						{
							if ( m_Vial.Amount >= 1 )
							{
								m_Vial.Amount -= 1;
							
								if ( m_Vial.Amount == 0 )
									m_Vial.Delete();
							}

							from.PlaySound( Utility.RandomList( 62, 63 ) );
							from.SendMessage( "The vial has broken." );
						}

						break;

						case 1:
						from.SendMessage( "You fail to sample this creatures dna." );
						from.SendMessage( "The creature has died due to the tramua from the dna sample." );
						bc.Kill();

						if ( bc.Corpse != null )
							bc.Corpse.Delete();

						if ( Utility.Random( 100 ) < 35 )
						{
							if ( m_Vial.Amount >= 1 )
							{
								m_Vial.Amount -= 1;
							
								if ( m_Vial.Amount == 0 )
									m_Vial.Delete();
							}

							from.PlaySound( Utility.RandomList( 62, 63 ) );
							from.SendMessage( "The vial has broken." );
						}

						break;
					}
				}
			}
			else
			{
				from.SendMessage( "You cannot sample dna from a tamed creature." );
			}
		}
	}
}