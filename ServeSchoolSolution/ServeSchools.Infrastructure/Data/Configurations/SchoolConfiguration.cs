using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServeSchools.Domain.Schools;

namespace ServeSchools.Infrastructure.Data.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("schools");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x=> x.IsDeleted).HasColumnName("is_deleted").IsRequired().HasDefaultValue(false);
            builder.Property(x => x.FoundingDate).HasColumnName("founding_date").IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnName("created_date").IsRequired(false).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.LastUpdated).HasColumnName("last_updated").IsRequired(false);
        }
    }
}
