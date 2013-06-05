using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class GoldVest : BaseArmor
    {
        public override string Name { get { return "GOLD VEST"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 800; } }

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
                    if (Parent.Class.HasFlag(Class.Beginner))
                        ret = 5;
                }
                return ret;
            }
        }

        public override int SellPrice { get { return 250000; } }

        public override int LevelReq { get { return 160; } }
        public override Class ClassReq { get { return Class.Beginner; } }
        public override ArmorType ArmorType { get { return ArmorType.Armor; } }

        public GoldVest()
            : base(185)
        {
        }

        public GoldVest(Serial serial)
            : base(serial)
        {
        }
    }
}
