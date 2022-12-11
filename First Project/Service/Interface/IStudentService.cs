using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Service.Interface
{
    public interface IStudentService
    {
        Task<int> SaveStudent(StudentInfo student);
        Task<IEnumerable<StudentInfo>> GetStudent();
        Task<StudentInfo> GetStudentInfobyId(int id);
        Task<IEnumerable<Section>> GetSection();
        Task<int> SaveSection(Section section);
        Task<int> SaveResult(Resultsheet result);
        Task<IEnumerable<Resultsheet>> GetResultSheet(int id);
        Task<StudentInfo> GetStudentDetails(int id);
        //Task<IEnumerable<StudentInfo>> GetAllStudent(int sectionId);
        //Task<StudentInfo> GetStudentEdit(int id);
        //Task<bool> DeletestudentsInfoById(int Id);
        Task<int> UpdateStudentActiveStatus(int id, int status);
        Task<IEnumerable<ClassInfo>> GetAllClasses();
        Task<int> SaveClassInfo(ClassInfo classs);
        Task<IEnumerable<Gender>> GetAllGenders();
        Task<int> SaveGenderInfo(Gender classs);
    }
}
