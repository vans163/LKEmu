using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.model
{
    public class CombatHandler2
    {
        io.IOClient client;
        PlayerHandler handler;
        public CombatHandler2(io.IOClient client, PlayerHandler handler)
        {
            this.client = client;
            this.handler = handler;
        }

        public void HandleCast(int header, script.spells.Spell spell, Player player, int target = 0, short castx = 0, short casty = 0)
        {
            if (spell is script.spells.Teleport)
                (spell as script.spells.Teleport).CastIt(player, new Point2D(castx, casty));
          //  if (spell is script.spells.Trace)
           //     (spell as script.spells.Trace).CastIt(player, new Point2D(castx, casty));
            
        }

        public void HandleMelee(Player play, int swingdir)
        {
            List<BaseObject> target = World.GetTileTarget(play, AdjecentTile(play, swingdir), swingdir);
            if (target == null)
                return;
            var take = play.Dam;

            foreach (var tar in target)
            {
                if (tar is Player)
                {
                    if (play.Map == "Village1" || play.Map == "Rest" || play.Map == "Arnold" || play.Map == "Loen")
                        continue;

                    take -= (tar as Player).AC;
                    if (take <= 0)
                        take = 1;
                    TakeDamage(play, tar, take);

                    if ((tar as Player).Color == 0)
                      play.pkpinkktime = Server.tickcount.ElapsedMilliseconds;

                    if ((tar as Player).Map == "Rest" && (tar as Player).Color != 1)
                    {
                        play.pklastpk.Add(Server.tickcount.ElapsedMilliseconds);
                        play.pklastred = Server.tickcount.ElapsedMilliseconds;
                    }
                }
                else if (tar is script.monster.Monster)
                {
                    take -= (tar as script.monster.Monster).AC;
                    if (take <= 0)
                        take = 1;
                    TakeDamage(play, tar, take);
                }
            }
        }

        public void TakeDamage(Player player, object tar, int take)
        {
            float h = 0;
            if (tar is Player)
                h = ((float)player.Hit / ((float)player.Hit + (float)(tar as Player).Hit)) * 200;
            else if (tar is script.monster.Monster)
                h = ((float)player.Hit / ((float)player.Hit + (float)(tar as script.monster.Monster).Hit)) * 200;
            

            if (h >= 100 || new Random().Next(0, 100) < (int)h)
            {
                if (player.Weapon is script.item.IProc)
                {
                    if (tar is Player)
                        take += (player.Weapon as script.item.IProc).Proc(player, null, tar as Player);
                    else if (tar is script.monster.Monster)
                        take += (player.Weapon as script.item.IProc).Proc(player, tar as script.monster.Monster);                           
                }

                var swingbuff = player.m_Buffs.Where(xe => xe.BuffEffect.BuffType == script.spells.BuffCase.Triple
                    || xe.BuffEffect.BuffType == script.spells.BuffCase.Twister).FirstOrDefault();
                if (swingbuff != null)
                {
                    var ttt = swingbuff.Level * 0.05;
                    take = (int)(take * (ttt + 0.40d));
                }

                if (tar is Player)
                {
                    (tar as Player).HPCur -= take;
                    World.SendToAll(new QueDele((tar as Player).m_Map, new HitAnimation((tar as Player).Serial,
                        Convert.ToByte(((((float)(tar as Player).HPCur / (float)(tar as Player).HP) * 100) * 1))).Compile()));
                }
                else if (tar is script.monster.Monster)
                {
                    (tar as script.monster.Monster).HPCur -= take;
                    World.SendToAll(new QueDele((tar as script.monster.Monster).m_Map, new HitAnimation((tar as script.monster.Monster).m_Serial,
                        Convert.ToByte(((((float)(tar as script.monster.Monster).HPCur / (float)(tar as script.monster.Monster).HP) * 100) * 1))).Compile()));

                    if ((tar as script.monster.Monster).HPCur <= 0)
                    {
                        if (player.Promo > 0)
                        {
                            var temp = (tar as script.monster.Monster).XP;

                            if (player.Promo >= 1 && player.Promo <= 6)
                                temp = (int)(temp * 0.03);
                            if (player.Promo >= 7)
                                temp = (int)(temp * 0.01);

                            player.XP += temp;// *3;
                        }
                        else
                            player.XP += (tar as script.monster.Monster).XP;// *3;
                        (tar as script.monster.Monster).DropLoot(player);
                        (tar as script.monster.Monster).m_Loc.X = (tar as script.monster.Monster).m_SpawnLoc.X;
                        (tar as script.monster.Monster).m_Loc.Y = (tar as script.monster.Monster).m_SpawnLoc.Y;
                    }
                }
            }
        }

        public static Point2D AdjecentTile(Player player, int swingloc)
        {
            if (swingloc == -1)
                swingloc = 7;
            if (swingloc == -2)
                swingloc = 6;
            if (swingloc == -3)
                swingloc = 5;
            if (swingloc == -4)
                swingloc = 4;
            if (swingloc == 8)
                swingloc = 0;
            if (swingloc == 9)
                swingloc = 1;
            if (swingloc == 10)
                swingloc = 2;
            if (swingloc == 11)
                swingloc = 3;

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
