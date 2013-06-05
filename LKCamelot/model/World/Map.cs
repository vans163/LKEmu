using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
namespace LKCamelot.model
{
    public class TiledMap
    {
        string Name;
        int sizeX;
        int sizeY;
        public MyPathNode[,] tiles;
        
        public TiledMap(string Name, int sizeX, int sizeY)
        {
            this.Name = Name;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            tiles = new MyPathNode[sizeX,sizeY];
        }
    }

    public static class Map
    {
        public static Dictionary<string, string> FullMaps = new Dictionary<string,string>()
        {
            { "Rest", "erest.map" },
            { "Village1", "32.map" },
            { "Loen", "loen.map" },
            { "Arnold", "anold.map" },
            { "Beginner", "estart1.map" },
            { "ELevel", "elevel.map" },
            { "Biggun1", "estart4.map" },
            { "Biggun2", "estart3.map" },
            { "Miro1", "miro1.map" },
            { "TreasureLand", "1000.map" },

            { "1000.map", "1000.map" },
            { "bone01.map", "bone01.map" },
            { "eabinc.map", "eabinc.map" },
            { "Soccer", "esoccer.map" },

            { "estart.map", "estart.map" },
            { "estart2.map", "estart2.map" },
            { "qweak1.map", "qweak1.map" },
            { "Miner0", "miner0.map" },
            { "Miner1", "miner1.map" },


            { "Great", "great.map" },
            { "010", "010map.map" },
            { "020", "020map.map" },
            { "030", "030map.map" },
            { "040", "040map.map" },
            { "050", "050map.map" },
            { "060", "060map.map" },
            { "070", "070map.map" },
            { "080", "080map.map" },
            { "ItemVillage", "ivillage.map" },
            { "ItemPigmy1", "ipigmy1.map" },
            { "ItemPigmy2", "ipigmy2.map" },
            { "ItemPigmy3", "ipigmy3.map" },
            { "ItemZomby1", "izomby1.map" },
            { "ItemZomby2", "izomby2.map" },
            { "ItemZomby3", "izomby3.map" },
            { "ItemSkel1", "iskel1.map" },
            { "ItemSkel2", "iskel2.map" },
            { "ItemSkel3", "iskel3.map" },
            { "ItemButcher1", "ibut1.map" },
            { "ItemButcher2", "ibut2.map" },
            { "ItemButcher3", "ibut3.map" },
            { "ItemMummy1", "imummy1.map" },
            { "ItemMummy2", "imummy2.map" },
            { "ItemMummy3", "imummy3.map" },
            { "ItemStone1", "istone1.map" },
            { "ItemStone2", "istone2.map" },
            { "ItemStone3", "istone3.map" },
            { "ItemStone4", "istone4.map" },
            { "ItemDummy1", "imummy1.map" },
            { "ItemDummy2", "imummy2.map" },
            { "ItemDummy3", "imummy3.map" },
            { "ItemDummy4", "istone3.map" },
            { "ItemDummy5", "istone4.map" },
            { "ItemWarDummy1", "imummy1.map" },
            { "ItemWarDummy2", "imummy2.map" },
            { "ItemWarDummy3", "imummy3.map" },
            { "ItemWarDummy4", "istone3.map" },
            { "ItemWarDummy5", "istone4.map" },
            { "ItemHardboil1", "imummy1.map" },
            { "ItemHardboil2", "imummy2.map" },
            { "ItemHardboil3", "imummy3.map" },
            { "ItemHardboil4", "istone3.map" },
            { "ItemHardboil5", "istone4.map" },
            { "ItemGolem1", "imummy1.map" },
            { "ItemGolem2", "imummy2.map" },
            { "ItemGolem3", "imummy3.map" },
            { "ItemGolem4", "istone3.map" },
            { "ItemGolem5", "istone4.map" },
            { "Venture4", "estart4.map" },
            { "Weakly1", "weakly1.map" },
            { "Weakly2", "weakly2.map" },
            { "Weakly3", "weakly3.map" },
            { "Weakly4", "weakly4.map" },
            { "Weakly5", "weakly5.map" },
            { "Skel1", "skel1.map" },
            { "Skel2", "skel2.map" },
            { "Skel3", "skel3.map" },
            { "Skel4", "skel4.map" },
            { "Skel5", "skel5.map" },

            { "Cave", "Cave.map" },
            { "Cave1", "cave1.map" },
            { "Cave2", "cave2.map" },

            { "Golem", "golem.map" },
            { "Golem1", "golem1.map" },
            { "Golem2", "golem2.map" },
            { "Golem3", "golem3.map" },
            { "Golem12", "golem12.map" },

            { "VV1", "vv1.map" },
            { "VV2", "vv2.map" },
            { "VV3", "vv3.map" },
            { "VV4", "vv4.map" },
            { "VV5", "vv5.map" },
        };

        public static Dictionary<string, Point2D> mapsizes = new Dictionary<string, Point2D>()
        {
           { "erest.map", new Point2D(44,48)},
           { "loen.map", new Point2D(44,48)},
           { "anold.map", new Point2D(44,48)},
           { "elevel.map", new Point2D(60,60)},
           { "32.map", new Point2D(200,200)},

           { "010map.map", new Point2D(150,100)},
           { "020map.map", new Point2D(100,100)},
           { "030map.map", new Point2D(120,120)},
           { "040map.map", new Point2D(100,100)},
           { "050map.map", new Point2D(100,100)},
           { "060map.map", new Point2D(120,100)},
           { "070map.map", new Point2D(100,100)},
           { "080map.map", new Point2D(120,100)},
           { "ivillage.map", new Point2D(200,200)},

           { "ipigmy1.map", new Point2D(64,64)},
           { "ipigmy2.map", new Point2D(80,50)},
           { "ipigmy3.map", new Point2D(80,50)},

           { "izomby1.map", new Point2D(80,50)},
           { "izomby2.map", new Point2D(80,50)},
           { "izomby3.map", new Point2D(80,50)},

           { "iskel1.map", new Point2D(80,50)},
           { "iskel2.map", new Point2D(80,50)},
           { "iskel3.map", new Point2D(80,50)},

           { "ibut1.map", new Point2D(80,50)},
           { "ibut2.map", new Point2D(80,50)},
           { "ibut3.map", new Point2D(80,50)},

           { "imummy1.map", new Point2D(80,50)},
           { "imummy2.map", new Point2D(80,50)},
           { "imummy3.map", new Point2D(80,50)},

           { "istone1.map", new Point2D(80,50)},
           { "istone2.map", new Point2D(80,50)},
           { "istone3.map", new Point2D(80,50)},
           { "istone4.map", new Point2D(80,50)},

           { "estart.map", new Point2D(64,64)},
           { "estart1.map", new Point2D(50,50)},
           { "estart2.map", new Point2D(60,60)},
           { "estart3.map", new Point2D(100,80)},
           { "estart4.map", new Point2D(100,80)},

           { "cave.map", new Point2D(80,80)},
           { "cave1.map", new Point2D(129,79)},
           { "cave2.map", new Point2D(190,110)},

           { "golem.map", new Point2D(50,50)},
           { "golem1.map", new Point2D(50,50)},
           { "golem2.map", new Point2D(50,50)},
           { "golem3.map", new Point2D(50,50)},
           { "golem12.map", new Point2D(80,80)},

           { "great.map", new Point2D(200,200)},
           { "miro1.map", new Point2D(80,200)},
           { "Viking.map", new Point2D(60,60)},
           { "1000.map", new Point2D(100,100)},

           { "miner0.map", new Point2D(160,80)},
           { "miner1.map", new Point2D(160,80)},
           { "miner2.map", new Point2D(160,80)},
           { "miner3.map", new Point2D(160,80)},

           { "qweak.map", new Point2D(20,20)},
           { "qweak1.map", new Point2D(230,150)},
           { "qweak2.map", new Point2D(210,110)},
           { "qweak3.map", new Point2D(220,120)},
           { "qweak4.map", new Point2D(255,155)},
           { "qweak5.map", new Point2D(190,110)},

           { "vv1.map", new Point2D(200,200)},
           { "vv2.map", new Point2D(200,200)},
           { "vv3.map", new Point2D(200,200)},
           { "vv4.map", new Point2D(200,200)},
           { "vv5.map", new Point2D(200,200)},

           { "ps01.map", new Point2D(100,100)},
           { "ps02.map", new Point2D(100,100)},
           { "ps03.map", new Point2D(100,100)},

           { "weakly1.map", new Point2D(64,64)},
           { "weakly2.map", new Point2D(64,64)},
           { "weakly3.map", new Point2D(64,64)},
           { "weakly4.map", new Point2D(64,64)},
           { "weakly5.map", new Point2D(64,64)},
           { "skel1.map", new Point2D(64,64)},
           { "skel2.map", new Point2D(64,64)},
           { "skel3.map", new Point2D(64,64)},
           { "skel4.map", new Point2D(64,64)},
           { "skel5.map", new Point2D(64,64)},
        };

        public static Dictionary<string, TiledMap> loadedmaps = new Dictionary<string, TiledMap>();

        public static Point2D SpawnPoint(string map)
        {
            Point2D temp = null;
            var nmap = LKCamelot.model.Map.FullMaps.Where(xe => xe.Key == map).FirstOrDefault().Value;
            var curmap = loadedmaps[nmap];
            var randomtile = curmap.tiles[Util.Random(0,mapsizes[nmap].X), Util.Random(0,mapsizes[nmap].Y)];
            if (randomtile.IsWall == false && randomtile.SpawnP == false)
            {
                temp = new Point2D(0,0);
                temp.X = randomtile.X;
                temp.Y = randomtile.Y;
                randomtile.SpawnP = true;
            }

            return temp;
        }

        public static Point2D SpawnPointFixed(string map, int xe, int ye, int xe2, int ye2)
        {
            Point2D temp = null;
            var nmap = LKCamelot.model.Map.FullMaps.Where(xee => xee.Key == map).FirstOrDefault().Value;
            var curmap = loadedmaps[nmap];
            var randomtile = curmap.tiles[Util.RandomMinMax(xe, xe2), Util.RandomMinMax(ye, ye2)];
            if (randomtile.IsWall == false && randomtile.SpawnP == false)
            {
                temp = new Point2D(0, 0);
                temp.X = randomtile.X;
                temp.Y = randomtile.Y;
                randomtile.SpawnP = true;
            }

            return temp;
        }

        static int offset = 76;
        public static void Init()
        {
            string[] filePaths = Directory.GetFiles(@"map");
            foreach (var file in filePaths)
            {
                var mapn = file.Substring(file.IndexOf(Path.DirectorySeparatorChar) + 1, file.Count() - (file.IndexOf(Path.DirectorySeparatorChar) + 1));

                if (mapsizes.ContainsKey(mapn))
                {
                    var tl = new TiledMap(mapn, mapsizes[mapn].X, mapsizes[mapn].Y);
                    var input = File.ReadAllBytes(file);
                    int cnt = mapsizes[mapn].X * mapsizes[mapn].Y;
                    int itr = 0, res2 = 0, res1 = 0;
                    byte[] temp = new byte[4];

                    while (itr != cnt)
                    {
                        Array.Copy(input, offset + (itr * 4), temp, 0, 4);
                        if (itr % mapsizes[mapn].X == 0 && itr != 0)
                        {
                            res2++;
                            res1 = 0;
                        }

                        if (temp[0] == 3 || temp[0] == 5 || (temp[0] == 2 && temp[2] == 3))
                        {
                            var tempp = new MyPathNode(res1, res2);
                            tempp.IsWall = true;
                            tl.tiles[res1++,res2] = tempp; //0
                        }
                        else
                        {
                            var temp2 = new MyPathNode(res1, res2);
                            tl.tiles[res1++,res2] = temp2; //1
                        }
                        itr++;
                    }

                    loadedmaps.Add(mapn, tl);
                }
            }
        }
    }
}
