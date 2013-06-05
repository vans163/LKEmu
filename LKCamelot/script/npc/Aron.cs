using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.npc
{
    public class Aron : BaseNPC
    {
        public override string Name { get { return "Aron"; } }
        public override string Map { get { return "Village1"; } }
        public override string ChatString { get { return "Aron: type \"make me a swordman\" to be a swordman."; } }
        public override int ID { get { return (int)LKCamelot.library.NPCs.Wizard; } }
        public override int X { get { return 98; } }
        public override int Y { get { return 57; } }
        public override int Face { get { return 1; } }
        public override int Sprite { get { return (int)LKCamelot.library.NPCs.Wizard; } }
        public override int aSpeed { get { return 4; } }
        public override int aFrames { get { return 7; } }

        public Aron()
        {
        }
    }
}
