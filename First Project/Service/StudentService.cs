using First_Project.Areas.Student.Models;
using First_Project.Data;
using First_Project.Datacontext;
using First_Project.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Service
{

    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveStudent(StudentInfo student)
        {
            if (student.Id != 0)
                _context.studentsInfo.Update(student);
            else
                _context.studentsInfo.Add(student);

            await _context.SaveChangesAsync();
            return student.Id;
        }

        public async Task<IEnumerable<StudentInfo>> GetStudent()
        {
            return await _context.studentsInfo.Include(x => x.section).AsNoTracking().ToListAsync();
        }
        public async Task<StudentInfo> GetStudentDetails(int id)
        {
            var data = await _context.studentsInfo.Include(x => x.section).Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            return data;
        }
      
      


        public async Task<int> SaveSection(Section section)
        {
            if (section.Id != 0)
                _context.sectionsInfo.Update(section);
            else
                _context.sectionsInfo.Add(section);

            await _context.SaveChangesAsync();
            return section.Id;
        }

        public async Task<IEnumerable<Section>> GetSection()
        {
            return await _context.sectionsInfo.AsNoTracking().ToListAsync();
        }
        public async Task<int> SaveResult(Resultsheet result)
        {
            if (result.Id != 0)
                _context.resultsheetsInfo.Update(result);
            else
                _context.resultsheetsInfo.Add(result);

            await _context.SaveChangesAsync();
            return result.Id;
        }

        public async Task<IEnumerable<Resultsheet>> GetResultSheet(int id)
        {
            var data = await _context.resultsheetsInfo.Include(x => x.studentInfo).Where(x => x.studentInfoId == id).AsNoTracking().ToListAsync();
            return data;
        }
        //public async Task<bool> DeletestudentsInfoById(int Id)
        //{
        //    try
        //    {
        //        _context.studentsInfo.Remove(_context.studentsInfo.Find(Id));
        //        return 1 == await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        }
    }





