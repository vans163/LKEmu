using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.npc
{
    public class BaseNPC
    {
        public virtual string Name { get { return ""; } }
        public virtual string Map { get { return ""; } }
        public virtual string ChatString { get { return ""; } }
        public virtual int ID { get { return 0; } }
        public virtual int X { get { return 0; } }
        public virtual int Y { get { return 0; } }
        public virtual int Face { get { return 0; } }
        public virtual int Sprite { get { return 0; } }
        public virtual int aSpeed { get { return 0; } }
        public virtual int aFrames { get { return 0; } }
        public virtual GUMP Gump { get { return null; } }

        public virtual void Buy(Player player, int buyslot)
        {
        }
    }

    public class GUMP
    {
        public int ID;
        public ushort Titlec;
        public ushort Boxc;
        public byte Time;
        public string ShopName;
        public List<item.Item> SellList;

        public GUMP()
        {
        }

        public GUMP(int ID, ushort titlec, ushort boxc, byte time, string shopname, List<item.Item> SellList)
        {
            this.ID = ID;
            this.Titlec = titlec;
            this.Boxc = boxc;
            this.Time = time;
            this.ShopName = shopname;
            this.SellList = SellList;
        }

        public byte[] ItemIDArray
        {
            get
            {
                byte[] list = new byte[32];
                int itr = 0;
                foreach (var sell in SellList)
                {
                    list[itr + 1] = (byte)(sell.m_ItemID >> 8);
                    list[itr] = (byte)sell.m_ItemID;

                    itr += 2;
                }
                return list;
            }
        }

        public string ItemNameString
        {
            get
            {
                string temp = "";
                foreach (var item in SellList)
                {
                    temp += item.BuyPrice +" "+item.Name + " ,";
                }
                return temp;
            }
        }

        public byte[] ItemNameArray
        {
            get
            {
                byte[] temp = new byte[512];
                int itr = 0;
                foreach (var item in SellList)
                {
                    var stemp = item.Name;
                    if (item != SellList.Last())
                        stemp += ",";
                    System.Buffer.BlockCopy(stemp.ToCharArray(), 0, temp, itr, stemp.Length);
                    itr += stemp.Length;
                }

                Array.Resize(ref temp, itr);
                return temp;
            }
        }
    }
}
