namespace LKCamelot.script.spells
{
    public class FlyingSword : Spell
    {
        public override string Name { get { return "FLYING SWORD"; } }
        public override int SpellLearnedIcon { get { return 49; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 606; } }
        public override int DamPl { get { return 12; } }
        public override int ManaCost { get { return -80; } }
        public override int dexCoff { get { return 6; } }
        public override int ManaCostPl { get { return 6; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Swordsman; } }
        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    50,  //oncast
                    35,  //moving
                    20,  //impact
                    0,  //thickness
                    2,  //type
                    9,  //speed
                    0  //streak
                    );
            }
        }

        public FlyingSword()
        {
        }
    }
}