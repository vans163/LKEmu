using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class RestDummy : Monster
    {
        public override string Name { get { return "Trainer"; }  }
        public override int HP { get { return 30000; } }
        public override int Dam { get { return 0; } }
        public override int AC { get { return 25000; } }
        public override int Hit { get { return 0; } }
        public override int XP { get { return 0; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }
        public override int WalkSpeed { get { return 990000; } }

        public RestDummy()
            : base(14)
        {
        }

        public RestDummy(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 14;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public RestDummy(Serial serial)
            : base(serial)
        {
        }
    }
}
