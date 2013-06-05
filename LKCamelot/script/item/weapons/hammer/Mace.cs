using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Mace : BaseWeapon
	{
		public override string Name { get { return "Mace"; } }

		public override int DamBase { get { return 37; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 170; } }
		public override int DexReq { get { return 50; } }

		public override int InitMinHits { get { return 400; } }
		public override int InitMaxHits { get { return 400; } }
        public override ulong BuyPrice { get { return 50000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public Mace() : base (14)
		{
		}

		public Mace(Serial serial) : base (serial)
		{
            m_ItemID = 35;
		}
	}
}
