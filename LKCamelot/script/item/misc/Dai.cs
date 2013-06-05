using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class Dai : Item
    {
        public override string Name { get { return "DAIYEN FOOELS"; } }
        public override int SellPrice { get { return 114000; } }
        public override ulong BuyPrice { get { return 250000; } }

        public Dai()
            : base(162)
        {
        }

        public Dai(Serial serial)
            : base(serial)
        {
            m_ItemID = 162;
        }
    }
}
