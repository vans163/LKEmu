using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Troy : BaseWeapon
	{
		public override string Name { get { return "Troy"; } }

		public override int DamBase { get { return ; } }
		public override int ACBase { get { return ; } }

		public override int StrReq { get { return 620; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 1200; } }
		public override int InitMaxHits { get { return 1200; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Troy() : base (10)
		{
		}

		public Troy(Serial serial) : base (serial)
		{
		}
	}
}
