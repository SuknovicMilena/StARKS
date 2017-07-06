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

        //TODO: name this route
        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = courseRepository.GetAllCourseModel();
            return Ok(courses);
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

            return Ok();
            //TODO: convert to CreatedAtRoute
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]CourseModel model)
        {
            var course = courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound("Taj kurs ne postoji");
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
                return NotFound("Taj kurs ne postoji");
            }
            courseRepository.Delete(id);
            courseRepository.Save();

            return new NoContentResult();

        }
    }
}
