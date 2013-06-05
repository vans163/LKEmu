using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class Zel : Item
    {
        public override string Name { get { return "ZELGO MER"; } }
        public override int SellPrice { get { return 70000; } }
        public override ulong BuyPrice { get { return 210000; } }

        public Zel()
            : base(161)
        {
        }

        public Zel(Serial serial)
            : base(serial)
        {
            m_ItemID = 161;
        }
    }
}
