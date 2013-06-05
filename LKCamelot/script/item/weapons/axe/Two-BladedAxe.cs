using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class TwoBladedAxe : BaseWeapon
	{
		public override string Name { get { return "Two-Bladed Axe"; } }

		public override int DamBase { get { return 81; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 425; } }
		public override int DexReq { get { return 123; } }

		public override int InitMinHits { get { return 600; } }
		public override int InitMaxHits { get { return 600; } }
		public override int SellPrice { get { return 10000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Axe; } }

		public TwoBladedAxe() : base (15)
		{
		}

		public TwoBladedAxe(Serial serial) : base (serial)
		{
		}
	}
}
