using TesttaskITExpert.BLL.Models;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;

namespace TesttaskITExpert.BLL.Services.Interfaces
{
    public interface IFilmService
    {
        public Task<FilmModel?> GetFilmByIdAsync(int id);
        public Task DeleteFilmAsync(int id);
        public Task AddFilmAsync(AddFilmModel model);
        public Task UpdateFilmAsync(UpdateFilmModel model);
        public Task<IList<FilmModel>?> GetAllFilmsAsync();
        public Task AddCategoriesToFilmAsync(int filmId, IList<int>? categoryIds);
        public Task<FilmModel> GetFilmWithCategoriesByFilmIdAsync(int filmId);
    }
}
