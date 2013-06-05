using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.library
{
    public static class TimeOfDay
    {
        public const byte Day = 0x01;
        public const byte Dusk = 0x02;
        public const byte Night = 0x03;
    }

    public enum Class
    {
        Knight = 1,
        Swordsman = 2,
        Wizard = 4,
        Shaman = 8,
        Beginner = 16,
    }

    public enum SpriteEquip
    {
        None = 0,
        Sword = 1,
        Axe = 2,
        Shield = 4,
        Hammer = 8,
        Cane = 16,
        Cane2 = 32,
        Spear = 64,
        Spear2 = 128,
    }

    public enum MagicType
    {
        Coord = 2, //1B-01-00-1B-00-13-00
        Target = 3, //18-01-00-00-00-00-00-1B-00-1E-00
        Casted = 4, //19-01-00 
        Target2 = 5 //3D-01-00-00-00-00-00-1A-00-13-00
    }

    public enum NPCs
    {
        Arnold = 1,
        Employee = 2,
        Loen = 3,
        Wizard = 4,
        SweepingGuy = 5,
        SittingMedGuy = 6,
        AnvilBoy = 7,
        HandsFoldedGirl = 8,
        RoadSign1 = 0x0a,
        RoadSign2 = 0x0b,
        RoadSign3 = 0x0c
    }

    public static class OPCObject
    {
        public const byte Char = 0x00;
        public const byte Monster = 0x01;
        public const byte Item = 0x02;
        public const byte Effect = 0x04;
        public const byte NPC = 0x0a;
        public const byte Ore = 0x0b;
    }

    public static class Direction
    {
        public const byte N = 0x00;
        public const byte NE = 0x01;
        public const byte E = 0x02;
        public const byte SE = 0x3;
        public const byte S = 0x4;
        public const byte SW = 0x05;
        public const byte W = 0x06;
        public const byte NW = 0x07;
    }

    public static class EquipSlot
    {
        public const byte Hat = 0x00;
        public const byte Amulet = 0x01;
        public const byte Weapon = 0x02;
        public const byte Armor = 0x03;
        public const byte Shield = 0x04;
        public const byte Ring = 0x05;
    }

    public static class EquipHighlight
    {
        public const byte Black = 0x00;
        public const byte Blue = 0x01;
        public const byte Green = 0x02;
        public const byte Red = 0x03;
    }

    public static class Magic
    {
        //Magic
        public const byte RedDots01 = 0x01;
        public const byte BlueBarrier02 = 0x02;
        public const byte GuardianSword03 = 0x03;
        public const byte DemonDeath04 = 0x04;
        public const byte MagicShield05 = 0x05;
        public const byte TeagueShieldQ06 = 0x06;
        public const byte RedOrb07 = 0x07;
        public const byte RedGroundFire08 = 0x08;
        public const byte SpinningHalo09 = 0x09;
        public const byte LightningStrike0A = 0x0a;
        public const byte WhiteCloud0B = 0x0b;
        public const byte BlueSpiralHold0C = 0x0c;
        public const byte LightblueSnake0D = 0x0d;
        public const byte GreenFire0E = 0x0e;
        public const byte Explosion0F = 0x0f;
        public const byte BigExplosion10 = 0x10;
        public const byte LargeFlame11 = 0x11;
        public const byte LightningWall12 = 0x12;
        public const byte LightningWallBig13 = 0x13;
        public const byte LowResExplosion14 = 0x14;
        public const byte PurpleRain15 = 0x15;
        public const byte SpinningYellowHalo16 = 0x16;
        public const byte Firebolt17 = 0x17;
        public const byte BlueStar18 = 0x18;
        public const byte SlowRedFlame19 = 0x19;
        public const byte FireBall1a = 0x1a;
        public const byte FireHawk1b = 0x1b;
        public const byte DragonOfFire1c = 0x1c;
        public const byte MultiColoredSpiral1d = 0x1d;
        public const byte LightningWallMedium1e = 0x1e;
        public const byte LightningWallLarge1f = 0x1f;
        public const byte ElectronicBall20 = 0x20;
        public const byte LargeElectronicBall21 = 0x21;
        public const byte SnowFlakes22 = 0x22;
        public const byte Sword23 = 0x23;
        public const byte ThinStick24 = 0x24;
        public const byte SideWinder25 = 0x25;
        public const byte Ghost26 = 0x26;
        public const byte GlowingSword27 = 0x27;
        public const byte ImplodingBall28 = 0x28;
        public const byte LargeImplodingBall29 = 0x29;
        public const byte FourBallsCirclingIn2a = 0x2a;
        public const byte DarkRedFastFlame2b = 0x2b;
        public const byte UpDownLightningWall2c = 0x2c;
        public const byte LargeUpDownLightningWall2d = 0x2d;
        public const byte AppearingLightningWaterBall2e = 0x2e;
        public const byte LargeAppearingLightningWaterBall2e = 0x2f;
        public const byte DarkBlueFastFlame30 = 0x30;
        public const byte GreenLightFlame31 = 0x31;
        public const byte SlowBlueFlame32 = 0x32;
        public const byte GreenBallFlash33 = 0x33;
        public const byte Firewall34 = 0x34;
        public const byte LightningEtc35 = 0x35;
        public const byte LightningEtc36 = 0x36;
        public const byte RubyGlacialCrystal37 = 0x37;
        public const byte SteelExplosion38 = 0x38;
        public const byte BlueStarTwo39 = 0x39;
        public const byte SlowFlameTwo3a = 0x3a;
        public const byte SlowBlueFlameTwo3b = 0x3b;
        public const byte SlowGreenFlameTwo3c = 0x3c;
        public const byte RisingMud3d = 0x3d;
        public const byte RisingIce3d = 0x3e;
        public const byte AirBrightExplosion3f = 0x3f;
        public const byte Bang40 = 0x40;
        public const byte DeadlyBang41 = 0x41;
        public const byte VeryDeadlyBang42 = 0x42;
        public const byte FourPincerClaw43 = 0x43;
        public const byte GhostCaster44 = 0x44;
        public const byte Execution45 = 0x45;
        public const byte FireProtector46 = 0x46;
        public const byte ThreeFlameCircle47 = 0x47;
        public const byte RisingIce48 = 0x48;
        public const byte GreenOrangeRedPurpleHoverOrb49 = 0x49;
        public const byte LightningRIse4a = 0x4a;
        public const byte LightningFromSky4b = 0x4b;
        public const byte IceFromSky4c = 0x4c;
        public const byte FireFromSkyExplosion4d = 0x4d;
        public const byte WierdOrganThing4e = 0x4e;
        public const byte IceOrLightComet4f = 0x4f;
        public const byte BlueOrb50 = 0x50;
        public const byte Comet51 = 0x51;
        public const byte SmallSprinkles52 = 0x52;
        public const byte FlamePillar53 = 0x53;
        public const byte LargeSprinkles54 = 0x54;
        public const byte StarOfDavid55 = 0x55;
        public const byte QuestionMark56 = 0x56;
        public const byte BladeSpinMagic = 0x70; //WindBlade Wizard
        //
    }

    public static class NextLevelC
    {
        public static List<int> NextLevelTable = new List<int>()
        {    
        1,
        107,
        247,
        428,
        664,
        968,
        1358,
        1859,
        2497,
        3309,
        4336,
        5631,
        7259,
        9299,
        11845,
        15014,
        18944,
        23805,
        29796,
        37161,
        46187,
        57215,
        70654,
        86983,
        106771,
        130683,
        159504,
        194148,
        235686,
        285359,
        344612,//30
        415115,
        498796,
        597873,
        714897,
        852785,
        1014871,
        1204953,
        1427346,
        1686940,
        1989262,//40
        2340544,
        2747793,
        3218867,  //level4 2nd promo
        3762558,
        4388672,
        5108122,
        5933021,
        6876774,
        7954182,
        9181541,//50
        10576744,
        12159386,
        13950868,
        15974500,
        18255595,
        20821574,
        23702048,
        26928907,
        30536393,
        34561163,//60
        39042345,
        44021573,
        49543011,
        55653353,
        62401807,
        69840059,
        78022199,
        87004640,
        96845990,
        107606903,//70
        119349899,
        132139142,
        146040195,
        161119727,
        177445192,
        195084469,
        214105466,
        234575684,
        256561752,
        280128928,//80
        305340558,
        332257524,
        360937647,
        391435082,
        423799685,
        458076366,
        494304442,
        532516975,
        572740115,
        614992455,//90
        659284397,
        705617540,
        753984097,
        804366346,
        856736129,
        911054390,
        967270783,
        1025323333,
        1025323333,
        //1st promo
        0,
        235671,
        487778,
        756957,
        1043758,
        1348733,
        1673379,
        2015146,
        2377426,
        2759552,
        3161783,
        3584307,
        4027226,
        4490557,
        4974223,
        5478045,
        6001743,
        6544926,
        7107090,
        7687615,
        7687615,
        //2nd Promo
        707013,
		1463364,
		2270871,
		3131274,
		4046199,
		5017137,
		6045438,
		7132278,
		8278656,
		9485349,
		10752921,
		12081678,
		13471671,
		14922669,
		16434135,
		18005229,
		19634778,
		21321270,
		23062845,
        23062845,
        //3rd promo
		1414026,
		2926728,
		4543742,
		6262548,
		8092398,
		10034274,
		12092876,
		14264556,
		16557312,
		18970698,
		21505842,
		21463356,
		26943342,
		29845338,
		32868270,
		36010458,
		39269556,
		43642540,
		46125690,
        46125690,
        //4th promo
		2828052,
		5853456,
		9083484,
		12525096,
		16184796,
		20068548,
		24181752,
		28529112,
		33114824,
		37941396,
		43011684,
		48326712,
		53886684,
		59690676,
		65736540,
		72020916,
		78539112,
		85285080,
		92251380,
        92251380,
        //5th promo
        5656104,
		11706912,
		18166968,
		25050192,
		32369592,
		40137096,
		48363504,
		57058224,
		66229248,
		75882792,
		86023368,
		96653424,
		107773368,
		119381352,
		131473080,
		144041832,
		157078224,
		170570161,
		184502760,
        184502760,
        //6th promo
		11312208,
		23413824,
		36339364,
		50100384,
		64739184,
		80274192,
		96727008,
		114116448,
		132458496,
		151765584,
		172046736,
		193306848,
		215546736,
		238762704,
		262946160,
		288083664,
		314156448,
		341140320,
		369005520,
		369005520,
        //7th promo
	3393663, 
    7024004, 
    10900182, 
    15030117, 
    19425108, 
    24100818, 
    29023112, 
    33688025, 
    38598376, 
    43756459, 
    49163521, 
    55238742, 
    61593940, 
    68228061, 
    75138647, 
    81939011, 
    89354836, 
    97029801, 
    104955439, 
    113222343,
  //  113222343,
 //8th promo 
 6787326, 
 14048008, 
 21800365, 
 30060235, 
 38850217, 
 48201636, 
 58046226, 
 67376052, 
 77196754, 
 87512921, 
 98327043, 
 109639537, 
 121448521, 
 133749625, 
 146536014, 
 159798140, 
 173523698, 
 187697551, 
 202481707, 
 202481707,
 //9th promo 
 13574652, 
 28096017, 
 43600730, 
 60120471, 
 77700434, 
 96403272, 
 116092450, 
 134752103, 
 154393506, 
 175025840, 
 196654085, 
 219279072, 
 242897040, 
 267499248, 
 293072025, 
 319596277, 
 347047393, 
 375395097, 
 404963410,
 404963410,
 //10th promo 
 27149304, 
 56192035, 
 87201461, 
 120240942, 
 155400868, 
 192806545, 
 232184901, 
 269504207, 
 308787013, 
 350051680, 
 393308170, 
 438558144, 
 485794080, 
 534998497, 
 586144051, 
 639192554, 
 697042170, 
 753978329, 
 813366070, 
 813366070,
 //11th promo 
 54298608, 
 112384071, 
 174402923, 
 240481885, 
 310801737, 
 385613090, 
 464369802, 
 539008414, 
 617574026, 
 700103361, 
 786616341, 
 877116288, 
 971588160, 
 1069996995, 
 1172288102, 
 1278385108, 
 1388189572, 
 1501580390, 
 1619853640, 
 1619853640, 
 //12th promo 
 16289582, 
 33715220, 
 52320875, 
 72144563, 
 93240518, 
 115683924, 
 139310937, 
 161702520, 
 185272203, 
 210031003, 
 235984896, 
 263134879, 
 291476440, 
 320999090, 
 351686421, 
 383515523, 
 416456861, 
 450474106, 
 485956080, 
 485956080,
 485956080,
        };
    }
}
