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
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();


            //  builder.Property(x => x.GithubAccountId).IsRequired(false);
            // builder.HasAlternateKey(x => x.GithubAccountId);

            builder.HasOne(x => x.GithubAccount)
                .WithOne(x => x.Member)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
           



        }
    }
}
