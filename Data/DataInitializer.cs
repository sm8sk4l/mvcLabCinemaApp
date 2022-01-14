using KinoProject.Data;

namespace KinoProject.Models;

public class DataInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<DataContext>();

            context.Database.EnsureCreated();

            // Movies 

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie
                        {
                            Name = "No Time To Die",
                            Price = 20,
                            Description = "James Bond has left active service. His peace is short-lived when Felix Leiter, an old friend from the CIA, turns up asking for help, leading Bond onto the trail of a mysterious villain armed with dangerous new technology.",
                            ImageURL = "shorturl.at/yEKN2",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(14),
                            MovieCategory = MovieCategory.Action,
                        },
                        new Movie
                        {
                            Name = "Spider-Man: No Way Home",
                            Price = 20,
                            Description = "With Spider-Man's identity now revealed, Peter asks Doctor Strange for help. When a spell goes wrong, dangerous foes from other worlds start to appear, forcing Peter to discover what it truly means to be Spider-Man.",
                            ImageURL = "shorturl.at/txKST",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(14),
                            MovieCategory = MovieCategory.Action,
                        },
                        new Movie
                        {
                            Name = "Wrath of Man",
                            Price = 20,
                            Description = "The plot follows H, a cold and mysterious character working at a cash truck company responsible for moving hundreds of millions of dollars around Los Angeles each week.",
                            ImageURL = "shorturl.at/gmGS3",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(14),
                            MovieCategory = MovieCategory.Action,
                        },
                        new Movie
                        {
                            Name = "House of Gucci",
                            Price = 20,
                            Description = "When Patrizia Reggiani, an outsider from humble beginnings, marries into the Gucci family, her unbridled ambition begins to unravel their legacy and triggers a reckless spiral of betrayal, decadence, revenge, and ultimately...murder.",
                            ImageURL = "shorturl.at/rMOX2",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(14),
                            MovieCategory = MovieCategory.Drama,
                        },
                        new Movie
                        {
                            Name = "The Shawshank Redemption",
                            Price = 20,
                            Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                            ImageURL = "shorturl.at/bdAFJ",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(14),
                            MovieCategory = MovieCategory.Drama,
                        },
                        new Movie
                        {
                            Name = "Intouchables",
                            Price = 20,
                            Description = "After he becomes a quadriplegic from a paragliding accident, an aristocrat hires a young man from the projects to be his caregiver.",
                            ImageURL = "shorturl.at/vEGRY",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(14),
                            MovieCategory = MovieCategory.Drama,
                        }
                    });
                context.SaveChanges();
            }
        }
    }
}