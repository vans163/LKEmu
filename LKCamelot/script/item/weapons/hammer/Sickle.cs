using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Sickle : BaseWeapon
	{
		public override string Name { get { return "Sickle"; } }

		public override int DamBase { get { return 9; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 30; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 150; } }
		public override int InitMaxHits { get { return 150; } }
        public override ulong BuyPrice { get { return 2000; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public Sickle() : base (14)
		{
		}

		public Sickle(Serial serial) : base (serial)
		{
		}
	}
}
