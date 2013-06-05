using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Hatchet : BaseWeapon
	{
		public override string Name { get { return "Hatchet"; } }

		public override int DamBase { get { return 13; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 50; } }
		public override int DexReq { get { return 0; } }
		public override int LevelReq { get { return 5; } }

		public override int InitMinHits { get { return 120; } }
		public override int InitMaxHits { get { return 120; } }
       		public override int SellPrice { get { return 500; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Axe; } }

		public Hatchet() : base (14)
		{
		}

		public Hatchet(Serial serial) : base (serial)
		{
		}
	}
}
