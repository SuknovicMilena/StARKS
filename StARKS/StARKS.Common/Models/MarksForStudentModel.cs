using System;
using System.Collections.Generic;
using System.Text;

namespace StARKS.Common.Models
{
    public class MarksForStudentModel
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public int CoursCode { get; set; }
        public string CoursName { get; set; }
        public int Mark { get; set; }

    }
}
