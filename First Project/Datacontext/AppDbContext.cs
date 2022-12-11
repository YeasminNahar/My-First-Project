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
        public DbSet<StudentInfo> studentInfos { get; set; }
        public DbSet<Section> sections { get; set; }
        public DbSet<Resultsheet> resultsheets { get; set; }
        public DbSet<ClassInfo> classInfos { get; set; }
        public DbSet<Gender> genders { get; set; }

    }
}






