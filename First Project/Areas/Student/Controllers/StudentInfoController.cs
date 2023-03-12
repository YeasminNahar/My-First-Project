using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Project.Areas.Student.Models;
using First_Project.Data;
using First_Project.Helpers;
using First_Project.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace First_Project.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentInfoController : Controller
    {
        private readonly IStudentService studentService;

        public StudentInfoController(IStudentService _student)
        {
            this.studentService = _student;
        }
        public async Task<IActionResult> Section()
        {
            StudentDetailsViewModel model = new StudentDetailsViewModel
            {
                sections = await studentService.GetSection(),
            };
            return View(model);
        }
      
      
        [HttpPost]
        public async Task<IActionResult> Section([FromForm] StudentDetailsViewModel model)
        {
            var data = new Section
            {
                Id=model.sectionsId,
                NameBN = model.NameBN,
                NameEN = model.NameEN,
            };

            await studentService.SaveSection(data);     
            return RedirectToAction(nameof(Section));
        }


        public async Task<IActionResult> StudentInfo(int id)
        {
            StudentDetailsViewModel model = new StudentDetailsViewModel
            {
                sections = await studentService.GetSection(),
                studentInfos = await studentService.GetStudent(),
                classInfos = await studentService.GetAllClasses(),
                studentsInfos = await studentService.GetStudentInfobyId(id),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> StudentInfo([FromForm] StudentDetailsViewModel model)
        {
            string imagePath = string.Empty;
            string fileName = "";
            if (model.imgUrl != null)
            {
                string message = FileSave.SaveImage(out fileName, model.imgUrl);
            }
            else
            {
                fileName = model.url;
            }

            var studentInfo = new StudentInfo
            {
                Id=model.studentId,
                Name = model.Name,
                classInfoId = model.classInfoId,
                sectionId = model.sectionId,
                Roll = model.Roll,
                Address = model.Address,
                url=fileName,
                isActive=model.isActive,
                genderId=model.genderId
            };
            await studentService.SaveStudent(studentInfo);
            return RedirectToAction("StudentInfoList");
        }
        public async Task<IActionResult>StudentInfoList()
        {
            var data = new StudentDetailsViewModel
            {
                studentInfos = await studentService.GetStudent(),
            };
            return View(data);
        }


        [HttpGet]
        public async Task<IActionResult> ResultSheet()
        {
            StudentDetailsViewModel model = new StudentDetailsViewModel
            {
                sections = await studentService.GetSection(),
                studentInfos = await studentService.GetStudent(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResultSheet([FromForm] StudentDetailsViewModel model)
        {
            if (model.childId != null)
            {
                for (int i = 0; i < model.childId.Length; i++)
                {
                    var result = new Resultsheet
                    {
                        Id = (int)model.childId[i],
                        Subject = model.Subject[i],
                        TotalMarks = model.TotalMarks[i],
                        Grade = model.Grade[i],
                        studentInfoId = model.studentId
                    };
                    await studentService.SaveResult(result);
                }
            }

            return RedirectToAction("ResultSheet");
        }
        public async Task<JsonResult> GetStudentDetails(int id)
        {
            var data = await studentService.GetStudentDetails(id);
            return Json(data);
        }
        public async Task<JsonResult> GetResultSheet(int id)
        {
            var data = new StudentDetailsViewModel
            {
                resultSheets = await studentService.GetResultSheet(id),
            };
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> StudentInfoActivateStatus(int Id, int status)
        {
            var data= await studentService.UpdateStudentActiveStatus(Id, status);
            return RedirectToAction("StudentInfoList");
        }

        [HttpGet]
        public async Task<IActionResult> ClassInfo()
        {
            var model = new StudentDetailsViewModel
            {
                classInfos = await studentService.GetAllClasses(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ClassInfo([FromForm] StudentDetailsViewModel model)
        {
            var data = new ClassInfo
            {
                Id = model.classInfoId,
                NameBn = model.NameBN,
                NameEn = model.NameEN,
            };

            await studentService.SaveClassInfo(data);
            return RedirectToAction(nameof(ClassInfo));
        }

        [HttpGet]
        public async Task<IActionResult> GenderInfo()
        {
            var model = new StudentDetailsViewModel
            {
                genders = await studentService.GetAllGenders(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> GenderInfo([FromForm] StudentDetailsViewModel model)
        {
            var data = new Gender
            {
                Id = model.classInfoId,
                NameBN = model.NameBN,
                NameEN = model.NameEN,
            };

            await studentService.SaveGenderInfo(data);
            return RedirectToAction(nameof(GenderInfo));
        }



    }
}

