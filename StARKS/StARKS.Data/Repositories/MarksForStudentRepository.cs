using StARKS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StARKS.Common.Models;
using System.Linq;

namespace StARKS.Data.Repositories
{
    public class MarksForStudentRepository : BaseRepository<MarksForStudent>
    {
        public MarksForStudentRepository(StARKSDbContext dbContext) : base(dbContext)
        {
        }

        public List<MarksForStudentModel> GetAllMarksModel()
        {
            var marks = dbSet.Select(m => new MarksForStudentModel
            {

                StudentId = m.StudentId,
                StudentName = m.Student.FirstName + " " + m.Student.LastName,
                CoursCode = m.CoursCode,
                CoursName = m.Cours.Name,
                Mark = m.Mark
            }).ToList();
            return marks;

        }
    }
}
