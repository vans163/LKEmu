using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Dagger : BaseWeapon
	{
		public override string Name { get { return "Dagger"; } }

		public override int DamBase { get { return 8; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 0; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 100; } }
		public override int InitMaxHits { get { return 100; } }

		public override Class ClassReq { get { return Class.Beginner | Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Dagger() : base (10)
		{
		}

		public Dagger(Serial serial) : base (serial)
		{
		}
	}
}
