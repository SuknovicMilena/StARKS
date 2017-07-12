using System;
using System.Collections.Generic;
using System.Text;

namespace StARKS.Common.Models
{
    public class MarksModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseCode { get; set; }
        public string CourseName { get; set; }
        public int MarkValue { get; set; }
    }
}
