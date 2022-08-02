using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sahra.Student.Command
{
    public class StudentRequest
    {
        [Display(Name = "شماره دانشجویی")]
        public int StudentCode { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseTitle { get; set; }
        public string Grade { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public bool StudentCodeValidation()
        {
            if (StudentCode == 0) return false;
            return true;
        }
        public bool NameValidation()
        {
            if (String.IsNullOrEmpty(FirstName)) return false;
            if (String.IsNullOrEmpty(LastName)) return false;
            return true;
        }
    }

}
