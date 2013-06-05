using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class Tomahawk : BaseWeapon
    {
        public override string Name { get { return "Tomahawk"; } }

        public override int DamBase { get { return 240; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 2515; } }
        public override int DexReq { get { return 1706; } }

        public override int InitMinHits { get { return 700; } }
        public override int InitMaxHits { get { return 700; } }
        
        public override int SellPrice { get { return 200000; } }//sell value based on scaling

        public override Class ClassReq { get { return Class.Knight; } }// Only for Knights
        public override WeaponType WeaponType { get { return WeaponType.Axe; } }

        public Tomahawk()
            : base(16)
        {
        }

        public Tomahawk(Serial serial)
            : base(serial)
        {
        }
    }
}
