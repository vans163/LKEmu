using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
using LKCamelot.library;

namespace LKCamelot.script.item
{
    public enum ItemLoc
    {
        Ground = 0,
        Inventory = 1,
        Equipped = 2,
        Shop = 3
    }

    public class Item
    {
        public Serial m_Serial;
        public int m_ItemID;
        public int m_InvSlot = -1;
        public Player m_Parent;
        public string m_Map;
        public Point2D m_Loc;
        public int Quantity;
        public int Stage;
        public int ParSer;

        public virtual bool Blessed { get { return false; } }
        public virtual string Name { get { return ""; } }
        public virtual string FlavorText { get { return null; } }
        public virtual string DescText { get { return null; } }
        public virtual ulong BuyPrice { get { return 1000000; } }
        public virtual int SellPrice { get { return 0; } }
        //   public virtual string ParsedStats { get { return ""; } }
        public virtual int StrReq { get { return 0; } }
        public virtual int MenReq { get { return 0; } }
        public virtual int DexReq { get { return 0; } }
        public virtual int VitReq { get { return 0; } }
        public virtual LKCamelot.library.Class ClassReq { get { return 0; } }
        public virtual int LevelReq { get { return 0; } }
        public virtual int ReduceCast { get { return 0; } }
        public virtual int ReduceSwing { get { return 0; } }
        public virtual bool Stackable { get { return false; } }

        public virtual int DamBase { get { return 0; } }
        public virtual int ACBase { get { return 0; } }
        public virtual int Level { get { return 0; } }
        public virtual int HPBonus { get { return 0; } }
        public virtual int MPBonus { get { return 0; } }
        public virtual int HitBonus { get { return 0; } }

        public virtual int StrBonus { get { return 0; } }
        public virtual int MenBonus { get { return 0; } }
        public virtual int DexBonus { get { return 0; } }
        public virtual int VitBonus { get { return 0; } }


        public int FullDam
        {
            get
            {
                var temp = DamBase;
                for (int x = 0; x < Stage; x++)
                {
                    temp += (int)(temp * 0.1) + 1;
                }
                return temp;
            }
        }

        public int FullAC
        {
            get
            {
                var temp = ACBase;
                for (int x = 0; x < Stage; x++)
                {
                    temp += (int)(temp * 0.1) + 1;
                }
                return temp;
            }
        }

        public long DropTime = 0;

        public string SQLSaveString()
        {
            string temp = "";
            temp += "\'" + Convert.ToInt32(m_Serial) + "\', ";
            temp += "\'" + this.ToString() + "\', ";
            temp += "\'" + m_ItemID + "\', ";
            temp += "\'" + Convert.ToInt32(ParSer) + "\', ";
            temp += "\'" + InvSlot + "\', ";
            temp += "\'" + Stage + "\', ";
            temp += "\'" + Quantity + "\', ";
            temp = temp.Substring(0, (temp.Count() - 2));
            return temp;
        }

        public string ClassReqString
        {
            get
            {
                string ret = "";
                if ((ClassReq & Class.Knight) != 0)
                    ret += "Knight - ";
                if ((ClassReq & Class.Swordsman) != 0)
                    ret += "Swordsman - ";
                if ((ClassReq & Class.Wizard) != 0)
                    ret += "Wizard - ";
                if ((ClassReq & Class.Shaman) != 0)
                    ret += "Shaman - ";
                if (ret != "")
                    ret = ret.Substring(0, ret.Count() - 3);

                return ret;
            }
        }

        public virtual string ParsedStats
        {
            get
            {
                int strr = StrReq;
                int menr = MenReq;
                int dexr = DexReq;
                int lvlr = LevelReq;

                if (this is BaseSpellbook && m_Parent != null)
                {
                    var spelta = m_Parent.MagicLearned.Where(xe => xe.Name == (this as BaseSpellbook).SpellTaught.Name).FirstOrDefault();
                    if (spelta != null)
                    {
                        strr += (this as BaseSpellbook).StrReqPl * m_Parent.MagicLearned[m_Parent.MagicLearned.IndexOf(spelta)].Level;
                        menr += (this as BaseSpellbook).MenReqPl * m_Parent.MagicLearned[m_Parent.MagicLearned.IndexOf(spelta)].Level;
                        dexr += (this as BaseSpellbook).DexReqPl * m_Parent.MagicLearned[m_Parent.MagicLearned.IndexOf(spelta)].Level;
                        lvlr += (this as BaseSpellbook).LevelReqPl * m_Parent.MagicLearned[m_Parent.MagicLearned.IndexOf(spelta)].Level;
                    }
                }

                string ret = "";
                ret += NPrefix() + " " + Name + "\n\t";
                if (StrReq != 0)
                    ret += "Strength Required: " + strr + "\n\t";
                if (MenReq != 0)
                    ret += "Mentality Required: " + menr + "\n\t";
                if (DexReq != 0)
                    ret += "Dexterity Required: " + dexr + "\n\t";
                if (DamBase != 0)
                    ret += "Damage: " + FullDam + "\n\t";
                if (ACBase != 0)
                    ret += "AC: " + FullAC + "\n\t";
                if (HitBonus != 0)
                    ret += "Hit: " + FullAC + "\n\t";
                if (HPBonus != 0)
                    ret += "HP: " + FullAC + "\n\t";
                if (MPBonus != 0)
                    ret += "MP: " + FullAC + "\n\t";
                if (ReduceCast != 0)
                    ret += "Cast Speed: " + (float)(ReduceCast * 0.01) + "\n\t";
                if (ReduceSwing != 0)
                    ret += "Swing Speed: " + (float)(ReduceSwing * 0.01) + "\n\t";
                if (Stage != 0)
                    ret += "Stage: " + Stage + "\n\t";
                if (ClassReq != 0)
                    ret += "Class Required: " + ClassReqString + "\n\t";
                if (LevelReq != 0)
                    ret += "Level Required: " + lvlr + "\n\t";
                if (SellPrice != 0)
                    ret += "Sell Price: " + SellPrice + "\n\t";
                if (DescText != null)
                    ret += "Special: " + DescText + "\n\t";
                if (FlavorText != null)
                    ret += "\n\t  " + FlavorText + "\n\t";
                

                if (ret != "")
                    ret = ret.Substring(0, ret.Count() - 2);
                return ret;
            }
        }

        public string NPrefix()
        {
            if (Stage >= 1)
            {
                if (this is BaseArmor)
                    return ((script.item.Upgrade)Stage).ToString().ToUpper();
                if (this is BaseWeapon)
                    return ((script.item.UpgradeWep)Stage).ToString().ToUpper();
            }
            return "";
        }

        public Item Inventory(Player play)
        {
            if (Stackable)
            {
                var ore = play.Inventory.Where(xe => xe.Name.Split(':')[0] == this.Name.Split(':')[0]).FirstOrDefault();
                if (ore != null)
                {
                    ore.Quantity++;
                    play.client.SendPacket(new LKCamelot.model.AddItemToInventory2(ore).Compile());
                    return ore;
                }
                else if (ore == null)
                {
                    Quantity++;
                    this.InvSlot = play.GetFreeSlot();
                    this.Loc = null;
                    this.Parent = play;
                }
            }
            else
            {
                this.InvSlot = play.GetFreeSlot();
                this.Loc = null;
                this.Parent = play;
            }
            return this;
        }

        public int EquipSlot
        {
            get
            {
                int ret = m_InvSlot - 25;
                if (ret < 0)
                    ret = 0;
                return ret;
            }
        }

        public int InvSlot
        {
            get { return m_InvSlot; }
            set
            {
                var m_OldInvSlot = m_InvSlot;
                m_InvSlot = value;
                if (m_Parent != null && m_Parent.client != null
                    && m_OldInvSlot != -1 && (value == -1 || value > 24))
                    m_Parent.client.SendPacket(new DeleteItemSlot((byte)m_OldInvSlot).Compile());
            }
        }

        public Point2D Loc
        {
            get { return m_Loc; }
            set
            {
                var old_Loc = m_Loc;
                m_Loc = value;

                if (old_Loc != null && value == null && m_Parent != null && m_Parent.client != null)
                {
                    m_Parent.client.SendPacket(new DeleteObject(m_Serial).Compile());
                }

                if (m_Loc != null && Parent != null)
                {
                    World.SendToAll(new QueDele(Parent.Map, new CreateItemGround2(this, m_Serial).Compile()));
                    //      m_Parent.client.SendPacket(new CreateItemGround2(this, m_Serial).Compile());
                }
            }
        }

        public Item(int itemID)
            : this()
        {
            m_ItemID = itemID;
        }

        public Item(Serial serial)
        {
            this.m_Serial = serial;
        }

        public Item()
        {
            m_Serial = Serial.NewMobile;

            //m_Items = new ArrayList( 1 );
            //     Visible = true;
            //     Movable = true;
            //     Amount = 1;
            //    m_Map = Map.Internal;

            //        World.AddItem(this);
        }

        public virtual Player Parent
        {
            get
            {
                return m_Parent;
            }
            set
            {
                if (m_Parent == value)
                    return;

                Player oldParent = m_Parent;

                if (value != null)
                    ParSer = value.Serial;

                m_Parent = value;

                if (m_Parent == null)
                {

                }

                /*		if ( m_Map != null )
                        {
                            if ( oldParent != null && m_Parent == null )
                                m_Map.OnEnter( this );
                            else if ( m_Parent != null )
                                m_Map.OnLeave( this );
                        }*/
            }
        }

        public virtual void Use(Player player)
        {
        }

        public virtual void Equip(Player player)
        {
            int eslot = -1;
            if (this is BaseWeapon)
            {
                if ((player.Class & (this as BaseWeapon).ClassReq) == 0)
                    return;

                /*         if ((this as BaseWeapon).WeaponType == WeaponType.Axe)
                             player.eqFlags |= library.SpriteEquip.Axe;
                         if ((this as BaseWeapon).WeaponType == WeaponType.Sword)
                             player.eqFlags |= library.SpriteEquip.Sword;
                         if ((this as BaseWeapon).WeaponType == WeaponType.Hammer)
                             player.eqFlags |= library.SpriteEquip.Hammer;
                      */
                eslot = 27;
            }
            else if (this is BaseArmor)
            {
                if ((player.Class & (this as BaseArmor).ClassReq) == 0
                    && (this as BaseArmor).ClassReq != 0)
                    return;

                if ((this as BaseArmor).ArmorType == ArmorType.Helmet)
                    eslot = 25;
                if ((this as BaseArmor).ArmorType == ArmorType.Amulet)
                    eslot = 26;
                if ((this as BaseArmor).ArmorType == ArmorType.Armor)
                    eslot = 28;
                if ((this as BaseArmor).ArmorType == ArmorType.Shield)
                {
                    //    if ((this as BaseArmor).ArmorType == ArmorType.Shield)
                    //     player.eqFlags |= library.SpriteEquip.Shield;
                    eslot = 29;
                }
                if ((this as BaseArmor).ArmorType == ArmorType.Ring)
                    eslot = 30;
            }

            if (eslot != -1)
            {
                if (World.NewItems.Where(xe => xe.Value.m_Parent != null && xe.Value.m_Parent == player
                    && xe.Value.InvSlot == eslot)
                    .FirstOrDefault().Value == null)
                {
                    if (Parent.GetStat("str") >= StrReq && Parent.GetStat("men") >= MenReq && Parent.GetStat("dex") >= DexReq && Parent.Level >= LevelReq)
                    {
                        InvSlot = eslot;
                        Parent.Equipped2.TryAdd(eslot, this);
                        Parent.client.SendPacket(new EquipItem2(this).Compile());
                        Parent.client.SendPacket(new UpdateCharStats(Parent).Compile());
                        World.SendToAll(new QueDele(Parent.Map, new ChangeObjectSpritePlayer(Parent).Compile()));
                        try
                        {
                            //   World.DBConnect.WriteQue.Enqueue(() => World.DBConnect.UpdateItem(this));
                            //    World.DBConnect.UpdateItem(this);
                        }
                        catch { Console.WriteLine("Update Item on Equip Failed"); }
                    }
                }
            }
        }

        public virtual void Unequip(Player player, int slot)
        {
            if (slot >= 25 && slot <= 30)
            {
                if (World.NewItems.Where(xe => xe.Value.m_Parent != null && xe.Value.m_Parent == player
                    && xe.Value.InvSlot == slot).FirstOrDefault().Value != null)
                {
                    var freeslot = Parent.GetFreeSlot();
                    if (freeslot != -1)
                    {
                        script.item.Item outt;
                        Parent.Equipped2.TryRemove(slot, out outt);
                        Parent.client.SendPacket(new DeleteEquipItem2(this).Compile());
                        InvSlot = freeslot;
                        Parent.client.SendPacket(new AddItemToInventory2(this).Compile());
                        Parent.client.SendPacket(new UpdateCharStats(Parent).Compile());
                        World.SendToAll(new QueDele(Parent.Map, new ChangeObjectSpritePlayer(Parent).Compile()));
                        try
                        {
                            //  World.DBConnect.WriteQue.Enqueue(() => World.DBConnect.UpdateItem(this));
                            //   World.DBConnect.UpdateItem(this);
                        }
                        catch { Console.WriteLine("Update Item on Unequip Failed"); }
                    }
                }
            }
        }

        /*
         public const byte Hat = 0x00;
        public const byte Amulet = 0x01;
        public const byte Weapon = 0x02;
        public const byte Armor = 0x03;
        public const byte Shield = 0x04;
        public const byte Ring = 0x05;
         */

        public void Drop(Player player)
        {
            InvSlot = -1;
            m_Map = player.Map;
            Loc = new Point2D(player.X, player.Y);
            Parent = null;
            ParSer = 0;
            try
            {
             //   World.DBConnect.WriteQue.Enqueue(() => World.DBConnect.DeleteItem(m_Serial));
                //   World.DBConnect.DeleteItem(m_Serial);
            }
            catch
            {
                Console.WriteLine("failed to delete item on drop");
            }
        }

        public void Drop(script.monster.Monster mob, Player player)
        {
            InvSlot = -1;
            m_Map = player.Map;
            DropTime = LKCamelot.Server.tickcount.ElapsedMilliseconds;

            Loc = new Point2D(mob.m_Loc.X, mob.m_Loc.Y);

            Parent = null;
        }
        public void Drop(Player player, int j)
        {
            InvSlot = -1;
            m_Map = player.Map;
            DropTime = LKCamelot.Server.tickcount.ElapsedMilliseconds;

            Loc = new Point2D(player.m_Loc.X, player.m_Loc.Y);

            Parent = null;
        }

        public void PickUp(Player player)
        {
            var slot = player.GetFreeSlot();
            if (this is Gold)
            {
                Item temp;
                player.Gold += (uint)Quantity;
                World.SendToAll(new QueDele(m_Map, new DeleteObject(m_Serial).Compile()));
                World.NewItems.TryRemove(m_Serial, out temp);
                Loc = null;
                World.RemoveDynamicObj(m_Map, m_Serial);

                return;
            }
            if (slot != -1)
            {
                DropTime = 0;
                World.RemoveDynamicObj(m_Map, m_Serial);
                World.SendToAll(new QueDele(m_Map, new DeleteObject(m_Serial).Compile()));
                m_Map = "inventory";
                Parent = player;


                Loc = null;
                InvSlot = slot;
               // World.DBConnect.WriteQue.Enqueue(() => World.DBConnect.UpdateItem(this));
                Parent.client.SendPacket(new AddItemToInventory2(this).Compile());
            }
        }

        public bool TryUpgrade()
        {
            if (Util.Random(0, 100) >= 100 * (Stage * 0.1))
            {
                Stage++;
             //   World.DBConnect.WriteQue.Enqueue(() => World.DBConnect.UpdateItem(this));
                return true;
            }
            else
            {
                DeleteGround();
                return false;
            }
        }

        public void DeleteGround()
        {
            World.SendToAll(new QueDele(m_Map, new DeleteObject(m_Serial).Compile()));
            Item temp;
            if (!World.NewItems.TryRemove(m_Serial, out temp))
                Console.WriteLine("Failed to delete item");
            World.RemoveDynamicObj(m_Map, m_Serial);
          //  World.DBConnect.WriteQue.Enqueue(() => World.DBConnect.DeleteItem(m_Serial));
        }

        public void Delete(Player player)
        {
            this.m_Loc = null;
            this.m_Map = null;
            this.Parent = null;
            this.ParSer = -1;
            Item temp;
            World.NewItems.TryRemove(m_Serial, out temp);
            player.client.SendPacket(new DeleteItemSlot((byte)InvSlot).Compile());
            this.InvSlot = -1;
            try
            {
             //   World.DBConnect.WriteQue.Enqueue(() => World.DBConnect.DeleteItem(m_Serial));
                //     World.DBConnect.DeleteItem(m_Serial);
            }
            catch
            {
                Console.WriteLine("failed to delete item on delete");
            }
        }
    }
}