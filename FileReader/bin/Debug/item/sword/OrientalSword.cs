using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class OrientalSword : BaseWeapon
	{
		public override string Name { get { return "Oriental Sword"; } }

		public override int DamBase { get { return ; } }
		public override int ACBase { get { return ; } }

		public override int StrReq { get { return 425; } }
		public override int DexReq { get { return 123; } }

		public override int InitMinHits { get { return 575; } }
		public override int InitMaxHits { get { return 575; } }

		public override Class ClassReq { get { return Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public OrientalSword() : base (10)
		{
		}

		public OrientalSword(Serial serial) : base (serial)
		{
		}
	}
}
