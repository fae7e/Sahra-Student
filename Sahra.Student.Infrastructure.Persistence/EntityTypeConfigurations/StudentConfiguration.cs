using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sahra.Student.Infrastructure.Persistence.EntityTypeConfigurations

{
    public class StudentConfiguration : IEntityTypeConfiguration<DomainModel.Student>
    {
        public void Configure(EntityTypeBuilder<DomainModel.Student> builder)
        {
            builder
                .Property(b => b.Id)
                .IsRequired();
        }
    }
}
