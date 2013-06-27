using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.model
{
    public class PacketOP
    {
        public static Dictionary<byte, string> PacketOPCodesOut = new Dictionary<byte, string>()
        {
	        {0x04, "CloseLogin"},
	        {0x05, "WrongPass"},
	        {0x07, "AlreadyOnline"},
	        {0x0A, "WrongID"},
	        {0x0D, "UpdateChatBox"},
	        {0x0F, "SetLevelGold"},
	        {0x10, "SetHP"},
	        {0x11, "SetMP"},
	        {0x12, "GoldChange"},
	        {0x13, "XPChange"},
	        {0x14, "UpdateCharStats"},
            {0x15, "EquipItem"},
	        {0x16, "DeleteEquipItem"},
	        {0x17, "AddItemToInventory"},
	        {0x18, "DeleteItemSlot"},
	        {0x19, "CreateSlotMagic"},
	        {0x1A, "DeleteSpell"},
	        {0x1B, "LoadWorld"},
	        {0x1C, "MoveSpriteTele"},
	        {0x1D, "CreateObject"},
	        {0x1E, "DeleteObject"},
	        {0x1F, "MoveSpriteWalk"}, 
	        {0x21, "SwingAnimation"},
	        {0x22, "ChangeFace"},
	        {0x23, "HitAnimation"},
	        {0x26, "ChangeObjectSprite"},
	        {0x28, "CurveMagic"},
	        {0x31, "AddItemToEntrust"},
	        {0x32, "DeleteEntrustSlot"},
	        {0x34, "SetObjectEffects"},
	        {0x38, "PlayMusic"},
	        {0x3A, "CreateNPC"},
	        {0x3E, "SpawnShopGump"},
        };

        public static Dictionary<byte, string> PacketOPCodesIn = new Dictionary<byte, string>()
        {
            {0x00, "UseItem"},
            {0x03, "Login"},
            {0x14, "Face"},
            {0x15, "Walk"},
            {0x16, "Chat"},
            {0x17, "AttackSwing"},
            {0x18, "Cast"},
            {0x19, "Cast"},
            {0x1E, "Equip"},
            {0x1F, "PickUp"},
            {0x20, "DropItem"},
            {0x23, "Unequip"},
            {0x24, "DragDrop"},
            {0x25, "Swap"},
            {0x26, "SwapMagic"},
            {0x2B, "BuyItemNPC"},
            {0x2C, "AddStr"},
            {0x2D, "AddMen"},
            {0x2E, "AddDex"},
            {0x2F, "AddVit"},
	        {0x34, "KeepAlive"},
            {0x35, "Sell"},
            {0x36, "Entrust"},
            {0x3A, "FindBank"},
            {0x3D, "Cast"},
            {0x45, "ClickNPCStore"},
            {0x49, "DeleteMagic"},
            {0xFF, "PlayMusic"},

        };
    }
}
