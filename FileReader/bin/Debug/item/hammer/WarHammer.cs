using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class WarHammer : BaseWeapon
	{
		public override string Name { get { return "War Hammer"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 525; } }
		public override int DexReq { get { return 150; } }

		public override int InitMinHits { get { return 750; } }
		public override int InitMaxHits { get { return 750; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public WarHammer() : base (35)
		{
		}

		public WarHammer(Serial serial) : base (serial)
		{
		}
	}
}
