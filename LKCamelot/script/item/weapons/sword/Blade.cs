using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Blade : BaseWeapon
	{
		public override string Name { get { return "Blade"; } }

		public override int DamBase { get { return 25; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 122; } }
		public override int DexReq { get { return 37; } }

		public override int InitMinHits { get { return 300; } }
		public override int InitMaxHits { get { return 300; } }
		
		public override int SellPrice { get { return 1500; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Blade() : base (11)
		{
		}

		public Blade(Serial serial) : base (serial)
		{
		}
	}
}
