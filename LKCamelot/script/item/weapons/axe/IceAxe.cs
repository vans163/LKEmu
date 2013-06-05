using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class IceAxe : BaseWeapon
	{
		public override string Name { get { return "Ice Axe"; } }

		public override int DamBase { get { return 48; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 253; } }
		public override int DexReq { get { return 81; } }

		public override int InitMinHits { get { return 500; } }
		public override int InitMaxHits { get { return 500; } }
		
		public override int SellPrice { get { return 5000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Axe; } }

		public IceAxe() : base (15)
		{
		}

		public IceAxe(Serial serial) : base (serial)
		{
		}
	}
}
