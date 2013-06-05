namespace LKCamelot.script.spells
{
    public class Lightning : Spell
    {
        public override string Name { get { return "LIGHTNING"; } } 
        public override int SpellLearnedIcon { get { return 72; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 66; } }
        public override int DamPl { get { return 6; } }
        public override int ManaCost { get { return 40; } }
        public override int ManaCostPl { get { return 6; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    44,  //oncast
                    31,  //moving
                    0,  //impact
                    0,  //thickness
                    0,  //type
                    3,  //speed
                    0  //streak
                    );
            }
        }

        public Lightning()
        {
        }
    }
}