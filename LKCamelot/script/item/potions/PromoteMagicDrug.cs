using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class PromoteMagicDrug : BasePotion
    {
        public override string Name { get { return "Promote Magic Drug"; } }
        public override ulong BuyPrice { get { return 5000; } }

        public PromoteMagicDrug()
            : base(23)
        {
        }

        public PromoteMagicDrug(Serial serial)
            : base(serial)
        {
            m_ItemID = 23;
        }
    }
}
