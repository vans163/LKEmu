namespace LKCamelot.script.spells
{
    public class Twister : Spell
    {
        public override string Name { get { return "TWISTER"; } }
        public override int SpellLearnedIcon { get { return 74; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Casted; } }

        public override int DamBase { get { return 0; } }
        public override int DamPl { get { return 0; } }
        public override int ManaCost { get { return 102; } }
        public override int ManaCostPl { get { return 6; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Knight; } }

        public override Buff BuffEffect
        {
            get
            {
                var tbuff = new Buff();
                tbuff.BuffType = BuffCase.Twister;
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
                    0,  //oncast
                    0,  //moving
                    0,  //impact
                    0,  //thickness
                    3,  //type
                    3,  //speed
                    0  //streak
                    );
            }
        }

        public Twister()
        {
        }
    }
}