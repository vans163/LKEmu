namespace LKCamelot.script.spells
{
    public class DeadlyBoom : Spell, ISingle
    {
        public override string Name { get { return "DEADLY BOOM"; } }
        public override int SpellLearnedIcon { get { return 69; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 555; } }
        public override int DamPl { get { return 14; } }
        public override int ManaCost { get { return -65; } } //65
        public override int ManaCostPl { get { return 5; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Wizard; } }
        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    49,  //oncast
                    0,  //moving
                    63,  //impact
                    0,  //thickness
                    3,  //type
                    30,  //speed
                    0  //streak
                    );
            }
        }

        public DeadlyBoom()
        {
        }
    }
}