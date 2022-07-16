using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    [Serializable]
    internal class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
