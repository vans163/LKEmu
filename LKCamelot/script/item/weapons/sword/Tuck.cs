using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Tuck : BaseWeapon
	{
		public override string Name { get { return "Tuck"; } }

		public override int DamBase { get { return 98; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 500; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 650; } }
		public override int InitMaxHits { get { return 650; } }
		
		public override int SellPrice { get { return 15000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Tuck() : base (13)
		{
		}

		public Tuck(Serial serial) : base (serial)
		{
		}
	}
}
