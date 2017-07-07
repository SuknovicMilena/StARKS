using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StARKS.Data.Entities
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        [InverseProperty("Course")]
        public List<Marks> Marks { get; set; }
    }
}
