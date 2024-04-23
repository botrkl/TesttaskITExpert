using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesttaskITExpert.DAL.Entities;

namespace TesttaskITExpert.DAL.EntitiesConfiguration
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.director)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.release)
                .IsRequired();
        }
    }
}
