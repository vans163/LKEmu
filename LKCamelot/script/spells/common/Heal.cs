using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.spells
{
    public class Heal : Spell
    {
        public override string Name { get { return "HEAL"; } }
        public override int SpellLearnedIcon { get { return 1; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Casted; } }

        public override int DamBase { get { return 0; } }
        public override int DamPl { get { return 0; } }
        public override int ManaCost { get { return 36; } }
        public override int ManaCostPl { get { return 0; } }
        public override int RecastTime { get { return 3000; } }

        public override bool Cast(LKCamelot.model.Player player)
        {
            CheckLevelUp(player);
            double temp = 0.60 + (Level * 0.02);
            player.HPCur += (int)(player.HP * temp);
            return true;
        }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    1,   //oncast
                    0,  //moving
                    0,   //impact
                    0,   //thickness
                    3,   //type
                    3,   //speed
                    0    //streak
                    );
            }
        }

        public Heal()
        {
        }
    }
}
