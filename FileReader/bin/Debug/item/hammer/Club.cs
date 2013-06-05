using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Club : BaseWeapon
	{
		public override string Name { get { return "Club"; } }

		public override int DamBase { get { return 7; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 18; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 80; } }
		public override int InitMaxHits { get { return 80; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public Club() : base (35)
		{
		}

		public Club(Serial serial) : base (serial)
		{
		}
	}
}
