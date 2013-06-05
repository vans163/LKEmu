namespace LKCamelot.script.spells
{
    public class DeadlyMessenger : Spell
    {
        public override string Name { get { return "DEADLY MESSENGER"; } }
        public override int SpellLearnedIcon { get { return 29; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 310; } }
        public override int DamPl { get { return 10; } }
        public override int ManaCost { get { return -66; } }
        public override int ManaCostPl { get { return 4; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Shaman; } }
        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    0,  //oncast
                    0,  //moving
                    75,  //impact
                    0,  //thickness
                    0,  //type
                    0,  //speed
                    0  //streak
                    );
            }
        }

        public DeadlyMessenger()
        {
        }
    }
}