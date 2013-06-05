using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.spells
{
    public class FireBall : Spell
    {
        public override string Name { get { return "FIRE BALL"; } }
        public override int SpellLearnedIcon { get { return 12; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 46; } }
        public override int DamPl { get { return 6; } }
        public override int ManaCost { get { return 32; } }
        public override int ManaCostPl { get { return 0; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    40,   //oncast
                    23,  //moving
                    00,   //impact
                    0,   //thickness
                    0,   //type
                    9,   //speed
                    0    //streak
                    );
            }
        }

        public FireBall()
        {
        }
    }
}
