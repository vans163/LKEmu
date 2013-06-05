using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.spells
{
    public class Sidewinder : Spell
    {
        public override string Name { get { return "SIDEWINDER"; } }
        public override int SpellLearnedIcon { get { return 41; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 300; } }
        public override int DamPl { get { return 10; } }
        public override int ManaCost { get { return -68; } }
        public override int ManaCostPl { get { return 4; } }
        public override library.Class ClassReq { get { return library.Class.Swordsman | library.Class.Shaman; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    8,   //oncast
                    37,  //moving
                    0,   //impact
                    0,   //thickness
                    0,   //type
                    9,   //speed
                    0    //streak
                    );
            }
        }

        public Sidewinder()
        {
        }
    }
}
