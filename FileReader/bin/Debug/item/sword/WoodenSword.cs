using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class WoodenSword : BaseWeapon
	{
		public override string Name { get { return "Wooden Sword"; } }

		public override int DamBase { get { return 5; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 0; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 80; } }
		public override int InitMaxHits { get { return 80; } }

		public override Class ClassReq { get { return Class.Beginner | Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public WoodenSword() : base (10)
		{
		}

		public WoodenSword(Serial serial) : base (serial)
		{
		}
	}
}
