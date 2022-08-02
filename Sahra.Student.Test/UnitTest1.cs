using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Sahra.Student.DomainModel;
using Sahra.Student.Infrastructure.Persistence;
using System;
using System.Linq;

namespace Sahra.Student.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                          .UseInMemoryDatabase(databaseName: "SahraStudentDatabase.db").Options;

            using (var context = new DataContext(options))
            {
                context.Students.Add(new DomainModel.Student { Id = new System.Guid("cdecb475-525f-40c9-8fbe-f5bea1cc5d93"), FirstName = "Faeze", LastName = "safi" , StudentCode= 891317});
                context.Students.Add(new DomainModel.Student { Id = System.Guid.NewGuid(), FirstName = "Faeze", LastName = "safi" });
                context.Students.Add(new DomainModel.Student { Id = System.Guid.NewGuid(), FirstName = "Faeze", LastName = "safi" });
                context.SaveChanges();
            }
            
            using (var context = new DataContext(options))
            {
                StudentRepository studentRepository = new StudentRepository(context);
                var students = studentRepository.GetAll();

                Assert.AreEqual(3, students.Count);
            }
        }

        [Test]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                        .UseInMemoryDatabase(databaseName: "SahraStudentDatabase.db").Options;

            using (var context = new DataContext(options))
            {

                context.Students.Add(new DomainModel.Student { Id = new Guid("d9fac970-a417-4479-95f1-2e6865707858"), FirstName = "Faeze", LastName = "safi", StudentCode = 891315 });
                context.Students.Add(new DomainModel.Student { Id = new Guid("86f681e4-819a-489c-9cfe-85b9dee157a0"), FirstName = "Faeze", LastName = "safi" , StudentCode = 891316 });
                context.Students.Add(new DomainModel.Student { Id = System.Guid.NewGuid(), FirstName = "Faeze", LastName = "safi", StudentCode = 891317 });
                context.SaveChanges();                
            }
            using (var context = new DataContext(options))
            {
                int initialCount = context.Students.Count();
                context.Students.Remove(new DomainModel.Student { Id = new Guid("d9fac970-a417-4479-95f1-2e6865707858") });
                context.SaveChanges();
                Assert.AreEqual(context.Students.Count(), initialCount - 1);
            }
        }
    }
}