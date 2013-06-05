using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Hack : BaseWeapon
	{
		public override string Name { get { return "Hack"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 228; } }
		public override int DexReq { get { return 67; } }

		public override int InitMinHits { get { return 750; } }
		public override int InitMaxHits { get { return 750; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public Hack() : base (35)
		{
		}

		public Hack(Serial serial) : base (serial)
		{
		}
	}
}
