using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24FileSystemWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher w = new FileSystemWatcher();
            w.Path = "c:\\";
            w.Filter = "*.*";
            w.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.LastAccess;
            w.Renamed += W_Renamed;
            w.Deleted += W_Deleted;
            w.Created += W_Created;
            w.EnableRaisingEvents = true;

            Console.WriteLine("Start watching....");
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void W_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.FullPath + " 생성됨");
        }

        private static void W_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.FullPath + " 삭제됨");
        }

        private static void W_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine(e.OldName + " => " + e.Name + "로이름 변경됨");
        }
    }
}
