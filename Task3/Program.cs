using System;
using System.IO;

namespace Task3
{
    internal class Program
    {
        const string Path = @"C:\SkillFactory";

        static void Main(string[] args)
        {

            DirectoryInfo dI = new DirectoryInfo(Path);
            DeleteFolder(dI);
        }

        static void DeleteFolder(DirectoryInfo dir)
        {

            long fileSize = 0;
            if(dir.Exists)
            {
                fileSize=dir.DirSize();
                Console.WriteLine($"{dir.Name} Directory size: {fileSize}");
            }
            long deletedFiles =0;
            foreach (FileInfo file in dir.GetFiles())
            {
                if (IsUsed(file))
                {
                    deletedFiles+=file.Length;
                    
                    file.Delete();

                }

            }
            Console.WriteLine($"{dir.Name} was cleaned over {deletedFiles} bayt");
            Console.WriteLine($"{dir.Name} size now is - {fileSize-deletedFiles}");
            if (dir.GetDirectories().Equals(null))
            {
                return;
            }
            foreach (DirectoryInfo directory in dir.GetDirectories())
            {

                if (IsUsed(directory))
                {
                    try
                    {
                        DeleteFolder(dir);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        static bool IsUsed<T>(T data)
        {
            DateTime lastAccess = File.GetLastAccessTime(data.ToString());
            if (DateTime.Now.AddMinutes(-30) <= lastAccess)
            {
                return true;
            }
            return false;
        }
    }
}
}
