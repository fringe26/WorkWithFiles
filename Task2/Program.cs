using System;
using System.IO;

namespace Task2
{
    internal class Program
    {
        const string Path = @"C:\SkillFactory";

        static void Main(string[] args)
        {

            DirectoryInfo dI = new DirectoryInfo(Path);
            try
            {
                Console.WriteLine(DirSize(dI));
            }
            catch
            {
                throw new AccessViolationException();
            }
            
        }

        static long DirSize(DirectoryInfo dir)
        {
            long size = 0;

            foreach (FileInfo fi in dir.GetFiles())
            {
                size += fi.Length;
            }

            foreach(DirectoryInfo directoryInfo in dir.GetDirectories())
            {
                size += DirSize(directoryInfo);
            }
            return size;
        }
    }
}
