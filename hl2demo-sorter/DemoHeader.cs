using System;


namespace hl2demo_sorter
{

    public struct DemoHeader
    {
        public int DemoProtocol;
        public int NetworkProtocol;
        
        public string ServerName;
        public string ClientName;
        public string MapName;

        public float PlaybackTime;
        public int Ticks;
        public int Frames;
        public int SignOnLength;

        public DemoHeader(byte[] File) {

            int Pointer = 0;
            Console.WriteLine(File.ReadHeader(ref Pointer));
            DemoProtocol = File.ReadInt(ref Pointer);
            Console.WriteLine("DemoProtocol:{0}", DemoProtocol);
            NetworkProtocol = File.ReadInt(ref Pointer);
            Console.WriteLine("NetworkProtocol:{0}", NetworkProtocol);
            ServerName = File.ReadString(ref Pointer);
            Console.WriteLine("ServerName:{0}", ServerName);
            ClientName = File.ReadString(ref Pointer);
            Console.WriteLine("ClientName:{0}", ClientName);
            MapName = File.ReadString(ref Pointer);
            Console.WriteLine("MapName:{0}", MapName);
            PlaybackTime = File.ReadFloat(ref Pointer);
            Console.WriteLine("PlaybackTime:{0}", PlaybackTime);
            Ticks = File.ReadInt(ref Pointer);
            Console.WriteLine("Ticks:{0}", Ticks);
            Frames = File.ReadInt(ref Pointer);
            Console.WriteLine("Frames:{0}", Frames);
            SignOnLength = File.ReadInt(ref Pointer);
            Console.WriteLine("SignOnLength:{0}", SignOnLength);
        }
    }

}