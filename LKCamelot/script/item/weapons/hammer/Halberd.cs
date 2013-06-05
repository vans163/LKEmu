using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Halberd : BaseWeapon
	{
		public override string Name { get { return "Halberd"; } }

		public override int DamBase { get { return 145; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 580; } }
		public override int DexReq { get { return 165; } }

		public override int InitMinHits { get { return 950; } }
		public override int InitMaxHits { get { return 950; } }
		
		public override int SellPrice { get { return 125000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public Halberd() : base (16)
		{
		}

		public Halberd(Serial serial) : base (serial)
		{
		}
	}
}
