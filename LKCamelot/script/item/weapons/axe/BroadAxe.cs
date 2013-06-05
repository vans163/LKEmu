using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class BroadAxe : BaseWeapon
	{
		public override string Name { get { return "Broad Axe"; } }

		public override int DamBase { get { return 57; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 302; } }
		public override int DexReq { get { return 95; } }

		public override int InitMinHits { get { return 700; } }
		public override int InitMaxHits { get { return 700; } }
		
		public override int SellPrice { get { return 7500; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Axe; } }

		public BroadAxe() : base (15)
		{
		}

		public BroadAxe(Serial serial) : base (serial)
		{
		}
	}
}
