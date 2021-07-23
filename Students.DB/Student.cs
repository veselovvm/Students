using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Students.DB
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Fio { get; set; }
        public DateTime Birthday { get; set; }
        public virtual StudentProgress Progress { get; set; }
    }
}
