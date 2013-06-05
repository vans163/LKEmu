using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.spells
{
    public class ElectronicBall : Spell
    {
        public override string Name { get { return "ELECTRONIC BALL"; } }
        public override int SpellLearnedIcon { get { return 58; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 35; } }
        public override int DamPl { get { return 5; } }
        public override int ManaCost { get { return 25; } }
        public override int ManaCostPl { get { return 0; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    45,
                    32,
                    0,
                    0,
                    0,
                    9,
                    0
                    );
            }
        }

        public ElectronicBall()
        {
        }
    }
}