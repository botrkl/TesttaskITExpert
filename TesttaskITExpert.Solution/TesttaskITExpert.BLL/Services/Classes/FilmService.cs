using AutoMapper;
using TesttaskITExpert.BLL.Models;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.BLL.Services.Interfaces;
using TesttaskITExpert.DAL.Entities;
using TesttaskITExpert.DAL.Repositories.Interfaces;

namespace TesttaskITExpert.BLL.Services.Classes
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly IFilmRepository _filmRepository;
        public FilmService(IMapper mapper, IFilmRepository filmRepository)
        {
            _mapper = mapper;
            _filmRepository = filmRepository;
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

        public async Task<ICollection<FilmModel>?> GetAllFilms()
        {
            var allFilms = await _filmRepository.GetAllAsync();
            return _mapper.Map<ICollection<FilmModel>>(allFilms);
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
