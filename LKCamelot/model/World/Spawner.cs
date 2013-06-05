using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.model
{
    public static class Spawnere
    {
        static int temps = 15;
        public static void Spawn()
        {
            if (World.NewMonsters == null)
            {
                World.NewMonsters = new Dictionary<Serial, script.monster.Monster>()
                {
                    { temps, new script.monster.Pigmy(temps++, 9,25,"Beginner")},
                    { temps, new script.monster.Pigmy(temps++, 9,38,"Beginner")},
                    { temps, new script.monster.Pigmy(temps++, 5,43,"Beginner")},
                    { temps, new script.monster.Pigmy(temps++, 4,45,"Beginner")},
                    { temps, new script.monster.Pigmy(temps++, 7,45,"Beginner")},

                    { temps, new script.monster.PigmyKing(temps++, 35,35,"Weakly3")},
                    { temps, new script.monster.WarButcher(temps++, 15,16,"010")},
               //     { temps, new script.monster.RestDummy(temps++, 10,20,"Rest")},
            //        { temps, new script.monster.RestDummy(temps++, 10,15,"Rest")},

                    { temps, new script.monster.ItemPigmy(temps++, 59,19,"ItemPigmy3")},
                    { temps, new script.monster.ItemZombie(temps++, 46,28,"ItemZomby3")},
                    { temps, new script.monster.ItemSkel(temps++, 61,29,"ItemSkel3")},
                    { temps, new script.monster.ItemButcher(temps++, 63,36,"ItemButcher3")},
                    { temps, new script.monster.ItemMummy(temps++, 63,36,"ItemMummy3")},
                    { temps, new script.monster.ItemStone(temps++, 53,40,"ItemStone4")},
                    { temps, new script.monster.SD(temps++, 6,14,"Rest")},

                    { temps, new script.monster.WildDog(temps++, 23,24,"Beginner")},
                    { temps, new script.monster.WildDog(temps++, 23,28,"Beginner")},
                    { temps, new script.monster.WildDog(temps++, 25,31,"Beginner")},
                    { temps, new script.monster.WildDog(temps++, 30,27,"Beginner")},
                    { temps, new script.monster.WildDog(temps++, 26,30,"Beginner")},

                    { temps, new script.monster.NeoViking(temps++, 52,41,"020")},
                    { temps, new script.monster.NeoSkelEscottor(temps++, 50,90,"020")},

                    { temps, new script.monster.NeoGreatStone(temps++, 90,20,"050")},
                    { temps, new script.monster.NeoDummy(temps++, 50,90,"050")},
                    { temps, new script.monster.NeoWarDummy(temps++, 20,20,"050")},
                };

                for (int x = 0; x < 30; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPoint("Weakly1")) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Pigmy(temps++, tempmob.X, tempmob.Y, "Weakly1"));
                }
                for (int x = 0; x < 20; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPoint("Weakly2")) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Pigmy(temps++, tempmob.X, tempmob.Y, "Weakly2"));
                }
                for (int x = 0; x < 30; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPoint("Weakly2")) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.PigmyRed(temps++, tempmob.X, tempmob.Y, "Weakly2"));
                }

                for (int x = 0; x < 30; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPoint("Skel1")) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Skeleton(temps++, tempmob.X, tempmob.Y, "Skel1"));
                }
                for (int x = 0; x < 30; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPoint("Skel2")) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.SkeletonRed(temps++, tempmob.X, tempmob.Y, "Skel2"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPoint("Skel2")) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Skeleton(temps++, tempmob.X, tempmob.Y, "Skel2"));
                }

                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("010", 54, 6, 100, 27)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.HeadCutter(temps++, tempmob.X, tempmob.Y, "010"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("010", 8, 9, 31, 30)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Butcher(temps++, tempmob.X, tempmob.Y, "010"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("010", 101, 5, 133, 32)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.WarBadGirl(temps++, tempmob.X, tempmob.Y, "010"));
                }

                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("020", 52, 41, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.BoneDry(temps++, tempmob.X, tempmob.Y, "020"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("020", 52, 41, 99, 0)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.BonePatrol(temps++, tempmob.X, tempmob.Y, "020"));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("020", 0, 0, 52, 41)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Viking(temps++, tempmob.X, tempmob.Y, "020"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("020", 0, 70, 50, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.SkelEscottor(temps++, tempmob.X, tempmob.Y, "020"));
                }

                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("030", 52, 41, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Viking(temps++, tempmob.X, tempmob.Y, "030"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("030", 52, 41, 99, 0)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.SkelFighter(temps++, tempmob.X, tempmob.Y, "030"));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("030", 0, 0, 52, 41)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.WarBone(temps++, tempmob.X, tempmob.Y, "030"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("030", 0, 70, 50, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.SkelEscottor(temps++, tempmob.X, tempmob.Y, "030"));
                }

                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("040", 52, 41, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.SkelEscottor(temps++, tempmob.X, tempmob.Y, "040"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("040", 52, 41, 99, 0)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.LargeSkel(temps++, tempmob.X, tempmob.Y, "040"));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("040", 0, 0, 52, 41)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GeneralSkel(temps++, tempmob.X, tempmob.Y, "040"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("040", 0, 70, 50, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Stone(temps++, tempmob.X, tempmob.Y, "040"));
                }

                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("050", 52, 41, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Stone(temps++, tempmob.X, tempmob.Y, "050"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("050", 52, 41, 99, 0)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GreatStone(temps++, tempmob.X, tempmob.Y, "050"));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("050", 0, 0, 52, 41)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.WarDummy(temps++, tempmob.X, tempmob.Y, "050"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("050", 0, 70, 50, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Dummy(temps++, tempmob.X, tempmob.Y, "050"));
                }
                for (int x = 0; x < 1; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("050", 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.ItemDummy(temps++, tempmob.X, tempmob.Y, "050"));
                }

                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("060", 52, 41, 119, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.WarDummy(temps++, tempmob.X, tempmob.Y, "060"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("060", 52, 41, 119, 0)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Mummy060(temps++, tempmob.X, tempmob.Y, "060"));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("060", 0, 0, 52, 41)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.StoneGolem060(temps++, tempmob.X, tempmob.Y, "060"));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("060", 0, 70, 50, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.HardBoild060(temps++, tempmob.X, tempmob.Y, "060"));
                }

                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("070", 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Mummy060(temps++, tempmob.X, tempmob.Y, "070"));
                }
                for (int x = 0; x < 20; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("070", 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.HardBoild060(temps++, tempmob.X, tempmob.Y, "070"));
                }
                for (int x = 0; x < 1; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("070", 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.ItemHardBoil(temps++, tempmob.X, tempmob.Y, "070"));
                }
                for (int x = 0; x < 25; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("080", 0, 0, 119, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.StoneGolem060(temps++, tempmob.X, tempmob.Y, "080"));
                }
                for (int x = 0; x < 20; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("080", 0, 0, 119, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.HardBoild060(temps++, tempmob.X, tempmob.Y, "080"));
                }
                for (int x = 0; x < 1; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("080", 0, 0, 119, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.ItemGolem(temps++, tempmob.X, tempmob.Y, "080"));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemPigmy1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 63, 63)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Pigmy(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemPigmy2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.PigmyRed(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemPigmy3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.PigmyBlue(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemPigmy3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.PigmyGreen(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemZomby1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Zombie(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemZomby2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.ZombieRed(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemZomby3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.ZombieGreen(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemZomby3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.ZombieBlue(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemSkel1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Skeleton(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemSkel2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.BoneDryRed(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemSkel2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.BoneDryGreen(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemSkel3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.BoneDryBlue(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemButcher1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iButcher(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemButcher2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iButcherRed(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemButcher3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iButcherBlue(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemButcher3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iButcherGreen(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemMummy1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iMummy(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemMummy2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iMummyRed(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemMummy3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iMummyGreen(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemMummy3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iMummyBlue(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemStone1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iStone(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemStone2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iStoneRed(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemStone3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iStoneGreen(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemStone4";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iStoneBlue(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemDummy1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iDummy(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemDummy2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iDummyRed(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemDummy3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iDummyGreen(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemDummy4";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iDummyBlue(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemDummy5";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iWarDummy(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 1; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemDummy5";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.ItemDummy(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemWarDummy1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iWarDummy(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemWarDummy2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iWarDummyRed(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemWarDummy3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iWarDummyGreen(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemWarDummy4";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iWarDummyBlue(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 1; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemWarDummy5";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.ItemWarDummy(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemHardboil1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iHardBoil(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemHardboil2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iHardBoilRed(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemHardboil3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iHardBoilGreen(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemHardboil4";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iHardBoilBlue(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 50; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemHardboil5";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.iHardBoilBlue(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 1; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemHardboil5";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.ItemHardBoil(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemGolem1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GolemGuard(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemGolem2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GolemGuard(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 20; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemGolem3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GolemGuard(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 20; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemGolem4";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GolemGuard(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 50; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemGolem5";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GolemGuard(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 1; x++)
                {
                    Point2D tempmob = null; string mapn = "ItemGolem5";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.ItemGolem(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 3; x++)
                {
                    Point2D tempmob = null; string mapn = "TreasureLand";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.HoundsOfDoom(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 6; x++)
                {
                    Point2D tempmob = null; string mapn = "TreasureLand";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.BoneTrio1(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 6; x++)
                {
                    Point2D tempmob = null; string mapn = "TreasureLand";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.BoneTrio2(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 6; x++)
                {
                    Point2D tempmob = null; string mapn = "TreasureLand";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.BoneTrio3(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 5; x++)
                {
                    Point2D tempmob = null; string mapn = "TreasureLand";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.BioRubber(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 5; x++)
                {
                    Point2D tempmob = null; string mapn = "TreasureLand";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Mercenary(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 5; x++)
                {
                    Point2D tempmob = null; string mapn = "TreasureLand";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Leo(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 5; x++)
                {
                    Point2D tempmob = null; string mapn = "TreasureLand";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.SmokeGiant(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 5; x++)
                {
                    Point2D tempmob = null; string mapn = "TreasureLand";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 99)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Spot(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 20; x++)
                {
                    Point2D tempmob = null; string mapn = "Biggun1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 79)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Rowedy(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "Biggun1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 79)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Biggun(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 20; x++)
                {
                    Point2D tempmob = null; string mapn = "Biggun2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 79)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Rowedy(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 25; x++)
                {
                    Point2D tempmob = null; string mapn = "Biggun2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 99, 79)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Biggun(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 50; x++)
                {
                    Point2D tempmob = null; string mapn = "Miro1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Cyclops(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 50; x++)
                {
                    Point2D tempmob = null; string mapn = "Miro1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.OneEye(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 15; x++)
                {
                    Point2D tempmob = null; string mapn = "Golem";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 49, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GolemGuard(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "Golem1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 49, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GolemGuard(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 6; x++)
                {
                    Point2D tempmob = null; string mapn = "Golem1";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 49, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.vIronGolem(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 5; x++)
                {
                    Point2D tempmob = null; string mapn = "Golem2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 49, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GolemGuard(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "Golem2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 49, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.vIronGolem(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "Golem2";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 49, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.SuperIronGolem(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 8; x++)
                {
                    Point2D tempmob = null; string mapn = "Golem3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 49, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.DevilKid(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 14; x++)
                {
                    Point2D tempmob = null; string mapn = "Golem3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 49, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.vIronGolem(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 10; x++)
                {
                    Point2D tempmob = null; string mapn = "Golem3";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 49, 49)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.SuperIronGolem(temps++, tempmob.X, tempmob.Y, mapn));
                }
                for (int x = 0; x < 80; x++)
                {
                    Point2D tempmob = null; string mapn = "Golem12";
                    while ((tempmob = Map.SpawnPointFixed(mapn, 0, 0, 79, 79)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Rioter(temps++, tempmob.X, tempmob.Y, mapn));
                }

                for (int x = 0; x < 20; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("Venture4", 0, 0, 99, 79)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Scorpian(temps++, tempmob.X, tempmob.Y, "Venture4"));
                }
                for (int x = 0; x < 30; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("Venture4", 0, 0, 99, 79)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.BloodShot(temps++, tempmob.X, tempmob.Y, "Venture4"));
                }

                for (int x = 0; x < 8; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("Great", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Phantom(temps++, tempmob.X, tempmob.Y, "Great"));
                }
                for (int x = 0; x < 8; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("Great", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Temptress(temps++, tempmob.X, tempmob.Y, "Great"));
                }
                for (int x = 0; x < 8; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("Great", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Solo(temps++, tempmob.X, tempmob.Y, "Great"));
                }
                for (int x = 0; x < 8; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("Great", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.FireDragon(temps++, tempmob.X, tempmob.Y, "Great"));
                }
                for (int x = 0; x < 1; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("Great", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.PrincessShea(temps++, tempmob.X, tempmob.Y, "Great"));
                }
                for (int x = 0; x < 1; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("Great", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.QueenSpriss(temps++, tempmob.X, tempmob.Y, "Great"));
                }
                for (int x = 0; x < 12; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("Great", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Centeur(temps++, tempmob.X, tempmob.Y, "Great"));
                }

                for (int x = 0; x < 35; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV1", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.SkelGiant(temps++, tempmob.X, tempmob.Y, "VV1"));
                }
                for (int x = 0; x < 75; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV1", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Gargoyle(temps++, tempmob.X, tempmob.Y, "VV1"));
                }
                for (int x = 0; x < 60; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV2", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Gargoyle(temps++, tempmob.X, tempmob.Y, "VV2"));
                }
                for (int x = 0; x < 50; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV2", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.SkelGiant(temps++, tempmob.X, tempmob.Y, "VV2"));
                }
                for (int x = 0; x < 50; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV3", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Gargoyle(temps++, tempmob.X, tempmob.Y, "VV3"));
                }
                for (int x = 0; x < 60; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV3", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Ninja(temps++, tempmob.X, tempmob.Y, "VV3"));
                }
                for (int x = 0; x < 50; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV3", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Necromancer(temps++, tempmob.X, tempmob.Y, "VV3"));
                }
                for (int x = 0; x < 60; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV4", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Ninja(temps++, tempmob.X, tempmob.Y, "VV4"));
                }
                for (int x = 0; x < 60; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV4", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Necromancer(temps++, tempmob.X, tempmob.Y, "VV4"));
                }
                for (int x = 0; x < 50; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV4", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.LoupGarou(temps++, tempmob.X, tempmob.Y, "VV4"));
                }
                for (int x = 0; x < 50; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV4", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GhostKnight(temps++, tempmob.X, tempmob.Y, "VV4"));
                }
                for (int x = 0; x < 50; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV5", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.GhostKnight(temps++, tempmob.X, tempmob.Y, "VV5"));
                }
                for (int x = 0; x < 50; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV5", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.DevilGuard(temps++, tempmob.X, tempmob.Y, "VV5"));
                }
                for (int x = 0; x < 60; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("VV5", 0, 0, 199, 199)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Devil(temps++, tempmob.X, tempmob.Y, "VV5"));
                }

                for (int x = 0; x < 60; x++)
                {
                    Point2D tempmob = null;
                    while ((tempmob = Map.SpawnPointFixed("Miner0", 0, 0, 159, 79)) == null) ;
                    World.NewMonsters.Add(temps, new script.monster.Iron(temps++, tempmob.X, tempmob.Y, "Miner0"));
                }
            }
        }
    }
}
