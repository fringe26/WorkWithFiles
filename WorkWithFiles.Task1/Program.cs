using System;
using System.IO;

namespace WorkWithFiles.Task1
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
            foreach(FileInfo file in dir.GetFiles())
            {
                if (IsUsed(file))
                {
                    file.Delete();
                }
               
            }

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
