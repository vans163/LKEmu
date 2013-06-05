using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class OneEdgedAxe : BaseWeapon
	{
		public override string Name { get { return "One-Edged Axe"; } }

		public override int DamBase { get { return 24; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 112; } }
		public override int DexReq { get { return 34; } }
		public override int LevelReq { get { return 10; } }

		public override int InitMinHits { get { return 300; } }
		public override int InitMaxHits { get { return 300; } }
		public override int SellPrice { get { return 2000; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Axe; } }

		public OneEdgedAxe() : base (14)
		{
		}

		public OneEdgedAxe(Serial serial) : base (serial)
		{
		}
	}
}
