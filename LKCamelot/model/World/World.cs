using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Timers;
using System.IO;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;

namespace LKCamelot.model
{
    public class MyPathNode : IPathNode<Object>, IDisposable
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Boolean IsWall { get; set; }
        public bool SpawnP;

        public bool IsWalkable(Object unused)
        {
            return !IsWall;
        }

        public MyPathNode(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Dispose()
        {

        }
    }

    public class MySolver<TPathNode, TUserContext> : SpatialAStar<TPathNode, TUserContext> where TPathNode : IPathNode<TUserContext>, IDisposable
    {
        protected override Double Heuristic(PathNode inStart, PathNode inEnd)
        {
            return Math.Abs(inStart.X - inEnd.X) + Math.Abs(inStart.Y - inEnd.Y);
        }

        protected override Double NeighborDistance(PathNode inStart, PathNode inEnd)
        {
            return Heuristic(inStart, inEnd);
        }

        public MySolver(TPathNode[,] inGrid)
            : base(inGrid)
        {
        }

        public void Dispose()
        {
            base.Dispose();
        }
    }

    public class QueDele
    {
        public string Map;
        public byte[] Packet;
        public long Serial;
        public int tempser;

        public QueDele(string map, byte[] packet)
        {
            this.Map = map;
            this.Packet = packet;
            this.Serial = -1;
        }

        public QueDele(long ser, string map, byte[] packet)
        {
            this.Map = map;
            this.Packet = packet;
            this.Serial = ser;
        }

        public QueDele()
        {
        }
    }

    public class World
    {
        public static World singleton = new World();
        public static World getSingleton()
        {
            if (singleton == null)
                singleton = new World();

            return singleton;
        }


        public static ConcurrentDictionary<Serial, LKCamelot.script.item.Item> NewItems;
        public static Dictionary<Serial, LKCamelot.script.npc.BaseNPC> NewNpcs;
        public static Dictionary<Serial, LKCamelot.script.monster.Monster> NewMonsters;
        public static ConcurrentDictionary<Serial, LKCamelot.script.item.AuctionItem> NewAuctions;

        public static ConcurrentDictionary<Serial, Serial> m_MObjects;
        public PlayerHandler handler;
        public static Server w_server;
        Task spawner;

        public long LastRegen = 0;
        public long lastitemsave = 0;

        public static List<QueDele> TickQue = new List<QueDele>();

        public void Tick()
        {

            if (NewItems == null)
            {
                NewItems = new ConcurrentDictionary<Serial, LKCamelot.script.item.Item>();
                NewAuctions = new ConcurrentDictionary<Serial, script.item.AuctionItem>();
                foreach (var items in BinaryIO.LoadItems())
                    NewItems.TryAdd(items.m_Serial, items);
                foreach (var play in BinaryIO.LoadAuctions())
                    NewAuctions.TryAdd(play.item.m_Serial, play);
                foreach (var play in BinaryIO.LoadPlayers())
                    handler.add.TryAdd(play.Name, play);
                Console.WriteLine("Loaded " + NewAuctions.Count + " Auctions.");
                Console.WriteLine("Loaded " + NewItems.Count + " Items.");
                Console.WriteLine("Loaded " + handler.add.Count + " Players.");
            }

            if (m_MObjects == null)
            {
                m_MObjects = new ConcurrentDictionary<Serial, Serial>();
                foreach (var mobile in handler.add.Values)
                    m_MObjects.TryAdd(mobile.Serial, mobile.Serial);
                foreach (var item in NewItems)
                    m_MObjects.TryAdd(item.Key, item.Key);
                foreach (var item in NewAuctions)
                    m_MObjects.TryAdd(item.Key, item.Key);
            }

            if (NewNpcs == null)
                NewNpcs = new Dictionary<Serial, LKCamelot.script.npc.BaseNPC>()
                {
                   { 1, new script.npc.Arnold() },
                   { 2, new script.npc.Employee() },
                   { 3,  new script.npc.Loen() },
                   { 4, new script.npc.Aron() },
                   { 7, new script.npc.Boy() },
                   { 5, new script.npc.Alias() },
                };

            if (World.NewMonsters == null)
                Spawnere.Spawn();

            if (spawner == null)
            {
                spawner = Task.Factory.StartNew(() =>
                    { spawnrun(); }
                    );
            }


            QueDele tq;
            List<QueDele> TickQued = new List<QueDele>();
            try
            {
                TickQued = TickQue.ToList();
            }
            catch { };

            foreach (var tick in TickQued)
            {
                if (tick == null)
                {
                    TickQue.RemoveAt(0);
                    continue;
                }

                if (tick.Serial < LKCamelot.Server.tickcount.ElapsedMilliseconds)
                {
                    SendToAll(tick);
                    TickQue.Remove(tick);
                    //  var ttt = tick.Packet.Skip(1).Take(4);
                    Serial temp;
                    if (m_MObjects.ContainsKey(tick.tempser))
                        m_MObjects.TryRemove(tick.tempser, out temp);
                }
            }

            if (LKCamelot.Server.tickcount.ElapsedMilliseconds - 3600000 > lastitemsave)
            {
                lastitemsave = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                SaveAll();
                string chat = "[Alias]: Bring your friends to the Last Kingdom!";
                SendToAll(new QueDele("all", new UpdateChatBox(0x08, 0x02, 0, (short)chat.Count(), chat).Compile()));
                chat = "[Alias]: Visit the trader at: lk.kingdomofk.net/trader!";
                SendToAll(new QueDele("all", new UpdateChatBox(0x08, 0x02, 0, (short)chat.Count(), chat).Compile()));
            }


            foreach (var playe in w_server.OnlineConnections)
            {
                if (playe.Client == null || playe.Client.player == null)
                    continue;

                KeyValuePair<string, Player> play =
                    new KeyValuePair<string, Player>(playe.Client.player.Name, playe.Client.player);
                if (play.Value == null || play.Value.loggedIn == false)
                    continue;

                if ((play.Value.client.keepalive + 15000) < Server.tickcount.ElapsedMilliseconds)
                    w_server.Disconnect(play.Value.client.connection);

                if (play.Value.client.connection == null || play.Value.client.connection.Socket == null)
                    w_server.Disconnect(play.Value.client.connection);


                if (play.Value.Color == 0)
                {
                    if (play.Value.pklastpk.Count > 0)
                        play.Value.Color = 1;
                    else if (Server.tickcount.ElapsedMilliseconds > play.Value.pkPinkDelay &&
                        Server.tickcount.ElapsedMilliseconds - play.Value.pkpinkktime < play.Value.pkPinkDelay)
                        play.Value.Color = 2;
                }
                if (play.Value.Color == 2)
                {
                    if (Server.tickcount.ElapsedMilliseconds - play.Value.pkpinkktime > play.Value.pkPinkDelay)
                        play.Value.Color = 0;
                    if (play.Value.pklastpk.Count > 0)
                        play.Value.Color = 1;
                }

                if (play.Value.Color == 1)
                {
                    try
                    {
                        long[] pkslist = new long[play.Value.pklastpk.Count];
                        play.Value.pklastpk.CopyTo(pkslist);
                        if (Server.tickcount.ElapsedMilliseconds - play.Value.pklastred > play.Value.pkRedDelay)
                        {
                            play.Value.pklastred = Server.tickcount.ElapsedMilliseconds;
                            play.Value.pklastpk.RemoveAt(0);
                        }
                        if (play.Value.pklastpk.Count == 0)
                            play.Value.Color = 0;
                        /*     foreach (var pk in pkslist)
                             {
                                 if (Server.tickcount.ElapsedMilliseconds - pk > play.Value.pkRedDelay)
                                     play.Value.pklastpk.Remove(pk);
                             }*/
                    }
                    catch { }
                }

                if (play.Value.AutoMana && play.Value.MPCur < (play.Value.MP * play.Value.AutoManaP))
                {
                    var pot = NewItems.Where(xe => xe.Value.Parent != null && (xe.Value.Parent == play.Value || xe.Value.ParSer == play.Value.Serial)
                        && (xe.Value.Name == "Magic Drug" || xe.Value.Name == "Full Magic Drug")).FirstOrDefault();
                    if (pot.Value != null)
                        pot.Value.Use(play.Value);
                }
                if (play.Value.AutoHP && play.Value.HPCur < (play.Value.HP * play.Value.AutoHPP))
                {
                    var pot = NewItems.Where(xe => xe.Value.Parent != null && (xe.Value.Parent == play.Value || xe.Value.ParSer == play.Value.Serial)
                        && (xe.Value.Name == "Life Drug" || xe.Value.Name == "Full Life Drug")).FirstOrDefault();
                    if (pot.Value != null)
                        pot.Value.Use(play.Value);
                }

                if (play.Value.AutoHit && LKCamelot.Server.tickcount.ElapsedMilliseconds - play.Value.AttackSpeed > play.Value.autohittick
                    && LKCamelot.Server.tickcount.ElapsedMilliseconds - play.Value.AttackSpeed > play.Value.client.LastAttack)
                {
                    play.Value.autohittick = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                    play.Value.client.LastAttack = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                    World.SendToAll(new QueDele(play.Value.Map, new SwingAnimationChar(play.Value.Serial, play.Value.Face).Compile()));
                    play.Value.client.combatHandler.HandleMelee(play.Value, play.Value.Face);
                }

                if (LKCamelot.Server.tickcount.ElapsedMilliseconds - play.Value.RegenTick > play.Value.LastRegen)
                {
                    float regamt = 0.1f;
                    if (play.Value.Map == "Rest")
                        regamt = 0.25f;
                    play.Value.LastRegen = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                    var playhp = play.Value;
                    playhp.HPCur += (int)((float)playhp.HP * regamt);
                    playhp.MPCur += (int)((float)playhp.MP * regamt);
                }

                /*      var Items = World.NewItems.Where(xe => xe.Value.m_Map != null
                       && xe.Value.m_Map == play.Value.Map)
                       .Select(xe => xe);
  */




                /*       var LocalPlayers = handler.add.Where(xe => xe.Value != null && xe.Value.Map != null
                           && xe.Value.loggedIn && xe.Value.Map == play.Value.Map).Select(xe => xe);



                       foreach (var playee in LocalPlayers)
                       {
                           if (playee.Key == play.Key)
                               continue;

                           if (!play.Value.InstancedObjects.Contains(playee.Value.Serial))
                           {
                               play.Value.InstancedObjects.Add(playee.Value.Serial);
                               play.Value.client.SendPacket(new CreateChar(playee.Value, playee.Value.Serial).Compile());
                               play.Value.client.SendPacket(new SetObjectEffectsPlayer(playee.Value).Compile());
                           }
                       }*/

                //   System.Threading.Tasks.Parallel.ForEach(Monsters, mob => ProcMobs(play, mob));

            }

        }

        public static int lastswing = 0;
        public static int lastmove = 0;
        public static int LastSpawn = 0;

        public void spawnrun()
        {
            while (true)
            {
                try
                {
                    foreach (var mob in NewMonsters)
                    {
                        var LocalPlayers = w_server.OnlineConnections.Where(xe => xe.Client != null && xe.Client.player != null &&
                        xe.Client.player.Map != null && xe.Client.player.loggedIn && xe.Client.player.m_Map == mob.Value.m_Map).Select(xe => xe.Client.player);

                        if (mob.Value.Alive == false)
                        {
                            if (LKCamelot.Server.tickcount.ElapsedMilliseconds - mob.Value.SpawnTime > mob.Value.LastSpawn)
                            {
                                mob.Value.m_Loc.X = mob.Value.m_SpawnLoc.X;
                                mob.Value.m_Loc.Y = mob.Value.m_SpawnLoc.Y;
                                mob.Value.Alive = true;
                                //ProcQue.Enqueue(new QueDele(mob.Value.m_Map, new CreateMonster(mob.Value, mob.Value.m_Serial).Compile()));
                            }
                            else
                            {
                                continue;
                            }
                        }


                        var losttarget = LocalPlayers.Where(xe => xe.Serial == mob.Value.Target).FirstOrDefault();
                        if (losttarget == null || Dist2d(losttarget.Loc, mob.Value.m_Loc) >= 15)
                        {
                            mob.Value.Target = 0;
                            mob.Value.TargetP = null;
                        }
                        if (mob.Value.Target == 0)
                        {
                            foreach (var play in LocalPlayers)
                            {
                                if (Dist2d(play.m_Loc, mob.Value.m_Loc) <= 11)
                                {
                                    mob.Value.Target = play.Serial;
                                    mob.Value.TargetP = play;
                                    break;
                                }
                            }
                        }
                        if (mob.Value.Target == 0)
                            continue;
                        var mobdist = Dist2d(mob.Value.m_Loc.X, mob.Value.m_Loc.Y, mob.Value.TargetP.X, mob.Value.TargetP.Y);

                        if (mobdist >= 2 && mobdist < 18 && LKCamelot.Server.tickcount.ElapsedMilliseconds - mob.Value.WalkSpeed > mob.Value.LastAction)
                        {
                            mob.Value.LastAction = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                            var newp = mob.Value.AIStep(Map.loadedmaps[mob.Value.LoadMap], mob.Value.TargetP);

                            if (newp.X == mob.Value.m_Loc.X && newp.Y == mob.Value.m_Loc.Y)
                                continue;

                            mob.Value.Face = (int)GetAngle((short)newp.X, (short)newp.Y, (short)mob.Value.m_Loc.X, (short)mob.Value.m_Loc.Y);

                            //    Point2D newStep = AddMove(mob.Value);

                            SendToAll(new QueDele(mob.Value.m_Map, new MoveSpriteWalk(mob.Value.m_Serial, (short)mob.Value.Face,
                                    (short)mob.Value.m_Loc.X, (short)mob.Value.m_Loc.Y).Compile()));

                            mob.Value.m_Loc.X = newp.X;
                            mob.Value.m_Loc.Y = newp.Y;

                            newp.Dispose();
                            newp = null;

                            if (Dist2d(mob.Value.m_Loc.X, mob.Value.m_Loc.Y, mob.Value.TargetP.X, mob.Value.TargetP.Y) <= 1)
                            {
                                mob.Value.LastAction = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                                mob.Value.Attack(mob.Value.TargetP);

                                SendToAll(new QueDele(mob.Value.m_Map, new SwingAnimation(mob.Value.m_Serial, AttackRange(mob.Value.TargetP.X,
                                        mob.Value.TargetP.Y, (short)mob.Value.m_Loc.X, (short)mob.Value.m_Loc.Y)).Compile()));
                            }
                        }
                        else if (mobdist <= 1 && LKCamelot.Server.tickcount.ElapsedMilliseconds - mob.Value.AttackSpeed > mob.Value.LastAction)
                        {
                            mob.Value.LastAction = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                            mob.Value.Attack(mob.Value.TargetP);

                            SendToAll(new QueDele(mob.Value.m_Map, new SwingAnimation(mob.Value.m_Serial, AttackRange(mob.Value.TargetP.X,
                                    mob.Value.TargetP.Y, (short)mob.Value.m_Loc.X, (short)mob.Value.m_Loc.Y)).Compile()));
                        }
                    }
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    Console.WriteLine("spawner fail " + e.StackTrace);
                }
            }
        }

        public static Point2D AddMove(script.monster.Monster mob)
        {
            int face = mob.Face;
            int x = mob.m_Loc.X;
            int y = mob.m_Loc.Y;
            if (face == 0)
                y -= 1;
            if (face == 1)
            {
                x += 1;
                y -= 1;
            }
            if (face == 2)
                x += 1;
            if (face == 3)
            {
                x += 1;
                y += 1;
            }
            if (face == 4)
                y += 1;
            if (face == 5)
            {
                x -= 1;
                y += 1;
            }
            if (face == 6)
                x -= 1;
            if (face == 7)
            {
                y -= 1;
                x -= 1;
            }
            var p = new Point2D(x, y);

            return p;
        }

        public static short AttackRange(short x, short y, short x2, short y2)
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

            return 0;
        }

        public static short GetAngle(short myx, short myy, short x2, short y2)
        {
            var angle = Math.Atan2(y2 - myy, x2 - myx);
            var test = (angle > 0 ? angle : (2 * Math.PI + angle)) * 360 / (2 * Math.PI);

            if (test == 90)
                return 0;
            if (test > 90 && test < 180)
                return 1;
            if (test == 180)
                return 2;
            if (test > 180 && test < 270)
                return 3;
            if (test == 270)
                return 4;
            if (test > 270 && test < 360)
                return 5;
            if (test == 360)
                return 6;
            if (test > 0 && test < 90)
                return 7;

            return 0;
        }

        public static int Dist2d(int x, int y, int x2, int y2)
        {
            int ret = (int)Math.Sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));
            return ret;
        }

        public static int Dist2d(Point2D one, Point2D two)
        {
            int ret = (int)Math.Sqrt((one.X - two.X) * (one.X - two.X) + (one.Y - two.Y) * (one.Y - two.Y));
            return ret;
        }


        private interface IEntityEntry
        {
            Serial Serial { get; }
            int TypeID { get; }
            long Position { get; }
            int Length { get; }
        }

        public static Serial FindMobile(Serial serial)
        {
            Serial id;

            if (m_MObjects == null)
                m_MObjects = new ConcurrentDictionary<Serial, Serial>();


            m_MObjects.TryGetValue(serial, out id);

            if (id != 0)
                return Serial.MinusOne;

            return serial;
        }

        public static void RemoveDynamicObj(string map, int m_Serial)
        {
            foreach (var ple in PlayerHandler.getSingleton().add)
            {
                if (ple.Key == null || ple.Value == null || ple.Value.loggedIn == false)
                    continue;
                if (ple.Value.Map == map)
                {
                    ple.Value.InstancedObjects.Remove(m_Serial);
                }
            }
        }

        public static void SendToAll(QueDele p)
        {
            var cons = w_server.OnlineConnections;
            foreach (var conn in cons)
            {
                var player = conn.Client.player;
                var client = conn.Client;

                if (player == null || !player.loggedIn)
                    continue;

                if (!client.connection.IsConnected || client.connection._server == null)
                    w_server.Disconnect(client.connection);

                if (p.Map != null && p.Map == "all")
                {
                    client.SendPacket(p.Packet);
                }
                else if (p.Map != null && p.Map == player.Map)
                {
                    if (p.Serial == player.Serial)
                    {
                    }
                    else
                    {
                        client.SendPacket(p.Packet);
                    }
                }
            }

            /*   foreach (var play in PlayerHandler.getSingleton().add)
               {
                   if (play.Value == null || play.Value.loggedIn == false)
                       continue;

                   if (!play.Value.client.connection.IsConnected || play.Value.client.connection._server == null)
                       w_server.Disconnect(play.Value.client.connection);

                   if (p.Map != null && p.Map == "all")
                   {
                       if (!play.Value.loggedIn)
                           continue;
                       play.Value.client.SendPacket(p.Packet);
                   }
                   else if (p.Map != null && p.Map == play.Value.Map)
                   {
                       if (p.Serial == play.Value.Serial)
                       {
                       }
                       else
                       {
                           if (!play.Value.loggedIn)
                               continue;
                           play.Value.client.SendPacket(p.Packet);
                       }
                   }
               }*/
        }

        public static void SendToAllRange(QueDele p, Player playee, int range)
        {
            var cons = w_server.OnlineConnections.Where(xe => xe.Client != null && xe.Client.player != null
                && Dist2d(xe.Client.player.Loc, playee.Loc) < range).Select(xe => xe).ToArray();
            foreach (var conn in cons)
            {
                var player = conn.Client.player;
                var client = conn.Client;

                if (player == null || !player.loggedIn)
                    continue;

                if (!client.connection.IsConnected || client.connection._server == null)
                    w_server.Disconnect(client.connection);

                if (p.Map != null && p.Map == player.Map)
                {
                    if (p.Serial == player.Serial)
                    {
                    }
                    else
                    {
                        client.SendPacket(p.Packet);
                    }
                }
            }

            /*       foreach (var play in PlayerHandler.getSingleton().add.Where(xe => xe.Key != null && xe.Value != null && xe.Value.loggedIn && Dist2d(xe.Value.Loc, playee.Loc) < range).Select(xe => xe))
                   {
                       if (play.Value == null)
                           continue;

                       if (p.Map != null && p.Map == play.Value.Map)
                       {
                           if (p.Serial == play.Value.Serial)
                           {
                           }
                           else
                           {
                               play.Value.client.SendPacket(p.Packet);
                           }
                       }
                   }*/

        }


        public static List<BaseObject> GetTileTarget(Player play, Point2D adjecentTile, int swingdir = 0)
        {
            List<BaseObject> ret = new List<BaseObject>();
            var Targets = World.NewMonsters.Where(xe => xe.Value.m_Map != null
                && xe.Value.m_Map == play.Map
                && xe.Value.m_Loc.X == adjecentTile.X
                && xe.Value.m_Loc.Y == adjecentTile.Y
                && xe.Value.Alive).Select(xe => xe);
            // .Select(xe => xe);

            foreach (var tttt in Targets)
                ret.Add(tttt.Value);


            var Targets2 = PlayerHandler.getSingleton().add.Where(xe => xe.Value != null
                && xe.Value.Map != null
                && xe.Value != play && xe.Value.Map == play.Map
                && xe.Value.loggedIn
                && xe.Value.Loc.X == adjecentTile.X
                && xe.Value.Loc.Y == adjecentTile.Y)
                .Select(xe => xe);
            foreach (var tttt in Targets2)
                ret.Add(tttt.Value);

            var TargetOre = World.NewMonsters.Where(xe => xe.Value.m_Map != null
                && xe.Value.m_Map == play.Map
                && xe.Value.m_Loc.X == adjecentTile.X
                && xe.Value.m_Loc.Y == adjecentTile.Y
                && (xe.Value is script.monster.BaseNode)
                && xe.Value.Alive).Select(xe => xe);

            foreach (var ore in TargetOre)
            {
                (ore.Value as script.monster.BaseNode).Hit(play);
                return null;
            }

            if (play.m_Buffs.Where(xe => xe.BuffEffect.BuffType == script.spells.BuffCase.Triple)
                .FirstOrDefault() != null)
            {
                ret.Clear();
                Targets = World.NewMonsters.Where(xe => xe.Value.m_Map != null && xe.Value.m_Map == play.Map
              &&
              (
              (xe.Value.m_Loc.X == adjecentTile.X && xe.Value.m_Loc.Y == adjecentTile.Y)
              || (xe.Value.m_Loc.X == CombatHandler2.AdjecentTile(play, swingdir - 1).X && xe.Value.m_Loc.Y == CombatHandler2.AdjecentTile(play, swingdir - 1).Y)
              || (xe.Value.m_Loc.X == CombatHandler2.AdjecentTile(play, swingdir + 1).X && xe.Value.m_Loc.Y == CombatHandler2.AdjecentTile(play, swingdir + 1).Y)
              )
              && xe.Value.Alive)
             .Select(xe => xe);

                Targets2 = PlayerHandler.getSingleton().add.Where(xe => xe.Key != null && xe.Value != null && xe.Value.loggedIn && xe.Value.Map == play.Map
                    &&
                    (
                   (xe.Value.m_Loc.X == adjecentTile.X && xe.Value.m_Loc.Y == adjecentTile.Y)
                    || (xe.Value.m_Loc.X == CombatHandler2.AdjecentTile(play, swingdir - 1).X && xe.Value.m_Loc.Y == CombatHandler2.AdjecentTile(play, swingdir - 1).Y)
                    || (xe.Value.m_Loc.X == CombatHandler2.AdjecentTile(play, swingdir + 1).X && xe.Value.m_Loc.Y == CombatHandler2.AdjecentTile(play, swingdir + 1).Y)
                    )
                    ).Select(xe => xe);
                foreach (var tttt in Targets)
                    ret.Add(tttt.Value);
                foreach (var tttt in Targets2)
                    ret.Add(tttt.Value);
            }

            if (play.m_Buffs.Where(xe => xe.BuffEffect.BuffType == script.spells.BuffCase.Twister)
                .FirstOrDefault() != null)
            {
                ret.Clear();
                Targets = World.NewMonsters.Where(xe => xe.Value.m_Map != null && xe.Value.m_Map == play.Map
              &&
              (
              (xe.Value.m_Loc.X == adjecentTile.X && xe.Value.m_Loc.Y == adjecentTile.Y)
              || (xe.Value.m_Loc.X == CombatHandler2.AdjecentTile(play, swingdir - 2).X && xe.Value.m_Loc.Y == CombatHandler2.AdjecentTile(play, swingdir - 2).Y)
              || (xe.Value.m_Loc.X == CombatHandler2.AdjecentTile(play, swingdir + 2).X && xe.Value.m_Loc.Y == CombatHandler2.AdjecentTile(play, swingdir + 2).Y)
              || (xe.Value.m_Loc.X == CombatHandler2.AdjecentTile(play, swingdir + 4).X && xe.Value.m_Loc.Y == CombatHandler2.AdjecentTile(play, swingdir + 4).Y)
              )
              && xe.Value.Alive)
             .Select(xe => xe);

                Targets2 = PlayerHandler.getSingleton().add.Where(xe => xe.Key != null && xe.Value != null && xe.Value.loggedIn && xe.Value.Map == play.Map
                    &&
                    (
                   (xe.Value.m_Loc.X == adjecentTile.X && xe.Value.m_Loc.Y == adjecentTile.Y)
                    || (xe.Value.m_Loc.X == CombatHandler2.AdjecentTile(play, swingdir - 2).X && xe.Value.m_Loc.Y == CombatHandler2.AdjecentTile(play, swingdir - 2).Y)
                    || (xe.Value.m_Loc.X == CombatHandler2.AdjecentTile(play, swingdir + 2).X && xe.Value.m_Loc.Y == CombatHandler2.AdjecentTile(play, swingdir + 2).Y)
                    || (xe.Value.m_Loc.X == CombatHandler2.AdjecentTile(play, swingdir + 4).X && xe.Value.m_Loc.Y == CombatHandler2.AdjecentTile(play, swingdir + 4).Y)
                    )
                    ).Select(xe => xe);
                foreach (var tttt in Targets)
                    ret.Add(tttt.Value);
                foreach (var tttt in Targets2)
                    ret.Add(tttt.Value);
            }

            return ret.Count > 0 ? ret : null;
        }

        public static void SaveAll()
        {
            try
            {
                Console.WriteLine("Player Size: " + Server.playerHandler.add.Count);
                var Playss = Server.playerHandler.add.Where(xe => xe.Key != null && xe.Value != null).Select(xe => xe.Value).ToList();

                var Itemss = NewItems.Values.Where(xe => xe.InvSlot >= 0).Select(xe => xe).ToList();
                Console.WriteLine("Item Size: " + Itemss.Count());

                var AuctionItemss = NewAuctions.Values.Where(xe => xe != null).Select(xe => xe).ToList();
                Console.WriteLine("Auction Size: " + AuctionItemss.Count());

                Console.WriteLine("World Save Complete");
                BinaryIO.SavePlayers(Playss);
                BinaryIO.SaveItems(Itemss);
                BinaryIO.SaveAuctionItems(AuctionItemss);
                BinaryIO.BackUpData();
                Console.WriteLine("World Save IO Complete");
                /*foreach (var item in Itemss)
                {
                    World.DBConnect.WriteQue.Enqueue(() => World.DBConnect.InsertItem(item));
                }*/
            }
            catch
            {
                Console.WriteLine("failed to save all");
            }

            /*       foreach (var mobiles in LKCamelot.model.World.m_MObjects)
                       LKCamelot.model.World.DBConnect.InsertObject(mobiles.Value);*/
        }
    }
}
