using WebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Infrascture.DataBase.EF.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.SiteName).IsRequired().HasMaxLength(30);
            builder.Property(c => c.SiteUrl).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Customer).IsRequired().HasMaxLength(30);
            builder.Property(c => c.StartDate).IsRequired(false).HasColumnType("Date");
            builder.Property(c => c.EndDate).IsRequired(false).HasColumnType("Date");
            builder.Property(c => c.Description).IsRequired().HasMaxLength(1000);
            builder.HasMany(c => c.Category).WithOne().HasForeignKey(c => c.Product_ID).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.HasMany(c => c.Services).WithOne().HasForeignKey(c => c.Product_ID).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.HasMany(c => c.Tags).WithOne().HasForeignKey(c => c.Product_ID).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.HasMany(c => c.Images).WithOne().HasForeignKey(c => c.Product_ID).OnDelete(DeleteBehavior.Cascade).IsRequired();

            builder.HasQueryFilter(c => c.Delete == false);


        }
    }
}
