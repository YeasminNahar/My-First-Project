using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Data.MasterData
{
    public class ClassName : Base
    {
        [Column(TypeName = "NVARCHAR(120)")]
        public string ClassNameEn { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string ClassNameBn { get; set; }
        public int? Order { get; set; }

    }
}
