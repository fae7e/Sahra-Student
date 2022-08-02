using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahra.Student.DomainModel
{
    public class Student
    {
        public Guid Id { get; set; }
        public int StudentCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseTitle { get; set; }
        public string Grade { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
