using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Claymore : BaseWeapon
	{
		public override string Name { get { return "Claymore"; } }

		public override int DamBase { get { return 76; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 400; } }
		public override int DexReq { get { return 115; } }

		public override int InitMinHits { get { return 550; } }
		public override int InitMaxHits { get { return 550; } }
		
		public override int SellPrice { get { return 10000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Claymore() : base (12)
		{
		}

		public Claymore(Serial serial) : base (serial)
		{
		}
	}
}
