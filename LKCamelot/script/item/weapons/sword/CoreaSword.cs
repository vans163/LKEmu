using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class CoreaSword : BaseWeapon
	{
		public override string Name { get { return "Corea Sword"; } }

		public override int DamBase { get { return 130; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 600; } }
		public override int DexReq { get { return 171; } }

		public override int InitMinHits { get { return 900; } }
		public override int InitMaxHits { get { return 900; } }
		
		public override int SellPrice { get { return 40000; } }

		public override Class ClassReq { get { return Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public CoreaSword() : base (13)
		{
		}

		public CoreaSword(Serial serial) : base (serial)
		{
		}
	}
}
