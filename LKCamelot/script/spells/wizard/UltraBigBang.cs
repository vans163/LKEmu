namespace LKCamelot.script.spells
{
    public class UltraBigBang : Spell
    {
        public override string Name { get { return "ULTRA BIG BANG"; } }
        public override int SpellLearnedIcon { get { return 64; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target; } }

        public override int DamBase { get { return 902; } }
        public override int DamPl { get { return 20; } }
        public override int ManaCost { get { return -65; } }
        public override int ManaCostPl { get { return 5; } }
        public override int menCoff { get { return 12; } }
        public override int Range
        {
            get
            {
                return 9;
            }
        }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Wizard; } }
        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    0,  //oncast
                    0,  //moving
                    65,  //impact
                    0,  //thickness
                    3,  //type
                    3,  //speed
                    0  //streak
                    );
            }
        }

        public UltraBigBang()
        {
        }
    }
}