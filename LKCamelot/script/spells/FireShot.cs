using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.spells
{
    public class FireShot : Spell
    {
        public override string Name { get { return "FIRE SHOT"; } }
        public override int SpellLearnedIcon { get { return 13; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 360; } }
        public override int DamPl { get { return 8; } }
        public override int ManaCost { get { return 180; } }
        public override int ManaCostPl { get { return 0; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    41,   //oncast
                    26,  //moving
                    0,   //impact
                    0,   //thickness
                    0,   //type
                    9,   //speed
                    0    //streak
                    );
            }
        }

        public FireShot()
        {
        }
    }
}
