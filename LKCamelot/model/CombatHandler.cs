using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.script.monster;
using LKCamelot.script.spells;
namespace LKCamelot.model
{
    public class CombatHandler
    {
        io.IOClient client;
        PlayerHandler handler;
        public CombatHandler(io.IOClient client, PlayerHandler handler)
        {
            this.client = client;
            this.handler = handler;
        }

        public void HandleMelee( Player play, int swingdir)
        {
            var Targets = World.NewMonsters.Where(xe => xe.Value.m_Map != null
              && xe.Value.m_Map == play.Map
              && xe.Value.m_Loc.X == AdjecentTile(play, swingdir).X && xe.Value.m_Loc.Y == AdjecentTile(play, swingdir).Y
              && xe.Value.Alive)
             .Select(xe => xe);
            var Targets2 = PlayerHandler.getSingleton().add.Where(xe => xe.Value != null  && xe.Value.Map != null
                && xe.Value != play && xe.Value.Map == play.Map &&
                xe.Value.Loc.X == AdjecentTile(play, swingdir).X && xe.Value.Loc.Y == AdjecentTile(play, swingdir).Y).Select(xe => xe);


            if (play.m_Buffs.Where(xe => xe.Name == "TRIPLE").FirstOrDefault() != null)
            {
                Targets = World.NewMonsters.Where(xe => xe.Value.m_Map != null && xe.Value.m_Map == play.Map
              && 
              (
              (xe.Value.m_Loc.X == AdjecentTile(play, swingdir).X && xe.Value.m_Loc.Y == AdjecentTile(play, swingdir).Y)
              || (xe.Value.m_Loc.X == AdjecentTile(play, swingdir-1).X && xe.Value.m_Loc.Y == AdjecentTile(play, swingdir-1).Y )
              || (xe.Value.m_Loc.X == AdjecentTile(play, swingdir+1).X && xe.Value.m_Loc.Y == AdjecentTile(play, swingdir+1).Y)
              )
              && xe.Value.Alive)
             .Select(xe => xe);

                Targets2 = PlayerHandler.getSingleton().add.Where(xe => xe.Key != null && xe.Value != null && xe.Value.Map == play.Map 
                    && 
                    (
                   ( xe.Value.m_Loc.X == AdjecentTile(play, swingdir).X && xe.Value.m_Loc.Y == AdjecentTile(play, swingdir).Y)
                    || (xe.Value.m_Loc.X == AdjecentTile(play, swingdir-1).X && xe.Value.m_Loc.Y == AdjecentTile(play, swingdir-1).Y)
                    || (xe.Value.m_Loc.X == AdjecentTile(play, swingdir+1).X && xe.Value.m_Loc.Y == AdjecentTile(play, swingdir+1).Y)  
                    )
                    ).Select(xe => xe);
            }

            
            foreach(var plays in Targets2)
            {
                if (play.Map == "Village1" || play.Map == "Rest" || play.Map == "Arnold" || play.Map == "Loen"
                || plays.Value.Level < play.Level - 40)
                    break;

                var take = (play.Dam - plays.Value.AC);
                if (take <= 0)
                    take = 1;
                if (play.m_Buffs.Where(xe => xe.Name == "TRIPLE").FirstOrDefault() != null)
                {
                    var ttt = (play.m_Buffs.Where(xe => xe.Name == "TRIPLE").FirstOrDefault().Level * 0.05);
                    var tpp = take * (ttt + 0.40d);
                    take = (int)tpp;

                    int tempface1 = play.Face - 1, tempface2 = play.Face+1;
                    if (tempface1 == -1)
                        tempface1 = 7;
                    if (tempface2 == 8)
                        tempface2 = 0;

                    World.TickQue.Add(new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + (int)(play.AttackSpeed * 0.1d), play.Map, new SwingAnimation(play.Serial, (short)(tempface1)).Compile()));
                    World.TickQue.Add(new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + (int)(play.AttackSpeed * 0.2d), play.Map, new SwingAnimation(play.Serial, (short)(tempface2)).Compile()));
                    World.TickQue.Add(new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + (int)(play.AttackSpeed * 0.3d), play.Map, new ChangeFace(play.Serial, (short)(play.Face)).Compile()));
                }

                TakeDamage(play, plays.Value,take);
            }

            foreach (var mobs in Targets)
            {

                var take = (play.Dam - mobs.Value.AC);
                if (take <= 0)
                    take = 1;
                if (play.m_Buffs.Where(xe => xe.Name == "TRIPLE").FirstOrDefault() != null)
                {
                    var ttt = (play.m_Buffs.Where(xe => xe.Name == "TRIPLE").FirstOrDefault().Level * 0.05);
                    var tpp = take * (ttt + 0.40d);
                    take = (int)tpp;

                    int tempface1 = play.Face - 1, tempface2 = play.Face + 1;
                    if (tempface1 == -1)
                        tempface1 = 7;
                    if (tempface2 == 8)
                        tempface2 = 0;

                    World.TickQue.Add(new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + (int)(play.AttackSpeed * 0.1d), play.Map, new SwingAnimation(play.Serial, (short)(tempface1)).Compile()));
                    World.TickQue.Add(new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + (int)(play.AttackSpeed * 0.2d), play.Map, new SwingAnimation(play.Serial, (short)(tempface2)).Compile()));
                    World.TickQue.Add(new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + (int)(play.AttackSpeed * 0.3d), play.Map, new ChangeFace(play.Serial, (short)(play.Face)).Compile()));
             
                }

                TakeDamage(play, mobs.Value, take);
            }

            World.SendToAll(new QueDele(play.Serial, play.Map, new SwingAnimationChar(play.Serial, play.Face).Compile()));
        }

        public void TakeDamage(Player player, Monster mob, int take)
        {
            float h = ((float)player.Hit / ((float)player.Hit + (float)mob.Hit)) * 200;

            if (h >= 100 || new Random().Next(0, 100) < (int)h)
            {
                if (player.Weapon is script.item.IProc)
                    take += (player.Weapon as script.item.IProc).Proc(player, mob);
                

                mob.HPCur -= take;
                World.SendToAll(new QueDele(mob.m_Map, new HitAnimation(mob.m_Serial,
                    Convert.ToByte(((((float)mob.HPCur / (float)mob.HP) * 100) * 1))).Compile()));

                if (mob.HPCur <= 0)
                {
                    if (player.Promo > 0)
                    {
                        var temp = mob.XP;
                        if (player.Promo >= 1 && player.Promo <= 6)
                            temp = (int)(temp * 0.03);
                        if (player.Promo >= 7)
                            temp = (int)(temp * 0.01);

                        player.XP += temp;// *3;
                    }
                    else
                        player.XP += mob.XP;// *3;
                    mob.DropLoot(player);
                    mob.m_Loc.X = mob.m_SpawnLoc.X;
                    mob.m_Loc.Y = mob.m_SpawnLoc.Y;
                }
            }
        }

        public void TakeDamage(Player player, Player player2, int take)
        {
            float h = ((float)player.Hit / ((float)player.Hit + (float)player2.Hit)) * 200;

            if (h >= 100 || new Random().Next(0, 100) < (int)h)
            {
                if (player.Weapon is script.item.IProc)
                    take += (player.Weapon as script.item.IProc).Proc(player, null, player);

                player2.HPCur -= take;
                World.SendToAll(new QueDele(player2.m_Map, new HitAnimation(player2.Serial,
                    Convert.ToByte(((((float)player2.m_HPCur / (float)player2.HP) * 100) * 1))).Compile()));
            }
        }

        public Point2D AdjecentTile(Player player, int swingloc)
        {
            if (swingloc == -1)
                swingloc = 7;
            if (swingloc == 8)
                swingloc = 0;

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
    }
}
