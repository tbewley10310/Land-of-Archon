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
using daat99;

namespace Server.Items
{
	public class ResourceRecipe : Item
	{
		private CraftResource cr_Recipe;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Recipe { get { return cr_Recipe; } set { cr_Recipe = value; InvalidateProperties(); } }

		[Constructable]
		public ResourceRecipe() : this( (CraftResource)RecipesLists.Resources[Utility.Random(RecipesLists.Resources.Count)] )
		{
		}
		
		
		[Constructable]
		public ResourceRecipe( CraftResource resource ) : base( 0x227A )
		{
			cr_Recipe = resource;
			Name = "Resource Recipe";
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if ( cr_Recipe == CraftResource.None )
			{
				Delete();
				from.SendMessage(32, "This is an invalid recipe, it'll be deleted.");
				return;
			}
			
			if (!(IsChildOf(from.Backpack)))
			{
				from.SendMessage("This must be in your backpack to use.");
				return;
			}
			
			NewDaat99Holder dh = (NewDaat99Holder)daat99.Daat99OWLTR.TempHolders[from];
			
			string s_Key = cr_Recipe.ToString(), s_Temp = cr_Recipe.ToString();
			int i_Break = s_Temp.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(),1);
			if ( i_Break > -1 )
			{
				s_Key = s_Temp.Substring( 0, i_Break );
				s_Temp = s_Temp.Substring( i_Break );
				i_Break = s_Temp.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(),1);
				while ( i_Break > -1 )
				{
					s_Key = s_Key + " " + s_Temp.Substring(0, i_Break );
					s_Temp =  s_Temp.Substring( i_Break );
					i_Break = s_Temp.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(),1);
				}
				if ( s_Temp != null && s_Temp != s_Key )
					s_Key += " " + s_Temp;
			}

			if ( dh.Resources == null )
				dh.Resources = new ArrayList();
			else if ( dh.Resources.Contains( cr_Recipe ) )
			{
				dh.Resources.Remove((CraftResource)cr_Recipe);
				from.SendMessage(88, "You learned how to use {0}.", s_Key);
				Delete();
				return;
			}
			from.SendMessage(33, "You already know how to use {0}!!!", s_Key);
		}
		
		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

			if ( cr_Recipe == CraftResource.None )
				return;

			string s_Key = cr_Recipe.ToString(), s_Temp = cr_Recipe.ToString();
			int i_Break = s_Temp.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(),1);
			if ( i_Break > -1 )
			{
				s_Key = s_Temp.Substring( 0, i_Break );
				s_Temp = s_Temp.Substring( i_Break );
				i_Break = s_Temp.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(),1);
				while ( i_Break > -1 )
				{
					s_Key = s_Key + " " + s_Temp.Substring(0, i_Break );
					s_Temp =  s_Temp.Substring( i_Break );
					i_Break = s_Temp.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(),1);
				}
				if ( s_Temp != null && s_Temp != s_Key )
					s_Key += " " + s_Temp;
			}

			if ( cr_Recipe >= CraftResource.DullCopper && cr_Recipe <= CraftResource.Platinum )
				list.Add( 1060844, "{0} ore", s_Key );
			else if ( cr_Recipe >= CraftResource.SpinedLeather && cr_Recipe <= CraftResource.EtherealLeather )
				list.Add( 1060844, "{0}", s_Key );
			else if ( cr_Recipe >= CraftResource.RedScales && cr_Recipe <= CraftResource.GoldScales )
				list.Add( 1060844, "{0}", s_Key );
			else if ( cr_Recipe >= CraftResource.OakWood && cr_Recipe <= CraftResource.Petrified )
				list.Add( 1060844, "{0} wood", s_Key );
		}
		
		public ResourceRecipe( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 

			writer.Write( (int) cr_Recipe );
			
		}

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 

			cr_Recipe = (CraftResource)reader.ReadInt();

		} 
	}
}