using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Falchion : BaseWeapon
	{
		public override string Name { get { return "Falchion"; } }

		public override int DamBase { get { return 66; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 351; } }
		public override int DexReq { get { return 101; } }

		public override int InitMinHits { get { return 500; } }
		public override int InitMaxHits { get { return 500; } }

		public override int SellPrice { get { return 5000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Falchion() : base (12)
		{
		}

		public Falchion(Serial serial) : base (serial)
		{
		}
	}
}
