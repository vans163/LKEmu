using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Saver : BaseWeapon
	{
		public override string Name { get { return "Saver"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 151; } }
		public override int DexReq { get { return 46; } }

		public override int InitMinHits { get { return 400; } }
		public override int InitMaxHits { get { return 400; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Saver() : base (10)
		{
		}

		public Saver(Serial serial) : base (serial)
		{
		}
	}
}
