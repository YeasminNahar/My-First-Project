using First_Project.Data.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Service.Interface
{
    public interface IMasterService
    {
        #region
        Task<int> SaveCountry(Country country);
        Task<IEnumerable<Country>> GetCountry();
        #endregion

        #region
        Task<int> SaveDivision(Division division);
        Task<IEnumerable<Division>> GetDivision();
        #endregion

    }
}
