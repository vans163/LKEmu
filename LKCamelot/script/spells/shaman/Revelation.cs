namespace LKCamelot.script.spells
{
    public class Revelation : Spell, ISingle
    {
        public override string Name { get { return "REVELATION"; } }
        public override int SpellLearnedIcon { get { return 65; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 655; } }
        public override int DamPl { get { return 15; } }
        public override int ManaCost { get { return -80; } }
        public override int ManaCostPl { get { return 6; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Shaman; } }
        public override int menCoff { get { return 10; } }
        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    49,  //oncast
                    0,  //moving
                    21,  //impact
                    0,  //thickness
                    3,  //type
                    0,  //speed
                    0  //streak
                    );
            }
        }

        public Revelation()
        {
        }
    }
}