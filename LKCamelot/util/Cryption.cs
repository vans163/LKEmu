using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;
namespace LKCamelot.util
{
    public static class Cryption
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static string CreateSaltedSHA256(string pass, string username)
        {
            byte[] result;
            string salted = username+pass;
            byte[] bytes = new byte[salted.Length * sizeof(char)];
            System.Buffer.BlockCopy(salted.ToCharArray(), 0, bytes, 0, bytes.Length);

            using (SHA256 shaM = new SHA256Managed())
                result = shaM.ComputeHash(bytes);

            string hex = BitConverter.ToString(result);
            hex = hex.Replace("-", "");

            return hex;
        }

        public static bool CheckHashPass(string shapass, string username, string input)
        {
            string salted = username + input;
            byte[] bytes = new byte[salted.Length * sizeof(char)];
            System.Buffer.BlockCopy(salted.ToCharArray(), 0, bytes, 0, bytes.Length);

            using (SHA256 shaM = new SHA256Managed())
            {
                var hashed = BitConverter.ToString(shaM.ComputeHash(bytes)).Replace("-", "");
                if (hashed == shapass)
                    return true;
            }
            return false;
        }

        public static Byte[] Encrypt(Byte[] data)
        {
            Byte[] ret = new Byte[2048];
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
