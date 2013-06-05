using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.spells
{
    public class TeagueShield : Spell
    {
        public override string Name { get { return "TEAGUE SHIELD"; } }
        public override int SpellLearnedIcon { get { return 28; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Casted; } }

        public override int DamBase { get { return 0; } }
        public override int DamPl { get { return 0; } }
        public override int ManaCost { get { return 66; } }
        public override int ManaCostPl { get { return 0; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Shaman; } }
        public override Buff BuffEffect
        {
            get
            {
                var tbuff = new Buff();
                tbuff.BuffType = BuffCase.ManaAsHP | BuffCase.ReflectDamage;
                tbuff.Dam = 35;
                tbuff.Dampl = 5;
                tbuff.AC = 8;
                tbuff.ACpl = 4;
                return tbuff;
            }
        }

        public override bool Cast(LKCamelot.model.Player player)
        {
            CheckLevelUp(player);
            player.AddBuff(this);
            return true;
        }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    6,   //oncast
                    0,  //moving
                    0,   //impact
                    0,   //thickness
                    0,   //type
                    3,   //speed
                    0    //streak
                    );
            }
        }

        public TeagueShield()
        {
        }
    }
}
