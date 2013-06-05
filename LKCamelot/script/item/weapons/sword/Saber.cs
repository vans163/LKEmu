using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Saber : BaseWeapon
	{
		public override string Name { get { return "Saber"; } }

		public override int DamBase { get { return 19; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 83; } }
		public override int DexReq { get { return 26; } }

		public override int InitMinHits { get { return 200; } }
		public override int InitMaxHits { get { return 200; } }
		
		public override int SellPrice { get { return 2000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Saber() : base (10)
		{
		}

		public Saber(Serial serial) : base (serial)
		{
		}
	}
}
