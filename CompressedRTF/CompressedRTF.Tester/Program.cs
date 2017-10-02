using System;
using System.Linq;

namespace CompressedRTF.Tester
{
    class Program
    {

        static void Main(string[] args)
        {
            TestCompress();
            TestCompressionRepeatedTokens();
            TestCrc32();
        }

       public static void TestCompressionRepeatedTokens()
        {
            var data = "7b5c72746631205758595a5758595a5758595a5758595a5758595a7d";
            var result = BitConverter.ToString(new CompressedRTF().Compress(StrToByteArray(data))).Replace("-","").ToLower();
            var expectedResult = "1a0000001c0000004c5a4675e2d44b51410004205758595a0d6e7d010eb0";

            Console.WriteLine($"         Result: {result}");
            Console.WriteLine($"Expected Result: {expectedResult}");

            var testResult = result == expectedResult ? "PASSED" : "FAILED";
            Console.WriteLine($"TestCompressionRepeatedTokens: {testResult}");
        }

        public static void TestCompress()
        {
            var data = "7b5c727466315c616e73695c616e7369637067313235325c706172642068656c6c6f20776f726c647d0d0a";
            var result = BitConverter.ToString(new CompressedRTF().Compress(StrToByteArray(data))).Replace("-", "").ToLower();
            var expectedResult = "2d0000002b0000004c5a4675f1c5c7a703000a007263706731323542320af32068656c090020627705b06c647d0a800fa0";
            
            Console.WriteLine($"         Result: {result}");
            Console.WriteLine($"Expected Result: {expectedResult}");

            var testResult = result == expectedResult ? "PASSED" : "FAILED";
            Console.WriteLine($"TestCompress: {testResult}");
        }

        public static void TestCrc32()
        {
            var data = @"03000a007263706731323542320af32068656c090020627705b06c647d0a800fa0";
            uint result = (Crc32.CalculateCrc32(StrToByteArray(data)));
            uint expectedResult = (uint)0xa7c7c5f1; ///REsult from the library 

            Console.WriteLine($"         Result: {result}");
            Console.WriteLine($"Expected Result: {expectedResult}");

            var testResult = result == expectedResult ? "PASSED" : "FAILED";
            Console.WriteLine($"TestCrc32: {testResult}");
        }

        public static byte[] StrToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }


    }
}

