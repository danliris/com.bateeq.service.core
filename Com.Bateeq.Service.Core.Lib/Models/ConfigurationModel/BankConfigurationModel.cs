using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Com.Bateeq.Service.Core.Lib.Models.ConfigurationModel
{
    public class BankConfigurationModel : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.Property(c => c.Code).HasMaxLength(150);
            builder.Property(c => c.Name).HasMaxLength(200);
            builder.Property(c => c.Description).HasMaxLength(250);
        }
    }
}
