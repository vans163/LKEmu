using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class Bone : Item
    {
        public override string Name { get { return "BONE"; } }
        public override int SellPrice { get { return 200; } }

        public Bone()
            : base(124)
        {
        }

        public Bone(Serial serial)
            : base(serial)
        {
        }
    }
}
