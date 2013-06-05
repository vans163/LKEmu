using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.script.spells;
namespace LKCamelot.model
{
    public class CastHandler
    {
        io.IOClient client;
        PlayerHandler handler;
        public CastHandler(io.IOClient client, PlayerHandler handler)
        {
            this.client = client;
            this.handler = handler;
        }

        public void CreateMagicEffect(Point2D target, string map, byte sprite, int time = 1500)
        {
            int mobile = Serial.NewMobile;
            World.SendToAll(new QueDele(map, new CreateMagicEffect(mobile, 1, (short)target.X, (short)target.Y, new byte[] { 4, 0, 0, 0, 0, 0, 0, 0, 0, sprite }, 0).Compile()));
            var tmp = new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + time, map, new DeleteObject(mobile).Compile());
            tmp.tempser = mobile;
            World.TickQue.Add(tmp);
        }

        public void TakeDamage(Player caster, Player target, script.spells.Spell spell)
        {
            float h = ((float)caster.Hit / ((float)caster.Hit + (float)target.Hit)) * 200;

            if (h >= 100 || new Random().Next(0, 100) < (int)h)
            {
                int take = spell.DamBase + (spell.DamPl * spell.Level);// +(spell.DamPl * spell.SLevel2);
                if (spell.ManaCostPl != 0)
                {
                    take += (caster.GetStat("men") / spell.menCoff);
                    take += (caster.GetStat("str") / spell.strCoff);
                    take += (caster.GetStat("dex") / spell.dexCoff);
                }
                if (spell is script.spells.DemonDeath)
                    take = Convert.ToInt32(caster.HP * 0.5) + caster.GetStat("dex");

                if (target.Color == 0)
                    caster.pkpinkktime = Server.tickcount.ElapsedMilliseconds;
                
                target.HPCur -= (take - target.AC);
                if (target.Map == "Rest" && target.Color != 1)
                {
                    caster.pklastpk.Add(Server.tickcount.ElapsedMilliseconds);
                    caster.pklastred = Server.tickcount.ElapsedMilliseconds;
                }
                World.SendToAll(new QueDele(caster.m_Map, new HitAnimation(target.Serial,
                   Convert.ToByte(((((float)target.m_HPCur / (float)target.HP) * 100) * 1))).Compile()));
            }
        }



        public void HandleCast(int header, script.spells.Spell castspell, Player player, int target = 0, short castx = 0, short casty = 0)
        {
            if (castspell is Teleport)
            {
                var teleportdist = ((castspell.Level / 2) * 2);
                if (teleportdist <= 3) teleportdist = 4;
                if (teleportdist > 12) teleportdist = 12;
                if (World.Dist2d(castx, casty, player.X, player.Y) <= teleportdist
                    && player.MPCur > castspell.RealManaCost(player))
                {
                    var nmap = LKCamelot.model.Map.FullMaps.Where(xe => xe.Key == player.Map).FirstOrDefault().Value;
                    TiledMap curmap = null;
                    try
                    {
                        curmap = LKCamelot.model.Map.loadedmaps[nmap];
                    }
                    catch
                    {
                        Console.WriteLine(string.Format("Failed to nmap at {0}", nmap));
                    }
                    LKCamelot.model.MyPathNode randomtile;
                    try
                    {
                        randomtile = curmap.tiles[castx, casty];
                    }
                    catch
                    {
                        return;
                    }
                    if (randomtile.IsWall)
                        return;

                    player.MPCur -= castspell.RealManaCost(player);
                    castspell.CheckLevelUp(player);

                    player.Loc = new Point2D(castx, casty);
                    World.SendToAll(new QueDele(player.Map, new MoveSpriteTele(player.Serial, player.Face, player.X, player.Y).Compile()));
                    return;
                }
            }
            if (castspell is Trace)
            {
                if (player.MPCur > castspell.RealManaCost(player))
                {
                    player.MPCur -= castspell.RealManaCost(player);
                    castspell.CheckLevelUp(player);

                    try
                    {
                        var traceto = script.map.Portal.Portals.Where(xe => xe.Map == player.Map).Select(xe => xe).ToList();
                        if (traceto.Count > 1)
                        {
                            var temp = new Point2D(traceto[0].Locs[0].X, traceto[0].Locs[0].Y + 2);
                            player.Loc = temp;
                        }
                    }
                    catch { return; }

                    World.SendToAll(new QueDele(player.Map, new MoveSpriteTele(player.Serial, player.Face, player.X, player.Y).Compile()));
                    return;
                }
            }
            if (castspell is ComeBack)
            {
                return;
            }

            var caston = World.NewMonsters.Where(xe => xe.Value.m_Serial == target
                                && World.Dist2d(xe.Value.m_Loc.X, xe.Value.m_Loc.Y, player.X, player.Y) <= castspell.Range
                                && xe.Value.Alive
                && xe.Value.m_Map != null && xe.Value.m_Map == player.m_Map
                ).Select(xe => xe.Value);

            var playcaston = PlayerHandler.getSingleton().add.Where(xe => xe.Value != null && xe.Value != player && xe.Value.loggedIn
                && World.Dist2d(xe.Value.m_Loc.X, xe.Value.m_Loc.Y, player.m_Loc.X, player.m_Loc.Y) <= castspell.Range
                && xe.Value.Serial == (Serial)target
                && xe.Value.m_Map != null && xe.Value.m_Map == player.m_Map).FirstOrDefault();

            if (castspell.mType == LKCamelot.library.MagicType.Casted || castspell.mType == LKCamelot.library.MagicType.Target)
            {
                caston = World.NewMonsters.Where(xe => xe.Value.m_Map != null
                       && xe.Value.m_Map == player.Map
                       && World.Dist2d(xe.Value.m_Loc.X, xe.Value.m_Loc.Y, player.X, player.Y) <= castspell.Range
                       && xe.Value.Alive)
                      .Select(xe => xe.Value);
            }


            if (playcaston.Key != null
                && !(player.Map == "Village1" || player.Map == "Rest" || player.Map == "Arnold" || player.Map == "Loen")
                )
            {

                if (castspell is ISingle)
                {
                    if (player.MPCur < castspell.RealManaCost(player))
                        return;
                    player.MPCur -= castspell.RealManaCost(player);
                    castspell.CheckLevelUp(player);

                    CreateMagicEffect(playcaston.Value.Loc, playcaston.Value.Map, (byte)castspell.Seq.OnImpactSprite, 1500);

                    TakeDamage(player, playcaston.Value, castspell);
                    return;
                }

                if (castspell.Name == "DEMON DEATH")
                {
                    if (player.HPCur < (int)(player.HP * 0.70))
                        return;

                    var miyamo = player.Equipped.Where(xe => xe.GetType() == typeof(script.item.MiyamotosStick)).FirstOrDefault();
                    var recast = castspell.RecastTime;
                    if (miyamo != null)
                    {
                        recast -= 1000;
                        recast -= miyamo.Stage * 300;
                    }
                    
                    if (LKCamelot.Server.tickcount.ElapsedMilliseconds - recast > castspell.Cooldown)
                    {
                        castspell.Cooldown = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                    }
                    else
                        return;

                    player.HPCur -= castspell.RealManaCost(player);
                    castspell.CheckLevelUp(player);

                    int mobile = Serial.NewMobile;
                    World.SendToAll(new QueDele(player.Map, new CreateMagicEffect(mobile, 1, (short)playcaston.Value.m_Loc.X, (short)playcaston.Value.m_Loc.Y, new byte[] { 4, 0, 0, 0, 0, 0, 0, 0, 0, (byte)castspell.Seq.OnImpactSprite }, 0).Compile()));
                    var tmp = new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + 2000, player.m_Map, new DeleteObject(mobile).Compile());
                    tmp.tempser = mobile;
                    World.TickQue.Add(tmp);

                    TakeDamage(player, playcaston.Value, castspell);

                    return;
                }

                if (player.MPCur < castspell.RealManaCost(player))
                    return;
                player.MPCur -= castspell.RealManaCost(player);
                castspell.CheckLevelUp(player);
                TakeDamage(player, playcaston.Value, castspell);
                World.SendToAll(new QueDele(player.Map, new CurveMagic(player.Serial,
                    castx, casty, castspell.Seq).Compile()));
            }


            switch (castspell.mType)
            {
                case (LKCamelot.library.MagicType.Target2):
                    foreach (var targete in caston)
                    {
                        if (castspell is ISingle)
                        {
                            if (player.MPCur < castspell.RealManaCost(player))
                                return;
                            player.MPCur -= castspell.RealManaCost(player);
                            castspell.CheckLevelUp(player);

                            CreateMagicEffect(targete.m_Loc, targete.m_Map, (byte)castspell.Seq.OnImpactSprite, 1500);

                            targete.TakeDamage(player, castspell);
                            return;
                        }

                        if (castspell.Name == "DEMON DEATH")
                        {
                            if (player.HPCur < (int)(player.HP * 0.70))
                                return;

                            var miyamo = player.Equipped.Where(xe => xe.GetType() == typeof(script.item.MiyamotosStick)).FirstOrDefault();
                            var recast = castspell.RecastTime;
                            if (miyamo != null)
                            {
                                recast -= 1000;
                                recast -= miyamo.Stage * 300;
                            }

                            if (LKCamelot.Server.tickcount.ElapsedMilliseconds - recast > castspell.Cooldown)
                            {
                                castspell.Cooldown = LKCamelot.Server.tickcount.ElapsedMilliseconds;
                            }
                            else
                                return;

                            player.HPCur -= castspell.RealManaCost(player);
                            castspell.CheckLevelUp(player);

                            int mobile = Serial.NewMobile;
                            World.SendToAll(new QueDele(player.Map, new CreateMagicEffect(mobile, 1, (short)targete.m_Loc.X, (short)targete.m_Loc.Y, new byte[] { 4, 0, 0, 0, 0, 0, 0, 0, 0, (byte)castspell.Seq.OnImpactSprite }, 0).Compile()));
                            var tmp = new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + 2000, player.m_Map, new DeleteObject(mobile).Compile());
                            tmp.tempser = mobile;
                            World.TickQue.Add(tmp);

                            targete.TakeDamage(player, castspell);

                            return;
                        }

                        if (player.MPCur < castspell.RealManaCost(player))
                            return;
                        player.MPCur -= castspell.RealManaCost(player);
                        castspell.CheckLevelUp(player);
                        targete.TakeDamage(player, castspell);
                        World.SendToAll(new QueDele(player.Map, new CurveMagic(player.Serial,
                            castx, casty, castspell.Seq).Compile()));
                    }

                    break;

                case (LKCamelot.library.MagicType.Casted):
                    if (player.MPCur < castspell.RealManaCost(player))
                        return;
                    player.MPCur -= castspell.RealManaCost(player);

                    if (castspell.Cast(player))
                        return;

                    foreach (var targete in caston)
                        targete.TakeDamage(player, castspell);

                    World.SendToAll(new QueDele(player.Map, new CurveMagic(player.Serial,
                      1, 1, castspell.Seq).Compile()));

                    break;
                case (LKCamelot.library.MagicType.Target):
                    if (player.MPCur < castspell.RealManaCost(player))
                        return;
                    player.MPCur -= castspell.RealManaCost(player);
                    if (castspell.Cast(player))
                        return;

                    World.SendToAll(new QueDele(player.Map, new CurveMagic(player.Serial, 1, 1, castspell.Seq).Compile()));
                    foreach (var targetee in caston)
                    {
                        int mobile = Serial.NewMobile;
                        World.SendToAll(new QueDele(player.Map, new CreateMagicEffect(mobile, 1, (short)targetee.m_Loc.X, (short)targetee.m_Loc.Y, new byte[] { 4, 0, 0, 0, 0, 0, 0, 0, 0, (byte)castspell.Seq.OnImpactSprite }, 0).Compile()));
                        // World.SendToAll(new QueDele(player.Map, new SetObjectEffectsMonsterSpell(targetee, castspell.Seq.OnImpactSprite).Compile()));
                        targetee.TakeDamage(player, castspell);
                        var tmp = new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + 1000, player.m_Map, new DeleteObject(mobile).Compile());
                        tmp.tempser = mobile;
                        World.TickQue.Add(tmp);
                    }
                    break;
            }
        }
    }
}
