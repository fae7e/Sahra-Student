using AutoMapper;
using Sahra.Student.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sahra.Student.Application.MapperProfile
{
    public class StudentMapperProfile : Profile
    {
        public StudentMapperProfile()
        {
            CreateMap<StudentRequest, DomainModel.Student>();
        }
    }
}
