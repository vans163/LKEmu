using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class ItemPigmy : Monster
    {
        public override string Name { get { return "Item Pigmy"; } }
        public override int HP { get { return 300; } }
        public override int Dam { get { return 98; } }
        public override int AC { get { return 58; } }
        public override int Hit { get { return 127; } }
        public override int XP { get { return 1; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 300000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(2, typeof(script.item.ThunderCrossBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.FlameRoundBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.TraceBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.Mantle), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.Rapier), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.Mask), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.Saber), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.TraceBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.SquareShield), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.OneEdgedAxe), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.SmallAxe), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.Cape), "15d10+225", 1, 1, 1),
                //  new LootPackEntry(2, typeof(script.item.ComebackBook), "15d10+225", 1, 1, 1),                        
                    new LootPackEntry(25.0, typeof(script.item.Gold), "5d10+800", 40, 1, 1),
                });
            }
        }

        public ItemPigmy()
            : base(4)
        {
        }

        public ItemPigmy(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 4;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public ItemPigmy(Serial serial)
            : base(serial)
        {
        }
    }
}
