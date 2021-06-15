using System;
using System.IO;
namespace hl2demo_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var FilterPath = args[0];
            var OutPutPath = args[1];
            var ToFilter = Directory.GetFiles(FilterPath, "*.dem", SearchOption.TopDirectoryOnly);
            
            foreach(var item in ToFilter) {
                Console.WriteLine(item);
                var Header = File.ReadAllBytes(item).GetDemoHeader();
                Console.WriteLine("New Folder:{0}", Header.GetPath());
                var NewPath = Path.Combine(OutPutPath, Header.GetPath());
                Console.WriteLine(NewPath);
                File.Move(item, NewPath);
                try
                {
                    File.Move(item.Replace(".dem", ".json"), NewPath);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e);
                }

            }

        }
    }
}
