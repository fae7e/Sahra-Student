using AutoMapper;
using CSharpFunctionalExtensions;
using Sahra.Student.Command;
using Sahra.Student.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahra.Student.Application
{
    public interface IStudentService
    {
        Result AddNewStudent(StudentRequest request);
        Result<List<StudentResponse>> GetAllStudents();
        Result<StudentResponse> GetStudentById(int id);
        Result UpdateStudent(StudentRequest request);
        Result DeleteStudent(int studentCode);
    }
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public Result AddNewStudent(StudentRequest request)
        {
            DomainModel.Student model = _mapper.Map<DomainModel.Student>(request);

            try
            {
                StudentResponse insertedData = _studentRepository.GetStudentByCode(model.StudentCode);
                if (insertedData == null)
                {
                    _studentRepository.Add(model);
                    return Result.Success(".:New Student Successfully added:.");
                }

                else
                    return Result.Failure(".:Duplicate Student Code. Please enter a new one:.");

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }

        }
        public Result<List<StudentResponse>> GetAllStudents()
        {
            List<StudentResponse> studentList = _studentRepository.GetAll();
            if (!studentList.Any())
                return Result.Failure<List<StudentResponse>>(".:No Data Found:.");

            return studentList;

        }
        public Result<StudentResponse> GetStudentById(int id)
        {
            StudentResponse response = _studentRepository.GetStudentByCode(id);

            if (response == null)
                return Result.Failure<StudentResponse>(".:No Data Found:.");
            else
                return Result.Success(response);
        }
        public Result UpdateStudent(StudentRequest request)
        {
            DomainModel.Student model = _mapper.Map<DomainModel.Student>(request);

            var entity = GetStudentById(request.StudentCode);
            if (entity.IsFailure)
                return Result.Failure<StudentResponse>(".:No Data Found:.");
            else
            {
                model.Id = entity.Value.Id;

                _studentRepository.Update(model);
                return Result.Success($".:Student {model.FirstName} {model.LastName} Successfully updated:.");
            }
        }
        public Result DeleteStudent(int studentCode)
        {
            var entity = GetStudentById(studentCode);
            if (entity.IsFailure)
                return Result.Failure<StudentResponse>(".:No Data Found:.");
            else
            {
                _studentRepository.RemoveStudentByCode(studentCode);
                return Result.Success();
            }
        }
    }
}
