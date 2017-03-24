using System;
using Server;
using Server.Network;
using System.Collections;
using System.Collections.Generic;

namespace Server.Items
{

	public class DaemonSword : Item
	{
		[Constructable]
		public DaemonSword() : base(0x2554)
		{
            Name = "Daemon Sword";
			Weight = 1.0;
		}

        public DaemonSword(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	
	public class EttinHammer : Item
	{
		[Constructable]
		public EttinHammer() : base(0x2555)
		{
            Name = "Ettin Hammer";
			Weight = 1.0;
		}

        public EttinHammer(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	
	public class FrostTrollClub : Item
	{
		[Constructable]
		public FrostTrollClub() : base(0x2566)
		{
            Name = "FrostTroll Club";
			Weight = 1.0;
		}

        public FrostTrollClub(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 4.0 )
				Weight = 1.0;
		}
	}

	
	public class LichesStaff : Item
	{
		[Constructable]
		public LichesStaff() : base(0x2556)
		{
            Name = "Liche's Staff";
			Weight = 1.0;
		}

        public LichesStaff(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( Weight == 4.0 )
				Weight = 1.0;
		}
	}

    
    public class LizardmansSpear : Item
    {
        [Constructable]
        public LizardmansSpear()
            : base(0x2558)
        {
            Name = "Lizardman's Spear";
            Weight = 1.0;
        }

        public LizardmansSpear(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }
    
    public class MagicStaff : Item
    {
        [Constructable]
        public MagicStaff()
            : base(0x256E)
        {
            Name = "Magic Staff";
            Weight = 1.0;
        }

        public MagicStaff(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }
    
    public class OgresClub : Item
    {
        [Constructable]
        public OgresClub()
            : base(0x2559)
        {
            Name = "Ogre's Club";
            Weight = 1.0;
        }

        public OgresClub(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }
    
    public class OphidianBardiche : Item
    {
        [Constructable]
        public OphidianBardiche()
            : base(0x255B)
        {
            Name = "Ophidian Bardiche";
            Weight = 1.0;
        }

        public OphidianBardiche(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }
    
    public class OrcLordBattleaxe : Item
    {
        [Constructable]
        public OrcLordBattleaxe()
            : base(0x2567)
        {
            Name = "Orc Lord Battleaxe";
            Weight = 1.0;
        }

        public OrcLordBattleaxe(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }
    
    public class TerathanSpear : Item
    {
        [Constructable]
        public TerathanSpear()
            : base(0x2562)
        {
            Name = "Terathan Spear";
            Weight = 1.0;
        }

        public TerathanSpear(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }
    
    public class TrollMaul : Item
    {
        [Constructable]
        public TrollMaul()
            : base(0x2565)
        {
            Name = "Troll Maul";
            Weight = 1.0;
        }

        public TrollMaul(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (Weight == 4.0)
                Weight = 1.0;
        }
    }
}