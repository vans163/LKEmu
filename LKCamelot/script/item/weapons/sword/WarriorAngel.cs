using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class WarriorAngel : BaseWeapon
    {
        public override string Name { get { return "Warrior Angel"; } }

        public override int DamBase { get { return 190; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 900; } }
        public override int DexReq { get { return 650; } }
        public override int MenReq { get { return 0; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }
        
        public override int SellPrice { get { return 90000; } }

        public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
        public override WeaponType WeaponType { get { return WeaponType.Sword; } }

        public WarriorAngel()
            : base(13)
        {
        }

        public WarriorAngel(Serial serial)
            : base(serial)
        {
        }
    }
}
