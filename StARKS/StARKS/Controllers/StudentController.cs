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
    [Route("students")]
    public class StudentController : Controller
    {
        private StudentRepository studentRepository;
        private CourseRepository courseRepository;
        public StudentController(StudentRepository studentRepository, CourseRepository courseRepository)
        {
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult GetAllStudentModel()
        {
            var students = studentRepository.GetAllStudentModel();
            return Ok(students);
        }

        [HttpGet("{studentId}", Name = "GetStudent")]
        public IActionResult Get(int studentId)
        {
            var student = studentRepository.GetById(studentId);

            if (student == null)
            {
                return NotFound("Student does not exist.");
            }

            return Ok(student);
        }

        [HttpGet("{studentId}/courses")]
        public IActionResult GetAvailableCourses(int studentId)
        {
            var student = studentRepository.GetById(studentId);

            if (student == null)
            {
                return NotFound("Student does not exist.");
            }

            var courses = courseRepository.GetAvailableCourses(studentId);

            return Ok(courses);
        }


        [HttpPost]
        public IActionResult Add([FromBody]StudentModel model)
        {
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                City = model.City,
                Gender = model.Gender,
                State = model.State,
                DateOfBirth = model.DateOfBirth
            };

            studentRepository.Insert(student);
            studentRepository.Save();

            var modelToReturn = new StudentModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Address = student.Address,
                City = student.City,
                Gender = student.Gender,
                State = student.State,
                DateOfBirth = student.DateOfBirth
            };

            return CreatedAtRoute("GetStudent", new { studentId = student.Id }, modelToReturn);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]StudentModel model)
        {
            var student = studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound("Student does not exist.");
            }

            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Address = model.Address;
            student.City = model.City;
            student.Gender = model.Gender;
            student.DateOfBirth = model.DateOfBirth;
            student.State = model.State;

            studentRepository.Save();
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound("Student does not exist.");
            }

            studentRepository.Delete(student);
            studentRepository.Save();
            return new NoContentResult();
        }

    }
}
