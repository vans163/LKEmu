using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.spells
{
    public class ZigZag : Spell
    {
        public override string Name { get { return "ZIG ZAG"; } }
        public override int SpellLearnedIcon { get { return 21; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 22; } }
        public override int DamPl { get { return 4; } }
        public override int ManaCost { get { return 16; } }
        public override int ManaCostPl { get { return 0; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    0,   //oncast
                    81,  //moving
                    0,   //impact
                    0,   //thickness
                    0,   //type
                    7,   //speed
                    0    //streak
                    );
            }
        }

        public ZigZag()
        {
        }
    }
}
