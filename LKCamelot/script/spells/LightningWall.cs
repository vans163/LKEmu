namespace LKCamelot.script.spells
{
    public class LightningWall : Spell
    {
        public override string Name { get { return "LIGHTNING WALL"; } }
        public override int SpellLearnedIcon { get { return 57; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 152; } }
        public override int DamPl { get { return 8; } }
        public override int ManaCost { get { return 102; } }
        public override int ManaCostPl { get { return 0; } }

        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    0,  //oncast
                    0,  //moving
                    45,  //impact
                    3,  //thickness
                    0,  //type
                    2,  //speed
                    0  //streak
                    );
            }
        }

        public LightningWall()
        {
        }
    }
}