using System;
using System.Collections.Generic;

using Server;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;

namespace CustomsFramework.Systems.AnimalBODSystem
{
    public class AnimalBODCore : BaseCore
    {
        public const String SystemVersion = "1.0.0";

        private static AnimalBODCore m_Core;
        public static AnimalBODCore Core { get { return m_Core; } }

        public AnimalBODCore() : base()
        {
            this.Enabled = true;
        }

        public AnimalBODCore(CustomSerial serial) : base(serial)
        {
        }

        public override String Name { get { return "Animal BOD Core"; } }
        public override String Description { get { return "Core that contains everything for the Animal BOD System."; } }
        public override String Version { get { return SystemVersion; } }
        public override AccessLevel EditLevel { get { return AccessLevel.Developer; } }
        public override Gump SettingsGump { get { return null; } }

        public static void Initialize()
        {
            AnimalBODCore core = World.GetCore(typeof(AnimalBODCore)) as AnimalBODCore;

            if (core == null)
            {
                core = new AnimalBODCore();

                core.Prep();
            }

            m_Core = core;
            
            CommandSystem.Register("ABODToggle", AccessLevel.Developer, new CommandEventHandler(ABODToggle_OnCommand));
        }

        // Called after all cores are loaded
        public override void Prep()
        {
        	return;
        }
        
        [Usage("ABODToggle")]
        [Description("Toggles the Animal BOD System on and off.")]
        public static void ABODToggle_OnCommand(CommandEventArgs e)
        {
            if (AnimalBODCore.Core == null)
                return;

            if ( AnimalBODCore.Core.Enabled )
            {
            	AnimalBODCore.Core.Enabled = false;
            	e.Mobile.SendMessage( "You have disabled the animal bod system." );
            }
            else
            {
            	AnimalBODCore.Core.Enabled = true;
            	e.Mobile.SendMessage( "you have enabled the animal bod system." );
            }
            	
        }
        
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            Utilities.WriteVersion(writer, 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            Int32 version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    break;
            }
        }
    }
}