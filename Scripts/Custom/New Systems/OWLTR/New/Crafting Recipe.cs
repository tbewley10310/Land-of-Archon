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
using System;
using System.Collections;
using daat99;


namespace Server.Items
{
	public class CraftingRecipe : Item
	{
		private Type t_Recipe;

		[CommandProperty( AccessLevel.GameMaster )]
		public Type Recipe { get{ return t_Recipe; } set { t_Recipe = value; } }

		[Constructable]
		public CraftingRecipe() : this( 0 )
		{
		}

		[Constructable]
		public CraftingRecipe( int level ) : base( 0x227B )
		{
			switch (level)
			{
				case 0: default: t_Recipe = (Type)RecipesLists.All[Utility.Random(RecipesLists.All.Count)]; break;
				case 1: t_Recipe = (Type)RecipesLists.Lvl1[Utility.Random(RecipesLists.Lvl1.Count)]; break;
				case 2: t_Recipe = (Type)RecipesLists.Lvl2[Utility.Random(RecipesLists.Lvl2.Count)]; break;
				case 3: t_Recipe = (Type)RecipesLists.Lvl3[Utility.Random(RecipesLists.Lvl3.Count)]; break;
				case 4: t_Recipe = (Type)RecipesLists.Lvl4[Utility.Random(RecipesLists.Lvl4.Count)]; break;
				case 5: t_Recipe = (Type)RecipesLists.Lvl5[Utility.Random(RecipesLists.Lvl5.Count)]; break;
				case 6: t_Recipe = (Type)RecipesLists.Lvl6[Utility.Random(RecipesLists.Lvl6.Count)]; break;
			}
			Name = "Crafting Recipe";
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( t_Recipe == null )
			{
				Delete();
				from.SendMessage(32, "This is an invalid recipe, it'll be deleted.");
				return;
			}
			
			if (!(IsChildOf(from.Backpack)))
			{
				from.SendMessage(32, "This must be in your backpack to use.");
				return;
			}

			NewDaat99Holder dh = (NewDaat99Holder)daat99.Daat99OWLTR.TempHolders[from];

			string s_Key = t_Recipe.Name, s_Temp = t_Recipe.Name;
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

			if ( dh.ItemTypeList == null )
				dh.ItemTypeList = new ArrayList();
			else if ( dh.ItemTypeList.Contains( t_Recipe ) )
			{
				dh.ItemTypeList.Remove((Type)t_Recipe);
				from.SendMessage(88, "You learned how to make {0}.", s_Key);
				Delete();
				return;
			}
			from.SendMessage(33, "You already know how to make {0}!!!", s_Key);
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			if ( t_Recipe == null  )
				return;
			string s_Key = t_Recipe.Name, s_Temp = t_Recipe.Name;
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
			list.Add( 1060844, "{0}", s_Key );
		}
		
		public CraftingRecipe( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 

			writer.Write( (string) t_Recipe.Name );
		}

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 

			try
			{
				t_Recipe = ScriptCompiler.FindTypeByName(reader.ReadString());
			}
			catch
			{
				t_Recipe = null;
			}
		} 
	}
}