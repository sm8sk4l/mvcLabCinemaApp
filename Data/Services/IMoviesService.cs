using KinoProject.Models;

namespace KinoProject.Data.Services;

public interface IMoviesService
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Movie GetById(int id);
    void Add(Movie movie);
    Movie Update(int id, Movie newMovie);
    void Delete(int id);
}