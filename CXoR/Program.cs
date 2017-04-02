using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXoR
{
    class Program
    {
        static void Main(string[] args)
        {
      
            var myVal = "InhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhaltInhalt";
            var Key = "MyKey";

            var mval = Encoding.UTF8.GetBytes(myVal);
            var mkey = ScrambleKey(Key, mval.Length);

            int[] erg = new int[mval.Length];

            for (int i = 0; i < mval.Length; i++)
            {//
                erg[i] = mval[i] ^ mkey[i];
            }

            var decoded1 = Encoding.UTF8.GetString(erg.Select(m => (byte)m).ToArray());

            for (int i = 0; i < mval.Length; i++)
            {
                erg[i] ^= mkey[i];
            }

            var decoded = Encoding.UTF8.GetString(erg.Select(m => (byte)m).ToArray());

            Debugger.Break();
        }

        private static byte[] ScrambleKey(string input, int length)
        {
            var bt = Encoding.UTF8.GetBytes(input);
            var bt1 = bt.Reverse().ToArray();
            var erg = new byte[bt.Length * 2];
            while (bt.Length < length)
            {
                int i2 = 0;
                for (int i = 0; i < bt.Length; i++)
                {
                    erg[i2] = bt[i];
                    i2++;
                    erg[i2] = bt1[i];
                    i2++;
                }
                bt = erg;
                if (bt.Length >= length) continue;
                bt1 = bt.Reverse().ToArray();
                erg = new byte[bt.Length * 2];
            }

            return bt;
        }
    }
}
