//#define NOSQL
#define PROMOCAP12

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

using LKCamelot.net;
using LKCamelot.util;
using LKCamelot.model;
using LKCamelot.script;

using System.Diagnostics;
using System.Threading;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace LKCamelot.io
{
    public partial class IOClient
    {
        public Connection connection;
        private long connectedAt;
        public bool CStatus = true;
        public LKCamelot.net.PacketWriter mm_stream;
        private object _bufferLock = new object();
        public CastHandler castHandler;
        public CombatHandler2 combatHandler;
        private long ChatTimeout = 0, lastcmd = 0;
        private int AliasStage = 0;
        private int AronStage = 0;
        bool firstlogin = false;
        public long keepalive = 0;

        private readonly Stream incomingStream = new Stream();

        public Player player;
        public PlayerHandler handler;

        public IOClient(Connection s)
        {
            this.connection = s;
            this.connectedAt = Server.CurrentTimeMillis();
            this.mm_stream = new PacketWriter(255);
            this.castHandler = new CastHandler(this, handler);
            this.combatHandler = new CombatHandler2(this, handler);
            //    IOHostList.add(connectedFrom);
        }

        delegate void UpdatePacketInvoker(Byte[] packet);

        public void Parse(ConnectionDataEventArgs e)
        {
            incomingStream.AppendData(e.Data.ToArray());
            while (incomingStream.IsPacketAvailable())
            {
                var packet = incomingStream.PopPacket();

                try
                {
                    //   Logger.LogIncomingPacket(message); 
                    //       Console.WriteLine(packet.ToFormatedHexString());
                    HandleIncoming(packet);
                }
                catch (NotImplementedException) { }
                catch (Exception ee)
                {
                    Console.WriteLine("Unknown process exception: {0}", ee.StackTrace);
                }
            }
            incomingStream.Flush();
        }

        public void SendPacket(Byte[] packet)
        {
            lock (this._bufferLock)
                connection.Send(packet);
        }

        public void Process()
        {
        }

        public short AttackRange(short x, short y, short x2, short y2)
        {
            if (x2 - x == 0 && y2 - y == 0)
                return 0;
            if (x2 - x == -1 && y2 - y == 1)
                return 1;
            if (x2 - x == -1 && y2 - y == 0)
                return 2;
            if (x2 - x == -1 && y2 - y == -1)
                return 3;
            if (x2 - x == 0 && y2 - y == -1)
                return 4;
            if (x2 - x == 1 && y2 - y == -1)
                return 5;
            if (x2 - x == 1 && y2 - y == 0)
                return 6;
            if (x2 - x == 1 && y2 - y == 1)
                return 7;
            if (x2 - x == 0 && y2 - y == 1)
                return 0;

            return -1;
        }
     //   System.Collections.Concurrent.ConcurrentDictionary<long, Point2D> walktrace = 
     //       new System.Collections.Concurrent.ConcurrentDictionary<long, Point2D>();
        System.Collections.Generic.List<long> walktrace = new System.Collections.Generic.List<long>();
        private bool Loaded = false;
        public void LoadPlayer()
        {
            if (player == null || Loaded)
                return;
            Loaded = true;

            if (!LKCamelot.model.Map.FullMaps.ContainsKey(player.Map))
            {
                player.m_Map = "Rest";
                player.m_Loc = new Point2D(15, 15);
            }

            var invent = World.NewItems.Where(xe => xe.Value.ParSer == player.Serial).Select(xe => xe.Value);
            foreach (var item in invent)
            {
                item.Parent = player;
            }

            SendPacket(new LoadWorld(player, 1).Compile());

            SendPacket(new UpdateCharStats(player).Compile());
            SendPacket(new SetLevelGold(player).Compile());

            player.LoadNPCs();

            foreach (var spell in player.MagicLearned)
                SendPacket(new CreateSlotMagic2(spell).Compile());

            foreach (var item in World.NewItems.Where(xe => xe.Value.m_Parent == player || xe.Value.ParSer == player.Serial).ToList())
            {
                if (item.Value.InvSlot >= 0 && item.Value.InvSlot <= 24)
                {
                    SendPacket(new AddItemToInventory2(item.Value).Compile());
                }
                else if (item.Value.InvSlot >= 25 && item.Value.InvSlot <= 30)
                {
                    player.Equipped2.TryAdd(item.Value.InvSlot, item.Value);
                    SendPacket(new EquipItem2(item.Value).Compile());
                }
            }

            player.Map = player.Map;

            //01 05 green 
            string text = "Welcome to Last Kingdom Eclipse. ";
            SendPacket(new UpdateChatBox(0x25, 0x65, 5, (short)text.Count(), text).Compile());
            text = "Version 2.0.5. Alpha. May 31, 2013 : 3:18 UTC ";
            SendPacket(new UpdateChatBox(0x00, 0xff, 20737, (short)text.Count(), text).Compile());
            string text2 = "Dedi: Kernel=Linux 3.2.13, Ram=8.2GB, Cores=4 ";
            SendPacket(new UpdateChatBox(0x50, 0x65, 5, (short)text2.Count(), text2).Compile());
            text2 = "Code open-sourced lk.kingdomofk.net/source. ";
            SendPacket(new UpdateChatBox(0x00, 0xff, 5, (short)text2.Count(), text2).Compile());
            text2 = "Contribute.. ))";
            SendPacket(new UpdateChatBox(0x00, 0xff, 5, (short)text2.Count(), text2).Compile());
            // text2 = "@stats added. hp mp extra off 65k cap ";
            // SendPacket(new UpdateChatBox(0x00, 0xff, 5, (short)text2.Count(), text2).Compile());

            if (firstlogin)
            {
                text2 = "Welcome to the Last Kingdom! Here are some tips ";
                SendPacket(new UpdateChatBox(0x25, 0x65, 5, (short)text2.Count(), text2).Compile());
                text2 = "First @go beginner and get level 5 ";
                SendPacket(new UpdateChatBox(0x25, 0x65, 5, (short)text2.Count(), text2).Compile());
                text2 = "Next @go aron and pick a class (knight, swordman, wizard, shaman) ";
                SendPacket(new UpdateChatBox(0x25, 0x65, 5, (short)text2.Count(), text2).Compile());
                text2 = "Next checkout @go weakly and @go skel ";
                SendPacket(new UpdateChatBox(0x25, 0x65, 5, (short)text2.Count(), text2).Compile());
                text2 = "After which you can try @go level and @go item ";
                SendPacket(new UpdateChatBox(0x25, 0x65, 5, (short)text2.Count(), text2).Compile());
                text2 = "Refer to the maps in your client to find you way ";
                SendPacket(new UpdateChatBox(0x25, 0x65, 5, (short)text2.Count(), text2).Compile());
            }

            World.SendToAll(new QueDele(player.Map, new ChangeObjectSpritePlayer(player).Compile()));
        }

        public void HandleGo(string goloc)
        {
            switch (goloc.ToLower())
            {
                case "village":
                    player.Loc = new Point2D(99, 100);
                    player.Map = "Village1";
                    break;
                case "rest":
                case "death":
                    player.Loc = new Point2D(18, 18);
                    player.Map = "Rest";
                    break;
                case "arnold":
                    player.Loc = new Point2D(8, 12);
                    player.Map = "Arnold";
                    break;
                case "aron":
                    player.Loc = new Point2D(98, 60);
                    player.Map = "Village1";
                    break;
                case "loen":
                    player.Loc = new Point2D(8, 12);
                    player.Map = "Loen";
                    break;
                case "employee":
                    player.Loc = new Point2D(128, 94);
                    player.Map = "Village1";
                    break;
                case "alias":
                    player.Loc = new Point2D(90, 176);
                    player.Map = "Village1";
                    break;

                case "beginner":
                    player.Loc = new Point2D(44, 48);
                    player.Map = "Beginner";
                    break;
                case "biggun":
                    player.Loc = new Point2D(167, 119);
                    player.Map = "Village1";
                    break;
                case "miro":
                    player.Loc = new Point2D(135, 58);
                    player.Map = "Village1";
                    break;
                case "golem":
                    player.Loc = new Point2D(15, 0);
                    player.Map = "Golem";
                    break;

                case "weakly":
                    player.Loc = new Point2D(66, 123);
                    player.Map = "Village1";
                    break;
                case "skel":
                    player.Loc = new Point2D(139, 137);
                    player.Map = "Village1";
                    break;
                case "level":
                    player.Loc = new Point2D(99, 130);
                    player.Map = "Village1";
                    break;
                case "item":
                    player.Loc = new Point2D(70, 68);
                    player.Map = "Village1";
                    break;
                case "venture":
                    player.Loc = new Point2D(31, 17);
                    player.Map = "Venture4";
                    break;
                case "treasureland":
                    player.Loc = new Point2D(25, 25);
                    player.Map = "TreasureLand";
                    break;

                case "vv1":
                    player.Loc = new Point2D(25, 25);
                    player.Map = "VV1";
                    break;
                case "vv2":
                    player.Loc = new Point2D(25, 25);
                    player.Map = "VV2";
                    break;
                case "vv3":
                    player.Loc = new Point2D(25, 25);
                    player.Map = "VV3";
                    break;
                case "vv4":
                    player.Loc = new Point2D(25, 25);
                    player.Map = "VV4";
                    break;
                case "vv5":
                    player.Loc = new Point2D(25, 25);
                    player.Map = "VV5";
                    break;

                case "miner":
                    player.Loc = new Point2D(15, 38);
                    player.Map = "Miner0";
                    break;

                case "soccerfield":
                    player.Loc = new Point2D(18, 18);
                    player.Map = "Soccer";
                    break;/*
                      case "eect":
                          player.Loc = new Point2D(18, 18);
                          player.Map = "eect.map";
                          break;*/
            }
        }

        public void parseFace()
        {
            var face = player.Face;
            if (face == 0)
            {
                player.Y--;
            }
            if (face == 1)
            {
                player.X++;
                player.Y--;
            }
            if (face == 2)
            {
                player.X++;
            }
            if (face == 3)
            {
                player.X++;
                player.Y++;
            }
            if (face == 4)
            {
                player.Y++;
            }
            if (face == 5)
            {
                player.X--;
                player.Y++;
            }
            if (face == 6)
            {
                player.X--;
            }
            if (face == 7)
            {
                player.X--;
                player.Y--;
            }
        }
        public long LastAttack, LastCast;
        /*     public int ParseEquipSlot(Item item)
             {
                 var i = item.Sprite;

                 if (i == 0x04 || i == 0xB4 || i == 0xB2)
                 {
                     return LKCamelot.library.EquipSlot.Hat;
                 }
                 if (item.Sprite == 0x52)
                 {
                     return LKCamelot.library.EquipSlot.Amulet;
                 }
                 if ((i >= 9 && i <= 0x10) || (i >= 0x20 && i <= 0x24)
                     || i == 0xB5)
                 {
                     return LKCamelot.library.EquipSlot.Weapon;
                 }
                 if (i == 5 || i == 6 || i == 7 || i == 8 ||
                     i == 0xB1 || i == 0xB6 || i == 0xB8 || i == 0xB9)
                 {
                     return LKCamelot.library.EquipSlot.Armor;
                 }
                 if ((i >= 0x11 && i <= 0x13) || i == 0xB7)
                 {
                     return LKCamelot.library.EquipSlot.Shield;
                 }
                 if (item.Sprite == 1 || item.Sprite == 2 || item.Sprite == 0x53)
                 {
                     return LKCamelot.library.EquipSlot.Ring;
                 }

                 return -1;
             }*/

        public Point2D AdjecentTile(byte swingloc)
        {
            if (swingloc == 0)
                return new Point2D(player.X, player.Y - 1);
            if (swingloc == 1)
                return new Point2D(player.X + 1, player.Y - 1);
            if (swingloc == 2)
                return new Point2D(player.X + 1, player.Y);
            if (swingloc == 3)
                return new Point2D(player.X + 1, player.Y + 1);
            if (swingloc == 4)
                return new Point2D(player.X, player.Y + 1);
            if (swingloc == 5)
                return new Point2D(player.X - 1, player.Y + 1);
            if (swingloc == 6)
                return new Point2D(player.X - 1, player.Y);
            if (swingloc == 7)
                return new Point2D(player.X - 1, player.Y - 1);

            return new Point2D(1, 1);
        }

        public void HandleIncoming(Byte[] data)
        {
            PacketReader p = null;
            switch (data[0])
            {
                case 0x34: // Keep Alive
                    keepalive = Server.tickcount.ElapsedMilliseconds;
                    break;
                //Identifiy
                /*     case 0x37:
                         //     for (int x = 0; x < 40; x++)
                         //     {
                         //        SendPacket(new CreateSlotMagic(new MagicSpell((byte)(x+81), "Hii", 1, 1, (byte)x, library.MagicType.Casted)).Compile());
                         //    }
                         int y = 14;
                         byte sprite = 0;
                         for (int x = 0; x < 255; x++)
                         {
                             Thread.Sleep(100);
                             if (x != 0 && x % 19 == 0)
                             {
                                 y += 3;
                                 x -= 19;
                             }
                             //    SendPacket(new CreateMonster(new Monster(3, (short)(x+23),(short)y,"village.map", sprite.ToString(), sprite, 0), Serial.NewMobile).Compile());
                             sprite++;
                         }
                         break;*/
                case 0x3A: //find
                    if (player.Map == "Loen")
                    {
                        var slot = data[1] + 40 + (12 * player.BankTab);
                        var itemtofind = World.NewItems.Where(xe => xe.Value.ParSer == player.Serial && xe.Value.InvSlot == slot).FirstOrDefault();
                        if (itemtofind.Value != null)
                        {
                            if (player.GetFreeSlot() != -1)
                            {
                                SendPacket(new DeleteEntrustSlot((byte)data[1]).Compile());

                                itemtofind.Value.InvSlot = player.GetFreeSlot();
                                SendPacket(new AddItemToInventory2(itemtofind.Value).Compile());
                            }
                        }
                    }
                    break;
                case 0x36: //Entrust
                    if (player.Map == "Loen")
                    {
                        var itemtoentrust = World.NewItems.Where(xe => xe.Value.ParSer == player.Serial && xe.Value.InvSlot == data[1]).FirstOrDefault();
                        if (itemtoentrust.Value != null)
                        {
                            SendPacket(new DeleteItemSlot((byte)itemtoentrust.Value.InvSlot).Compile());
                            itemtoentrust.Value.InvSlot = player.FreeBankSlot;
                            SendPacket(new AddItemToEntrust(itemtoentrust.Value).Compile());
                        }
                    }
                    break;

                case 0x35: //sell
                    if (player.Map == "Loen")
                    {
                        var itemtosell = World.NewItems.Where(xe => xe.Value.ParSer == player.Serial && xe.Value.InvSlot == data[1]).FirstOrDefault();
                        if (itemtosell.Value != null && itemtosell.Value.SellPrice > 0)
                        {
                            player.Gold += (uint)itemtosell.Value.SellPrice;
                            itemtosell.Value.Delete(player);
                        }
                    }
                    break;

                //Cast
                //  3D-00-00-01-00-00-00-0A-00-09-00
                case 0x3D:
                case 0x19:
                case 0x18:
                    if (LKCamelot.Server.tickcount.ElapsedMilliseconds - player.CastSpeed > LastCast)
                    {
                        LastCast = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                        p = new PacketReader(data, data.Count(), true);
                        int spellslot = p.ReadInt16();
                        if (player.MagicLearned.Count() < spellslot)
                            return;
                        int castonid = p.ReadInt32();
                        short castx = p.ReadInt16();
                        short casty = p.ReadInt16();

                        script.spells.Spell castspell = player.MagicLearned.Where(xe => xe.Slot == spellslot).FirstOrDefault();
                        if (castspell == null) return;

                        castHandler.HandleCast(data[0], castspell, player, castonid, castx, casty);
                    }
                    break;
                //Attack
                case 0x17:
                    if (LKCamelot.Server.tickcount.ElapsedMilliseconds - player.AttackSpeed > LastAttack)
                    {
                        LastAttack = LKCamelot.Server.tickcount.ElapsedMilliseconds;

                        World.SendToAll(new QueDele(player.Serial, player.Map, new SwingAnimationChar(player.Serial, player.Face).Compile()));
                        combatHandler.HandleMelee(player, data[1]);
                    }
                    break;

                //NPC Shop
                case 0x45:
                    var npclook = World.NewNpcs.Where(xe => xe.Key == data[1]).FirstOrDefault();
                    if (npclook.Value != null)
                    {
                        if (npclook.Value.Name == "Loen")
                        {
                            SendPacket(new SpawnShopGump2(npclook.Value.Gump).Compile());
                        }
                        if (npclook.Value.Name == "Arnold")
                        {
                            SendPacket(new SpawnShopGump2(npclook.Value.Gump).Compile());
                        }
                        if (npclook.Value.Name == "Employee")
                        {
                            SendPacket(new SpawnShopGump2(npclook.Value.Gump).Compile());
                        }
                        if (npclook.Value.Name == "Boy")
                        {
                            SendPacket(new SpawnShopGump2(npclook.Value.Gump).Compile());
                        }
                    }
                    break;

                case 0x2B: //2B-03-00-00-00-01-00-04-00-4D-65-6E-75-00
                    p = new PacketReader(data, data.Count(), true);
                    var npcid = p.ReadInt32();
                    var buyslot = p.ReadByte();

                    var npcitself = World.NewNpcs.Where(xe => xe.Key == npcid).FirstOrDefault();
                    if (npcitself.Value != null)
                        npcitself.Value.Buy(player, buyslot);

                    break;

                //Inventory
                case 0x00: //use
                    if (data[1] == 0)
                        return;
                    var itemu = World.NewItems.Where(xe => xe.Value.m_Parent == player
                      && xe.Value.InvSlot == data[1]).FirstOrDefault();

                    if (itemu.Value != null)
                        itemu.Value.Use(player);

                    break;

                case 0x20: //drop
                    var item = World.NewItems.Where(xe => xe.Value.m_Parent == player
                        && xe.Value.InvSlot == data[1]).FirstOrDefault();

                    if (item.Value != null)
                        item.Value.Drop(player);
                    break;

                case 0x1F: //pickup
                    var item1 = World.NewItems.Where(xe => xe.Value.m_Map != null
                        && xe.Value.m_Map == player.Map
                        && xe.Value.Loc.X == player.X && xe.Value.Loc.Y == player.Y)
                       .FirstOrDefault();

                    if (item1.Value != null)
                        item1.Value.PickUp(player);

                    break;
                case 0x1E: //equip Use
                    // case 0x36:
                    var eitem = World.NewItems.Where(xe => xe.Value.m_Parent == player
                        && xe.Value.InvSlot == data[1]).FirstOrDefault();

                    if (eitem.Value != null)
                    {
                        if (eitem.Value is script.item.BaseArmor || eitem.Value is script.item.BaseWeapon)
                            eitem.Value.Equip(player);
                        if (eitem.Value is script.item.BaseSpellbook)
                            eitem.Value.Use(player);
                        if (eitem.Value is script.item.BasePotion)
                            eitem.Value.Use(player);
                    }

                    break;
                case 0x23://unequip
                    var uitem = World.NewItems.Where(xe => xe.Value.m_Parent == player
                        && xe.Value.InvSlot == (data[1] + 25)).FirstOrDefault();

                    if (uitem.Value != null)
                        uitem.Value.Unequip(player, data[1] + 25);
                    break;

                case 0x25: //swap items
                    var item11 = World.NewItems.Where(xe => xe.Value.ParSer == player.Serial && xe.Value.InvSlot == data[1]).FirstOrDefault().Value;
                    int sss = 0;
                    if (data.Count() > 3)
                        sss = data[3];

                    var target1 = World.NewItems.Where(xe => xe.Value.ParSer == player.Serial && xe.Value.InvSlot == sss).FirstOrDefault().Value;

                    player.SwapItems(item11, target1, sss);

                    break;

                case 0x24: //drag,drop
                    var itemdragdrop = World.NewItems.Where(xe => xe.Value.ParSer == player.Serial && xe.Value.InvSlot == data[1]).FirstOrDefault().Value;
                    if (itemdragdrop != null)
                    {
                        p = new PacketReader(data, data.Count(), false);
                        var targetid = p.ReadInt32();

                        script.item.Item targeti = null;
                        World.NewItems.TryGetValue(targetid, out targeti);
                        if (targeti != null)
                        {
                            string fail = "Refining failed.";
                            string succ = "Refining success.";
                            if ((itemdragdrop is script.item.Zel && targeti is script.item.BaseArmor)
                                || (itemdragdrop is script.item.Dai && targeti is script.item.BaseWeapon))
                            {
                                if (targeti.TryUpgrade())
                                {
                                    castHandler.CreateMagicEffect(targeti.Loc, targeti.m_Map, 42);
                                    SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)succ.Count(), succ).Compile());
                                    SendPacket(new DeleteObject(targeti.m_Serial).Compile());
                                    SendPacket(new CreateItemGround2(targeti, targeti.m_Serial).Compile());
                                }
                                else
                                {
                                    castHandler.CreateMagicEffect(targeti.Loc, targeti.m_Map, 56);
                                    SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)fail.Count(), fail).Compile());
                                }
                                itemdragdrop.Delete(player);
                            }
                        }

                        if (targetid == 4)
                        {
                            if (itemdragdrop.Name == "Promote Life Drug" && AronStage == 4)
                            {
                                AronStage = 1;
                                itemdragdrop.Delete(player);
                                string achat = "[Aron]: Are you ready for the promotion?";
                                SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)achat.Count(), achat).Compile());
                            }
                            if (itemdragdrop.Name == "Promote Magic Drug" && AronStage == 4)
                            {
                                AronStage = 2;
                                itemdragdrop.Delete(player);
                                string achat = "[Aron]: Are you ready for the promotion?";
                                SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)achat.Count(), achat).Compile());
                            }
                        }
                    }
                    break;

                //Chat message
                case 0x16:
                    p = new PacketReader(data, data.Count(), false);
                    var str = p.ReadString();
                    var str2 = str.Split(' ');

                    if (Util.ContainsUnicodeCharacter(str))
                    {
                        var x = 1;
                    }

                    HandleChat(str2, str);

                    break;

                //Movement
                case 0x14:
                    player.Face = data[1];
                    World.SendToAll(new QueDele(player.Serial, player.Map, new ChangeFace(player.Serial, player.Face).Compile()));
                    break;
                case 0x15:

                    if (Server.tickcount.ElapsedMilliseconds - player.lastmove < 150)
                    {
                        return;
                    }

                    long totalwalk = 0;
                    foreach (var loc in walktrace)
                    {
                        totalwalk += loc;
                    }

                  //  if(player.Name == "SIR")
                  //  Console.WriteLine(string.Format("{0},{1}   {2}", px, py, Server.tickcount.ElapsedMilliseconds));           
                    if (Server.tickcount.ElapsedMilliseconds - player.lastmove > player.m_MoveSpeed)
                    {
                        p = new PacketReader(data, data.Count(), true);
                        player.Face = p.ReadInt16();
                        var px = p.ReadInt16();
                        var py = p.ReadInt16();

                        walktrace.Add(Server.tickcount.ElapsedMilliseconds - player.lastmove);
                        player.lastmove = Server.tickcount.ElapsedMilliseconds;
                        /*
                        if (walktrace.Count > 3 && totalwalk < 1600)
                        {
                            SendPacket(new MoveSpriteWalkChar(player.Serial, player.Face, player.X, player.Y).Compile());
                            return;
                        }

                        while (walktrace.Count > 4)
                            walktrace.Remove(walktrace.ElementAt(0)); 
                               */
                        if (World.Dist2d(new Point2D(px, py), player.m_Loc) > 3)
                        {
                            SendPacket(new MoveSpriteWalkChar(player.Serial, player.Face, player.X, player.Y).Compile());
                            return;
                        }
                        player.X = px;
                        player.Y = py;

                        World.SendToAll(new QueDele(player.Serial, player.Map, new MoveSpriteWalkChar(player.Serial, player.Face,
                        player.X, player.Y).Compile()));
                        parseFace();
                    }
                    else
                    {
                        SendPacket(new MoveSpriteWalkChar(player.Serial, player.Face, player.X, player.Y).Compile());
                    }
                    break;

                //Stats
                case 0x2C:
                    player.AddStat(ref player.m_Str);
                    SendPacket(new UpdateCharStats(player).Compile());
                    break;
                case 0x2D:
                    player.AddStat(ref player.m_Men);
                    SendPacket(new UpdateCharStats(player).Compile());
                    break;
                case 0x2E:
                    player.AddStat(ref player.m_Dex);
                    SendPacket(new UpdateCharStats(player).Compile());
                    break;
                case 0x2F:
                    player.AddStat(ref player.m_Vit);
                    SendPacket(new UpdateCharStats(player).Compile());
                    break;


                case 0x03: //Login
                    var result = TryLogin(data);
                    switch (result[0])
                    {
                        case '1':
                            var puser2 = result.Remove(0, 1).Split(',');
                            player = handler.add.Where(xe => xe.Value.Name == puser2[0]).FirstOrDefault().Value;
                            player.client = this;
                            player.loggedIn = true;
                            LoadPlayer();
                            SendPacket(new CloseLogin().Compile());
                            break;
                        case '2':
                            SendPacket(new WrongPass().Compile());
                            break;
                        case '3':
                            SendPacket(new WrongID().Compile());
                            break;
                        case '4': //invalid chars
                            SendPacket(new WrongID().Compile());
                            break;
                        case '5':
                            SendPacket(new AlreadyOnline().Compile());
                            break;
                        case '6':
                            player = new Player(this);
                            player.CreateBeginner(result.Remove(0, 1));
                            firstlogin = true;
                            LoadPlayer();
                            player.Pass = Cryption.CreateSaltedSHA256(player.Pass, player.Name);
                            try
                            {
                                handler.add.TryAdd(player.Name, player);
                                var touch = handler.add.Where(xe => xe.Key == player.Name).FirstOrDefault();
                                touch.Value.client = this;
                                touch.Value.loggedIn = true;
                                //   BinaryIO.SavePlayer(player);
                                // World.DBConnect.InsertPlayer(player);
                            }
                            catch
                            {
                                Console.WriteLine("failed to insert new player");
                            }
                            SendPacket(new CloseLogin().Compile());
                            break;
                    }
                    break;

                case 0x49: //delete magic
                    var magdelslot = data[1];
                    player.DeleteMagic(magdelslot);
                    break;

                case 0x26: //swap magic
                    if (data.Count() < 4)
                        player.SwapMagic(data[1], 0);
                    else
                        player.SwapMagic(data[1], data[3]);
                    break;

                case 0xff:
                    SendPacket(new PlayMusic(1000).Compile());
                    if (true) //Login
                    {
                        //         SendPacket(new CloseLogin().Compile());

                        //           SendPacket(new LoadWorld(1, 0x12, 0x12, new byte[] { 00, 04, 00, 00, 00, 00, 00, 00, 00, 03 },
                        //               01, 01, 00, 03, 04, 00, 00,
                        //               new byte[] { 0x69, 0x70, 0x69, 0x67, 0x6d, 0x79, 0x31, 0x2e, 0x6d, 0x61, 0x70, 00 }).Format());
                        break;
                    }
            }
        }
        static object WriteLock = new object();
        public static void WriteBug(string bug)
        {
            lock (WriteLock)
            {
                System.IO.StreamWriter sr = new System.IO.StreamWriter("bugs.txt", true);
                sr.WriteLine(bug);
                sr.Close(); sr.Dispose();
            }
        }

        public string TryLogin(byte[] data)
        {
            byte[] user = new byte[10];
            byte[] pass = new byte[10];
            Buffer.BlockCopy(data, 1, user, 0, 10);
            Buffer.BlockCopy(data, 33, pass, 0, 10);

            int usercnt = 0, passcnt = 0;
            for (int x = 0; x < 10; x++)
            {
                if (user[x] == 00)
                    break;
                if ((int)user[x] > 127)
                    return "4";
                usercnt++;
            }
            for (int x = 0; x < 10; x++)
            {
                if (pass[x] == 00)
                    break;
                if ((int)pass[x] > 127)
                    return "4";
                passcnt++;
            }

            string test = Encoding.ASCII.GetString(user, 0, usercnt).ToUpper().Trim();
            var test2 = Encoding.ASCII.GetString(pass, 0, passcnt);

            //SHA1

            if (!System.Text.RegularExpressions.Regex.IsMatch(test, @"^[a-zA-Z0-9]+$"))
                return "4";

            if (test.Count() < 3 || test2.Count() < 5)
                return "4";

            if (handler.HasPlayer(test))
                return "5";

#if NOSQL
            return "6" + test + "," + test2;
#endif

            //  var info = BinaryIO.LoadName(test);
            var infos = handler.add.Where(xe => xe.Value.Name == test).FirstOrDefault().Value;
            if (infos == null)
                return "6" + test + "," + test2;

            List<string> info = new List<string>();
            info.Add(infos.Name); info.Add(infos.Pass);
            if (info != null && info[0] == test)
            {
                if (info[1].Count() <= 10)
                {
                    if (info[1] != test2)
                        return "2";
                }
                else
                {
                    if (!Cryption.CheckHashPass(info[1], test, test2))
                        return "2";
                }

                return "1" + test + "," + test2;
            }
            else
            {

                return "6" + test + "," + test2;
            }
        }
    }
}
