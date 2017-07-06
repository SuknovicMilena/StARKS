using StARKS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StARKS.Common.Models;
using System.Linq;

namespace StARKS.Data.Repositories
{
    public class MarksRepository : BaseRepository<Mark>
    {
        public MarksRepository(StARKSDbContext dbContext) : base(dbContext)
        {
        }

        public List<MarkModel> GetAllMarksModel()
        {
            var marks = dbSet.Select(m => new MarkModel
            {
                StudentId = m.StudentId,
                StudentName = m.Student.FirstName + " " + m.Student.LastName,
                CourseCode = m.CourseCode,
                CourseName = m.Course.Name,
                Mark = m.MarkValue
            }).ToList();
            return marks;
        }
    }
}
