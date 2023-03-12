using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Data.MasterData
{
    public class BookName : Base
    {
        public int? classId { get; set; }
        public ClassName className { get; set; }

        [Column(TypeName = "NVARCHAR(120)")]
        public string BookNameEn { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string BookNameBn { get; set; }
        public string url { get; set; }
        public int? Order { get; set; }


    }
}
