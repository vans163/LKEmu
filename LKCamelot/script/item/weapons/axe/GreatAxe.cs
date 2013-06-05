using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class GreatAxe : BaseWeapon
	{
		public override string Name { get { return "Great Axe"; } }

		public override int DamBase { get { return 168; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 660; } }
		public override int DexReq { get { return 189; } }

		public override int InitMinHits { get { return 1100; } }
		public override int InitMaxHits { get { return 1100; } }

		public override int SellPrice { get { return 75000; } }
		
		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Axe; } }

		public GreatAxe() : base (16)
		{
		}

		public GreatAxe(Serial serial) : base (serial)
		{
		}
	}
}
