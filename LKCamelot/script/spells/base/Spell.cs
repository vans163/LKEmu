using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.spells
{
    public interface ISingle
    {
    }

    public enum BuffCase
    {
        ManaAsHP = 1,
        ReflectDamage = 2,
        Triple = 4,
        Twister = 8,
    }

    public class Buff
    {
        public float fAC = 0f, fDam = 0f, fACpl = 0f, fDampl = 0f;
        public int AC = 0, Dam = 0, ACpl = 0, Dampl = 0;
        public BuffCase BuffType;
    }

	public class Spell
	{
        public virtual string Name { get { return ""; } }

        public Player Caster;
        public int Level = 1, SLevel2 = 1, Slot;
        public long Cooldown;

        public virtual LKCamelot.library.MagicType mType { get { return 0; } }
        public virtual int SpellLearnedIcon { get { return 0; } }
        public virtual SpellSequence Seq { get { return null; } }
        public virtual int DamBase { get { return 0; } }
        public virtual int DamPl { get { return 0; } }
        public virtual int ManaCost { get { return 0; } }
        public virtual int ManaCostPl { get { return 0; } }
        public virtual Buff BuffEffect { get { return null; } }
        public virtual LKCamelot.library.Class ClassReq { get { return 0; } }
        public virtual int Range { get { return 7; } }
        public virtual int RecastTime { get { return 0; } }
        public virtual int menCoff { get { return 16; } }
        public virtual int strCoff { get { return 5000; } }
        public virtual int dexCoff { get { return 5000; } }

        public int RealManaCost(Player play)
        {
                int temp = 0;
                if (ManaCost >= 0)
                    temp = ManaCost + (ManaCostPl * Level);
                if (ManaCost < 0)
                {
                    double tt = (ManaCost*-0.01);
                    tt = tt + ((ManaCostPl * Level) * -0.01);
                    if (this.Name == "DEMON DEATH")
                    {
                        temp = (int)(tt * play.HP);
                    }
                    else
                    {
                        temp = (int)(tt * play.MP);
                    }
                }
                return temp;
        }

        public virtual bool Cast(Player player)
        {
            CheckLevelUp(player);
            return false;
        }

        public virtual void CheckLevelUp(Player player)
        {
            if (Util.RandomMinMax(0, (50 * SLevel2)) == 5)
            {
                SLevel2++;
                player.client.SendPacket(new CreateSlotMagic2(this).Compile());
                int mobile = Serial.NewMobile;
                World.SendToAll(new QueDele(player.m_Map, new CreateMagicEffect(mobile, 1, (short)player.m_Loc.X, (short)player.m_Loc.Y, new byte[] { 4, 0, 0, 0, 0, 0, 0, 0, 0, 85 }, 0).Compile()));
                var tmp = new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + 2000, player.m_Map, new DeleteObject(mobile).Compile());
                tmp.tempser = mobile;
                World.TickQue.Add(tmp);
            }
        }
	}
}