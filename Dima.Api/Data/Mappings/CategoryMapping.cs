﻿using Microsoft.EntityFrameworkCore;
using Dima.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category> //IEntityTypeConfiguration - Define o que o mapeamento precisa ter.
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
           builder.ToTable("Category");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);
            builder.Property(x => x.UserId)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160);
        }
    }
}