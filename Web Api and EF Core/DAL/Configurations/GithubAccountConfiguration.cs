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
    public class GithubAccountConfiguration : IEntityTypeConfiguration<GithubAccount>
    {
        public void Configure(EntityTypeBuilder<GithubAccount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            
            builder.HasIndex(x => x.MemberId).IsUnique();
            builder.Property(x => x.Nickname).HasMaxLength(100).IsRequired();


            builder.HasOne(x => x.Member)
                .WithOne(x => x.GithubAccount)
                .HasForeignKey<GithubAccount>(x => x.MemberId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

        }
    }
}
