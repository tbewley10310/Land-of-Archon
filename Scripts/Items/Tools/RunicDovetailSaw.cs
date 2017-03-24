using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
    public class RunicDovetailSaw : BaseRunicTool
    {
        [Constructable]
        public RunicDovetailSaw(CraftResource resource)
            : base(resource, 0x1028)
        {
            this.Weight = 2.0;
            this.Hue = CraftResources.GetHue(resource);
        }

        [Constructable]
        public RunicDovetailSaw(CraftResource resource, int uses)
            : base(resource, uses, 0x1028)
        {
            this.Weight = 2.0;
            this.Hue = CraftResources.GetHue(resource);
        }

        public RunicDovetailSaw(Serial serial)
            : base(serial)
        {
        }

        public override CraftSystem CraftSystem
        {
            get
            {
                return DefCarpentry.CraftSystem;
            }
        }
        public override int LabelNumber
        {
            get
            {
                int index = CraftResources.GetIndex(this.Resource);

                if (index >= 1 && index <= 6)
                    return 1072633 + index;
					
                return 1024137; // dovetail saw
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

		//daat99 OWTLR start - runic storage
		public override System.Type GetCraftableType()
		{
			switch (Resource)
			{
				case CraftResource.OakWood:
                    return typeof(OakRunicDovetailSaw);
				case CraftResource.AshWood:
                    return typeof(AshRunicDovetailSaw);
				case CraftResource.YewWood:
                    return typeof(YewRunicDovetailSaw);
				case CraftResource.Heartwood:
                    return typeof(HeartwoodRunicDovetailSaw);
				case CraftResource.Bloodwood:
                    return typeof(BloodwoodRunicDovetailSaw);
				case CraftResource.Frostwood:
                    return typeof(FrostwoodRunicDovetailSaw);
				case CraftResource.Ebony:
                    return typeof(EbonyRunicDovetailSaw);
				case CraftResource.Bamboo:
                    return typeof(BambooRunicDovetailSaw);
				case CraftResource.PurpleHeart:
                    return typeof(PurpleHeartRunicDovetailSaw);
				case CraftResource.Redwood:
                    return typeof(RedwoodRunicDovetailSaw);
				case CraftResource.Petrified:
                    return typeof(PetrifiedRunicDovetailSaw);
				default:
					return null;
			}
		}
		//daat99 OWLTR end - runic storage
	}
}