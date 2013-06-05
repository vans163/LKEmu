using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class MorningStar : BaseWeapon
	{
		public override string Name { get { return "Morning Star"; } }

		public override int DamBase { get { return 35; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 131; } }
		public override int DexReq { get { return 39; } }

		public override int InitMinHits { get { return 300; } }
		public override int InitMaxHits { get { return 300; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public MorningStar() : base (35)
		{
		}

		public MorningStar(Serial serial) : base (serial)
		{
		}
	}
}
