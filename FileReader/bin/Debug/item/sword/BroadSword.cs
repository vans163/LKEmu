using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class BroadSword : BaseWeapon
	{
		public override string Name { get { return "Broad Sword"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 277; } }
		public override int DexReq { get { return 81; } }

		public override int InitMinHits { get { return 480; } }
		public override int InitMaxHits { get { return 480; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public BroadSword() : base (10)
		{
		}

		public BroadSword(Serial serial) : base (serial)
		{
		}
	}
}
