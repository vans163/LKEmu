using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class SmallAxe : BaseWeapon
	{
		public override string Name { get { return "Small Axe"; } }

		public override int DamBase { get { return 18; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 74; } }
		public override int DexReq { get { return 0; } }
		public override int LevelReq { get { return 7; } }

		public override int InitMinHits { get { return 200; } }
		public override int InitMaxHits { get { return 200; } }
		public override int SellPrice { get { return 1000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Axe; } }

		public SmallAxe() : base (14)
		{
		}

		public SmallAxe(Serial serial) : base (serial)
		{
		}
	}
}
