/// 作者:杨枫/crazYoung(nowayno)
/// 完成时间:
/// 说明:其中很多string数组，都是默认为保存的二进制数据
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

        /// <summary>
        /// 异或运算
        /// </summary>
        /// <param name="one">第一个二进制字符串数组</param>
        /// <param name="two">第二个二进制字符串数组</param>
        /// <returns>异或结果二进制</returns>
        private string[] Xor(string[] one, string[] two)
        {
            string[] result = new string[Math.Max(one.Length, two.Length)];
            int min = Math.Min(one.Length, two.Length);
            for (int index = result.Length; index > 0; index--)
            {
                if (index <= min)
                    result[index - 1] = (Convert.ToInt32(one[index - 1]) ^ Convert.ToInt32(two[index - 1])).ToString().Trim();//异或运算
                else
                    result[index - 1] = "1";
            }
            return result;//结果被视作二进制表示
        }

        /// <summary>
        /// 长度是否大于64或者是否为64的倍数
        /// </summary>
        /// <param name="beforString">传入的二进制字符串</param>
        /// <returns>转化成64位的二进制字符串</returns>
        private string LengthAnd64(string beforString)
        {
            string afterString = "";
            int stringLength = afterString.Length;
            //转化前字符串长度是否大于64位并且不是64的倍数
            //为true就在字符串后面加入‘0’,直到是64的倍数
            //为flase就在字符串后面加入‘0’，知道是64位
            afterString = (beforString.Length > 64) && (beforString.Length % 64 != 0) ? beforString.PadRight(64 - stringLength % 64 + stringLength, '0') : beforString.PadRight(64, '0');
            return afterString;
        }

        /// <summary>
        /// 拆分字符串
        /// </summary>
        /// <param name="beforString">要拆分字符串</param>
        /// <returns>拆分后的数组</returns>
        private List<string[]> Split(string beforString)
        {
            List<string[]> afterString = new List<string[]>();
            string foreString = beforString.Substring(0, beforString.Length / 2);
            string[] tempFString = new string[foreString.Length];
            string[] tempBString = new string[foreString.Length];
            string backString = beforString.Substring(0, beforString.Length / 2);
            //将拆分的两组字符串分别再拆分为一个字符，以便于后面的移位
            for (int index = 0; index < foreString.Length; index++)
            {
                tempFString[index] = foreString.Substring(index, 1);
                tempBString[index] = foreString.Substring(index, 1);
            }
            //将最终拆分的字符串放到List中，方便后面对左右组移位
            afterString.Add(tempFString);
            afterString.Add(tempBString);
            return afterString;
        }

        /// <summary>
        /// 字符串数组移位操作
        /// </summary>
        /// <param name="beforString">要操作的字符串</param>
        /// <param name="which">移位表</param>
        /// <returns>已移位的字符串</returns>
        private string[] Move(string[] beforString, int which)
        {
            //确定移位表
            int[] temp = { };
            switch (which)
            {
                case 0:
                    temp = new int[Key.PC_1.Length];
                    temp = Key.PC_1;
                    break;
                case 1:
                    temp = new int[Key.PC_2.Length];
                    temp = Key.PC_2;
                    break;
                case 2:
                    temp = new int[Key.LeftShift.Length];
                    temp = Key.LeftShift;
                    break;
                case 3:
                    temp = new int[Key.IP.Length];
                    temp = Key.IP;
                    break;
                case 4:
                    temp = new int[Key.E.Length];
                    temp = Key.E;
                    break;
                case 5:
                    temp = new int[Key.P.Length];
                    temp = Key.P;
                    break;
                case 6:
                    temp = new int[Key.IP_1.Length];
                    temp = Key.IP_1;
                    break;
            }
            //临时保存移位后的字符串
            string tempSave = "";
            for (int index = 0; index < temp.Length; index++)
            {
                tempSave += beforString[1];
            }
            //拆分临时字符串，保存到新的字符串数组中
            string[] afterString = new string[tempSave.Length];
            for (int index = 0; index < tempSave.Length; index++)
            {
                afterString[index] = tempSave.Substring(index, 1);
            }
            return afterString;
        }

        /// <summary>
        /// 选择S表中的数据
        /// </summary>
        /// <param name="beforString">要操作的字符串数组</param>
        /// <returns>改变后的字符串数组</returns>
        private string[] SelectRowCol(string[] beforString)
        {
            string tempSave = "";
            for (int which = 0; which < 8; which++)
            {
                int[,] temp = Key.S[which];
                for (int index = 0; index < 48; index += 6)
                {
                    int row = Convert.ToInt32(beforString[index]) + Convert.ToInt32(beforString[index + 5]);
                    int col = Convert.ToInt32(beforString[index + 1]) + Convert.ToInt32(beforString[index + 2]) + Convert.ToInt32(beforString[index + 3]) + Convert.ToInt32(beforString[index + 4]);
                    tempSave += Convert.ToString(temp[row, col], 2).PadLeft(4, '0');
                }
            }

            string[] afterString = new string[tempSave.Length];
            for (int index = 0; index < tempSave.Length; index++)
            {
                afterString[index] = tempSave.Substring(index, 1);
            }
            return afterString;
        }

        /// <summary>
        /// F方法
        /// </summary>
        /// <param name="R">明文二进制有半部分</param>
        /// <param name="K">PC_2改变后的K</param>
        /// <returns></returns>
        private string[] F(string[] R, string[] K)
        {
            string one = Convert.ToString(Move(R, 4));
            for (int index = 0; index < one.Length; index++)
                R[index] = one.Substring(index, 1);
            string[] sbi = Xor(R, K);
            sbi = SelectRowCol(sbi);
            string[] p = Move(sbi, 5);
            return p;
        }

        /// <summary>
        /// 字符串转换成二进制字符串
        /// </summary>
        /// <param name="beforString">要转二进制的字符串</param>
        /// <returns>二进制字符串</returns>
        private string StringToB(string beforString)
        {
            string result = "";
            byte[] tempByte = Encoding.Default.GetBytes(beforString);
            //将byte数组转成二进制字符串，每个byte值转换成8位二进制，不足8位在前面补0
            for (int index = 0; index < tempByte.Length; index++)
                result += Convert.ToString(tempByte[index], 2).PadLeft(8, '0');
            return result;
        }
        /// <summary>
        /// 二进制字符串转换为原文字符串
        /// </summary>
        /// <param name="beforString">要转换的二进制字符串</param>
        /// <returns>原文字符串</returns>
        private string BToString(string[] beforString)
        {
            string result = "";
            byte[] tempByte = new byte[beforString.Length / 8];
            for (int index = 0; index < beforString.Length; index += 8)
            {
                tempByte[index] = Convert.ToByte(beforString[index] + beforString[index + 1] + beforString[index + 2] + beforString[index + 3] + beforString[index + 4] + beforString[index + 5] + beforString[index + 6] + beforString[index + 7], 2);
            }
            result = Encoding.Default.GetString(tempByte);
            return result;
        }

        /// <summary>
        /// 加密解密算法过程
        /// </summary>
        /// <param name="text">需要操作的文本</param>
        /// <param name="secretkey">密钥</param>
        /// <param name="which">选择解密还是加密，默认是加密</param>
        /// <returns>密文/明文</returns>
        private string DEStool(string text, string secretkey, int which = 0)
        {
            string result = "";
            text = LengthAnd64(StringToB(text));
            secretkey = LengthAnd64(StringToB(secretkey));
            List<string[]> textList = Split(text);
            if (which == 0)
            {

            }
            else
            {

            }

            return result;
        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="text">明文</param>
        /// <param name="secretkey">密钥</param>
        /// <returns>密文</returns>
        public string DESencrypt(string text, string secretkey)
        {
            return DEStool(text, secretkey, 0);
        }
        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="text">密文</param>
        /// <param name="secretkey">密钥</param>
        /// <returns>明文</returns>
        public string DESdecrypt(string text, string secretkey)
        {
            return DEStool(text, secretkey, 1);
        }
    }
}
