using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sahra.Student.Command
{
    public class StudentResponse
    {
        public Guid Id { get; set; }
        public int StudentCode { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]

        public string FirstName { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]

        public string LastName { get; set; }
        public string StudentName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }
        public string CourseTitle { get; set; }
        public string Grade { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
