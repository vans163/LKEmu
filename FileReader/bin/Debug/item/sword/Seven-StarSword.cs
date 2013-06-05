using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Seven-StarSword : BaseWeapon
	{
		public override string Name { get { return "Seven-Star Sword"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 583; } }
		public override int DexReq { get { return 166; } }

		public override int InitMinHits { get { return 900; } }
		public override int InitMaxHits { get { return 900; } }

		public override Class ClassReq { get { return Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Seven-StarSword() : base (10)
		{
		}

		public Seven-StarSword(Serial serial) : base (serial)
		{
		}
	}
}
