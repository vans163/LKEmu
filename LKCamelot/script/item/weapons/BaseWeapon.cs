using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.library;
using LKCamelot.model;
namespace LKCamelot.script.item
{
    public enum WeaponType
    {
        Sword = 1,
        Axe = 2,
        Cane = 3,
        Spear = 4,
        Hammer = 5,
        Cane2,
        Spear2
    }

    public enum UpgradeWep
    {
        None = 0,
        Savage = 1,
        Deadly = 2,
        Revengeful = 3,
        Dreadful = 4,
        Angry = 5,
        Awesome = 6,
        Tremendous = 7,
        Bloody = 8,
        Invincible = 9,
        Angelic = 10,
    }

    public interface IProc
    {
        int Proc(Player player, script.monster.Monster monster, Player play = null);
    }

    public class BaseWeapon : Item
    {
        public virtual int InitMinHits { get { return 0; } }
        public virtual int InitMaxHits { get { return 0; } }

        public virtual WeaponType WeaponType { get { return 0; } }
        public virtual UpgradeWep Upgrade { get { return 0; } }

        public BaseWeapon(int itemID) : base(itemID)
        {
        }

        public BaseWeapon(Serial serial) : base(serial)
        {
        }
    }
}
