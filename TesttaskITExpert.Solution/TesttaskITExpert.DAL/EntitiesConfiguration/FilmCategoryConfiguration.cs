using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesttaskITExpert.DAL.Entities;

namespace TesttaskITExpert.DAL.EntitiesConfiguration
{
    public class FilmCategoryConfiguration : IEntityTypeConfiguration<FilmCategory>
    {
        public void Configure(EntityTypeBuilder<FilmCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x=>x.category_id)
                .IsRequired();

            builder.Property(x => x.film_id)
                .IsRequired();

            builder.HasOne(filmCategory => filmCategory.film)
                .WithMany(film => film.FilmCategories)
                .HasForeignKey(filmCategory => filmCategory.film_id);

            builder.HasOne(filmCategory => filmCategory.category)
               .WithMany(category => category.FilmCategories)
               .HasForeignKey(filmCategory => filmCategory.category_id);
        }
    }
}
