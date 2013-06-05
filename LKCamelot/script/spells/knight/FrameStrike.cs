namespace LKCamelot.script.spells
{
    public class FrameStrike : Spell, ISingle
    {
        public override string Name { get { return "FRAME STRIKE"; } }
        public override int SpellLearnedIcon { get { return 67; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 3000; } }
        public override int DamPl { get { return 300; } }
        public override int ManaCost { get { return -100; } }
        public override int ManaCostPl { get { return 10; } }
        public override int strCoff { get { return 2; } }
        public override int RecastTime { get { return 5000; } }
        public override int Range { get { return 2; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Knight; } }
        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    0,  //oncast
                    0,  //moving
                    110,  //impact
                    0,  //thickness
                    3,  //type
                    0,  //speed
                    0  //streak
                    );
            }
        }

        public FrameStrike()
        {
        }
    }
}