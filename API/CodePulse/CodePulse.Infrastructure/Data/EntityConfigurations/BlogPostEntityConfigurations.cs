using CodePulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodePulse.Infrastructure.Data.EntityConfigurations;

public class BlogPostEntityConfigurations : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Content).IsRequired();
        builder.Property(x => x.FeatureImageUrl).IsRequired();
        builder.Property(x => x.UrlHandle).IsRequired();
        builder.Property(x => x.IsVisible).IsRequired();
        builder.Property(x => x.Author).IsRequired().HasMaxLength(100);
        builder.Property(x => x.CreatedAt).IsRequired();
    }
}