using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.spells
{
    public class FlameRound : Spell
    {
        public override string Name { get { return "FLAME ROUND"; } }
        public override int SpellLearnedIcon { get { return 18; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Casted; } }

        public override int DamBase { get { return 70; } }
        public override int DamPl { get { return 6; } }
        public override int ManaCost { get { return 54; } }
        public override int ManaCostPl { get { return 0; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    40,   //oncast
                    25,  //moving
                    15,   //impact
                    0,   //thickness
                    1,   //type
                    6,   //speed
                    0    //streak
                    );
            }
        }

        public FlameRound()
        {
        }
    }
}
