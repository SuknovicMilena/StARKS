using Microsoft.AspNetCore.Mvc;
using StARKS.Common.Models;
using StARKS.Data.Entities;
using StARKS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StARKS.Controllers
{
    [Route("marks")]
    public class MarksForStudentController : Controller
    {
        private MarksForStudentRepository marksForStudentRepository;
        private CourseRepository courseRepository;
        private StudentRepository studentRepository;

        public MarksForStudentController(MarksForStudentRepository marksForStudentRepository, CourseRepository courseRepository, StudentRepository studentRepository)
        {
            this.marksForStudentRepository = marksForStudentRepository;
            this.courseRepository = courseRepository;
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetAllModel()
        {
            var marks = marksForStudentRepository.GetAllMarksModel();
            return Ok(marks);
        }

        [HttpPost]
        public IActionResult Add([FromBody]MarksForStudentModel model)
        {
            var mark = new MarksForStudent
            {
                StudentId = model.StudentId,
                CoursCode = model.CoursCode,
                Mark = model.Mark
            };

            marksForStudentRepository.Insert(mark);
            marksForStudentRepository.Save();

            return new NoContentResult();
        }

        [HttpPut("{CourseId}/{StudentId}")]
        public IActionResult Update(int CourseId, int StudentId, [FromBody]MarksForStudentModel model)
        {
            var mark = marksForStudentRepository.GetById(CourseId, StudentId);

            if (mark == null)
            {
                BadRequest("Ta ocena ne postoji.");
            }

            mark.Mark = model.Mark;

            marksForStudentRepository.Save();

            return new NoContentResult();
        }

        [HttpDelete("{CourseId}/{StudentId}")]
        public IActionResult Delete(int CourseId, int StudentId)
        {
            var mark = marksForStudentRepository.GetById(CourseId, StudentId);
            if (mark == null)
            {
                BadRequest("Ta ocena ne postoji.");
            }

            marksForStudentRepository.Delete(mark);
            marksForStudentRepository.Save();

            return new NoContentResult();
        }
    }
}
