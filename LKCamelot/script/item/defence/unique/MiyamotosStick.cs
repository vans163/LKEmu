using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class MiyamotosStick : BaseWeapon
    {
        public override string Name { get { return "*Miyamoto's Wooden Stick"; } }
        public override string DescText { get { return "Reduces cooldown of Demon Death based on refine"; } }
        public override string FlavorText { get { return "\"Miyamoto was asked to arm himself. He picked up a stick.\""; } }
        public override int DamBase { get { return 1; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 7; } }
        public override int DexReq { get { return 35000; } }

        public override int InitMinHits { get { return 500; } }
        public override int InitMaxHits { get { return 500; } }

        public override Class ClassReq { get { return Class.Swordsman; } }
        public override WeaponType WeaponType { get { return WeaponType.Sword; } }

        public MiyamotosStick()
            : base(9)
        {
        }

        public MiyamotosStick(Serial serial)
            : base(serial)
        {
        }
    }
}
