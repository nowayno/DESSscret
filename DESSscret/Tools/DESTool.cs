using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESSscret.Tools
{
    class DESTool
    {
        static DESTool Instance;

        public DESTool()
        {

        }
        /// <summary>
        /// 获得DESTools实例
        /// </summary>
        /// <returns></returns>
        static public DESTool getInstace()
        {
            if (Instance == null)
                Instance = new DESTool();
            return Instance;
        }

        public byte[] Xor(byte[] one, byte[] two)
        {
            byte[] result = new byte[Math.Max(one.Length, two.Length)];
            int min = Math.Min(one.Length, two.Length);
            for (int index = result.Length; index > 0; index--)
            {
                if (index <= min)
                    result[index - 1] = (byte)(one[index - 1] ^ two[index - 1]);
                else
                    result[index - 1] = 1;
            }
            return result;
        }
    }
}
