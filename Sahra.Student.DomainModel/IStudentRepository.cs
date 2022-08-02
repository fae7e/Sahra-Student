using Sahra.Student.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sahra.Student.DomainModel
{
    public interface IStudentRepository
    {        void Add(Student model);
        List<StudentResponse> GetAll();
        StudentResponse GetStudentByCode(int id);
        void Update(Student model);
        void RemoveStudentByCode(int id);
    }
}
