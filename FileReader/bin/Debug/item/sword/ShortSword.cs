using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class ShortSword : BaseWeapon
	{
		public override string Name { get { return "Short Sword"; } }

		public override int DamBase { get { return 11; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 0; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 120; } }
		public override int InitMaxHits { get { return 120; } }

		public override Class ClassReq { get { return Class.Beginner | Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public ShortSword() : base (10)
		{
		}

		public ShortSword(Serial serial) : base (serial)
		{
		}
	}
}
