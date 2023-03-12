using First_Project.Data.Master;
using First_Project.Datacontext;
using First_Project.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Service
{
    public class MasterService : IMasterService
    {
        private readonly AppDbContext _context;

        public MasterService(AppDbContext context)
        {
            _context = context;
        }

        #region
        public async Task<int> SaveCountry(Country country)
        {
            if (country.Id != 0)
                _context.countries.Update(country);
            else
                _context.countries.Add(country);

            await _context.SaveChangesAsync();
            return country.Id;
        }
        public async Task<IEnumerable<Country>> GetCountry()
        {
            return await _context.countries.AsNoTracking().ToListAsync();
        }
        #endregion


        #region
        public async Task<int> SaveDivision(Division division)
        {
            if (division.Id != 0)
                _context.divisions.Update(division);
            else
                _context.divisions.Add(division);

            await _context.SaveChangesAsync();
            return division.Id;
        }
        public async Task<IEnumerable<Division>> GetDivision()
        {
            return await _context.divisions.Include(x=>x.country).AsNoTracking().ToListAsync();
        }
        #endregion
        #region
        public async Task<int> SaveDistrict(District district)
        {
            if (district.Id != 0)
                _context.districts.Update(district);
            else
                _context.districts.Add(district);

            await _context.SaveChangesAsync();
            return district.Id;
        }
        public async Task<IEnumerable<District>> GetDistrict()
        {
            return await _context.districts.Include(x => x.division).AsNoTracking().ToListAsync();
        }
        #endregion

    }
}
