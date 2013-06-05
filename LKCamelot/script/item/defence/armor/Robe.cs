using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Robe : BaseArmor
	{
		public override string Name { get { return "Robe"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 82; } }

		public override int StrReq { get { return 220; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 520; } }
		public override int InitMaxHits { get { return 520; } }
        public override ulong BuyPrice { get { return 200000; } }
        public override int SellPrice { get { return 50000; } }

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

		public Robe() : base (6)
		{
		}

		public Robe(Serial serial) : base (serial)
		{
            m_ItemID = 5;
		}
	}
}
