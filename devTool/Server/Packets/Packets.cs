using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devTool
{
    public sealed class AddItemToInventory2 : Packet
    {
        public AddItemToInventory2()
            : base(0x17)
        {
            m_Stream.Write((byte)01);
            m_Stream.Write((short)02);
            m_Stream.Write((byte)02);
            m_Stream.Write((short)02);
            m_Stream.WriteAsciiNull("hihihi");
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

    public sealed class Generic : Packet
    {
        public Generic(byte[] data)
            : base(0x07)
        {
            m_Stream.Position -= 1;
            m_Stream.Write(data, 0, data.Length);
        }
    }
 
    public sealed class LoadWorld : Packet
    {
        public LoadWorld()
            : base(0x1B)
        {
            m_Stream.Write((byte)1);
            m_Stream.Write((int)5);
            m_Stream.Fill(4);
            m_Stream.Write((short)1);
            m_Stream.Write((short)10);
            m_Stream.Write((short)10);
            m_Stream.Fill(10);
            m_Stream.Write((byte)0);
            m_Stream.Write((byte)0); //color
            m_Stream.Write((byte)0);
            m_Stream.Write((byte)3);
            m_Stream.Write((byte)0);
            m_Stream.Fill(4);
            m_Stream.Write((byte)0); //spawn buff
            m_Stream.Write((byte)0x52);
            m_Stream.Write((byte)0x53);
            m_Stream.Write((byte)0x54);
            m_Stream.Write((byte)0x55);
            m_Stream.Write((byte)0);
            m_Stream.WriteAsciiNull("32.map");
        }
    }

    public class Packet
    {
        protected PacketWriter m_Stream;
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

            m_Stream = PacketWriter.CreateInstance();
            m_Stream.Write((byte)packetID);
        }

        public Packet(int packetID, int length)
        {
            m_PacketID = packetID;
            m_Length = length;

            m_Stream = PacketWriter.CreateInstance(length);
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

            PacketWriter.ReleaseInstance(m_Stream);
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