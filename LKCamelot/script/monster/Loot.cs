using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.script.item;
using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class LootPackEntry
    {
        public int m_Chance;
        public LootPackDice m_Quantity;
        public int m_MaxProps;
        private int m_MinIntensity, m_MaxIntensity;

        private bool m_AtSpawnTime;
        private LootPackItem[] m_Items;
        public Type m_item;

        public Type t_item
        {
            get
            {
                if (PackItems == null)
                    return m_item;

                var rand = new Random();
                var ret = PackItems[rand.Next(PackItems.Length)];
                return ret;
            }
        }
        public Type[] PackItems = null;

        public LootPackEntry(double chance, Type item, string quantity)
            : this(chance, item, new LootPackDice(quantity), 0, 0, 0)
        {
        }

        public LootPackEntry(double chance, Type item, int quantity)
            : this(chance, item, new LootPackDice(0, 0, quantity), 0, 0, 0)
        {
        }

        public LootPackEntry(double chance, Type item, string quantity, int maxProps, int minIntensity, int maxIntensity)
            : this(chance, item, new LootPackDice(quantity), maxProps, minIntensity, maxIntensity)
        {
        }

        public LootPackEntry(double chance, Type[] item, string quantity, int maxProps, int minIntensity, int maxIntensity)           
        {
            m_Chance = (int)(100 * chance);
            PackItems = item;
            m_Quantity = new LootPackDice(quantity);
            m_MaxProps = maxProps;
            m_MinIntensity = minIntensity;
            m_MaxIntensity = maxIntensity;
        }

        public LootPackEntry(double chance, Type item, int quantity, int maxProps, int minIntensity, int maxIntensity)
            : this(chance, item, new LootPackDice(0, 0, quantity), maxProps, minIntensity, maxIntensity)
        {
        }

        public LootPackEntry(double chance, Type item, LootPackDice quantity, int maxProps, int minIntensity, int maxIntensity)
        {
            m_Chance = (int)(100 * chance);
            m_item = item;
            m_Quantity = quantity;
            m_MaxProps = maxProps;
            m_MinIntensity = minIntensity;
            m_MaxIntensity = maxIntensity;
        }

        public bool TryDrop()
        {
            var roll = Util.Random(1, 10000);
            if (roll <= m_Chance)
                return true;
            return false;
        }
    }

    public class LootPackItem
    {
        private Type m_Type;
        private int m_Chance;

        public Type Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        public int Chance
        {
            get { return m_Chance; }
            set { m_Chance = value; }
        }

        public static script.item.Item RandomScroll(int index, int minCircle, int maxCircle)
        {
            return null;
        }

        public script.item.Item Construct(bool inTokuno, bool isMondain)
        {

            return null;
        }

        public LootPackItem(Type type, int chance)
        {
            m_Type = type;
            m_Chance = chance;
        }
    }

    public class LootPackDice
    {
        private int m_Count, m_Sides, m_Bonus;

        public int Count
        {
            get { return m_Count; }
            set { m_Count = value; }
        }

        public int Sides
        {
            get { return m_Sides; }
            set { m_Sides = value; }
        }

        public int Bonus
        {
            get { return m_Bonus; }
            set { m_Bonus = value; }
        }

        public int Roll()
        {
            int v = m_Bonus;

            for (int i = 0; i < m_Count; ++i)
                v += Util.Random(1, m_Sides);

            return v;
        }

        public LootPackDice(string str)
        {
            int start = 0;
            int index = str.IndexOf('d', start);

            if (index < start)
                return;

            m_Count = Util.ToInt32(str.Substring(start, index - start));

            bool negative;

            start = index + 1;
            index = str.IndexOf('+', start);

            if (negative = (index < start))
                index = str.IndexOf('-', start);

            if (index < start)
                index = str.Length;

            m_Sides = Util.ToInt32(str.Substring(start, index - start));

            if (index == str.Length)
                return;

            start = index + 1;
            index = str.Length;

            m_Bonus = Util.ToInt32(str.Substring(start, index - start));

            if (negative)
                m_Bonus *= -1;
        }

        public LootPackDice(int count, int sides, int bonus)
        {
            m_Count = count;
            m_Sides = sides;
            m_Bonus = bonus;
        }
    }

    public class LootPack
    {
        public LootPackEntry[] m_Entries;

        public LootPack(LootPackEntry[] entries)
        {
            m_Entries = entries;
        }


    }
}
