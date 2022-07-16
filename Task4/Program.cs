using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"\Studentss");
            CreateFolder(dirInfo);
            string path = @"\Studentss\Students.dat";
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
                var student = (Student)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {student.Name} --- Возраст: {student.DateOfBirth}");
            }
            Console.ReadLine();
        }
    }
}
