using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StARKS.Data.Entities
{
    public class Marks
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseCode { get; set; }
        public int MarkValue { get; set; }

        [ForeignKey("StudentId")]
        [InverseProperty("Marks")]
        public Student Student { get; set; }

        [ForeignKey("CourseCode")]
        [InverseProperty("Marks")]
        public Course Course { get; set; }
    }
}
