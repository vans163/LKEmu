namespace LKCamelot.script.spells
{
    public class FireWall : Spell
    {
        public override string Name { get { return "FIRE WALL"; } }
        public override int SpellLearnedIcon { get { return 17; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 130; } }
        public override int DamPl { get { return 8; } }
        public override int ManaCost { get { return 96; } }
        public override int ManaCostPl { get { return 6; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    0,  //oncast
                    0,  //moving
                    0x96,  //impact
                    3,  //thickness
                    0,  //type
                    2,  //speed
                    0  //streak
                    );
            }
        }

        public FireWall()
        {
        }
    }
}