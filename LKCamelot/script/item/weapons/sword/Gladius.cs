using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Gladius : BaseWeapon
	{
		public override string Name { get { return "Gladius"; } }

		public override int DamBase { get { return 87; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 450; } }
		public override int DexReq { get { return 129; } }

		public override int InitMinHits { get { return 600; } }
		public override int InitMaxHits { get { return 600; } }
		
		public override int SellPrice { get { return 12500; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Gladius() : base (12)
		{
		}

		public Gladius(Serial serial) : base (serial)
		{
		}
	}
}
