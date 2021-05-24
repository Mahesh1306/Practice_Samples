using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExample.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
