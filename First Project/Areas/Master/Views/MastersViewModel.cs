using First_Project.Data;
using First_Project.Data.Master;
using First_Project.Data.MasterData;
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
        #region Country
        public int countryId { get; set; }
        public string countryName { get; set; }
        public string countryNameBn { get; set; }
        public IEnumerable<Country> countries { get; set; }
        #endregion

        #region Division
        public int countriesId { get; set; }
        public int divisionId { get; set; }
        public string divisionName { get; set; }
        public string divisionNameBn { get; set; }
        public IEnumerable<Division> divisions { get; set; }
        #endregion
        #region District
        public int districtId { get; set; }
        
        public string districtName { get; set; }
        public string districtNameBn { get; set; }
        public IEnumerable<District> districts { get; set; }
        #endregion
        
        #region BookName
        public string BookNameEn { get; set; }
        public string BookNameBn { get; set; }
        public string url { get; set; }
        public IEnumerable<BookName> bookNames { get; set; }
        public IEnumerable<ClassInfo> classInfos { get; set; }
        #endregion

    }
}
