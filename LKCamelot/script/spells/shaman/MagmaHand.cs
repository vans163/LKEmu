namespace LKCamelot.script.spells
{
    public class MagmaHand : Spell, ISingle
    {
        public override string Name { get { return "MAGMA HAND"; } }
        public override int SpellLearnedIcon { get { return 70; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 1500; } }
        public override int DamPl { get { return 30; } }
        public override int ManaCost { get { return -78; } }
        public override int ManaCostPl { get { return 6; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Shaman; } }
        public override int menCoff { get { return 6; } }
        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    0,  //oncast
                    0,  //moving
                    7,  //impact
                    0,  //thickness
                    3,  //type
                    0,  //speed
                    0  //streak
                    );
            }
        }

        public MagmaHand()
        {
        }
    }
}