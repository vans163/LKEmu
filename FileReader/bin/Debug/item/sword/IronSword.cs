using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class IronSword : BaseWeapon
	{
		public override string Name { get { return "Iron Sword"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 204; } }
		public override int DexReq { get { return 61; } }

		public override int InitMinHits { get { return 420; } }
		public override int InitMaxHits { get { return 420; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public IronSword() : base (10)
		{
		}

		public IronSword(Serial serial) : base (serial)
		{
		}
	}
}
