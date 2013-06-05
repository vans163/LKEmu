using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class SpikedClub : BaseWeapon
	{
		public override string Name { get { return "Spiked Club"; } }

		public override int DamBase { get { return 21; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 93; } }
		public override int DexReq { get { return 30; } }

		public override int InitMinHits { get { return 250; } }
		public override int InitMaxHits { get { return 250; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

		public SpikedClub() : base (35)
		{
		}

		public SpikedClub(Serial serial) : base (serial)
		{
		}
	}
}
