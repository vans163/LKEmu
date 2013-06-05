using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Maul : BaseWeapon
	{
		public override string Name { get { return "Maul"; } }

		public override int DamBase { get { return 92; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 475; } }
		public override int DexReq { get { return 136; } }

		public override int InitMinHits { get { return 900; } }
		public override int InitMaxHits { get { return 900; } }
		
		public override int SellPrice { get { return 110000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public Maul() : base (16)
		{
		}

		public Maul(Serial serial) : base (serial)
		{
		}
	}
}
