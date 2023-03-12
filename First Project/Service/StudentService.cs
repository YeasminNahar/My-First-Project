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
                _context.studentInfos.Update(student);
            else
                _context.studentInfos.Add(student);

            await _context.SaveChangesAsync();
            return student.Id;
        }
        public async Task<IEnumerable<StudentInfo>> GetStudent()
        {
            return await _context.studentInfos.Include(x => x.classInfo).Include(x => x.section).Include(x => x.gender).AsNoTracking().ToListAsync();
        }
        public async Task<StudentInfo> GetStudentInfobyId(int id)
        {
            return await _context.studentInfos.Include(x => x.section).Where(x=>x.Id==id).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<StudentInfo> GetStudentDetails(int id)
        {
            var data = await _context.studentInfos.Include(x => x.section).Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            return data;
        }
     
       public async Task<int> SaveSection(Section section)
        {
            if (section.Id != 0)
                _context.sections.Update(section);
            else
                _context.sections.Add(section);

            await _context.SaveChangesAsync();
            return section.Id;
        }

        public async Task<IEnumerable<Section>> GetSection()
        {
            return await _context.sections.AsNoTracking().ToListAsync();
        }
        public async Task<int> SaveResult(Resultsheet result)
        {
            if (result.Id != 0)
                _context.resultsheets.Update(result);
            else
                _context.resultsheets.Add(result);
            
            await _context.SaveChangesAsync();
            return result.Id;
        }

        public async Task<IEnumerable<Resultsheet>> GetResultSheet(int id)
        {
            var data = await _context.resultsheets.Include(x => x.studentInfo).Where(x => x.studentInfoId == id).AsNoTracking().ToListAsync();
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

        public async Task<int> UpdateStudentActiveStatus(int id, int status)
        {
            try
            {
                var student = _context.studentInfos.Find(id);
                student.isActive = status;
                _context.studentInfos.Update(student);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<ClassInfo>> GetAllClasses()
        {
            var data = await _context.classInfos.AsNoTracking().ToListAsync();
            return data;
        }
        public async Task<int> SaveClassInfo(ClassInfo classs)
        {
            if (classs.Id != 0)
                _context.classInfos.Update(classs);
            else
                _context.classInfos.Add(classs);

            await _context.SaveChangesAsync();
            return classs.Id;
        }

        public async Task<IEnumerable<Gender>> GetAllGenders()
        {
            var data = await _context.genders.AsNoTracking().ToListAsync();
            return data;
        }
        public async Task<int> SaveGenderInfo(Gender gender)
        {
            if (gender.Id != 0)
                _context.genders.Update(gender);
            else
                _context.genders.Add(gender);

            await _context.SaveChangesAsync();
            return gender.Id;
        }

    }
}




