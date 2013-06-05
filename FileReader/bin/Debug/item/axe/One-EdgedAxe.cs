using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class One-EdgedAxe : BaseWeapon
	{
		public override string Name { get { return "One-Edged Axe"; } }

		public override int DamBase { get { return 24; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 112; } }
		public override int DexReq { get { return 34; } }

		public override int InitMinHits { get { return 300; } }
		public override int InitMaxHits { get { return 300; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Axe; } }

		public One-EdgedAxe() : base (14)
		{
		}

		public One-EdgedAxe(Serial serial) : base (serial)
		{
		}
	}
}
