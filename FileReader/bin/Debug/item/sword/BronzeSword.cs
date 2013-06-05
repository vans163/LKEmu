using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class BronzeSword : BaseWeapon
	{
		public override string Name { get { return "Bronze Sword"; } }

		public override int DamBase { get { return ; } }
		public override int ACBase { get { return ; } }

		public override int StrReq { get { return 73; } }
		public override int DexReq { get { return 24; } }

		public override int InitMinHits { get { return 190; } }
		public override int InitMaxHits { get { return 190; } }

		public override Class ClassReq { get { return Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public BronzeSword() : base (10)
		{
		}

		public BronzeSword(Serial serial) : base (serial)
		{
		}
	}
}
