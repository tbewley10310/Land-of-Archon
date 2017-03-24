/*
 created by:
     /\            888                   888     .d8888b.   .d8888b.  
____/_ \____       888                   888    d88P  Y88b d88P  Y88b 
\  ___\ \  /       888                   888    888    888 888    888 
 \/ /  \/ /    .d88888  8888b.   8888b.  888888 Y88b. d888 Y88b. d888 
 / /\__/_/\   d88" 888     "88b     "88b 888     "Y888P888  "Y888P888 
/__\ \_____\  888  888 .d888888 .d888888 888           888        888 
    \  /      Y88b 888 888  888 888  888 Y88b.  Y88b  d88P Y88b  d88P 
     \/        "Y88888 "Y888888 "Y888888  "Y888  "Y8888P"   "Y8888P"  
*/
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Commands;

namespace daat99
{
	public class Daat99OWLTR : Item 
	{
		public bool Deletable = true;
		public override bool Decays { get { return Deletable; } }
		
		public static int MajorVersion 	=  3;
		public static int MinorVersion 	= 01;
		public static int BuildNumber 	= 00; 
		
		private static Hashtable htStaticHolders = new Hashtable();
		public static Hashtable StaticHolders{ get{ return htStaticHolders; } set{ htStaticHolders = value; } }

		private static Hashtable htTempHolders = new Hashtable();
		public static Hashtable TempHolders{ get{ return htTempHolders; } set{ htTempHolders = value; } }


		public override void Consume() { if (Deletable) base.Consume(); }
		public override void Consume(int amount) { if (Deletable) base.Consume(amount); }
		public override void RemoveItem(Item item) { if (Deletable) base.RemoveItem(item); }
		public override void OnRemoved(object parent) { if (Deletable) base.OnRemoved(parent); }
		public override void OnDelete() { if (Deletable) base.OnDelete(); }
		public override void Delete() { if (Deletable) base.Delete(); }

		[Constructable]
		public Daat99OWLTR() : this(true) { }
		[Constructable] 
		public Daat99OWLTR(bool deletableVisible) : base( 10900 ) 
		{ 
			Hue = 2; 
			Name = "Daat99's OWLTR Control and Information Center";
			Movable = false;
			Light = LightType.Circle300;
			Deletable = deletableVisible;
			Visible = deletableVisible;
		} 

		public override void OnDoubleClick( Mobile from ) 
		{ 
			from.CloseGump( typeof( Daat99CustomOWLTRGump ) );
			if ( !from.Player ) 
				return; 
			if (from.AccessLevel >= AccessLevel.Administrator)
				from.SendGump( new Daat99CustomOWLTRGump((PlayerMobile)from) );
			else
				from.SendGump( new Daat99CustomOWLTRGump((PlayerMobile)from) );
		}

		public static void Initialize()
		{
			OWLTROptionsManager.Manager.InitOwltrOptions();
			bool found = false;
			foreach (Item item in World.Items.Values)
				if (item is Daat99OWLTR && !((Daat99OWLTR)item).Deletable)
					found = true;
			if ( !found )
				GenOWLTR();
			if ( StaticHolders == null )
				StaticHolders = new Hashtable();
			if ( TempHolders == null )
				TempHolders = new Hashtable();

			CommandSystem.Register( "OWLTR", AccessLevel.Player, new CommandEventHandler( OWLTR_OnCommand ) );
			if ( Core.AOS )
				CommandSystem.Register( "OWLTRBOD", AccessLevel.Player, new CommandEventHandler( OWLTRBOD_OnCommand ) );

			if ( OWLTROptionsManager.IsEnabled(OWLTROptionsManager.OPTIONS_ENUM.RECIPE_CRAFT) )
				CommandSystem.Register( "MissingRecipes", AccessLevel.Player, new CommandEventHandler( MissingRecipes_OnCommand ) );
			CommandSystem.Register( "Daat99Holder", AccessLevel.Administrator, new CommandEventHandler( Daat99HolderOnCommand ) );

			EventSink.Login += new LoginEventHandler( OnLogin );
			EventSink.Disconnected += new DisconnectedEventHandler( EventSink_Disconnected );
		}

		[Usage( "OWLTR" )]
		[Description( "Open the OWLTR Control Center Gump." )]
		public static void OWLTR_OnCommand( CommandEventArgs e )
		{
			if (!(e.Mobile is PlayerMobile))
				return;
			if (e.Mobile.AccessLevel >= AccessLevel.Administrator)
				e.Mobile.SendGump(new Daat99CustomOWLTRGump((PlayerMobile)e.Mobile));
			else
				e.Mobile.SendGump(new Daat99CustomOWLTRGump((PlayerMobile)e.Mobile));
		}
		
		[Usage( "OWLTRBOD" )]
		[Description( "Open the bods request Gump." )]
		public static void OWLTRBOD_OnCommand( CommandEventArgs e )
		{
			if (e.Mobile is PlayerMobile)
				e.Mobile.SendGump(new OWLTRbodGump((PlayerMobile)e.Mobile));
		}

		[Usage( "MissingRecipes" )]
		[Description( "Show the player what recipes he's missing." )]
		public static void MissingRecipes_OnCommand( CommandEventArgs e )
		{
			if (e.Mobile is PlayerMobile)
				e.Mobile.SendGump(new MissingRecipesGump((PlayerMobile)e.Mobile, 0));
		}
		
		[Usage( "Daat99Holder" )]
		[Description( "Send the administrator the Daat99Holder gump of a specific player." )]
		public static void Daat99HolderOnCommand( CommandEventArgs e )
		{
			e.Mobile.Target = new Daat99Target(0);
		}
			
		public static void GenOWLTR()
		{
			Daat99OWLTR dowl = new Daat99OWLTR();
			dowl.MoveToWorld( new Point3D(1434,1707,18), Map.Trammel );
			Daat99OWLTR dowl2 = new Daat99OWLTR();
			dowl2.MoveToWorld( new Point3D(1434,1707,18), Map.Felucca );
			Daat99OWLTR dowl3 = new Daat99OWLTR(false);
			dowl3.MoveToWorld( new Point3D(0,0,0), Map.Tokuno );
		}

		private static void OnLogin( LoginEventArgs e )
		{
			Mobile from = e.Mobile;
			
			if ( !htTempHolders.Contains(from) )
			{
				if ( !htStaticHolders.Contains(from) )
					htStaticHolders.Add( from, new NewDaat99Holder() );
				htTempHolders.Add( from, htStaticHolders[from] );
			}
		}
			
		private static void EventSink_Disconnected( DisconnectedEventArgs e )
		{
			Mobile from = e.Mobile;
			htStaticHolders[from] = htTempHolders[from];
			htTempHolders.Remove( from );
		}

		public Daat99OWLTR( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			
			writer.Write( (int) 0 ); // version
			
			writer.Write( (bool) Deletable ); //must be writen first

			//version 1 make it save string\bool\string instead of just bool and create hash table instead of daat99holders.
			if (!Deletable)
			{
				OWLTROptionsManager.Manager.Serialize(writer);
				
				foreach (DictionaryEntry de in htTempHolders) //update the static hashtable before save
					if ( htStaticHolders.Contains((Mobile)de.Key) )
						htStaticHolders[(Mobile)de.Key] = htTempHolders[(Mobile)de.Key];

				int count = htStaticHolders.Count;
				foreach (DictionaryEntry de in htStaticHolders) 
					if ((Mobile)de.Key == null)
						count--;

				Hashtable htSerialTable = new Hashtable();
				foreach ( DictionaryEntry de in htStaticHolders )
					if ( de.Value != null && (Mobile)de.Key != null) //serial 003
						htSerialTable.Add( de.Key, de.Value );
				
				writer.Write( htSerialTable.Count );
				foreach ( DictionaryEntry de in htSerialTable )
				{
					writer.Write( (Mobile)de.Key );
					((NewDaat99Holder)de.Value).Serialize( writer );
				}
			}
		}

		public override void Deserialize( GenericReader reader ) 
		{
			base.Deserialize( reader ); 

			int version = reader.ReadInt();

			if (version >= 0)
			{
				Deletable = reader.ReadBool(); //must be read first
					
				if (!Deletable)
				{
					OWLTROptionsManager.Manager.Deserialize(reader);

					int count = reader.ReadInt();
					for (int i=0; i < count; i++)
					{
						Mobile from = reader.ReadMobile();
						NewDaat99Holder ndh = new NewDaat99Holder( reader );
						if (from != null)
							htStaticHolders.Add( from, ndh );
					}
				}
			}
		}
		
		public class OwltrOps
		{
			private string s_Title;
			private bool b_Setting;
			private string s_Desctiption;
			public string Title{ get{ return s_Title;} set{ s_Title = value;} }
			public bool Setting{ get{ return b_Setting;} set{ b_Setting= value;} }
			public string Desctiption{ get{ return s_Desctiption;} set{ s_Desctiption= value;} }
			
			public OwltrOps(string name, bool setting, string desc)
			{
				s_Title = name;
				b_Setting = setting;
				s_Desctiption = desc;
			}
		}

		private class Daat99Target : Target
		{
			private int iSwitch;
 
			public Daat99Target(int i) : base(12, false, TargetFlags.None)
			{
				iSwitch = i;
			}
 
			protected override void OnTarget(Mobile from, object target)
			{
				switch (iSwitch)
				{
					case 0: //daat99holder command
					{
						if (target is PlayerMobile)
							from.SendGump( new Daat99HolderGump( from, (NewDaat99Holder)htTempHolders[(Mobile)target], (Mobile)target, true ) );
						else
							from.SendMessage("You must target a player.");
						break;
					}
				}
			}
		}
	}
}