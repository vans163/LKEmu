using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Simitar : BaseWeapon
	{
		public override string Name { get { return "Simitar"; } }

		public override int DamBase { get { return 31; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 160; } }
		public override int DexReq { get { return 49; } }

		public override int InitMinHits { get { return 450; } }
		public override int InitMaxHits { get { return 450; } }
		
		public override int SellPrice { get { return 3000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Simitar() : base (12)
		{
		}

		public Simitar(Serial serial) : base (serial)
		{
		}
	}
}
