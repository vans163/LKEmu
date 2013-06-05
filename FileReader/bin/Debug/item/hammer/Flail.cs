using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Flail : BaseWeapon
	{
		public override string Name { get { return "Flail"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 326; } }
		public override int DexReq { get { return 94; } }

		public override int InitMinHits { get { return 500; } }
		public override int InitMaxHits { get { return 500; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public Flail() : base (35)
		{
		}

		public Flail(Serial serial) : base (serial)
		{
		}
	}
}
