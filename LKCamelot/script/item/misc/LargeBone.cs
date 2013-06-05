using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class LargeBone : Item
    {
        public override string Name { get { return "LARGE BONE"; } }
        public override int SellPrice { get { return 400; } }

        public LargeBone()
            : base(124)
        {
        }

        public LargeBone(Serial serial)
            : base(serial)
        {
        }
    }
}
