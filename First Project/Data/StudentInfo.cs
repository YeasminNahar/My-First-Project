using System;
using System.Collections.Generic;
using System.Text;

namespace First_Project.Data
{
    public class StudentInfo : Base
    {
        public string Name { get; set; }
        public string Roll { get; set; }
        public string Address { get; set; }
        public int? sectionId { get; set; }
        public Section section { get; set; }
        public int? isActive { get; set; }
        public string url { get; set; }
        public string Gender { get; set; }

    }
}

