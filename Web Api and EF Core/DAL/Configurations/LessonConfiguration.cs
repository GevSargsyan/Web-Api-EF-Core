using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Link).HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(1000);

            builder.HasMany(x => x.Homework)
                .WithOne(x => x.Lesson)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.NoAction);
                

        }
    }
}
