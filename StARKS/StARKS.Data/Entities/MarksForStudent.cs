﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StARKS.Data.Entities
{
    public class MarksForStudent
    {
        public int StudentId { get; set; }
        public int CoursCode { get; set; }
        public int Mark { get; set; }

        [ForeignKey("StudentId")]
        [InverseProperty("Marks")]
        public Student Student { get; set; }

        [ForeignKey("CoursCode")]
        [InverseProperty("Marks")]
        public Cours Cours { get; set; }
    }
}