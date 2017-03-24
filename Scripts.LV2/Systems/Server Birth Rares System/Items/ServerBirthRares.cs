#region References

using Server.Network;

#endregion

namespace Server.Items
{
    public class ServerBirthSpittoon : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSpittoon() : base(0x1003)
        {
            Name = "a spittoon";
        }

        public ServerBirthSpittoon(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthDirtyPan : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthDirtyPan() : base(0x9E8)
        {
            Name = "a dirty pan";
        }

        public ServerBirthDirtyPan(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthDirtyPot : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthDirtyPot() : base(0x9E6)
        {
            Name = "a dirty pot";
        }

        public ServerBirthDirtyPot(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthDirtyKettle : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthDirtyKettle() : base(0x9DC)
        {
            Name = "a dirty kettle";
        }

        public ServerBirthDirtyKettle(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthWoodCurls : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthWoodCurls() : base(0x1038)
        {
            Name = "wood curls";
        }

        public ServerBirthWoodCurls(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthWig : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthWig() : base(0xE0E)
        {
            Name = "a wig";
        }

        public ServerBirthWig(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthCutHair : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthCutHair() : base(0xDFE)
        {
            Name = "cut hair";
        }

        public ServerBirthCutHair(Serial serial) : base(serial)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthBarberScissors : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthBarberScissors() : base(0xDFC)
        {
            Name = "barber scissors";
        }

        public ServerBirthBarberScissors(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthPlayingCardsNorth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthPlayingCardsNorth() : base(0xE15)
        {
            Name = "playing cards";
        }

        public ServerBirthPlayingCardsNorth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthPlayingCardsSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthPlayingCardsSouth() : base(0xE16)
        {
            Name = "playing cards";
        }

        public ServerBirthPlayingCardsSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthCeramicMug : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthCeramicMug() : base(0x995)
        {
            Name = "a ceramic mug";
        }

        public ServerBirthCeramicMug(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthChessmenBlackNorth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthChessmenBlackNorth() : base(0xE12)
        {
            Name = "chess pieces";
        }

        public ServerBirthChessmenBlackNorth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthChessmenBlackWest : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthChessmenBlackWest() : base(0xE13)
        {
            Name = "chess pieces";
        }

        public ServerBirthChessmenBlackWest(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthChessmenWhiteEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthChessmenWhiteEast() : base(0xE14)
        {
            Name = "chess pieces";
        }

        public ServerBirthChessmenWhiteEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthChessmenWhiteSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthChessmenWhiteSouth() : base(0xFA8)
        {
            Name = "chess pieces";
        }

        public ServerBirthChessmenWhiteSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthDartBoardWithKnives : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthDartBoardWithKnives() : base(0x1E32)
        {
            Name = "a dart board";
        }

        public ServerBirthDartBoardWithKnives(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthBlueGlass : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthBlueGlass() : base(0x1F82)
        {
            Name = "a glass";
        }

        public ServerBirthBlueGlass(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthGoldenGoblet : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthGoldenGoblet() : base(0x9B3)
        {
            Name = "a golden goblet";
        }

        public ServerBirthGoldenGoblet(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthCheckersRedWest : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthCheckersRedWest() : base(0xE1A)
        {
            Name = "checkers";
        }

        public ServerBirthCheckersRedWest(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthCheckersWhiteEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthCheckersWhiteEast() : base(0xE1B)
        {
            Name = "checkers";
        }

        public ServerBirthCheckersWhiteEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthCheckersRedNorth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthCheckersRedNorth() : base(0xFA4)
        {
            Name = "checkers";
        }

        public ServerBirthCheckersRedNorth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthCheckersWhiteSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthCheckersWhiteSouth() : base(0xFA5)
        {
            Name = "checkers";
        }

        public ServerBirthCheckersWhiteSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthPlayingCards : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthPlayingCards() : base(0xFA3)
        {
            Name = "playing cards";
        }

        public ServerBirthPlayingCards(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthSkullMug : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSkullMug() : base(0xFFB)
        {
            Name = "a skull mug";
        }

        public ServerBirthSkullMug(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthSkinnedDeerSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSkinnedDeerSouth() : base(0x1E90)
        {
            Name = "a skinned deer";
        }

        public ServerBirthSkinnedDeerSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthSkinnedDeerEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSkinnedDeerEast() : base(0x1E91)
        {
            Name = "a skinned deer";
        }

        public ServerBirthSkinnedDeerEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthSkinnedGoatSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSkinnedGoatSouth() : base(0x1E88)
        {
            Name = "a skinned goat";
        }

        public ServerBirthSkinnedGoatSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthSkinnedGoatEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSkinnedGoatEast() : base(0x1E89)
        {
            Name = "a skinned goat";
        }

        public ServerBirthSkinnedGoatEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthDishingStump : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthDishingStump() : base(0x1865)
        {
            Name = "a dishing stump";
        }

        public ServerBirthDishingStump(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthEmptyJar : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthEmptyJar() : base(0x1005)
        {
            Name = "an empty jar";
        }

        public ServerBirthEmptyJar(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthEmptyJars : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthEmptyJars() : base(0xE46)
        {
            Name = "empty jars";
        }

        public ServerBirthEmptyJars(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthFullJar : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthFullJar() : base(0x1006)
        {
            Name = "a full jar";
        }

        public ServerBirthFullJar(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthFilledJars : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthFilledJars() : base(0xE4B)
        {
            Name = "filled jars";
        }

        public ServerBirthFilledJars(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthGinseng : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthGinseng() : base(0x18EB)
        {
            Name = "ginseng";
        }

        public ServerBirthGinseng(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthHourglass : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthHourglass() : base(0x1811)
        {
            Name = "an hourglass";
        }

        public ServerBirthHourglass(Serial serial) : base(serial)
        {
        }


        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthMandrakeRoot : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthMandrakeRoot() : base(0x18DD)
        {
            Name = "mandrake root";
        }

        public ServerBirthMandrakeRoot(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthEmptyVials : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthEmptyVials() : base(0x185B)
        {
            Name = "empty vials";
        }

        public ServerBirthEmptyVials(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthFilledVials : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthFilledVials() : base(0x185D)
        {
            Name = "filled vials";
        }

        public ServerBirthFilledVials(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthLogsSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthLogsSouth() : base(0x1BDE)
        {
            Name = "log pile";
        }

        public ServerBirthLogsSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthLogsEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthLogsEast() : base(0x1BE1)
        {
            Name = "log pile";
        }

        public ServerBirthLogsEast(Serial serial) : base(serial)
        {
        }


        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthLogsLargeEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthLogsLargeEast() : base(0x1BDF)
        {
            Name = "log pile";
        }

        public ServerBirthLogsLargeEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthLogsLargeSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthLogsLargeSouth() : base(0x1BE2)
        {
            Name = "log pile";
        }

        public ServerBirthLogsLargeSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthShafts : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthShafts() : base(0x1BD6)
        {
            Name = "shafts";
        }

        public ServerBirthShafts(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthOpenBookSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthOpenBookSouth() : base(0xFBE)
        {
            Name = "a book";
        }

        public ServerBirthOpenBookSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthOpenBookWest : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthOpenBookWest() : base(0xFBD)
        {
            Name = "a book";
        }

        public ServerBirthOpenBookWest(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthSheetMusicSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSheetMusicSouth() : base(0xEBF)
        {
            Name = "sheet music";
        }

        public ServerBirthSheetMusicSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthSheetMusicEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSheetMusicEast() : base(0xEC0)
        {
            Name = "sheet music";
        }

        public ServerBirthSheetMusicEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthGoldIngot : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthGoldIngot() : base(0x1BE9)
        {
            Name = "a gold ingot";
        }

        public ServerBirthGoldIngot(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthGoldIngots : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthGoldIngots() : base(0x1BEB)
        {
            Name = "gold ingots";
        }

        public ServerBirthGoldIngots(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthSilverIngot : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSilverIngot() : base(0x1BF5)
        {
            Name = "a silver ingot";
        }

        public ServerBirthSilverIngot(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthSilverIngots : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSilverIngots() : base(0x1BF7)
        {
            Name = "silver ingots";
        }

        public ServerBirthSilverIngots(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthBoardSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthBoardSouth() : base(0x1E6E)
        {
            Name = "a board";
        }

        public ServerBirthBoardSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthBoardEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthBoardEast() : base(0x1E77)
        {
            Name = "a board";
        }

        public ServerBirthBoardEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthMauldingBoardSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthMauldingBoardSouth() : base(0x14E9)
        {
            Name = "a maulding board";
        }

        public ServerBirthMauldingBoardSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthMauldingBoardEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthMauldingBoardEast() : base(0x14EA)
        {
            Name = "a maulding board";
        }

        public ServerBirthMauldingBoardEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthUnfinishedChairSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthUnfinishedChairSouth() : base(0x1E6F)
        {
            Name = "an unfinished chair";
        }

        public ServerBirthUnfinishedChairSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthUnfinishedChairEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthUnfinishedChairEast() : base(0x1E78)
        {
            Name = "an unfinished chair";
        }

        public ServerBirthUnfinishedChairEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthUnfinishedDrawersSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthUnfinishedDrawersSouth() : base(0x1E71)
        {
            Name = "an unfinished chest of drawers";
        }

        public ServerBirthUnfinishedDrawersSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthUnfinishedDrawersEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthUnfinishedDrawersEast() : base(0x1E7A)
        {
            Name = "an unfinished chest of drawers";
        }

        public ServerBirthUnfinishedDrawersEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthUnfinishedDrawer : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthUnfinishedDrawer() : base(0x1E79)
        {
            Name = "an unfinished drawer";
        }

        public ServerBirthUnfinishedDrawer(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthScarecrowSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthScarecrowSouth() : base(0x1E34)
        {
            Name = "a scarecrow";
        }

        public ServerBirthScarecrowSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthScarecrowEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthScarecrowEast() : base(0x1E35)
        {
            Name = "a scarecrow";
        }

        public ServerBirthScarecrowEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthFishingWeight : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthFishingWeight() : base(0xDCF)
        {
            Name = "a fishing weight";
        }

        public ServerBirthFishingWeight(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthTarotCards : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthTarotCards() : base(0x12A5)
        {
            Name = "tarot cards";
        }

        public ServerBirthTarotCards(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthBloodyBandage : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthBloodyBandage() : base(0xE22)
        {
            Name = "a bloody bandage";
        }

        public ServerBirthBloodyBandage(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthBloodyWater : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthBloodyWater() : base(0xE23)
        {
            Name = "a bowl of bloody water";
        }

        public ServerBirthBloodyWater(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthStackOfBooks : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthStackOfBooks() : base(0x1E24)
        {
            Name = "a stack of books";
        }

        public ServerBirthStackOfBooks(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthFoldedCloth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthFoldedCloth() : base(0x175F)
        {
            Name = "folded cloth";
        }

        public ServerBirthFoldedCloth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthKnittingNeedles : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthKnittingNeedles() : base(0xDF7)
        {
            Name = "knitting needles";
        }

        public ServerBirthKnittingNeedles(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthStretchedHideSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthStretchedHideSouth() : base(0x107A)
        {
            Name = "stretched hide";
        }

        public ServerBirthStretchedHideSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthStretchedHideLightSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthStretchedHideLightSouth() : base(0x107B)
        {
            Name = "stretched hide";
        }

        public ServerBirthStretchedHideLightSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthStretchedHideEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthStretchedHideEast() : base(0x106A)
        {
            Name = "stretched hide";
        }

        public ServerBirthStretchedHideEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthWoodenTraySouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthWoodenTraySouth() : base(0x991)
        {
            Name = "a wooden tray";
        }

        public ServerBirthWoodenTraySouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthWoodenTrayEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthWoodenTrayEast() : base(0x992)
        {
            Name = "a wooden tray";
        }

        public ServerBirthWoodenTrayEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthSilverwareSouth : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSilverwareSouth() : base(0x9D4)
        {
            Name = "silverware";
        }

        public ServerBirthSilverwareSouth(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthSilverwareEast : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthSilverwareEast() : base(0x9D5)
        {
            Name = "silverware";
        }

        public ServerBirthSilverwareEast(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthPot : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthPot() : base(0x9E1)
        {
            Name = "a pot";
        }

        public ServerBirthPot(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthKettle : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthKettle() : base(0x9ED)
        {
            Name = "a kettle";
        }

        public ServerBirthKettle(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ServerBirthEggshells : BaseServerBirthRare
    {
        [Constructable]
        public ServerBirthEggshells() : base(0x9B4)
        {
            Name = "egg shells";
        }

        public ServerBirthEggshells(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}