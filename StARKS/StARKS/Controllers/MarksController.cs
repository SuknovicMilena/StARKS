using Microsoft.AspNetCore.Mvc;
using StARKS.Common.Models;
using StARKS.Data.Entities;
using StARKS.Data.Repositories;
using System.Collections.Generic;
using System.Linq;


namespace StARKS.Controllers
{
    [Route("marks")]
    public class MarksController : Controller
    {
        private MarksRepository marksRepository;
        private CourseRepository courseRepository;
        private StudentRepository studentRepository;

        public MarksController(MarksRepository marksRepository, CourseRepository courseRepository, StudentRepository studentRepository)
        {
            this.marksRepository = marksRepository;
            this.courseRepository = courseRepository;
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var marks = marksRepository.GetAllMarksModel();
            return Ok(marks);
        }

        [HttpGet("{courseId}/students/{studentId}", Name = "GetMark")]
        public IActionResult Get(int courseId, int studentId)
        {
            var student = studentRepository.GetById(studentId);

            if (student == null)
            {
                return NotFound("Student does not exist.");
            }

            var course = courseRepository.GetById(courseId);

            if (course == null)
            {
                return NotFound("Course does not exist.");
            }

            var mark = marksRepository.Find(m => m.StudentId == studentId && m.CourseCode == courseId).FirstOrDefault();

            if (mark == null)
            {
                return NotFound("Mark does not exist.");
            }

            return Ok(mark);
        }

        [HttpPost]
        public IActionResult Add([FromBody]MarksModel model)
        {
            var student = studentRepository.GetById(model.StudentId);

            if (student == null)
            {
                return NotFound("Student does not exist.");
            }

            var course = courseRepository.GetById(model.CourseCode);

            if (course == null)
            {
                return NotFound("Course does not exist.");
            }

            var existingMark = marksRepository.Find(m => m.StudentId == model.StudentId && m.CourseCode == model.CourseCode).FirstOrDefault();

            if (existingMark != null)
            {
                return BadRequest("Student already has that mark entered.");
            }

            var mark = new Marks
            {
                StudentId = model.StudentId,
                CourseCode = model.CourseCode,
                MarkValue = model.Mark
            };

            marksRepository.Insert(mark);
            marksRepository.Save();

            return CreatedAtRoute("GetMark", new { studentId = mark.StudentId, courseId = mark.CourseCode }, mark);
            //return Ok(mark);
        }

        [HttpPut("{courseId}/students/{studentId}")]
        public IActionResult Update(int courseId, int studentId, [FromBody]MarksModel model)
        {
            var mark = marksRepository.GetById(courseId, studentId);

            if (mark == null)
            {
                return NotFound("Mark does not exist for this student.");
            }

            mark.MarkValue = model.Mark;

            marksRepository.Save();

            return new NoContentResult();
        }

        [HttpDelete("{courseId}/students/{studentId}")]
        public IActionResult Delete(int courseId, int studentId)
        {
            var mark = marksRepository.GetById(courseId, studentId);
            if (mark == null)
            {
                return NotFound("Mark does not exist for this student.");
            }

            marksRepository.Delete(mark);
            marksRepository.Save();

            return new NoContentResult();
        }
    }
}
