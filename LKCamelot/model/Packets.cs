using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.library;

namespace LKCamelot.model
{
    public sealed class AddItemToInventory2 : Packet
    {
        public AddItemToInventory2(LKCamelot.script.item.Item item)
            : base(0x17)
        {
            m_Stream.Write((byte)item.InvSlot);
            m_Stream.Write((short)item.m_ItemID);
            m_Stream.Write((byte)02);
            m_Stream.Write((short)item.ParsedStats.Count());
            m_Stream.WriteAsciiNull(item.ParsedStats);
        }
    }

    public sealed class AddItemToEntrust : Packet
    {
        public AddItemToEntrust(LKCamelot.script.item.Item item)
            : base(0x31)
        {
            var invslot = (item.InvSlot - 40);
            while (invslot >= 12)
                invslot -= 12;
            m_Stream.Write((byte)invslot);
            m_Stream.Write((short)item.m_ItemID);
            m_Stream.Write((byte)00);
            m_Stream.Write((short)item.ParsedStats.Count());
            m_Stream.WriteAsciiNull(item.ParsedStats);
        }
    }

    public sealed class DeleteEntrustSlot : Packet
    {
        public DeleteEntrustSlot(byte slot)
            : base(0x32)
        {
            m_Stream.Write(slot);
        }
    }

    public sealed class DeleteItemSlot : Packet
    {
        public DeleteItemSlot(byte slot)
            : base(0x18)
        {
            m_Stream.Write(slot);
        }
    }

    public sealed class CreateSlotMagic2 : Packet
    {
        public CreateSlotMagic2(script.spells.Spell spell)
            : base(0x19)
        {
            m_Stream.Write((byte)spell.Slot);
            m_Stream.Write((byte)spell.mType);
            m_Stream.Write((byte)spell.Level);
            m_Stream.Write((short)spell.SpellLearnedIcon);
            m_Stream.Fill(3);
            m_Stream.Write((byte)1);
            m_Stream.WriteAsciiNull(spell.Name + " :S" + spell.SLevel2.ToString());
        }
    }

    public sealed class DeleteObject : Packet
    {
        public DeleteObject(Serial obj)
            : base(0x1E)
        {
            m_Stream.Write((int)obj);
        }
    }

    public sealed class DeleteSpell : Packet
    {
        public DeleteSpell(int slot)
            : base(0x1A)
        {
            m_Stream.Write((byte)slot);
        }
    }

    public sealed class EquipItem2 : Packet
    {
        public EquipItem2(LKCamelot.script.item.Item item)
            : base(0x15)
        {
            m_Stream.Write((byte)item.EquipSlot);
            m_Stream.WriteAsciiFixed(item.NPrefix() + " " + item.Name, 32);
            m_Stream.Write((byte)0);
            m_Stream.Write((short)item.m_ItemID);
        }
    }

    public sealed class DeleteEquipItem2 : Packet
    {
        public DeleteEquipItem2(LKCamelot.script.item.Item item)
            : base(0x16)
        {
            m_Stream.Write((byte)item.EquipSlot);
        }
    }

    public sealed class PlayMusic : Packet
    {
        public PlayMusic(int track)
            : base(0x38)
        {
            m_Stream.Fill(5);
            m_Stream.Write(track);
        }
    }

    public sealed class GoldChange : Packet
    {
        public GoldChange(ulong amount)
            : base(0x12)
        {
            m_Stream.Write(amount > int.MaxValue ? int.MaxValue : Convert.ToInt32(amount));
        }
    }

    public sealed class XPChange : Packet
    {
        public XPChange(int amount)
            : base(0x13)
        {
            m_Stream.Write(amount);
        }
    }

    public sealed class HitAnimation : Packet
    {
        public HitAnimation(Serial ser, byte color)
            : base(0x23)
        {
            m_Stream.Write((int)ser);
            m_Stream.Write((byte)color); //0xCB max, 0xCC blue
        }
    }

    public sealed class ChangeFace : Packet
    {
        public ChangeFace(Serial ser, short face)
            : base(0x22)
        {
            m_Stream.Write((int)ser);
            m_Stream.Write(face);
        }
    }

    public sealed class SwingAnimationChar : Packet
    {
        public SwingAnimationChar(Serial ser, short face)
            : base(0x21)
        {
            m_Stream.Write((int)ser);
            m_Stream.Write(face);
        }
    }

    public sealed class SwingAnimation : Packet
    {
        public SwingAnimation(Serial ser, short face)
            : base(0x21)
        {
            m_Stream.Write((int)ser);
            m_Stream.Write((short)face);
        }
    }

    public sealed class MoveSpriteWalkChar : Packet
    {
        public MoveSpriteWalkChar(Serial ser, short face, short x, short y)
            : base(0x1f)
        {
            m_Stream.Write((int)ser);
            m_Stream.Write(face);
            m_Stream.Write(x);
            m_Stream.Write(y);
        }
    }

    public sealed class MoveSpriteWalk : Packet
    {
        public MoveSpriteWalk(Serial ser, short face, short x, short y)
            : base(0x1f)
        {
            m_Stream.Write((int)ser);
            m_Stream.Write((short)face);
            m_Stream.Write(x);
            m_Stream.Write(y);
        }
    }

    public sealed class MoveSpriteTele : Packet
    {
        public MoveSpriteTele(Serial ser, short face, short x, short y)
            : base(0x1c)
        {
            m_Stream.Write((int)ser);
            m_Stream.Write((short)face);
            m_Stream.Write(x);
            m_Stream.Write(y);
        }
    }

    public sealed class SetLevelGold : Packet
    {
        public SetLevelGold(Player player)
            : base(0x0F)
        {
            m_Stream.WriteAsciiFixed(player.FullClass, 32);
            m_Stream.Write((byte)player.PromoLevel);
            m_Stream.Write(player.XP);
            m_Stream.Write(player.XPNext);
            m_Stream.Write(player.Gold > int.MaxValue ? int.MaxValue : Convert.ToInt32(player.Gold));
            //  public const byte SetLevelGold = 0x0F; //0x0F 1 32text 1lvl 4exp 4 next 4money
        }
    }

    public sealed class CreateItemGround2 : Packet
    {
        public CreateItemGround2(LKCamelot.script.item.Item item, Serial key)
            : base(0x1D)
        {
            m_Stream.Write((int)key);
            m_Stream.Write((short)1); //facedir
            m_Stream.Write((short)item.Loc.X);
            m_Stream.Write((short)item.Loc.Y);
            m_Stream.Write((byte)2); //10 byte sprite 02 00 00 00 00 00 00 00 00 23 (first 2 last # id
            m_Stream.Fill(8);
            m_Stream.Write((short)item.m_ItemID);
            m_Stream.Write((byte)2);//1byte ukn
            m_Stream.Write((byte)0);//1byte ukn
            m_Stream.Write((byte)0);//1byte ukn
            m_Stream.Write((byte)0);//1byte ukn

            m_Stream.Write((byte)0x0); //1byte ukn
            m_Stream.Write((byte)03); //1byte unclickable, transparency
            m_Stream.Write((byte)0x0); //1byte ukn
            m_Stream.Write((byte)0x2); //1byte ukn

            m_Stream.Write((byte)12);
            m_Stream.Write((byte)12);
            m_Stream.Write((byte)12);
            m_Stream.Write((byte)0);

            m_Stream.Write((byte)01);

            m_Stream.WriteAsciiNull(item.NPrefix() + " " + item.Name);
        }
    }

    public sealed class CreateMonster : Packet
    {
        public CreateMonster(LKCamelot.script.monster.Monster item, Serial key)
            : base(0x1D)
        {
            m_Stream.Write((int)key);
            m_Stream.Write((short)item.Face); //facedir
            m_Stream.Write((short)item.m_Loc.X);
            m_Stream.Write((short)item.m_Loc.Y);
            m_Stream.Write((byte)1); //10 byte sprite 02 00 00 00 00 00 00 00 00 23 (first 2 last # id
            m_Stream.Fill(8);
            m_Stream.Write((short)item.m_MonsterID);
            m_Stream.Write((byte)item.Color);//1byte uk
            m_Stream.Write((byte)0);//1byte uk
            m_Stream.Write((byte)0);//1byte uk
            m_Stream.Write((byte)item.Transp);//transparency

            m_Stream.Write((byte)0); //1byte ukn
            m_Stream.Write((byte)0); //1byte ukn
            m_Stream.Write((byte)0); //1byte ukn
            m_Stream.Write((byte)0); //1byte ukn

            m_Stream.Write((byte)0); //static magic appearance
            m_Stream.Write((byte)0);
            m_Stream.Write((byte)0);
            m_Stream.Write((byte)0);

            m_Stream.Write((byte)0x02);
            m_Stream.WriteAsciiNull(item.Name);
        }
    }

    public sealed class CreateChar : Packet
    {
        public CreateChar(Player play, Serial key)
            : base(0x1D)
        {
            m_Stream.Write((int)key);
            m_Stream.Write(play.Face);
            m_Stream.Write(play.X);
            m_Stream.Write(play.Y);
            m_Stream.Write(play.Appearance, 0, 10);
            m_Stream.Write((byte)0x14);//1byte ukn
            m_Stream.Write((byte)play.Color); // color
            m_Stream.Write((byte)0x18); //thickness
            m_Stream.Write((byte)0);//uk
            m_Stream.Write((byte)play.Transparancy);//1byte transp

            m_Stream.Fill(4); //buffs
            m_Stream.Write((byte)0x0); //uk 
            m_Stream.Write((byte)0x0); //uk
            m_Stream.Write((byte)0x0); //uk
            m_Stream.Write((byte)0x0); //uk

            m_Stream.Write((byte)0x01);
            m_Stream.WriteAsciiNull(play.Name);
        }
    }

    public sealed class UpdateCharStats : Packet
    {
        public UpdateCharStats(Player player)
            : base(0x14)
        {
            m_Stream.Write(Util.checkUShort((uint)player.HPCur));
            m_Stream.Write(Util.checkUShort((uint)player.HP));
            m_Stream.Write(Util.checkUShort((uint)player.MPCur));
            m_Stream.Write(Util.checkUShort((uint)player.MP));
            m_Stream.Write(Util.checkUShort(player.GetStat("str", true)));
            m_Stream.Write(Util.checkUShort(player.GetStat("men", true)));
            m_Stream.Write(Util.checkUShort(player.GetStat("dex", true)));
            m_Stream.Write(Util.checkUShort(player.GetStat("vit", true)));
            m_Stream.Write(Util.checkUShort(player.GetStat("str")));
            m_Stream.Write(Util.checkUShort(player.GetStat("men")));
            m_Stream.Write(Util.checkUShort(player.GetStat("dex")));
            m_Stream.Write(Util.checkUShort(player.GetStat("vit")));
            m_Stream.Write(Util.checkUShort((uint)player.AC));
            m_Stream.Write(Util.checkUShort((uint)player.Hit));
            m_Stream.Write(Util.checkUShort((uint)player.Dam));
            m_Stream.Write(Util.checkUShort(player.Extra));
        }
    }

    public sealed class CreateNPC2 : Packet
    {
        public CreateNPC2(script.npc.BaseNPC npc)
            : base(0x3A)
        {
            m_Stream.Write((int)npc.ID);
            m_Stream.Write((short)1); //facedir
            m_Stream.Write((short)npc.X);
            m_Stream.Write((short)npc.Y);
            m_Stream.Write((byte)0x0A);
            m_Stream.Fill(8);
            m_Stream.Write((byte)npc.Sprite);
            m_Stream.Fill(4);
            m_Stream.Write((byte)npc.aSpeed);
            m_Stream.Fill(1);
            m_Stream.Write((byte)npc.aFrames);
            m_Stream.Fill(1);
        }
    }

    public sealed class UpdateChatBox : Packet
    {
        public UpdateChatBox(byte colortext, byte colortext2, short colorbar, short length, string text)
            : base(0x0D)
        {
            m_Stream.Write(colortext); //01 ff orange ff ff white 
            m_Stream.Write(colortext2);
            m_Stream.Write(colorbar);
            m_Stream.Write(length);
            m_Stream.WriteUTF8Null(text);
        }
    }

    public sealed class SpawnShopGump2 : Packet
    {
        public SpawnShopGump2(script.npc.GUMP shop)
            : base(0x3E)
        {
            m_Stream.Write(shop.ID);
            m_Stream.Write((byte)shop.SellList.Count());
            m_Stream.Write(shop.Titlec);
            m_Stream.Write(shop.Boxc);
            m_Stream.Fill(1);
            m_Stream.Write(shop.Time);
            m_Stream.Write(shop.ItemIDArray, 0, 32);
            m_Stream.WriteAsciiFixed(shop.ShopName, 32);
            m_Stream.Write((short)shop.ItemNameString.Length);
            m_Stream.WriteAsciiNull(shop.ItemNameString);
        }
    }

    //public const byte ChangeObjectSprite = 0x26; //0x26 1 4id 10 sprite 1uk 1color
    public sealed class ChangeObjectSprite : Packet
    {
        public ChangeObjectSprite(int objectid, byte color, byte[] sprite)
            : base(0x26)
        {
            m_Stream.Write((int)objectid);
            m_Stream.Write(sprite, 0, 10);
            m_Stream.Write((byte)0);
            m_Stream.Write((byte)color);
        }
    }

    public sealed class ChangeObjectSpritePlayer : Packet
    {
        public ChangeObjectSpritePlayer(Player play)
            : base(0x26)
        {
            m_Stream.Write(play.Serial);
            m_Stream.Write(play.Appearance, 0, 10);
            m_Stream.Write((byte)0);
            m_Stream.Write((byte)play.Color);
        }
    }

    public sealed class CreateMagicEffect : Packet
    {
        public CreateMagicEffect(int objectid, short facedir, short x, short y, byte[] sprite, byte width)
            : base(0x1D)
        {
            m_Stream.Write((int)objectid);
            m_Stream.Write(facedir);
            m_Stream.Write(x);
            m_Stream.Write(y);
            m_Stream.Write(sprite, 0, sprite.Count());
            m_Stream.Write((byte)0x0);
            m_Stream.Write((byte)0x0);
            m_Stream.Write((byte)width);
            m_Stream.Write((byte)0x0); ;//1byte ukn
            m_Stream.Write((byte)0x0); ;//1byte transp
        }
    }

    public sealed class CloseLogin : Packet
    {
        public CloseLogin()
            : base(0x04)
        {
            m_Stream.Write((byte)0x02);
            m_Stream.Write((byte)0x00);
        }
    }

    public sealed class WrongPass : Packet
    {
        public WrongPass()
            : base(0x05)
        {
            m_Stream.Write((byte)0xff);
            m_Stream.Write((byte)0xff);
        }
    }

    public sealed class WrongID : Packet
    {
        public WrongID()
            : base(0x0A)
        {
            m_Stream.Write((byte)0xff);
            m_Stream.Write((byte)0xff);
        }
    }

    public sealed class AlreadyOnline : Packet
    {
        public AlreadyOnline()
            : base(0x07)
        {
            m_Stream.Write((byte)0xff);
            m_Stream.Write((byte)0xff);
        }
    }

    public sealed class SetHP : Packet
    {
        public SetHP(LKCamelot.model.Player play)
            : base(0x10)
        {
            m_Stream.Write(Util.checkUShort((uint)play.HPCur));
        }
    }

    public sealed class SetMP : Packet
    {
        public SetMP(LKCamelot.model.Player play)
            : base(0x11)
        {
            m_Stream.Write(Util.checkUShort((uint)play.MPCur));
        }
    }

    public sealed class SetObjectEffectsMonster : Packet
    {
        public SetObjectEffectsMonster(script.monster.Monster play)
            : base(0x34)
        {
            //  SetObjectEffects = 0x34; // 0x34 4id 1light 1trans 4byffs 1staticmagic
            m_Stream.Write(play.m_Serial);
            m_Stream.Write((byte)0); //lightrad
            m_Stream.Write((byte)play.Transp); //transp
            m_Stream.Fill(4);
            m_Stream.Write((byte)0); //cast once

            m_Stream.Write((byte)play.FrameType);

            m_Stream.Write((byte)0); // speed
            m_Stream.Write((byte)1);
        }
    }

    public sealed class SetObjectEffectsMonsterSpell : Packet
    {
        public SetObjectEffectsMonsterSpell(script.monster.Monster play, int spell)
            : base(0x34)
        {
            //  SetObjectEffects = 0x34; // 0x34 4id 1light 1trans 4byffs 1staticmagic
            m_Stream.Write(play.m_Serial);
            m_Stream.Write((byte)0); //lightrad
            m_Stream.Write((byte)play.Transp); //transp
            m_Stream.Write((byte)spell);
            m_Stream.Fill(3);
            m_Stream.Write((byte)0); //cast once

            if (play.m_MonsterID >= 200)
                m_Stream.Write((byte)0);
            else
                m_Stream.Write((byte)1); //sprite frame type

            m_Stream.Write((byte)0); // speed
            m_Stream.Write((byte)1);
        }
    }

    public sealed class SetObjectEffectsPlayer : Packet
    {
        public SetObjectEffectsPlayer(Player play)
            : base(0x34)
        {
            //  SetObjectEffects = 0x34; // 0x34 4id 1light 1trans 4byffs 1staticmagic
            m_Stream.Write(play.Serial);
            m_Stream.Write((byte)play.LightRad);
            m_Stream.Write((byte)play.Transparancy);
            m_Stream.Write(play.BuffArray, 0, 4);

            if (play.m_Buffs.Where(xe => xe.Name == "MENTAL SWORD").FirstOrDefault() != null)
                m_Stream.Write((byte)0x63); //move with char
            else
                m_Stream.Write((byte)0); //move with char

            m_Stream.Write((byte)0); //sprite frame type
            m_Stream.Write((byte)0); // speed
            m_Stream.Write((byte)1);
        }
    }

    public sealed class CurveMagic : Packet
    {
        public CurveMagic(int objectID, short X, short Y, LKCamelot.script.spells.SpellSequence spellani)
            : base(0x28)
        {
            m_Stream.Write(objectID);
            m_Stream.Write(X);
            m_Stream.Write(Y);
            m_Stream.Write((byte)0);
            m_Stream.Write((byte)0);
            m_Stream.Write((byte)spellani.OnCastSprite);
            m_Stream.Write((byte)spellani.MovingSprite);
            m_Stream.Write((byte)spellani.OnImpactSprite);
            m_Stream.Fill(7);
            //   for (int i = 0; i < 7; i++) msg.Add(0x12);
            m_Stream.Write((byte)spellani.Thickness);
            m_Stream.Write((byte)spellani.Type);
            m_Stream.Write((byte)spellani.Speed);
            m_Stream.Write((byte)spellani.Streak);
        }
    }

    public sealed class LoadWorld : Packet
    {
        public LoadWorld(Player player, byte time)
            : base(0x1B)
        {
            m_Stream.Write((byte)time);
            m_Stream.Write((int)player.Serial);
            m_Stream.Fill(4);
            m_Stream.Write((short)player.Face);
            m_Stream.Write((short)player.X);
            m_Stream.Write((short)player.Y);
            m_Stream.Write(player.Appearance, 0, 10);
            m_Stream.Write((byte)0);
            m_Stream.Write((byte)player.Color); //color
            m_Stream.Write((byte)0);
            m_Stream.Write((byte)player.LightRad);
            m_Stream.Write((byte)player.Transparancy);
            m_Stream.Write(player.BuffArray, 0, 4);
            m_Stream.Write((byte)0); //spawn buff
            m_Stream.Write((byte)0x52);
            m_Stream.Write((byte)0x53);
            m_Stream.Write((byte)0x54);
            m_Stream.Write((byte)0x55);
            m_Stream.Write((byte)0);
            m_Stream.WriteAsciiNull(player.LoadMap);
        }
    }

    public class Packet
    {
        protected LKCamelot.net.PacketWriter m_Stream;
        private int m_PacketID;
        private int m_Length;

        public List<byte> msg = new List<byte>();
        public Packet()
        {
        }

        public Packet(int packetID)
        {
            m_PacketID = packetID;
            m_Length = 32;

            m_Stream = LKCamelot.net.PacketWriter.CreateInstance();
            m_Stream.Write((byte)packetID);
        }

        public Packet(int packetID, int length)
        {
            m_PacketID = packetID;
            m_Length = length;

            m_Stream = LKCamelot.net.PacketWriter.CreateInstance(length);
            m_Stream.Write((byte)packetID);
        }

        private byte[] m_CompiledBuffer;
        private int m_CompiledLength;

        public byte[] Compile()
        {
            System.IO.MemoryStream ms = m_Stream.UnderlyingStream;

            m_CompiledBuffer = ms.GetBuffer();
            m_CompiledLength = (int)ms.Length;

            int length = m_CompiledLength;
            byte[] old = m_CompiledBuffer;
            m_CompiledBuffer = new byte[length];
            Buffer.BlockCopy(old, 0, m_CompiledBuffer, 0, length);

            LKCamelot.net.PacketWriter.ReleaseInstance(m_Stream);
            m_Stream = null;

            return Encrypt(m_CompiledBuffer);
        }

        public byte[] Format()
        {
            return msg.ToArray<byte>();
        }

        public Byte[] Encrypt(Byte[] data)
        {
            Byte[] ret = new Byte[1024];
            int mLoopItr = 0;
            int loop3 = 0;
            byte var_f, var_e, var_d, var_c = 0, var_b = 0;

            mLoopItr = data.Count() / 3;
            if (data.Count() % 3 != 0)
                mLoopItr++;

            for (int x = 0; x < mLoopItr; x++)
            {
                var_d = data[loop3];
                if (loop3 + 1 < data.Count())
                    try { var_c = data[loop3 + 1]; }
                    catch { var_c = 0; }
                if (loop3 + 2 < data.Count())
                    try { var_b = data[loop3 + 2]; }
                    catch { var_b = 0; }

                ret[x * 4] = Convert.ToByte(var_d >> 2);
                var_e = Convert.ToByte((var_d & 3) << 4);
                var_f = Convert.ToByte(var_c >> 4);
                ret[x * 4 + 1] = Convert.ToByte(var_e | var_f);
                var_e = Convert.ToByte((var_c & 0x0F) << 2);
                var_f = Convert.ToByte(var_b >> 6);
                ret[x * 4 + 2] = Convert.ToByte(var_e | var_f);
                ret[x * 4 + 3] = Convert.ToByte(var_b & 0x3F);

                ret[x * 4] += 0x3B;
                ret[x * 4 + 1] += 0x3B;
                ret[x * 4 + 2] += 0x3B;
                ret[x * 4 + 3] += 0x3B;
                loop3 += 3;
            }
            int size = Array.IndexOf<Byte>(ret, 0);
            ret[size] = 0x2E;
            ret[size + 1] = 0x0A;
            //    ret[size + 2] = 0x00;

            Array.Resize(ref ret, size + 2);
            return ret;
        }
    }
}

/*
17 bonetil.Til,boneobj.Obj  62 6f 6e 65 74 69 6c 2e 54 69 6c 2c 62 6f 6e 65 6f 62 6a 2e 4f 62 6a
13 LkTil.Til,LkObj.Obj  4c 6b 54 69 6c 2e 54 69 6c 2c 4c 6b 4f 62 6a 2e 4f 62 6a
13 pstil.til,psobj.obj  70 73 74 69 6c 2e 74 69 6c 2c 70 73 6f 62 6a 2e 6f 62 6a
0D VV.Til,vv.obj        56 56 2e 54 69 6c 2c 76 76 2e 6f 62 6a   //towerish
17 weaktil.til,weakobj.obj  77 65 61 6b 74 69 6c 2e 74 69 6c 2c 77 65 61 6b 6f 62 6a 2e 6f 62 6a   //greenish
*/