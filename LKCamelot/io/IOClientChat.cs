#define PROMOCAP12

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public HashSet<string> GMS = new HashSet<string>()
        {
            "SIR",
            "PATHFINDER",
            "PATHGM1",
            "PATHGM2",
            "PATHGM3"
        };


        public void UpdateChat(string text, byte c1 = 0xff, byte c2 = 0xff, byte cb = 1)
        {
            SendPacket(new UpdateChatBox(c1, c2, 1, (short)text.Count(), text).Compile());
        }

        public void HandleGMChat(string[] str2)
        {
            if (!GMS.Contains(player.Name))
                return;

            if (str2[0][0] == '~')
            {
                var message = str2[0].Remove(0, 1);
                message = "[" + player.Name + "] : " + message;
                World.SendToAll(new QueDele(player.Serial, "all", new UpdateChatBox(0x08, 0x02, 0x0, (short)message.Count(), message).Compile()));
            }
            switch (str2[0])
            {
                case "@tele":
                    GMTele(str2);
                    break;
                case "@learn":
                    GMLearn(str2);
                    break;
                case "@invis":
                    GMInvis(str2);
                    break;
                case "@createitem":
                    GMCreateItem(str2);
                    break;
                case "@kick":
                    GMKick(str2);
                    break;
                case "@itemarray":
                    GMItemArray(str2);
                    break;
                case "@tap":
                    GMTapPlayer(str2);
                    break;
            }
        }

        public void HandleChat(string[] str2, string str)
        {
            if (str2[0] == "@go")
            {
                if (str2.Count() > 1)
                {
                    HandleGo(str2[1]);
                }
            }
            else if (str2[0] == "@commands")
            {
                UpdateChat("@go, @bug, @rank, @reset, @automp 0.10, @autohp 0.10, ");
                UpdateChat("@addstat str 100, @remitee, @autoloot, @autohit ");
                UpdateChat("@bankslot 0 (1,2..), @ping, @stats, @pkstats ");
            }
            else if (str[0] == '!')
            {
                var message = str.Remove(0, 1);
                message = "[" + player.Name + "] : " + message;
                World.SendToAll(new QueDele(player.Serial, "all", new UpdateChatBox(0xff, 0xff, 0x95, (short)message.Count(), message).Compile()));
            }
            else if (str[0] == '~' || str2[0] == "@tele" || str2[0] == "@learn"
                || str2[0] == "@invis" || str2[0] == "@createitem" || str2[0] == "@kick" || str2[0] == "@tap")
            {
                HandleGMChat(str2);
            }
            else if (str == "promote me")
            {
                var AronNpc = World.NewNpcs.Where(xe => xe.Value.Name == "Aron").FirstOrDefault();
                if (AronNpc.Value != null && World.Dist2d(player.X, player.Y, AronNpc.Value.X, AronNpc.Value.Y) < 7
                    && player.Level >= 80)
                {
                    if (AronStage == 0)
                    {
                        string achat = "[Aron]: Bring the life of drug from Alias.";
                        SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)achat.Count(), achat).Compile());
                        AronStage = 4;
                    }
                }
            }
            else if (str2[0] == "@drops")
            {

            }
            else if (str2[0] == "@ping")
            {

                long totalTime = 0;
                int timeout = 60;
                System.Net.NetworkInformation.Ping pingSender = new Ping();

                for (int i = 0; i < 1; i++)
                {
                    PingReply reply = pingSender.Send(connection.RemoteEndPoint.Address, timeout);
                    if (reply.Status == IPStatus.Success)
                    {
                        totalTime += reply.RoundtripTime;
                    }
                }
                long res = totalTime / 1;
                string achat = res + " ms";
                SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)achat.Count(), achat).Compile());
            }
            else if (str == "give me the life drug")
            {
                if (player.m_Map == "Village1" && World.Dist2d(player.Loc, new Point2D(90, 173)) <= 4)
                {
                    AliasStage = 1;
                    string achat = "[Alias]: I have a life drug. Do you need it?";
                    SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)achat.Count(), achat).Compile());
                }
            }
            else if (str2[0] == "@bug")
            {
                if (LKCamelot.Server.tickcount.ElapsedMilliseconds - 3000 > lastcmd)
                {
                    lastcmd = LKCamelot.Server.tickcount.ElapsedMilliseconds;

                    string bug = player.Name + " : " + str.Substring(4);
                    Console.WriteLine(bug);
                    WriteBug(bug);
                    string achat = "Bug report sent.";
                    SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)achat.Count(), achat).Compile());
                }
                else
                {
                    string achat = "Please wait before issuing another command.";
                    SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)achat.Count(), achat).Compile());
                }
            }
            else if (str2[0] == "@bankslot")
            {
                try { Convert.ToInt32(str2[1]); }
                catch { return; }
                player.BankTab = Convert.ToInt32(str2[1]);
                var invslots = (player.BankTab * 12) + 40;
                for (int x = 0; x < 12; x++)
                {
                    SendPacket(new DeleteEntrustSlot((byte)x).Compile());
                }
                foreach (var itm in player.BankContent.Where(xe => xe.InvSlot >= invslots && xe.InvSlot < (invslots + 12)))
                {
                    SendPacket(new AddItemToEntrust(itm).Compile());
                }
            }
            else if (str == "@reset")
            {
                if (player.GetFreeSlots() > 5)
                {
                    foreach (var it in player.Equipped2.Values)
                    {
                        it.Unequip(player, it.InvSlot);
                    }

                    var total = player.m_Str + player.m_Dex + player.m_Men + player.m_Vit + player.Extra;
                    player.Extra = (uint)total;
                    player.m_Str = 0;
                    player.m_Dex = 0;
                    player.m_Men = 0;
                    player.m_Vit = 0;
                    player.m_HPCur = player.HP;
                    player.m_MPCur = player.MP;
                    SendPacket(new UpdateCharStats(player).Compile());
                }
                else
                {
                    string achat = "Free up 5 slots";
                    SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)achat.Count(), achat).Compile());
                }
            }
            else if (str == "give me the magic drug")
            {
                if (player.m_Map == "Village1" && World.Dist2d(player.Loc, new Point2D(90, 173)) <= 2)
                {
                    AliasStage = 2;
                    string achat = "[Alias]: I have a magic drug. Do you need it?";
                    SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)achat.Count(), achat).Compile());
                }
            }
            else if (str == "yes")
            {
                if (player.m_Map == "Village1" && World.Dist2d(player.Loc, new Point2D(90, 173)) <= 2
                    && AliasStage > 0)
                {
                    if (AliasStage == 1)
                    {
                        AliasStage = 0;
                        var newitem = new script.item.PromoteLifeDrug().Inventory(player);
                        World.NewItems.TryAdd(newitem.m_Serial, newitem);
                        SendPacket(new AddItemToInventory2(newitem).Compile());
                    }
                    if (AliasStage == 2)
                    {
                        AliasStage = 0;
                        var newitem = new script.item.PromoteMagicDrug().Inventory(player);
                        World.NewItems.TryAdd(newitem.m_Serial, newitem);
                        SendPacket(new AddItemToInventory2(newitem).Compile());
                    }
                }

                var AronNpc = World.NewNpcs.Where(xe => xe.Value.Name == "Aron").FirstOrDefault();
                if (AronNpc.Value != null && World.Dist2d(player.X, player.Y, AronNpc.Value.X, AronNpc.Value.Y) < 7
                    && (player.Level >= 80 && player.Level <= 99) || (player.Level == (100 + (20 * player.Promo))))
                {
#if PROMOCAP12
                    if (player.Promo == 12)
                        return;
#else
                    if (player.Promo == 7)
                        return;
#endif

                    if (AronStage >= 1)
                    {
                        AronStage = 0;
                        if (player.Promo == 0)
                        {
                            player.XP = 0;
                            player.Level = 101;
                            player.Extra += 30;
                        }
                        else if (player.Promo >= 1)
                        {
                            player.XP = 0;
                            if (player.Promo == 1) player.Extra += 50;
                            if (player.Promo == 2) player.Extra += 80;
                            if (player.Promo == 3) player.Extra += 120;
                            if (player.Promo == 4) player.Extra += 180;
                            if (player.Promo == 5) player.Extra += 260;
                            if (player.Promo == 6) player.Extra += 360;
#if PROMOCAP12
                            if (player.Promo == 7) player.Extra += 480;
                            if (player.Promo == 8) player.Extra += 620;
                            if (player.Promo == 9) player.Extra += 780;
                            if (player.Promo == 10) player.Extra += 960;
                            if (player.Promo == 11) player.Extra += 1160;
#endif
                            if (player.Promo == 6 && player.GetFreeSlots() > 0)
                            {
                                script.item.Item prize = null;
                                if (player.Class == LKCamelot.library.Class.Knight)
                                    prize = new script.item.Excalibur().Inventory(player);
                                if (player.Class == LKCamelot.library.Class.Swordsman)
                                    prize = new script.item.DaeungDaegum().Inventory(player);
                                if (player.Class == LKCamelot.library.Class.Wizard)
                                    prize = new script.item.Kassandra().Inventory(player);
                                if (player.Class == LKCamelot.library.Class.Shaman)
                                    prize = new script.item.TaegkFan().Inventory(player);
                                try
                                {
                                    World.NewItems.TryAdd(prize.m_Serial, prize);
                                    SendPacket(new AddItemToInventory2(prize).Compile());
                                }
                                catch { Console.WriteLine("failed to add promo item"); }
                            }

                            player.Level++;

                        }
                        SendPacket(new SetLevelGold(player).Compile());
                        SendPacket(new UpdateCharStats(player).Compile());
                    }
                }

            }
            else if (str2[0] == "@time")
            {
                string achat = DateTime.Now.ToUniversalTime().ToString("MM/dd/yyyy hh:mm:ss.fff tt");
                SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)achat.Count(), achat).Compile());
            }
            else if (str2[0] == "@automp")
            {
                if (!player.AutoMana)
                    player.AutoMana = true;
                else
                    player.AutoMana = false;
                if (str2.Count() > 1)
                {
                    try
                    {
                        var temp = Convert.ToDouble(str2[1]);
                        if (temp > 1) temp = 1;
                        if (temp < 0) temp = 0;
                        player.AutoManaP = temp;
                    }
                    catch { }
                }
            }
            else if (str2[0] == "@stats")
            {
                string hpmp = string.Format("HP:{0}, MP:{1}, Level:{2}", player.HP, player.MP, player.Level);
                string stats = string.Format("Str:{0}, Men:{1}, Dex:{2}, Vit:{3}",
                    player.GetStat("str"), player.GetStat("men"), player.GetStat("dex"), player.GetStat("vit"));
                string ats = string.Format("AC:{0}, Dam:{1}, Hit:{2}, Extra:{3}",
                    player.AC, player.Dam, player.Hit, player.Extra);
                string golds = string.Format("Gold:{0}, Diamonds:{1}",
                     player.Gold, 0);
                SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)hpmp.Count(), hpmp).Compile());
                SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)stats.Count(), stats).Compile());
                SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)ats.Count(), ats).Compile());
                SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)golds.Count(), golds).Compile());
            }
            else if (str2[0] == "@pkstats")
            {
                string hpmp = string.Format("TempPKCount:{0}, RedTime:{1}",
                    player.pklastpk.Count, ((player.pklastpk.Count * player.pkRedDelay) / 1000) / 60 + "m");
                SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)hpmp.Count(), hpmp).Compile());
            }
            else if (str2[0] == "@addstat")
            {
                try
                {
                    var extras = Convert.ToUInt16(str2[2]);
                    var stat = str2[1];
                    if (player.Extra >= extras)
                    {
                        if (stat == "str") player.AddStat(ref player.m_Str, extras);
                        if (stat == "men") player.AddStat(ref player.m_Men, extras);
                        if (stat == "dex") player.AddStat(ref player.m_Dex, extras);
                        if (stat == "vit") player.AddStat(ref player.m_Vit, extras);
                        SendPacket(new UpdateCharStats(player).Compile());
                    }
                }
                catch
                {
                    string rankr = "Failed. Use: @addstat stat amount ";
                    SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)rankr.Count(), rankr).Compile());
                }
            }
            else if (str2[0] == "@autohp")
            {
                if (!player.AutoHP)
                    player.AutoHP = true;
                else
                    player.AutoHP = false;

                if (str2.Count() > 1)
                {
                    try
                    {
                        var temp = Convert.ToDouble(str2[1]);
                        if (temp > 1) temp = 1;
                        if (temp < 0) temp = 0;
                        player.AutoHPP = temp;
                    }
                    catch { }
                }
            }
            else if (str2[0] == "@tele")
            {
                if (!GMS.Contains(player.Name))
                    return;
                if (str2.Count() == 2)
                {
                    var teleon = handler.add.Where(xe => xe.Value != null && xe.Value.Name == str2[1]).FirstOrDefault().Value;
                    if (teleon != null)
                    {
                        player.Loc = new Point2D(teleon.Loc.X, teleon.Loc.Y);
                        player.Map = teleon.Map;
                    }

                }
                else if (str2.Count() == 4)
                {
                    player.Loc = new Point2D(Convert.ToInt16(str2[2]), Convert.ToInt16(str2[3]));
                    player.Map = str2[1];
                }
            }
            else if (str2[0] == "@learn")
            {
               if (!GMS.Contains(player.Name))
                    return;
                try
                {
                    string activatorstring = "LKCamelot.script.spells.";
                    var tempspell = Activator.CreateInstance(Type.GetType(activatorstring + str2[1]));
                    (tempspell as script.spells.Spell).Slot = player.GetFreeSpellSlot();
                    (tempspell as script.spells.Spell).SLevel2 = 99;
                    (tempspell as script.spells.Spell).Level = 12;
                    player.m_MagicLearned.Add((tempspell as script.spells.Spell));
                    SendPacket(new CreateSlotMagic2((tempspell as script.spells.Spell)).Compile());
                }
                catch { return; }
            }
            else if (str2[0] == "@invis")
            {
                if (!GMS.Contains(player.Name))
                    return;
                if (player.Transparancy == 0)
                {
                    player.Transparancy = 100;
                    World.SendToAll(new QueDele(player.Map, new SetObjectEffectsPlayer(player).Compile()));
                }
                else player.Transparancy = 0;
            }
            else if (str2[0] == "@createitem")
            {
                if (player.Name != "SIR")
                    return;
                script.item.Item temp;
                try
                {
                    temp = (script.item.Item)Activator.CreateInstance(Type.GetType("LKCamelot.script.item." + str2[1]));
                }
                catch { return; }

                var newitem = temp.Inventory(player);
                World.NewItems.TryAdd(newitem.m_Serial, newitem);
                SendPacket(new AddItemToInventory2(newitem).Compile());

            }
            else if (str2[0] == "@kick")
            {
                if (!GMS.Contains(player.Name))
                    return;

                if (str2[1] != "")
                {
                    var plr = handler.add.Where(xe => xe.Value != null && xe.Value.Name == str2[1].ToUpper()).FirstOrDefault().Value;
                    plr.loggedIn = false;
                    World.w_server.Disconnect(plr.client.connection);
                }
            }
            else if (str2[0] == "@remitee")
            {
                if (str2.Count() <= 2 || player.m_Map != "Loen")
                    return;
                try
                {
                    if (Convert.ToUInt64(str2[2]) < 0)
                        return;
                }
                catch { return; }

                var tradep = handler.add.Where(xe => xe.Key != null && xe.Value != null && xe.Value.Name == str2[1].ToUpper() && xe.Value.Map == "Loen").FirstOrDefault().Value;
                if (tradep != null && tradep != null && tradep.Name != player.Name && player.Gold >= Convert.ToUInt64(str2[2]))
                {
                    player.Gold -= Convert.ToUInt64(str2[2]);
                    tradep.Gold += Convert.ToUInt64(str2[2]);
                }
            }
            else if (str2[0] == "@cast")
            {
                /*   if (str2.Count() <= 7)
                       return;

                   int par;
                   for (int x = 1; x < 9; x++)
                   {
                       if (int.TryParse(str2[x], out par) == false)
                           return;
                   }

                   World.SendToAll(new QueDele(player.Map, new CurveMagic(player.Serial, Convert.ToInt16(str2[1]), Convert.ToInt16(str2[2]), new script.spells.SpellSequence(Convert.ToInt32(str2[3]), Convert.ToInt32(str2[4]),
                       Convert.ToInt32(str2[5]), Convert.ToInt32(str2[6]), Convert.ToInt32(str2[7]), Convert.ToInt32(str2[8]), Convert.ToInt32(str2[9]))).Compile()));
               */
            }
            else if (str2[0] == "@rank")
            {
                if (LKCamelot.Server.tickcount.ElapsedMilliseconds - 2000 > ChatTimeout)
                {
                    ChatTimeout = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                    string rankr = "Ranks: ";
                    var keys = handler.add.Values.Where(xe => xe != null && !GMS.Contains(xe.Name.ToUpper())).ToList();
                    var kl = keys.OrderByDescending(xe => xe.Level).ToList();
                    if (kl.Count > 25)
                        kl.RemoveRange(24, kl.Count - 24 - 1);

                    foreach (var rnk in kl)
                    {
                        rankr += rnk.Name + ", ";
                        if (rankr.Count() / 35 >= 1)
                        {
                            rankr = rankr.Substring(0, rankr.Count() - 2);
                            SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)rankr.Count(), rankr).Compile());
                            rankr = "";
                        }

                    }
                    if (rankr.Count() > 0)
                    {
                        rankr = rankr.Substring(0, rankr.Count() - 2);
                        SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)rankr.Count(), rankr).Compile());
                        rankr = "";
                    }
                    
                    var online = handler.add.Values.Where(xe => xe != null && !GMS.Contains(xe.Name.ToUpper())).ToList();
                    rankr = string.Format("Players Online: {0}", online.Count);
                    SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)rankr.Count(), rankr).Compile());
                }

                /*8          if (LKCamelot.Server.tickcount.ElapsedMilliseconds - ChatTimeout > LastAttack)
                          {
                              ChatTimeout = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                              string rankr = "Highest Ranks: ";
                              foreach (var rnk in World.DBConnect.GetRank(this))
                              {
                                  rankr += rnk.Name +", ";
                                  rankr = rankr.Substring(0, rankr.Count()-2);
                                  SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)rankr.Count(), rankr).Compile());
                              }
                          }*/
            }
            else if (str2[0] == "@autoloot")
            {
                var strloot = "";
                if (player.AutoLoot)
                {
                    player.AutoLoot = false;
                    strloot = "Autoloot disabled.";
                }
                else
                {
                    player.AutoLoot = true;
                    strloot = "Autoloot enabled.";
                }
                SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)strloot.Count(), strloot).Compile());
            }
            else if (str2[0] == "@autohit")
            {
                var strloot = "";
                if (player.AutoHit)
                {
                    player.AutoHit = false;
                    strloot = "Autohit disabled.";
                }
                else
                {
                    player.AutoHit = true;
                    strloot = "Autohit enabled.";
                }
                SendPacket(new UpdateChatBox(0xff, 0xff, 1, (short)strloot.Count(), strloot).Compile());
            }
            else if (str2[0] == "make" && str2[1] == "me" && str2[2] == "a")
            {
                var AronNpc = World.NewNpcs.Where(xe => xe.Value.Name == "Aron").FirstOrDefault();
                if (AronNpc.Value != null && World.Dist2d(player.X, player.Y, AronNpc.Value.X, AronNpc.Value.Y) < 7
                    && player.Level >= 5 && player.Promo == 0)
                {
                    switch (str2[3])
                    {
                        case "knight":
                            player.Class = LKCamelot.library.Class.Knight;
                            break;
                        case "swordman":
                            player.Class = LKCamelot.library.Class.Swordsman;
                            break;
                        case "wizard":
                            player.Class = LKCamelot.library.Class.Wizard;
                            break;
                        case "shaman":
                            player.Class = LKCamelot.library.Class.Shaman;
                            break;
                    }
                }
            }
            else if (str[0] == '/')
            {
                if (str2.Count() <= 1)
                    return;
                var str3 = player.Name + "> " + str.Substring(str2[0].Count());

                var parsename = str2[0].ToString().Substring(1).ToUpper();
                var whisp = handler.add.Where(xe => xe.Value != null && xe.Value.Name == parsename).FirstOrDefault();
                if (whisp.Key != null && whisp.Value != null && whisp.Value.loggedIn)
                {
                    var str1 = whisp.Value.Name + "< " + str.Substring(str2[0].Count());
                    SendPacket(new UpdateChatBox(0xff, 0x70, 1, (short)str1.Count(), str1).Compile());
                    whisp.Value.client.SendPacket(new UpdateChatBox(0xff, 0x70, 1, (short)str3.Count(), str3).Compile());
                }
            }
            else
            {
                str = "[" + player.Name + "] : " + str;
                World.SendToAllRange(new QueDele(player.Map, new UpdateChatBox(0xff, 0xff, 1, (short)str.Count(), str).Compile()), player, 10);
            }
        }

        public void GMKick(string[] str2)
        {
            if (str2[1] != "")
            {
                var plr = handler.add.Where(xe => xe.Value != null && xe.Value.Name == str2[1].ToUpper()).FirstOrDefault().Value;
                plr.loggedIn = false;
                World.w_server.Disconnect(plr.client.connection);
            }
        }

        public void GMCreateItem(string[] str2)
        {
            if (player.Name != "SIR")
                return;

            script.item.Item temp;
            try
            {
                temp = (script.item.Item)Activator.CreateInstance(Type.GetType("LKCamelot.script.item." + str2[1]));
            }
            catch { return; }

            var newitem = temp.Inventory(player);
            World.NewItems.TryAdd(newitem.m_Serial, newitem);
            SendPacket(new AddItemToInventory2(newitem).Compile());
        }

        public void GMInvis(string[] str2)
        {
            if (player.Transparancy == 0)
            {
                player.Transparancy = 100;
                World.SendToAll(new QueDele(player.Map, new SetObjectEffectsPlayer(player).Compile()));
            }
            else player.Transparancy = 0;
        }

        public void GMItemArray(string[] str2)
        {

            if (player.Transparancy == 0)
            {
                player.Transparancy = 100;
                World.SendToAll(new QueDele(player.Map, new SetObjectEffectsPlayer(player).Compile()));
            }
            else player.Transparancy = 0;
        }

        public void GMTapPlayer(string[] str2)
        {
            if (str2[1] != "")
            {
                LKCamelot.model.Modules.NSA.Tap(str2[1]);
            }
        }

        public void GMLearn(string[] str2)
        {
            try
            {
                string activatorstring = "LKCamelot.script.spells.";
                var tempspell = Activator.CreateInstance(Type.GetType(activatorstring + str2[1]));
                (tempspell as script.spells.Spell).Slot = player.GetFreeSpellSlot();
                (tempspell as script.spells.Spell).SLevel2 = 99;
                (tempspell as script.spells.Spell).Level = 12;
                player.m_MagicLearned.Add((tempspell as script.spells.Spell));
                SendPacket(new CreateSlotMagic2((tempspell as script.spells.Spell)).Compile());
            }
            catch { return; }
        }

        public void GMTele(string[] str2)
        {
            if (str2.Count() == 2)
            {
                var teleon = handler.add.Where(xe => xe.Value != null && xe.Value.Name == str2[1]).FirstOrDefault().Value;
                if (teleon != null)
                {
                    player.Loc = new Point2D(teleon.Loc.X, teleon.Loc.Y);
                    player.Map = teleon.Map;
                }

            }
            else if (str2.Count() == 4)
            {
                player.Loc = new Point2D(Convert.ToInt16(str2[2]), Convert.ToInt16(str2[3]));
                player.Map = str2[1];
            }
        }
    }
}
