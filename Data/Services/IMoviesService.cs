using KinoProject.Models;

namespace KinoProject.Data.Services;

public interface IMoviesService
{
    Task<IEnumerable<Movie>> GetAll();
    Movie Update(int id, Movie newMovie);
    Movie GetById(int id);
    void Add(Movie movie);
    void Delete(int id);
}