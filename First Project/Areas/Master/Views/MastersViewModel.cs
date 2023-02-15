using First_Project.Data;
using First_Project.Data.Master;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace First_Project.Areas.Master.Models
{
    public class MastersViewModel
    {
        #region
        public int countriesId { get; set; }
        public string countryName { get; set; }
        public string countryNameBn { get; set; }
        public IEnumerable<Country> countries { get; set; }
        #endregion

        #region
        public int divisionId { get; set; }
        public int? countryId { get; set; }
        public string divisionName { get; set; }
        public string divisionNameBn { get; set; }
        public IEnumerable<Division> divisions { get; set; }
        #endregion

    }
}
