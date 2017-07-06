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
        public IActionResult Get(int id)
        {
            var mark = marksRepository.GetById(id);
            return Ok(mark);
        }

        [HttpPost]
        public IActionResult Add([FromBody]MarkModel model)
        {
            var mark = new Mark
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
        public IActionResult Update(int courseId, int studentId, [FromBody]MarkModel model)
        {
            var mark = marksRepository.GetById(courseId, studentId);

            if (mark == null)
            {
                return NotFound("Ta ocena ne postoji.");
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
                return NotFound("Ta ocena ne postoji.");
            }

            marksRepository.Delete(mark);
            marksRepository.Save();

            return new NoContentResult();
        }
    }
}
