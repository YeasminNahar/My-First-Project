﻿using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace First_Project.Areas.Student.Models
{
    public class StudentDetailsViewModel
    {
        public int sectionsId { get; set; }
        public int studentId { get; set; }
        public int resultId { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }
        public string Address { get; set; }
        public string NameBN { get; set; }
        public string NameEN { get; set; }
        public string[] Subject { get; set; }
        public int[] TotalMarks { get; set; }
        public string[] Grade { get; set; }
        public int? studentInfoId { get; set; }
        public int? sectionId { get; set; }
        public int?[] childId { get; set; }

        public IEnumerable<Data.Section> sectionsInfo { get; set; }
        public IEnumerable<StudentInfo> studentsInfo { get; set; }
        public StudentInfo studentsInfos { get; set; }
    }
}