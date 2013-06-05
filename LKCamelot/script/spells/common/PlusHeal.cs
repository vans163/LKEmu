using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.spells
{
    public class PlusHeal : Spell
    {
        public override string Name { get { return "PLUS HEAL"; } }
        public override int SpellLearnedIcon { get { return 2; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 0; } }
        public override int DamPl { get { return 0; } }
        public override int ManaCost { get { return 118; } }
        public override int ManaCostPl { get { return 0; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    0,   //oncast
                    1,  //moving
                    0,   //impact
                    0,   //thickness
                    0,   //type
                    6,   //speed
                    3    //streak
                    );
            }
        }

        public PlusHeal()
        {
        }
    }
}
