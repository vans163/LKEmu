using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class DogBone : Item
    {
        public override string Name { get { return "DOG BONE"; } }
        public override int SellPrice { get { return 100; } }

        public DogBone()
            : base(124)
        {
        }

        public DogBone(Serial serial)
            : base(serial)
        {
        }
    }
}
