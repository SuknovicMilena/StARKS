using StARKS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StARKS.Common.Models;
using System.Linq;

namespace StARKS.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(StARKSDbContext dbContext) : base(dbContext)
        {
        }
        public List<StudentModel> GetAllStudentModel()
        {
            var students = dbSet.Select(s => new StudentModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                DateOfBirth = s.DateOfBirth,
                Gender = s.Gender,
                City = s.City,
                State = s.State,
                Address = s.Address
            }).ToList();
            return students;
        }
    }
}
