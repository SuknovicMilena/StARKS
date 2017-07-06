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
        public StudentController(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        //TODO: name this route
        [HttpGet]
        public IActionResult GetAllStudentModel()
        {
            var students = studentRepository.GetAllStudentModel();
            return Ok(students);
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
            return Ok();
            //TODO: convert to CreatedAtRoute
        }

        //TODO: rename Id to id
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody]StudentModel model)
        {
            var student = studentRepository.GetById(Id);
            if (student == null)
            {
                return NotFound("Ne postoji taj student.");
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

        //TODO: rename Id to id
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var student = studentRepository.GetById(Id);
            if (student == null)
            {
                return NotFound("Ne postoji taj student.");
            }

            studentRepository.Delete(student);
            studentRepository.Save();
            return new NoContentResult();
        }

    }
}
