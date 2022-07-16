using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task3
{
    static class FileSizeExtenssion
    {
        public static long DirSize(this DirectoryInfo dir)
        {
            long size = 0;

            foreach (FileInfo file in dir.GetFiles())
            {
                size+=file.Length;
            }

            foreach (DirectoryInfo directory in dir.GetDirectories())
            {
                size += DirSize(directory);
            }

            return size;
        }
    }
}
