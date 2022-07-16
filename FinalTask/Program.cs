using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        const string Group150 = @"Studentss\Group150.txt";
        const string Group151 = @"Studentss\Group151.txt";
        const string Group152 = @"Studentss\Group152.txt";
        const string Group153 = @"Studentss\Group153.txt";
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"\Studentss");
            File.Create(Group150);
            File.Create(Group151);
            File.Create(Group152);
            File.Create(Group153);


            CreateFolder(dirInfo);
            string path = @"Students.dat";
            BinaryFileReader(path);

        }

        static void CreateFolder(DirectoryInfo directory)
        {
            if (!directory.Exists)
            {
                directory.Create();
            }

        }

        static void BinaryFileReader(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var student = formatter.Deserialize(fs) as Student[];
                Console.WriteLine("Объект десериализован");
                foreach (Student stu in student)
                {
                    if (stu.Group.Equals("G - 150"))
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(Group150, FileMode.Append)))
                        {
                            writer.Write($"Имя {stu.Name} дата рождения {stu.DateOfBirth} {Environment.NewLine}");
                        }
                    }
                    else if (stu.Group.Equals("G-151"))
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(Group151, FileMode.Append)))
                        {
                            writer.Write($"Имя {stu.Name} дата рождения {stu.DateOfBirth} {Environment.NewLine}");
                        }
                    }
                    else if (stu.Group.Equals("G-152"))
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(Group152, FileMode.Append)))
                        {
                            writer.Write($"Имя {stu.Name} дата рождения {stu.DateOfBirth} {Environment.NewLine}");
                        }
                    }
                    else if (stu.Group.Equals("G - 153"))
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(Group153, FileMode.Append)))
                        {
                            writer.Write($"Имя {stu.Name} дата рождения {stu.DateOfBirth} {Environment.NewLine}");
                        }
                    }

                }

            }

            
        }


    }
}
