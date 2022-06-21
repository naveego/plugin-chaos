using System;

namespace PluginChaos.API.Utility
{
    public static partial class Utility
    {
        public static bool GenerateBool()
        //Random True or False return.
        {
            var rnd = new Random();
            var rndBool = rnd.Next(0, 1);
            return rndBool != 0;
        }

        public static byte GenerateByte()
        //Random single byte.
        {
            var rnd = new Random();
            var newByte = rnd.Next(256);
            return (byte)newByte;
        }

        public static int GenerateInt()
        //Random int.
        {
            var rnd = new Random();
            var rndNum = rnd.Next(int.MinValue, int.MaxValue);
            return rndNum;
        }

        public static double GenerateFloat()
        //Random float generated with Random.NextDouble.
        {
            var rnd = new Random();
            var newF = rnd.NextDouble();
            return newF;
        }

        public static char GenerateChar()
        //Random char generated from first 999 ascii chars.
        {
            var rnd = new Random();
            var newChar = (char)rnd.Next(1000);
            return newChar;
        }

        public static string GenerateString()
        //random string of length(25) with chars(a-zA-Z) but including a few symbols.
        {
            var rnd = new Random();
            var newString = "";
            for (int go = 1; go <= 25; go++)
            {
                newString += ((char)rnd.Next(65, 122)).ToString();
            }

            return newString;
        }

        public static DateTime GenerateDateTime()
        {
            return DateTime.Now;
        }

        public static decimal GenerateDecimal()
        {
            return Convert.ToDecimal("0.0");
        }
    }
}