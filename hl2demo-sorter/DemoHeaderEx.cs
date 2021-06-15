using System;
using System.Linq;

namespace hl2demo_sorter
{

    public static class DemoHeaderEx
    {

        public static int GetLittleEndianIntegerFromByteArray(byte[] data)
        {
            int length = data.Length;
            int result = 0;

            for (int i = length - 1; i >= 0; i--)
            {
                result |= data[i] << i * 8;
            }
            return result;
        }

        public static int ReadInt(this byte[] File, ref int Pointer) {
            var output = GetLittleEndianIntegerFromByteArray(File.Skip(Pointer).Take(4).ToArray());
            Pointer = Pointer + 4;
            return output;
        }
        public static float ReadFloat(this byte[] File, ref int Pointer) {
            return (float)File.ReadInt(ref Pointer);
        }
        public static string ReadString(this byte[] File,ref int Pointer) {
            var output = System.Text.ASCIIEncoding.ASCII.GetString(File, Pointer, 260);
            Pointer = Pointer + 260;
            return output;
        }
        public static bool ReadHeader(this byte[] File,ref int Pointer) {
            Console.WriteLine("Header0:{0}", System.Text.ASCIIEncoding.ASCII.GetString(File, Pointer, 7));
            Console.WriteLine("Header1:{0}", System.Text.ASCIIEncoding.ASCII.GetString(File, Pointer, 8));
            var output = System.Text.ASCIIEncoding.ASCII.GetString(File, Pointer, 7) == "HL2DEMO";
            Pointer = Pointer + 8;
            return output;
        }
        public static DemoHeader GetDemoHeader(this byte[] File) {
            return new DemoHeader(File);
        }
        public static string GetPath(this DemoHeader demo) {
            return $@"{demo.ClientName}/{demo.ServerName}/{demo.MapName}/".Replace('.', '_').Replace(':', '_').Replace(' ', '_');
        }
    }

}