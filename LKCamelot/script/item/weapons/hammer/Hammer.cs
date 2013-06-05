using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Hammer : BaseWeapon
	{
		public override string Name { get { return "Hammer"; } }

		public override int DamBase { get { return 71; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 375; } }
		public override int DexReq { get { return 109; } }

		public override int InitMinHits { get { return 650; } }
		public override int InitMaxHits { get { return 650; } }
		
		public override int SellPrice { get { return 60000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public Hammer() : base (15)
		{
		}

		public Hammer(Serial serial) : base (serial)
		{
		}
	}
}
