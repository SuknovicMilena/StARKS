using StARKS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StARKS.Common.Models;
using System.Linq;

namespace StARKS.Data.Repositories
{
    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository(StARKSDbContext dbContext) : base(dbContext)
        {
        }
        public List<CourseModel> GetAllCourseModel()
        {

            var courses = dbSet.Select(c => new CourseModel
            {
                Code = c.Code,
                Name = c.Name,
                Description = c.Description

            }).ToList();
            return courses;
        }
    }
}
