using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class GreatMaul : BaseWeapon
	{
		public override string Name { get { return "Great Maul"; } }

		public override int DamBase { get { return 180; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 700; } }
		public override int DexReq { get { return 200; } }
		
		public override int SellPrice { get { return 200000; } }

		public override int InitMinHits { get { return 1000; } }
		public override int InitMaxHits { get { return 1000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public GreatMaul() : base (16)
		{
		}

		public GreatMaul(Serial serial) : base (serial)
		{
		}
	}
}
