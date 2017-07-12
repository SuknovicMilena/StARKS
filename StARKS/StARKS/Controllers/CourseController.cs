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
    [Route("courses")]
    public class CourseController : Controller
    {
        private CourseRepository courseRepository;
        public CourseController(CourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = courseRepository.GetAllCourseModel();
            return Ok(courses);
        }


        [HttpGet("{courseId}", Name = "GetCourse")]
        public IActionResult Get(int courseId)
        {
            var course = courseRepository.GetCourseModel(courseId);

            if (course == null)
            {
                return NotFound("Course does not exist.");
            }

            return Ok(course);
        }

        [HttpPost]
        public IActionResult Add([FromBody]CourseModel model)
        {
            var course = new Course
            {
                Description = model.Description,
                Name = model.Name
            };
            courseRepository.Insert(course);
            courseRepository.Save();

            var modelToReturn = new CourseModel
            {
                Description = course.Description,
                Name = course.Description

            };

            return CreatedAtRoute("GetCourse", new { courseCode = course.Code }, modelToReturn);


        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]CourseModel model)
        {
            var course = courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound("Course does not exist.");
            }
            course.Description = model.Description;
            course.Name = model.Name;

            courseRepository.Save();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound("Course does not exist.");
            }
            courseRepository.Delete(id);
            courseRepository.Save();

            return new NoContentResult();

        }
    }
}
