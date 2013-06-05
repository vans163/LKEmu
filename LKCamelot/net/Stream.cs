using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.net
{
    public class Stream
    {
        public byte[] Data = new byte[1024];
        public int Length;
        public int Position;
        public Queue<byte[]> packets = new Queue<byte[]>();

        public bool IsPacketAvailable()
        {
            if (packets.Count > 0)
                return true;
            else
                return false;
        }

        public byte[] PopPacket()
        {
            return Decrypt(packets.Dequeue());
        }

        public void Flush()
        {
            Array.Clear(Data, 0, Data.Count());
            Length = 0;
            Position = 0;
            packets.Clear();
        }

        public void AppendData(byte[] data)
        {
            if (data.Length > 1)
            {
                int newSize = (data.Length);
                Array.Resize(ref Data, newSize);
            }
            Array.Copy(data, 0, Data, 0, data.Length);
            Length += data.Length;
            LoadPackets();
        }

        private void LoadPackets()
        {
            int skip = 0;
            while (Position != Length)
            {
                if (Data[Position] == 0x0A)
                    if (Data[Position - 1] == 0x2E)
                    {
                        var packet = Data.Skip(skip).Take(Position + 1).ToArray();
                        packets.Enqueue(packet);
                        skip = Position + 1;
                    }
                Position++;
            }
        }

        public static Byte[] Decrypt(Byte[] data)
        {
            Byte[] ret = new Byte[512];
            List<Byte> temp = new List<Byte>();
            //   int TrimIndex = Array.IndexOf<Byte>(data, 0x2E);

            //     if (TrimIndex + 2 < data.Count())
            //          throw new Exception("Found 0x2E byte not at end of packet");

            //       data = data.Take(TrimIndex+1).ToArray();

            int mLoopItr = 0;
            int loop3 = 0;
            byte var_f, var_e, var_d, var_c, var_b, var_a;


            mLoopItr = (data.Count() - 1) >> 2;
            for (int x = 0; x < (data.Count() - 1); x++)
            {
                if (data[x] == 0x2E)
                    break;
                data[x] -= 0x3B;
            }


            for (int x = 0; x < mLoopItr; x++)
            {
                var_d = data[loop3];
                try { var_c = data[loop3 + 1]; }
                catch { var_c = 0; }
                try { var_b = data[loop3 + 2]; }
                catch { var_b = 0; }
                try { var_a = data[loop3 + 3]; }
                catch { var_a = 0; }

                var_e = Convert.ToByte((var_d << 2) & 0xFF);
                var_f = Convert.ToByte(var_c >> 4);
                // ret[x * 3] = Convert.ToByte(var_e | var_f);
                temp.Add(Convert.ToByte(var_e | var_f));
                var_e = Convert.ToByte((var_c << 4) & 0xFF);
                var_f = Convert.ToByte(var_b >> 2);
                //    ret[x * 3 + 1] = Convert.ToByte(var_e | var_f);
                temp.Add(Convert.ToByte(var_e | var_f));
                var_e = Convert.ToByte((var_b << 6) & 0xFF);
                var_f = var_a;
                //  ret[x * 3 + 2] = Convert.ToByte(var_e | var_f);
                temp.Add(Convert.ToByte(var_e | var_f));

                loop3 += 4;
            }
            //     int size = Array.IndexOf<Byte>(ret, 0);
            //   ret[size] = 0x00;
            //    Array.Resize(ref ret, size); //Last DWORD byte

            var i = temp.Count - 1;
            while (temp[i] == 0)
            {
                if (temp[0] == 0 && temp[1] == 0)
                {
                    i = 1; break;
                }
                i--;
            }
            temp = temp.Take(i + 2).ToList<Byte>();

            return temp.ToArray<Byte>();
        }
    }
}
