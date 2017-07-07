using StARKS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StARKS.Common.Models;
using System.Linq;

namespace StARKS.Data.Repositories
{
    public class MarksRepository : BaseRepository<Marks>
    {
        public MarksRepository(StARKSDbContext dbContext) : base(dbContext)
        {
        }

        public List<MarksModel> GetAllMarksModel()
        {
            var marks = dbSet.Select(m => new MarksModel
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
