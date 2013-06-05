using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Epee : BaseWeapon
	{
		public override string Name { get { return "Epee"; } }

		public override int DamBase { get { return 26; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 103; } }
		public override int DexReq { get { return 33; } }

		public override int InitMinHits { get { return 220; } }
		public override int InitMaxHits { get { return 220; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Epee() : base (10)
		{
		}

		public Epee(Serial serial) : base (serial)
		{
		}
	}
}
