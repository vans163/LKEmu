namespace LKCamelot.script.spells
{
    public class DragonOfFire : Spell
    {
        public override string Name { get { return "DRAGON OF FIRE"; } }
        public override int SpellLearnedIcon { get { return 63; } }
        public override LKCamelot.library.MagicType mType { get { return LKCamelot.library.MagicType.Target2; } }

        public override int DamBase { get { return 575; } }
        public override int DamPl { get { return 12; } }
        public override int ManaCost { get { return -78; } }
        public override int ManaCostPl { get { return 6; } }
        public override LKCamelot.library.Class ClassReq { get { return LKCamelot.library.Class.Wizard; } }
        public override int menCoff { get { return 6; } }
        public override SpellSequence Seq
        {
            get
            {
                return new SpellSequence(
                    42,  //oncast
                    28,  //moving
                   00,  //impact
                    0,  //thickness
                    0,  //type
                    9,  //speed
                    0  //streak
                    );
            }
        }

        public DragonOfFire()
        {
        }
    }
}