using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace First_Project.Data
{
     public class Resultsheet :Base
    {
        public string Subject { get; set; }
        public int TotalMarks { get; set; }
        public string Grade { get; set; }
        public int? studentInfoId { get; set; }
        public StudentInfo studentInfo { get; set; }
    }
}
