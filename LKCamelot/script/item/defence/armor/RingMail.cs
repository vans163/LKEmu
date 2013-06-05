using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class RingMail : BaseArmor
	{
		public override string Name { get { return "Ring Mail"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 146; } }

		public override int StrReq { get { return 457; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 990; } }
		public override int InitMaxHits { get { return 990; } }
        public override int SellPrice { get { return 70000; } }

        public override int APStage
        {
            get
            {
                var ret = 2;
                if (Parent != null)
                {
                    if (Parent.Class == (Class.Swordsman | Class.Knight))
                        ret = 2;
                    else if (Parent.Class == (Class.Shaman | Class.Wizard))
                        ret = 1;
                }
                return ret;
            }
        }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public RingMail() : base (7)
		{
		}

		public RingMail(Serial serial) : base (serial)
		{
		}
	}
}
