using System;

namespace Server.EventSystem
{
	public class EventPersistance : Item
	{
		private static EventPersistance m_Instance;

		public static EventPersistance Instance { get { return m_Instance; } }

		public override string DefaultName
		{
			get { return "EventSystem Persistance - Internal"; }
		}

		public EventPersistance()
			: base( 1 )
		{
			Movable = false;

			if ( m_Instance == null || m_Instance.Deleted )
				m_Instance = this;
			else
				base.Delete();
		}

		public EventPersistance( Serial serial )
			: base( serial )
		{
			m_Instance = this;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version

			EventCore.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					EventCore.Deserialize( reader );
					break;
				}
			}
		}

		public override void Delete()
		{
		}
	}
}