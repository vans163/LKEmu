using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Saw : BaseWeapon
	{
		public override string Name { get { return "Saw"; } }

		public override int DamBase { get { return 12; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 40; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 200; } }
		public override int InitMaxHits { get { return 200; } }
        public override ulong BuyPrice { get { return 8000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public Saw() : base (14)
		{
		}

		public Saw(Serial serial) : base (serial)
		{
            m_ItemID = 35;
		}
	}
}
