/*

$Id: 

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

*/

using System;

namespace Server.Items
{
    public class PowerScrollBookEntry
    {
        private SkillName m_Skill;
        private int m_SkillValue;
        private int m_Price;

        public SkillName Skill
        {
            get { return m_Skill; }
            set { m_Skill = value; }
        }

        public int SkillValue
        {
            get { return m_SkillValue; }
            set { m_SkillValue = value; }
        }

        public int Price
        {
            get { return m_Price; }
            set { m_Price = value; }
        }

        public Item Reconstruct()
        {
            return (new PowerScroll(m_Skill, m_SkillValue));
        }

        public PowerScrollBookEntry(PowerScroll ps)
        {
            m_Skill = ps.Skill;
            m_SkillValue = (int)ps.Value;
        }

        public PowerScrollBookEntry(GenericReader reader)
        {
            int version = reader.ReadEncodedInt();

            switch (version)
            {
                case 0:
                    m_Skill = (SkillName)reader.ReadEncodedInt();
                    m_SkillValue = reader.ReadEncodedInt();
                    m_Price = reader.ReadEncodedInt();
                    break;
            }
        }

        public void Serialize(GenericWriter writer)
        {
            writer.WriteEncodedInt((int)0);

            writer.WriteEncodedInt((int)m_Skill);
            writer.WriteEncodedInt((int)m_SkillValue);
            writer.WriteEncodedInt((int)m_Price);
        }
    }
}