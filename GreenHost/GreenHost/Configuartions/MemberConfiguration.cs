using GreenHost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenHost.Configuartions
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.Fullname)
                .IsRequired()
                .HasMaxLength(64);
            builder.Property(m => m.Image)
               .IsRequired()
               .HasMaxLength(256);
            builder.HasOne(m => m.Department)
                   .WithMany(d => d.Members)
                   .HasForeignKey(m => m.DepartmentId);
        }
    }
}
