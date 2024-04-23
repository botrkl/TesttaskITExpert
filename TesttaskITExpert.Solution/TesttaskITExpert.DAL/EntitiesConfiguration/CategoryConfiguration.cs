using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesttaskITExpert.DAL.Entities;

namespace TesttaskITExpert.DAL.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
