using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.library;
using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class BaseNode : monster.Monster
    {
        public int Hits = 0;
        public virtual script.item.BaseOre OreDrop { get { return null; } }

        public virtual void Hit(Player player)
        {
            Hits++;
            if (Hits % 10 == 0)
            {
                OreDrop.DropOre(player);
                if (Hits >= 100)
                    Alive = false;
            }
        }

        public BaseNode(Serial serial)
        {
            this.m_Serial = serial;
            HPCur = HP;
        }

        public BaseNode()
        {
            if (m_Serial == 0)
                m_Serial = Serial.NewMobile;
            HPCur = HP;
        }
    }
}
