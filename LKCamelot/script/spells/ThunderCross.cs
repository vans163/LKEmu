using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.spells
{
    public class ThunderCross : Spell
    {
        public override string Name { get { return "THUNDER CROSS"; } }
        public override int SpellLearnedIcon { get { return 24; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Casted; } }

        public override int DamBase { get { return 132; } }
        public override int DamPl { get { return 8; } }
        public override int ManaCost { get { return 105; } }
        public override int ManaCostPl { get { return 0; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    46,   //oncast
                    32,  //moving
                    0,   //impact
                    0,   //thickness
                    1,   //type
                    6,   //speed
                    0    //streak
                    );
            }
        }

        public ThunderCross()
        {
        }
    }
}
