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

        public List<MarksModel> GetAllMarksModel(int studentId)
        {
            var marks = dbSet.Where(m => m.StudentId == studentId).Select(m => new MarksModel
            {
                StudentId = m.StudentId,
                StudentName = m.Student.FirstName + " " + m.Student.LastName,
                CourseCode = m.CourseCode,
                CourseName = m.Course.Name,
                MarkValue = m.MarkValue
            }).ToList();
            return marks;
        }

        public MarksModel GetMarksModel(int studentId, int courseId)
        {
            var mark = dbSet.Where(m => m.StudentId == studentId && m.CourseCode == courseId).Select(m => new MarksModel
            {
                StudentId = m.StudentId,
                StudentName = m.Student.FirstName + " " + m.Student.LastName,
                CourseCode = m.CourseCode,
                CourseName = m.Course.Name,
                MarkValue = m.MarkValue
            }).FirstOrDefault();
            return mark;
        }
    }
}
