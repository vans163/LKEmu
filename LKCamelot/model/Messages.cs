using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.library;

namespace LKCamelot.model
{
    class Messages
    {
        public static class PacketHeader
        {
            public const byte CloseLogin = 0x04;
            public const byte UpdateCharStats = 0x14;
            public const byte LoadWorldChar = 0x1B;
            public const byte CreateNPC = 0x3a; //No ID
            public const byte CreateObject = 0x1D;
            public const byte UpdateChatBox = 0x0D;
            public const byte SpawnShopGump = 0x3E; //16-06-00-40-67-6F-20-68-69   size 0x00 value
            public const byte MoveItemToEquipSlot = 0x15;
            public const byte MoveItemToInventorySlot = 0x17;
            public const byte ChangeBrightness = 0x43; //0x43-00 level
            public const byte ChangeBrightness2 = 0x39; //0x39-00 level
            public const byte CurveMagic = 0x28;

            public const byte MoveSpriteTeleport = 0x1C; //0x1C //1byte 4byte id 2 face 2x 2y
            public const byte MoveSpriteWalk = 0x1F; //0x1F //1byte 4byte id 2 face 2x 2y
            public const byte SwingAnimation = 0x21; //0x21 1 4id 2 face
            public const byte ChangeFace = 0x22; //0x22 1 4id 2 face
            public const byte CastAnimation = 0x27; //0x27 1 4id 2 face
            public const byte CastMagicOnObject = 0x25; //0x25 1 4id 2spell
            public const byte ChangeObjectSprite = 0x26; //0x26 1 4id 10 sprite 1uk 1color
            public const byte HitAnimation = 0x23; //0x23 1 4id 1byte color 0xCB max, 0xCC blue
            public const byte DeleteObject = 0x1E; //0x1E 4 byte id
            public const byte SetObjectEffects = 0x34; // 0x34 4id 1light 1trans 4byffs 1staticmagic


            public const byte DeleteInvItem = 0x18; //0x1E 4 byte id
            public const byte DeleteE7uipItem = 0x16; //0x1E 4 byte id

            public const byte PlayMusic = 0x38; //38 00 00 00 00 00 e8 03 play wave

            public const byte GoldIncrease = 0x12; //0x12 1 4 amount
            public const byte XPIncrease = 0x13; //0x13 1 4 amount

            public const byte CreateSlotMagicIcon = 0x19; // 1head 1slot 1typeofmag 1 :x 2icon 4uk xxstring
            public const byte SetLevelGold = 0x0F; //0x0F 1 32text 1lvl 4exp 4 next 4money

            public const byte SetMaxHP = 0x10;// 1 4
            public const byte SetMaxMana = 0x11; //1 4

            public const byte OpenTradeBoard1 = 0x29;
            public const byte OpenTradeBoard2 = 0x2a;
            public const byte OpenTradeBoard3 = 0x2b;
            public const byte OpenTradeBoard4 = 0x2f;
        }

        public static class PacketHeaderRecv
        {
            public const byte Login = 0x03;

            public const byte ChangeFaceDir = 0x14; //14-07
            public const byte Move = 0x15; //15-03-00-17-00-17
            public const byte AttackSwing = 0x17; //attack melee   17-03
            public const byte Alive = 0x34; //34

            public const byte AddStr = 0x2C; //2C
            public const byte AddMen = 0x2D; //2D
            public const byte AddDex = 0x2E; //2E
            public const byte AddVit = 0x2F; //2F

            public const byte ChatMessage = 0x16; //16-06-00-40-67-6F-20-68-69   size 0x00 value

            public const byte ShopGumpClicked = 0x2B; //2B-50-50-50-50-08-00-08-00-67-6D-79-31-2E-6D-61-70
            public const byte PickUp = 0x1F; //1F
            public const byte Drop = 0x20; //20-01   slot
            public const byte Use = 0x00; //?? this is wrong
            public const byte Sell = 0x35; //35-01   slot
            public const byte Entrust = 0x36; //36-01   slot
            public const byte Identify = 0x37; //37-01   slot
            public const byte FixItem = 0x38; //38-01   slot
            public const byte TakeOff = 0x23; //23-02 Unequip gear
            public const byte Equip = 0x1E; //36-02 Equip + inventory slot
            public const byte DeleteMagic = 0x49; //slot 49-02

            public const byte NPCClicked = 0x45; // 45-02 4byte NPC ID

            public const byte CastedOnMob = 0x3D; //  3D-00-00-01-00-00-00-0A-00-09-00

            	//	GUIClick
		//    public const byte ListClicked = 0x0A-56; //
		//    public const byte GuildClicked = 0x3B-43; //
		//    public const byte RankingClicked = 0x16-05-00-40-52-41-4E-4B; //
        }
    }
}
