using Microsoft.AspNetCore.Mvc;
using StARKS.Common.Models;
using StARKS.Data.Entities;
using StARKS.Data.Repositories;
using System.Collections.Generic;
using System.Linq;


namespace StARKS.Controllers
{
    [Route("students/{studentId}/marks")]
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
        public IActionResult GetAll(int studentId)
        {
            var marks = marksRepository.GetAllMarksModel(studentId);
            return Ok(marks);
        }

        [HttpGet("courses/{courseId}", Name = "GetMark")]
        public IActionResult Get(int studentId, int courseId)
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

            var mark = marksRepository.GetMarksModel(studentId, courseId);

            if (mark == null)
            {
                return NotFound("Mark does not exist.");
            }

            return Ok(mark);
        }

        [HttpPost("courses/{courseId}")]
        public IActionResult Add(int studentId, int courseId, [FromBody]MarksModel model)
        {
            var student = studentRepository.GetById(studentId);

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

            if (model.MarkValue < 6 || model.MarkValue > 10)
            {
                return BadRequest("Invalid mark. Allowed values: 6 - 10");
            }

            var mark = new Marks
            {
                StudentId = model.StudentId,
                CourseCode = model.CourseCode,
                MarkValue = model.MarkValue
            };

            marksRepository.Insert(mark);
            marksRepository.Save();

            return CreatedAtRoute("GetMark", new { studentId = mark.StudentId, courseId = mark.CourseCode }, mark);
        }

        [HttpPut("courses/{courseId}")]
        public IActionResult Update(int studentId, int courseId, [FromBody]MarksModel model)
        {
            var mark = marksRepository.GetById(studentId, courseId);

            if (mark == null)
            {
                return NotFound("Mark does not exist for this student.");
            }

            if (model.MarkValue < 6 || model.MarkValue > 10)
            {
                return BadRequest("Invalid mark. Allowed values: 6 - 10");
            }

            mark.MarkValue = model.MarkValue;

            marksRepository.Save();

            return new NoContentResult();
        }

        [HttpDelete("courses/{courseId}")]
        public IActionResult Delete(int studentId, int courseId)
        {
            var mark = marksRepository.GetById(studentId, courseId);
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
