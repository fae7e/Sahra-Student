using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sahra.Student.Application;
using Sahra.Student.Command;
using System.Collections.Generic;

namespace Sahra.Student.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : BaseController
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Add New Student
        /// </summary>
        [HttpPost("add")]
        public IActionResult AddStudent([FromQuery] StudentRequest request)
        {
            if (request.NameValidation() && request.StudentCodeValidation())
            {
                var result = _studentService.AddNewStudent(request);
                if (result.IsSuccess)
                    return Ok(".:New Student Successfully added:.");
            
            else
                return FromResult(result);
            }
            else
                return Ok($".:Please enter First Name/Last Name and Student Code:.");

        }
        /// <summary>
        /// Get All Students
        /// </summary>
        [HttpGet("getAll")]
        public IActionResult GetAllStudent()
        {
            var result = _studentService.GetAllStudents();
            return FromResult(result);
        }

        /// <summary>
        /// Get Student By Id
        /// </summary>
        [HttpGet("{studentId:int}")]
        public IActionResult GetStudentById(int studentId)
        {
            StudentRequest request = new StudentRequest();
            var result = _studentService.GetStudentById(studentId);
            return FromResult(result);
        }
        /// <summary>
        /// Update an existing Student
        /// </summary>
        [HttpPost("update")]
        public IActionResult Update([FromQuery] StudentRequest request)
        {
            var result = _studentService.UpdateStudent(request);

            if (result.IsSuccess)
                return Ok($".:Student {request.FirstName} {request.LastName} Successfully updated:.");

            return FromResult(result);
        }

        /// <summary>
        /// Delete an existing Student
        /// </summary>
        [HttpPost("delete")]
        public IActionResult Delete(int studentId)
        {
            var result = _studentService.DeleteStudent(studentId);

            if (result.IsSuccess)
                return Ok($".:Student {studentId} Successfully Deleted:.");

            return FromResult(result);
        }
    }
}
