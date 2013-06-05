using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class BaseShield : BaseArmor
    {
        public BaseShield(int itemID) : base(itemID)
        {
        }

        public BaseShield(Serial serial) : base(serial)
        {
        }
    }
}
