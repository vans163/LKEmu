using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class LargeAxe : BaseWeapon
	{
		public override string Name { get { return "Large Axe"; } }

		public override int DamBase { get { return 100; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 420; } }
		public override int DexReq { get { return 123; } }

		public override int InitMinHits { get { return 850; } }
		public override int InitMaxHits { get { return 850; } }
		
		public override int SellPrice { get { return 25000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Axe; } }

		public LargeAxe() : base (16)
		{
		}

		public LargeAxe(Serial serial) : base (serial)
		{
		}
	}
}
