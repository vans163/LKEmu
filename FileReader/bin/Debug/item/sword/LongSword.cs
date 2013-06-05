using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class LongSword : BaseWeapon
	{
		public override string Name { get { return "Long Sword"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 180; } }
		public override int DexReq { get { return 54; } }

		public override int InitMinHits { get { return 350; } }
		public override int InitMaxHits { get { return 350; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public LongSword() : base (10)
		{
		}

		public LongSword(Serial serial) : base (serial)
		{
		}
	}
}
