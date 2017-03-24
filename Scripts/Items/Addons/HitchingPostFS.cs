using System;
using Server;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Items
{
    [Flipable(0x14E8, 0x14E7)]
    public class HitchingPostFS : AddonComponent
    {
        private int m_Charges = 100;

        [CommandProperty(AccessLevel.GameMaster)]
        public int Charges
        {
            get { return m_Charges; }
            set { m_Charges = value; InvalidateProperties(); }
        }

        public override bool ForceShowProperties { get { return ObjectPropertyList.Enabled; } }

        #region Constructors
        [Constructable]
        public HitchingPostFS()
            : this(0x14E7)
        {
        }

        [Constructable]
        public HitchingPostFS(int itemID)
            : base(itemID)
        {
        }

        public HitchingPostFS(Serial serial)
            : base(serial)
        {
        }
        #endregion

        public override void OnDoubleClick(Mobile from)
        {
            from.SendMessage(53, "ERROR: Addon no longer in use. A new addon deed has been added to your backpack");

            if (this.ItemID == 0x14E7)
            {
                from.AddToBackpack(new NewHitchingPostEastDeed());
            }
            else if (this.ItemID == 0x14E8)
            {
                from.AddToBackpack(new NewHitchingPostSouthDeed());
            }

            this.Delete();
        }

        public override void AddNameProperties(ObjectPropertyList list)
        {
            base.AddNameProperties(list);

            list.Add(1060658, "Charges\t{0}", m_Charges.ToString());
        }

        #region Serialization
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_Charges);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Charges = reader.ReadInt();
        }
        #endregion
        private class HitchingPostFSTarget : Target
        {
            private Mobile m_Owner;

            private HitchingPost m_Powder;

            public HitchingPostFSTarget(HitchingPost charge)
                : base(10, false, TargetFlags.None)
            {
                m_Powder = charge;
            }

            protected override void OnTarget(Mobile from, object target)
            {

                if (target == from)
                {
                    from.SendMessage("You cant shrink yourself!");
                }
                else if (target is PlayerMobile)
                {
                    from.SendMessage("That person gives you a dirty look.");
                }
                else if (target is Item)
                {
                    from.SendMessage("You can only shrink pets that you own");
                }
                else if (target is BaseBioCreature)
                {
                    from.SendMessage("Unnatural creatures cannot be shrunk");
                }
                else if (Server.Spells.SpellHelper.CheckCombat(from))
                {
                    from.SendMessage("You cannot shrink your pet while your fighting.");
                }
                else if (target is BaseCreature)
                {
                    BaseCreature c = (BaseCreature)target;

                    bool packanimal = false;
                    Type typ = c.GetType();
                    string nam = typ.Name;

                    foreach (string ispack in FSATS.PackAnimals)
                    {
                        if (ispack == nam)
                            packanimal = true;
                    }

                    if (c.BodyValue == 400 || c.BodyValue == 401 && c.Controlled == false)
                    {
                        from.SendMessage("That person gives you a dirty look.");
                    }
                    else if (c.ControlMaster != from && c.Controlled == false)
                    {
                        from.SendMessage("This is not your pet.");
                    }
                    else if (packanimal == true && (c.Backpack != null && c.Backpack.Items.Count > 0))
                    {
                        from.SendMessage("You must unload your pets backpack first.");
                    }
                    else if (c.IsDeadPet)
                    {
                        from.SendMessage("You cannot shrink the dead.");
                    }
                    else if (c.Summoned)
                    {
                        from.SendMessage("You cannot shrink a summoned creature.");
                    }
                    else if (c.Combatant != null && c.InRange(c.Combatant, 12) && c.Map == c.Combatant.Map)
                    {
                        from.SendMessage("Your pet is fighting, You cannot shrink it yet.");
                    }
                    else if (c.BodyMod != 0)
                    {
                        from.SendMessage("You cannot shrink your pet while its polymorphed.");
                    }
                    //else if ( Server.Spells.LostArts.CharmBeastSpell.IsCharmed( c ) )
                    //{
                    //	from.SendMessage( "Your hold over this pet is not strong enough to shrink it." );
                    //}
                    else if (c.Controlled == true && c.ControlMaster == from)
                    {
                        Type type = c.GetType();
                        ShrinkItem si = new ShrinkItem();
                        si.MobType = type;
                        si.Pet = c;
                        si.PetOwner = from;
                        if (c is BaseMount)
                        {
                            BaseMount mount = (BaseMount)c;
                            si.MountID = mount.ItemID;
                        }
                        from.AddToBackpack(si);

                        IEntity p1 = new Entity(Serial.Zero, new Point3D(from.X, from.Y, from.Z), from.Map);
                        IEntity p2 = new Entity(Serial.Zero, new Point3D(from.X, from.Y, from.Z + 50), from.Map);

                        Effects.SendMovingParticles(p2, p1, ShrinkTable.Lookup(c), 1, 0, true, false, 0, 3, 1153, 1, 0, EffectLayer.Head, 0x100);
                        from.PlaySound(492);

                        c.Delete();
                        m_Powder.Charges -= 1;
                        if (m_Powder.Charges == 0)
                            m_Powder.Delete();
                    }

                }
            }
        }
    }

	public class HitchingPostEastFSAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new HitchingPostEastFSDeed(); } }

		[Constructable]
		public HitchingPostEastFSAddon()
		{
			AddComponent( new HitchingPostFS( 0x14E7 ), 0, 0, 0);
		}

		public HitchingPostEastFSAddon( Serial serial ) : base( serial )
		{
		}

		#region Serialization
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
		#endregion
	}

	public class HitchingPostEastFSDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new HitchingPostEastFSAddon(); } }

		[Constructable]
		public HitchingPostEastFSDeed()
		{
			Name="Hitching Post (east)";
		}

		public HitchingPostEastFSDeed( Serial serial ) : base( serial )
		{
		}

		#region Serialization
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
		#endregion
	}

	
	public class HitchingPostSouthFSAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new HitchingPostSouthFSDeed(); } }

		[Constructable]
		public HitchingPostSouthFSAddon()
		{
			AddComponent( new HitchingPostFS( 0x14E8 ), 0, 0, 0);
		}

		public HitchingPostSouthFSAddon( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( 53, "ERROR: Addon no longer in use. A new addon deed has been added to your backpack" );
			
			from.AddToBackpack( new NewHitchingPostSouthDeed() );
		}

		#region Serialization
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
		#endregion
	}

	public class HitchingPostSouthFSDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new HitchingPostSouthFSAddon(); } }

		[Constructable]
		public HitchingPostSouthFSDeed()
		{
			Name="Hitching Post (south)";
		}

		public HitchingPostSouthFSDeed( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage( 53, "ERROR: Addon no longer in use. A new addon deed has been added to your backpack" );
			
			from.AddToBackpack( new NewHitchingPostEastDeed() );
		}

		#region Serialization
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
		#endregion
	}

}
