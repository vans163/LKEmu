using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class HolyDefender : BaseArmor
    {
        public override string Name { get { return "HOLY DEFENDER"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 129; } }

        public override int StrReq { get { return 1100; } }
        public override int DexReq { get { return 765; } }

        public override int InitMinHits { get { return 880; } }
        public override int InitMaxHits { get { return 880; } }
        public override int SellPrice { get { return 100000; } }

        public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
        public override ArmorType ArmorType { get { return ArmorType.Shield; } }

        public HolyDefender()
            : base(183)
        {
        }

        public HolyDefender(Serial serial)
            : base(serial)
        {
        }
    }
}
