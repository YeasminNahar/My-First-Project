using First_Project.Data;
using First_Project.Data.Master;
using First_Project.Data.MasterData;
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
        public DbSet<Country> countries { get; set; }
        public DbSet<Division> divisions { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<Thana> thanas { get; set; }
        public DbSet<Occupation> occupations { get; set; }
        public DbSet<Religion> religions { get; set; }
        public DbSet<ClassName> classNames { get; set; }
        public DbSet<BookName> bookNames { get; set; }
    }
}






