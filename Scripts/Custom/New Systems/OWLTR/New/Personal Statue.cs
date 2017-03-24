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
///made by daat99
///idea by Sunshine
using System;

namespace Server.Items
{
	public class PersonalStatueDeed : Item
	{
		[Constructable]
		public PersonalStatueDeed() : base( 5360 )
		{
			Name = "Personal Statue Deed";
		}

		public PersonalStatueDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
		public override void OnDoubleClick( Mobile from )
		{
			if (Deleted)
				return;
			if ( IsChildOf(from.Backpack) )
			{
				if (from.Body.IsMale)
					from.PlaySound(1054); //woohoo
				else
					from.PlaySound(783); //woohoo
				from.SendMessage( "Here's your personal statue {0}, enjoy", from.Name ); 					
				from.AddToBackpack( new PersonalStatue(from) );
				Delete();
			}
		}
	}
	public class PersonalStatue : Item
	{
		private DateTime m_NextActive;
		public PersonalStatue( Mobile from ) : base( 4645 )
		{
			Name = from.Name + "'s statue";
			if (from.Body.IsMale)
				switch (Utility.Random(6))
			{
				case 0: ItemID = 4811; break;
				case 1: ItemID = 4810; break;
				case 2: ItemID = 5020; break;
				case 3: ItemID = 4647; break;				
				case 4: ItemID = 5021; break;
				case 5: ItemID = 4648; break;
				case 6: ItemID = 4644; break;
			}
			else
				switch (Utility.Random(9))
				{
					case 0: ItemID = 4811; break;
					case 1: ItemID = 4810; break;
					case 2: ItemID = 5018; break;
					case 3: ItemID = 5019; break;
					case 4: ItemID = 4645; break;
					case 5: ItemID = 5021; break;
					case 6: ItemID = 4648; break;
					case 7: ItemID = 4644; break;
					case 8: ItemID = 4646; break;
				}
		}

		public PersonalStatue( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if (Deleted || m_NextActive > DateTime.Now)
				return;
			m_NextActive = DateTime.Now + TimeSpan.FromSeconds( 2.0 );
			if (from.Body.IsMale)
				switch (Utility.Random(10))
				{
					case 0: from.PlaySound(1051); from.Say("I've nothing to say..."); break;
					case 1: from.PlaySound(1055); from.Say("I think he missed a spot..."); break;
					case 2: from.PlaySound(1058); from.Say("Why don't I have one :("); break;
					case 3: from.PlaySound(1065); from.Say("That's breathtaking..."); break;
					case 4: from.PlaySound(1066); from.Say("That hair looks funny..."); break;
					case 5: from.PlaySound(1069); from.Say("Hey, I wanted that!!!"); break;
					case 6: from.PlaySound(1071); from.Say("What's that???"); break;
					case 7: from.PlaySound(1073); from.Say("Look at this nose..."); break;
					case 8: from.PlaySound(1087); from.Say("That's so ugly..."); break;
					case 9: from.PlaySound(1088); from.Say("That zit is HUGE..."); break;
				}
			else 
				switch (Utility.Random(10))
				{
					case 0: from.PlaySound(780); from.Say("I've nothing to say..."); break;
					case 1: from.PlaySound(784); from.Say("I think he missed a spot..."); break;
					case 2: from.PlaySound(787); from.Say("Why don't I have one :("); break;
					case 3: from.PlaySound(793); from.Say("That's breathtaking..."); break;
					case 4: from.PlaySound(794); from.Say("That hair looks funny..."); break;
					case 5: from.PlaySound(797); from.Say("Hey, I wanted that!!!"); break;
					case 6: from.PlaySound(799); from.Say("What's that???"); break;
					case 7: from.PlaySound(801); from.Say("Look at this nose..."); break;
					case 8: from.PlaySound(813); from.Say("That's so ugly..."); break;
					case 9: from.PlaySound(814); from.Say("That zip is HUGE..."); break;
				}
		}
	}
}