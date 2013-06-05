namespace LKCamelot.script.spells
{
    public class FlameWave : Spell
    {
        public override string Name { get { return "FLAME WAVE"; } } 
        public override int SpellLearnedIcon { get { return 16; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 58; } }
        public override int DamPl { get { return 6; } }
        public override int ManaCost { get { return 38; } }
        public override int ManaCostPl { get { return 6; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    40,  //oncast
                    52,  //moving
                    0,  //impact
                    2,  //thickness
                    0,  //type
                    6,  //speed
                    2  //streak
                    );
            }
        }

        public FlameWave()
        {
        }
    }
}