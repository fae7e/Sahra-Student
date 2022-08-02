using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sahra.Student.Command;
using Sahra.Student.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahra.Student.Infrastructure.Persistence
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _dbContext;

        public StudentRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(DomainModel.Student model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }
        public StudentResponse GetStudentByCode(int studentCode)
        {
            var query = _dbContext.Students.Select(e => new StudentResponse
            {
                Id = e.Id,
                StudentCode = e.StudentCode,
                FirstName = e.FirstName,
                LastName = e.LastName,
                CourseTitle = e.CourseTitle,
                Grade = e.Grade,
                EnrollmentDate = e.EnrollmentDate
            });

            query = query.Where(e => e.StudentCode == studentCode);
            return query.FirstOrDefault();
        }
        public List<StudentResponse> GetAll()
        {
            List<StudentResponse> dbResult = _dbContext.Students.Select(e => new StudentResponse
            {
                Id = e.Id,
                StudentCode = e.StudentCode,
                FirstName = e.FirstName,
                LastName = e.LastName,
                CourseTitle = e.CourseTitle,
                Grade = e.Grade,
                EnrollmentDate = e.EnrollmentDate
            }).ToList();
            return dbResult;
        }
        public void Update(DomainModel.Student model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void RemoveStudentByCode(int StudentCode)
        {
            var removeEntity = _dbContext.Students.Where(r => r.StudentCode == StudentCode).FirstOrDefault();
            if (removeEntity != null)
            {
                _dbContext.Entry(removeEntity).State = EntityState.Deleted;

                _dbContext.Remove(removeEntity);
                _dbContext.SaveChanges();
            }
        }

    }
}
