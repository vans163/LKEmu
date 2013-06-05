using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class AmityPlate : BaseArmor
    {
        public override string Name { get { return "AMITY PLATE"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 400; } }

        public override int StrReq { get { return 0; } }
        public override int DexReq { get { return 0; } }

        public override int InitMinHits { get { return 300; } }
        public override int InitMaxHits { get { return 300; } }

        public override int APStage
        {
            get
            {
                var ret = 0;
                if (Parent != null)
                {
                    if (Parent.Class.HasFlag(Class.Knight) || Parent.Class.HasFlag(Class.Swordsman))
                        ret = 4;
                    else if (Parent.Class.HasFlag(Class.Shaman) || Parent.Class.HasFlag(Class.Wizard))
                        ret = 3;
                    else if (Parent.Class.HasFlag(Class.Beginner))
                        ret = 5;
                }
                return ret;
            }
        }

        public override int SellPrice { get { return 250000; } }

        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return 0; } }
        public override ArmorType ArmorType { get { return ArmorType.Armor; } }

        public AmityPlate()
            : base(184)
        {
        }

        public AmityPlate(Serial serial)
            : base(serial)
        {
        }
    }
}
