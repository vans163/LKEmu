namespace LKCamelot.script.spells
{
    public class GrandBigBang : Spell
    {
        public override string Name { get { return "GRAND BIG BANG"; } }
        public override int SpellLearnedIcon { get { return 64; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target; } }

        public override int DamBase { get { return 1300; } }
        public override int DamPl { get { return 30; } }
        public override int ManaCost { get { return -77; } }
        public override int ManaCostPl { get { return 6; } }
        public override int menCoff { get { return 8; } }
        public override int Range
        {
            get
            {
                return 5;
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
                    66,  //impact
                    0,  //thickness
                    3,  //type
                    3,  //speed
                    0  //streak
                    );
            }
        }

        public GrandBigBang()
        {
        }
    }
}