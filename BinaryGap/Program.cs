using System;
using System.Linq;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while (Console.ReadLine() != null)
            {
                Console.WriteLine("please input a positive integer,then press the Enter key.");
                string strReadValue = Console.ReadLine();
                int iValue = -1;
                int.TryParse(strReadValue, out iValue);
                if (iValue < 0)
                {
                    Console.WriteLine("wrong input");
                }
                else
                {
                    string strBinaryValue = Convert.ToString(iValue, 2);
                    Console.WriteLine(string.Format("Binary Value is:{0}", strBinaryValue));
                    Console.WriteLine(string.Format("Binary Gap is:{0}", GetBinaryGap(strBinaryValue)));
                    Console.WriteLine(string.Format("Binary Gap is:{0}", solution(iValue)));
                    Console.WriteLine("please press the Enter key to continue.");
                }
            }
        }

        static int GetBinaryGap(string binaryString)
        {
            for (int i = binaryString.Length - 1; i >= 0; i--)
            {
                if (binaryString[i] == '0')
                {
                    binaryString = binaryString.Remove(i, 1);
                }
                else
                    break;
            }
            for (int i = binaryString.Length - 1; i > 0; i--)
            {
                if (binaryString[i] == '1')
                {
                    if (binaryString[i] == binaryString[i - 1])
                    {
                        binaryString = binaryString.Remove(i, 1);
                    }
                }
            }
            string[] zeroArray = binaryString.Split('1');
            return zeroArray.Max<string>().Count();
        }

        public static int solution(int N)
        {
            string binaryString = Convert.ToString(N, 2);
            for (int i = binaryString.Length - 1; i >= 0; i--)
            {
                if (binaryString[i] == '0')
                {
                    binaryString = binaryString.Remove(i, 1);
                }
                else
                    break;
            }
            for (int i = binaryString.Length - 1; i > 0; i--)
            {
                if (binaryString[i] == '1')
                {
                    if (binaryString[i] == binaryString[i - 1])
                    {
                        binaryString = binaryString.Remove(i, 1);
                    }
                }
            }
            string[] zeroArray = binaryString.Split('1');
            return zeroArray.Max<string>().Count();
        }
    }
}
