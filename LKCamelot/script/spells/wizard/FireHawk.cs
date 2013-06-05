namespace LKCamelot.script.spells
{
    public class FireHawk : Spell
    {
        public override string Name { get { return "FIRE HAWK"; } }
        public override int SpellLearnedIcon { get { return 14; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 456; } }
        public override int DamPl { get { return 14; } }
        public override int ManaCost { get { return -77; } }
        public override int ManaCostPl { get { return 6; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Wizard; } }
        public override int menCoff { get { return 12; } }
        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    42,  //oncast
                    27,  //moving
                    00,  //impact
                    0,  //thickness
                    0,  //type
                    9,  //speed
                    1  //streak
                    );
            }
        }

        public FireHawk()
        {
        }
    }
}