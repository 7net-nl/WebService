using CnetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnetCore.Infrascture.DataBase.EF.Configurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(40).IsRequired();
            builder.Property(c => c.Product_ID).IsRequired();
        }
    }
}
