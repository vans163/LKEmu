using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
using System.Drawing;
using System.Diagnostics;
namespace LKCamelot.script.monster
{
    public enum Race
    {
        Magical = 1,
        Animal = 2,
        Undead = 4,
        Demon = 8,
        Human = 16
    }

    public class Monster : BaseObject
    {
        public Serial m_Serial;
        public int m_MonsterID;
        public string m_Map;
        public string LoadMap { get { return LKCamelot.model.Map.FullMaps.Where(xe => xe.Key == m_Map).FirstOrDefault().Value; } }

        public Point2D m_Loc;
        public Point2D m_SpawnLoc;
        public int Face;
        private int m_HPCur;
        public bool SpawnReady, m_Alive = false;
        public Serial Target;
        public Player TargetP;
        public long LastAction = 0;
        public virtual int Transp { get { return 0; } }
        public virtual byte FrameType { get { return 1; } }
        public int XPMulti = 1;


        public virtual int HP { get { return 0; } }
        public virtual int Dam { get { return 0; } }
        public virtual int AC { get { return 0; } }
        public virtual int Hit { get { return 0; } }
        public virtual int XP { get { return 0; } }
        public virtual int Color { get { return 0; } }
        public virtual int SpawnTime { get { return 30000; } }
        public long LastSpawn;
        public virtual Race Race { get { return 0; } }

        public virtual int WalkSpeed { get { return 500; } }
        public virtual int AttackSpeed { get { return 1000; } }
        public virtual LootPack Loot { get { return null; } }

        MySolver<MyPathNode, Object> aStar;
        LKCamelot.model.SpatialAStar<MyPathNode, object>.PathNode path;

        public virtual void GenerateLoot()
        {
        }

        public MyPathNode AIStep(TiledMap map, Player target)
        {
            var mobs = World.NewMonsters.Where(xe => xe.Value != this && xe.Value.Alive && xe.Value.m_Map == target.Map);
            List<MyPathNode> tempsquares = new List<MyPathNode>();
            foreach (var mob in mobs)
            {
                var tile = map.tiles[mob.Value.m_Loc.X, mob.Value.m_Loc.Y];
                tile.IsWall = true;
                tempsquares.Add(tile);
            }

            aStar = new MySolver<MyPathNode, Object>(map.tiles);
            path = aStar.SearchOnce(new Point(m_Loc.X, m_Loc.Y), new Point(target.X, target.Y), null);

            foreach (var tile in tempsquares)
                map.tiles[tile.X, tile.Y].IsWall = false;
         //   foreach (var mob in mobs)
          //      map.tiles[mob.Value.m_Loc.X, mob.Value.m_Loc.Y].IsWall = false;

            MyPathNode p = new MyPathNode(m_Loc.X, m_Loc.Y);
            if (path != null)
            {
                p.X = path.X;
                p.Y = path.Y;
            }
            path = null;
            aStar.Dispose();
            aStar = null;
            return p;
        }

        public virtual void DropLoot(Player play)
        {
            if (Loot != null)
            {
                foreach (var loot in Loot.m_Entries)
                {
                    if (loot.TryDrop())
                    {
                        var inst = Activator.CreateInstance(Type.GetType(loot.t_item.ToString()));
                        if (inst is script.item.Gold)
                        {
                            var amount = loot.m_Quantity.Roll();
                            if (amount < 500)
                                (inst as script.item.Gold).m_ItemID = 40;
                            if (amount >= 500 && amount < 5000)
                                (inst as script.item.Gold).m_ItemID = 41;
                            if (amount >= 5000 && amount < 50000)
                                (inst as script.item.Gold).m_ItemID = 42;
                            if (amount >= 50000)
                                (inst as script.item.Gold).m_ItemID = 43;
                            (inst as script.item.Gold).Quantity = amount;
                        }
                        if (play.AutoLoot)
                        {
                            if (inst is script.item.Gold)
                                play.Gold += (uint)(inst as script.item.Item).Quantity;
                            else
                            {
                                if (play.GetFreeSlots() > 0)
                                {
                                    inst = (inst as script.item.Item).Inventory(play);
                                    string itdrop = this.Name +" gave you " + (inst as script.item.Item).Name+".";
                                    play.client.SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)itdrop.Count(), itdrop).Compile());
                                    play.client.SendPacket(new LKCamelot.model.AddItemToInventory2((inst as script.item.Item)).Compile());
                                }
                                else
                                {
                                    (inst as script.item.Item).Drop(play, 0);
                                }
                                World.NewItems.TryAdd((inst as script.item.Item).m_Serial, (inst as script.item.Item));
                            }  
                        }
                        else
                        {
                            (inst as script.item.Item).Drop(this, play);
                            World.NewItems.TryAdd((inst as script.item.Item).m_Serial, (inst as script.item.Item));
                        }
                        return;
                    }
                }
            }
        }

        public bool Alive
        {
            get { return m_Alive; }
            set
            {
                if (value == false)
                {
                    LastSpawn = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                    World.SendToAll(new QueDele(m_Map, new DeleteObject(m_Serial).Compile()));
                }

                if (m_Alive == false && value == true)
                {
                    HPCur = HP;
                    Target = 0;
                    //        play.Value.InstancedObjects.Add(m_Serial);
                           World.SendToAll(new QueDele(m_Map, new CreateMonster(this, m_Serial).Compile()));
                           World.SendToAll(new QueDele(m_Map, new SetObjectEffectsMonster(this).Compile()));
                }
                m_Alive = value;
            }
        }

        public int HPCur
        {
            get { return m_HPCur; }
            set
            {
                if (value > HP)
                    value = HP;
                if (value <= 0)
                {
                    value = 0;
                    Alive = false;
                    World.SendToAll(new QueDele(m_Map, new DeleteObject(m_Serial).Compile()));
                }

                if (value < m_HPCur)
                {

                }

                m_HPCur = (short)value;
            }
        }

        public virtual string Name { get { return ""; } }

        public Monster(int MonsterID)
            : this()
        {
            m_MonsterID = MonsterID;
            m_HPCur = HP;
        }

        public virtual void Attack(Player player)
        {
            float h = ((float)Hit / ((float)player.Hit + (float)Hit)) * 200;

            if (h >= 100 || new Random().Next(0, 100) < (int)h)
            {
                var take = Dam - player.AC;
                if (take <= 0)
                    take = 1;
                player.HPCur -= take;
            }
        }

        public virtual void TakeDamage(Player player)
        {
            float h = ((float)player.Hit / ((float)player.Hit + (float)Hit)) * 200;

            if (h >= 100 || new Random().Next(0, 100) < (int)h)
            {
                var take = (player.Dam - AC);
                if (take <= 0)
                    take = 1;
                HPCur -= take;
                World.SendToAll(new QueDele(m_Map, new HitAnimation(m_Serial,
                    Convert.ToByte(((((float)m_HPCur / (float)HP) * 100) * 1))).Compile()));

                if (HPCur <= 0)
                {
                    if (player.Promo > 0)
                    {
                        var temp = XP;

                        if (player.Promo >= 1 && player.Promo <= 6)
                            temp = (int)(temp * 0.03);
                        if (player.Promo >= 7)
                            temp = (int)(temp * 0.01);

                        player.XP += temp * XPMulti;
                    }
                    else
                        player.XP += XP * XPMulti;
                    DropLoot(player);
                    m_Loc.X = m_SpawnLoc.X;
                    m_Loc.Y = m_SpawnLoc.Y;
                }
            }
        }

        public virtual void TakeDamage(Player player, script.spells.Spell spell)
        {
            float h = ((float)player.Hit / ((float)player.Hit + (float)Hit)) * 200;

            if (h >= 100 || new Random().Next(0, 100) < (int)h)
            {
                int take = spell.DamBase + (spell.DamPl * spell.Level);// + (spell.DamPl * spell.SLevel2);
                if (spell.ManaCostPl != 0)
                {
                    take += (player.GetStat("men") / spell.menCoff);
                    take += (player.GetStat("str") / spell.strCoff);
                    take += (player.GetStat("dex") / spell.dexCoff);
                }
                if (spell is script.spells.DemonDeath)
                    take = Convert.ToInt32(player.HP * 0.5) + player.GetStat("dex");


                HPCur -= (take - AC);
                World.SendToAll(new QueDele(m_Map, new HitAnimation(m_Serial,
                   Convert.ToByte(((((float)m_HPCur / (float)HP) * 100) * 1))).Compile()));

                if (HPCur <= 0)
                {
                    if (player.Promo > 0)
                    {
                        var temp = XP;

                        if (player.Promo >= 1 && player.Promo <= 6)
                            temp = (int)(temp * 0.03);
                        if (player.Promo >= 7)
                            temp = (int)(temp * 0.01);

                        player.XP += temp * XPMulti;
                    }
                    else
                        player.XP += XP * XPMulti;
                    DropLoot(player);
                    m_Loc.X = m_SpawnLoc.X;
                    m_Loc.Y = m_SpawnLoc.Y;
                }
            }
        }

        public Monster(Serial serial)
        {
            this.m_Serial = serial;
            HPCur = HP;
        }

        public Monster()
        {
            if (m_Serial == 0)
                m_Serial = Serial.NewMobile;
            HPCur = HP;
        }
    }
}
