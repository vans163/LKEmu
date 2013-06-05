namespace LKCamelot.script.spells
{
    public class WindySpirit : Spell
    {
        public override string Name { get { return "WINDY SPIRIT"; } }
        public override int SpellLearnedIcon { get { return 29; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 3000; } }
        public override int DamPl { get { return 300; } }
        public override int ManaCost { get { return -100; } }
        public override int ManaCostPl { get { return 10; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Shaman; } }
        public override int RecastTime { get { return 5000; } }
        public override int menCoff { get { return 2; } }
        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    0,  //oncast
                    29,  //moving
                    56,  //impact
                    0,  //thickness
                    2,  //type
                    30,  //speed
                    2  //streak
                    );
            }
        }

        public WindySpirit()
        {
        }
    }
}