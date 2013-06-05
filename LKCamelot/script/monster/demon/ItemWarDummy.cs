using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class ItemWarDummy : Monster
    {
        public override string Name { get { return "Item War Dummy"; } }
        public override int HP { get { return 8500; } }
        public override int Dam { get { return 590; } }
        public override int AC { get { return 310; } }
        public override int Hit { get { return 567; } }
        public override int XP { get { return 1; } }
        public override int Color { get { return 0; } }
        public override int WalkSpeed { get { return 600; } }
        public override int SpawnTime { get { return 1200000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(2, typeof(script.item.RevelationBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.BraveRing), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.SamuraiPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(5, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    
                    new LootPackEntry(1, typeof(script.item.AssassinBook), "15d10+225", 1, 1, 1),                 

                    new LootPackEntry(1, typeof(script.item.WarStaff), "15d10+225", 1, 1, 1),
                    new LootPackEntry(.1, typeof(script.item.GrandStaff), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.Javelin), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.BastardSword), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.MailPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.GreatSword), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.GreatAxe), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.FullPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.SevenStarSword), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.BigBangBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(25.0, typeof(script.item.Gold), "10d20+4200", 40, 1, 1),
                });
            }
        }

        public ItemWarDummy()
            : base(13)
        {
        }

        public ItemWarDummy(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 13;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public ItemWarDummy(Serial serial)
            : base(serial)
        {
        }
    }
}
