using CodePulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodePulse.Infrastructure.Data.EntityConfigurations;

public class CategoryEntityConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.UrlHandle).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
    }
}