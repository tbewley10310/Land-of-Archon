namespace Server.Items
{
	public abstract class BaseServerBirthRare : Item
	{
		private bool m_HasBeenMoved;
		private bool m_CantBeLifted;

		public override bool ForceShowProperties
		{
			get { return ObjectPropertyList.Enabled; }
		}

		protected BaseServerBirthRare(int itemID) : base(itemID)
		{
			Movable = false;
			Weight = 10.0;
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add("Server Birth Rare");
		}

		public override bool VerifyMove(Mobile from)
		{
			if (m_CantBeLifted)
			{
				return false;
			}

			if (this.Movable != false || m_HasBeenMoved != false)
			{
				return Movable;
			}
			this.Movable = true;
			m_HasBeenMoved = true;
			return true;
		}

		public BaseServerBirthRare(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_HasBeenMoved);
			writer.Write(m_CantBeLifted);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
			switch (version)
			{
				case 0:
				{
					m_HasBeenMoved = reader.ReadBool();
					m_CantBeLifted = reader.ReadBool();
					break;
				}
			}
		}
	}

	public abstract class BaseServerBirthRareCont : Container
	{
		private bool m_HasBeenMoved;

		protected virtual int ArtifactRarity
		{
			get { return 0; }
		}

		public override bool ForceShowProperties
		{
			get { return ObjectPropertyList.Enabled; }
		}

		protected BaseServerBirthRareCont(int itemID) : base(itemID)
		{
			Movable = false;
			Weight = 10.0;
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);


			if (ArtifactRarity > 0)
			{
				list.Add(1061078, ArtifactRarity.ToString());
			}
		}

		public override bool VerifyMove(Mobile from)
		{
			if (this.Movable != false || m_HasBeenMoved != false)
			{
				return Movable;
			}
			this.Movable = true;
			m_HasBeenMoved = true;
			return true;
		}

		protected BaseServerBirthRareCont(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_HasBeenMoved);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
			switch (version)
			{
				case 0:
				{
					m_HasBeenMoved = reader.ReadBool();
					break;
				}
			}
		}
	}
}