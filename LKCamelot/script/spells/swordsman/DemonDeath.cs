namespace LKCamelot.script.spells
{
    public class DemonDeath : Spell
    {
        public override string Name { get { return "DEMON DEATH"; } }
        public override int SpellLearnedIcon { get { return 68; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 0; } }
        public override int DamPl { get { return 0; } }
        public override int ManaCost { get { return -50; } }
        public override int ManaCostPl { get { return 3; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Swordsman; } }
        public override int Range { get { return 2; } }
        public override int RecastTime { get { return 5000; } }
        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    0,  //oncast
                    0,  //moving
                    4,  //impact
                    0,  //thickness
                    0,  //type
                    3,  //speed
                    0  //streak
                    );
            }
        }

        public DemonDeath()
        {
        }
    }
}