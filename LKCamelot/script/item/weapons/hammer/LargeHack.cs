using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class LargeHack : BaseWeapon
	{
		public override string Name { get { return "Large Hack"; } }

		public override int DamBase { get { return 111; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 460; } }
		public override int DexReq { get { return 133; } }

		public override int InitMinHits { get { return 800; } }
		public override int InitMaxHits { get { return 800; } }
		
		public override int SellPrice { get { return 100000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public LargeHack() : base (15)
		{
		}

		public LargeHack(Serial serial) : base (serial)
		{
		}
	}
}
