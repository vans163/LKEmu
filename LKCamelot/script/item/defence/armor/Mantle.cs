using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Mantle : BaseArmor
	{
		public override string Name { get { return "Mantle"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 39; } }

		public override int StrReq { get { return 118; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 300; } }
		public override int InitMaxHits { get { return 300; } }
        public override int SellPrice { get { return 12500; } }

        public override int APStage
        {
            get
            {
                var ret = 1;
                if (Parent != null)
                {
                    if (Parent.Class == (Class.Swordsman | Class.Knight))
                        ret = 1;
                    else if (Parent.Class == (Class.Shaman | Class.Wizard))
                        ret = 1;
                }
                return ret;
            }
        }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public Mantle() : base (6)
		{
		}

		public Mantle(Serial serial) : base (serial)
		{
		}
	}
}
