using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class FullPlate : BaseArmor
	{
		public override string Name { get { return "Full Plate"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 228; } }

		public override int StrReq { get { return 714; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 1500; } }
		public override int InitMaxHits { get { return 1500; } }

        public override int APStage
        {
            get
            {
                var ret = 3;
                if (Parent != null)
                {
                    if (Parent.Class == (Class.Swordsman | Class.Knight))
                        ret = 3;
                    else if (Parent.Class == (Class.Shaman | Class.Wizard))
                        ret = 2;
                }
                return ret;
            }
        }

        public override int SellPrice { get { return 100000; } } 

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public FullPlate() : base (8)
		{
		}

		public FullPlate(Serial serial) : base (serial)
		{
		}
	}
}