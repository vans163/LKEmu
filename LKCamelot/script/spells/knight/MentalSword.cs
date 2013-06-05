namespace LKCamelot.script.spells
{
    public class MentalSword : Spell
    {
        public override string Name { get { return "MENTAL SWORD"; } }
        public override int SpellLearnedIcon { get { return 50; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Casted; } }

        public override int DamBase { get { return 0; } }
        public override int DamPl { get { return 0; } }
        public override int ManaCost { get { return -33; } }
        public override int ManaCostPl { get { return 0; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Knight; } }
        public override Buff BuffEffect
        {
            get
            {
                var tbuff = new Buff();
                tbuff.fDam = 0.70f;
                tbuff.fDampl = 0.10f;
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
                    63,  //oncast
                    0,  //moving
                    0,  //impact
                    0,  //thickness
                    0,  //type
                    0,  //speed
                    0  //streak
                    );
            }
        }

        public MentalSword()
        {
        }
    }
}