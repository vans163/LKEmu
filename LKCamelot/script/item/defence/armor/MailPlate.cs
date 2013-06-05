using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class MailPlate : BaseArmor
	{
		public override string Name { get { return "Mail Plate"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 190; } }

		public override int StrReq { get { return 593; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 1200; } }
		public override int InitMaxHits { get { return 1200; } }
        public override int SellPrice { get { return 80000; } }

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

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public MailPlate() : base (7)
		{
		}

		public MailPlate(Serial serial) : base (serial)
		{
		}
	}
}
