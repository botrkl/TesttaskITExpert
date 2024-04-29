using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TesttaskITExpert.BLL.Models;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.BLL.Services.Interfaces;
using TesttaskITExpert.DAL.Entities;
using TesttaskITExpert.DAL.Repositories.Classes;
using TesttaskITExpert.DAL.Repositories.Interfaces;

namespace TesttaskITExpert.BLL.Services.Classes
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly IFilmRepository _filmRepository;
        private readonly IFilmCategoryRepository _filmCategoryRepository;
        public FilmService(IMapper mapper, IFilmRepository filmRepository, IFilmCategoryRepository filmCategoryRepository)
        {
            _mapper = mapper;
            _filmRepository = filmRepository;
            _filmCategoryRepository = filmCategoryRepository;
        }
        public async Task AddCategoryToFilmAsync(int filmId, IList<int> categoryIds)
        {
            foreach (var category in categoryIds)
            {
                var filmCategory = new FilmCategory() { film_id = filmId, category_id = category };
                await _filmCategoryRepository.AddAsync(filmCategory);
            };
        }

        public async Task AddFilmAsync(AddFilmModel model)
        {
            var addFilm = _mapper.Map<Film>(model);
            await _filmRepository.AddAsync(addFilm);
        }

        public async Task DeleteFilmAsync(int id)
        {
            await _filmRepository.DeleteAsync(id);
        }

        public async Task<IList<FilmModel>?> GetAllFilms()
        {
            var allFilms = await _filmRepository.GetAllAsync();
            return _mapper.Map<IList<FilmModel>>(allFilms);
        }

        public async Task<FilmModel> GetFilmByIdWithCategoriesAsync(int filmId)//rename
        {
            var categories = await _filmCategoryRepository.GetCategoriesByFilmIdAsync(filmId);
            var filmModel = await this.GetFilmModelByIdAsync(filmId);
            filmModel.Categories = _mapper.Map<List<CategoryModel>>(categories);
            return filmModel;
        }

        public async Task<FilmModel?> GetFilmModelByIdAsync(int id)
        {
            var wantedFilm = await _filmRepository.GetByIdAsync(id);
            return _mapper.Map<FilmModel>(wantedFilm);
        }

        public async Task UpdateFilmAsync(UpdateFilmModel model)
        {
            var tempFilm = await _filmRepository.GetByIdAsync(model.Id);
            _mapper.Map(model, tempFilm);
            await _filmRepository.UpdateAsync(tempFilm);
        }

    }
}
