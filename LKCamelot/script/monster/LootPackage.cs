using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.script.monster;
namespace LKCamelot.script
{
    
    public static class Packs
    {
        public static Type[] CSWSFS = new Type[]{
            typeof(script.item.CurveShockBook),
            typeof(script.item.WindySpiritBook),
            typeof(script.item.FrameStrikeBook)};

        public static Type[] VVArmorPack = new Type[]{
            typeof(script.item.CelestialArmor),
            typeof(script.item.GoldVest),
            typeof(script.item.GoliathPlate),
            typeof(script.item.GrandeurPride)
        };

        public static Type[] GreatArmorPack = new Type[]{
            typeof(script.item.GoliathPlate),
            typeof(script.item.DiamondArmor),
            typeof(script.item.UnicornProtectoria),
            typeof(script.item.GrandeurPride)
        };

        public static Type[] GreatWeaponPack = new Type[]{
            typeof(script.item.Excalibur),
            typeof(script.item.DaeungDaegum),
            typeof(script.item.Kassandra),
            typeof(script.item.TaegkFan)
        };

        public static Type[] WeaponPack110 = new Type[]{
            typeof(script.item.GreatAxe),
            typeof(script.item.GreatMaul),
            typeof(script.item.GreatSword),
            typeof(script.item.GreatLance),
            typeof(script.item.Halberd),
            typeof(script.item.Troy),
            typeof(script.item.GiantHammer)
        };

        public static Type[] ArmorPack110 = new Type[]{
            typeof(script.item.FullPlate),
            typeof(script.item.WidePlate),
            typeof(script.item.SamuraiPlate),
            typeof(script.item.GrandShield),
            typeof(script.item.MailPlate),
            typeof(script.item.ShineHelmet),
            typeof(script.item.KiteShield),
            typeof(script.item.PigBasket),
            typeof(script.item.GrandeurHelmet),
            typeof(script.item.FieldCap),
        };
    }
}
