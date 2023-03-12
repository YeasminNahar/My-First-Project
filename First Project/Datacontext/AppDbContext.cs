using First_Project.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Datacontext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<StudentInfo> studentsInfo { get; set; }
        public DbSet<Section> sectionsInfo { get; set; }
        public DbSet<Resultsheet> resultsheetsInfo { get; set; }

    }
}






