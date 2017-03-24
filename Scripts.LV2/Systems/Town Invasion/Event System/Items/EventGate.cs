using System;
using Server.Items;

namespace Server.EventSystem
{
	public class EventGate : Moongate
	{
		private BaseEvent m_Event;

		[Constructable]
		public EventGate( BaseEvent e )
			: base()
		{
			m_Event = e;

			Hue = 1153;
			Name = e.EventName + " Gate";
			Dispellable = false;

			Target = e.StartingLocation;
			TargetMap = e.StartingMap;
		}

		public EventGate( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Delete();
		}
	}
}