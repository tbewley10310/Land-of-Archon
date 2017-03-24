MilkandCheese by Crystal 2003
(http://invisionfree.com/forums/Hyel_dev/index.php)

[The original post with this seems to be gone,
I haven't been able to find it again.]


This is a system for milking cows, sheep, and goats, and producing cheese from
that milk with a cheese form.


TODO: Include variable weight. Maybe 1 liter = 1 stone? I know that's kinda
heavy, but then again, big buckets full of milk ARE heavy. And this bucket
supposedly holds equivalent liquid of  *25*  2-liters. Can you carry that?


-------------------------------------------------------

Tool Items included: (add these to appropriate vendors)

MilkBucket - Double click and target a cow, sheep, or goat to gather milk. The
animal will tire out and need a rest after a little while. Once you have milk
gathered you can fill a cheese form with it (needs 15 liters) or fill a potion
bottle (needs one liter). Once you start milking a certain type of animal, you
can't switch with that bucket until it's empty. (For example, you can gather 15
liters from a cow, fill a cheese form, and start milking a sheep or goat, but
you can't milk 2 liters from a cow, fill a potion bottle, and then try and milk
a goat or sheep from that same bucket, since it will still have milk in it.
Buckets hold 50 liters.

CheeseForm - Fill with milk from a bucket then double-click to start the
fermentation process. Once the fermentation process is complete you can harvest
cheese from the form. There is a small chance based on the cooking skill of the
character to fail, as well as a small chance to get a magic cheese.

Both of these items have very detailed gumps (one was already in place, the
other I wrote myself based on the first) I had to translate the first, I believe
I did a fairly decent job of it, using Google and then my understanding of how
the system worked to refine the descriptions. Basically if you do anything wrong
the gump will pop up letting you know what the most likely problem was, and
giving a good description of how to use the items.

----------------------------------------------------------

Food Items included:

BottleCowMilk - A potion bottle filled with cow milk.
BottleGoatMilk -      "      "      "       goat milk.
BottleSheepMilk -     "      "      "       sheep milk.

---------------------------------------------------------

FromageDeVache - a full wheel of cow cheese
FromageDeVacheWedge - a 3/4 wheel of cow cheese
FromageDeVacheWedgeSmall - a 1/4 wedge of cow cheese

FromageDeChevre - a full wheel of goat cheese
FromageDeChevreWedge - a 3/4 wheel of goat cheese
FromageDeChevreWedgeSmall - a 1/4 wedge of goat cheese

FromageDeBrebis - a full wheel of sheep cheese
FromageDeBrebisWedge - a 3/4 wheel of sheep cheese
FromageDeBrebisWedgeSmall - sheep


The full wheels can be carved to produce
one "3/4" wheel (called "[name]Wedge")
and one "1/4" wedge (called "[name]WedgeSmall")

The "3/4" wheels can be carved to produce
3 more "1/4" wedges. (called "[name]WedgeSmall")

There's no actual name difference on the item objects themselves, since the
graphic changes make it obvious.


These were modified by me to be carvable, I used the same carving system that I
added to the 'ordinary' cheese in the main food package. However, the new wedges
are all unique objects, they won't "mix" with each other or with regular cheese
(I made the mistake of trying to base the new cheese off the original. Oops. =)

The carving system was added to other objects too, as a way to divide portions
for cooking or consumption. (That, and it felt silly needing a whole wheel of
cheese to make a pizza. Have you ever SEEN a wheel of cheese? The things are
huge! I'm not talking about those rinky-dink li'l shrink-wrapped "wheels", I'm
talking about a full, REAL wheel of cheese. They're BIG. Like, you could spend a
week snacking on one.)

-----------------------------------------------------------

Magic Food Items included: (these work like the magic fish)

FromageDeChevreMagic - Magic goat cheese. Boosts strength.
FromageDeVacheMagic - Magic cow cheese. Boosts intelligence.
FromageDeBrebisMagic - Magic sheep cheese. Boosts dexterity.

You get these occasionally while making cheese. They're not
useful in a cooking sense (yet) so not all that great.
Then again, those "special" fish are kinda junk too, considering.



That pretty much covers it. A lot of rambling for what would seem to be a simple
system, huh? :> I hope you enjoy this, and thank you for reading. ^.^

All I did on this was the translation, and adding in the carving up of large
wheels of custom cheese. Again, the rest of the coding was done by Crystal 2003.


Alari (alarihyena@gmail.com)