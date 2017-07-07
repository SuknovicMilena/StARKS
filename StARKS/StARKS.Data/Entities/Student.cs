using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StARKS.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        [InverseProperty("Student")]
        public List<Marks> Marks { get; set; }
    }
}
