﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask
{
    [Serializable]
    internal class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
