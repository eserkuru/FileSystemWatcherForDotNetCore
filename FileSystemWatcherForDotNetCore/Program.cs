using System;
using System.IO;

namespace FileSystemWatcherForDotNetCore
{
    class Program
    {
        static void Main()
        {
            string path = @"D:\FSW";
            MonitorDirectory(path);
            Console.ReadKey();
        }

        private static void MonitorDirectory(string path)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher {Path = path};
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            var sw = new StreamWriter(@"D:\FileWatcherLog.txt", true);
            sw.WriteLine("{0} {1} file was created.", DateTime.Now, e.Name);
            sw.Close();
        }

    }
}
