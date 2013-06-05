using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Buckler : BaseArmor
	{
		public override string Name { get { return "Buckler"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 5; } }

		public override int StrReq { get { return 0; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 50; } }
		public override int InitMaxHits { get { return 50; } }

		public override Class ClassReq { get { return Class.Beginner | Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Shield; } }

		public Buckler() : base (17)
		{
		}

		public Buckler(Serial serial) : base (serial)
		{
		}
	}
}
