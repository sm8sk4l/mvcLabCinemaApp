using Xunit;
using KinoProject.Models;
using System;
using System.Collections.Generic;
using KinoProject.Data.Services;

namespace KinoProjectTests
{
    public class MovieTests
    {
        public static IEnumerable<object[]> TestItemsDataOk =>
        new List<object[]>
        {
                new object[] {
                    new Movie {
                        Name = "Kiepscy",
                        Description = "Bardzo fajny film!",
                        StartDate = DateTime.Now + TimeSpan.FromDays(2),
                        EndDate = DateTime.Now + TimeSpan.FromDays(3),
                        Price = 69,
                        MovieCategory = MovieCategory.Comedy,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/1200px-Felis_catus-cat_on_snow.jpg"
                    }
                },
                new object[] {
                    new Movie {
                        Name = "Wied�min",
                        Description = "Film fantasy o go�ciu z mieczem",
                        StartDate = DateTime.Now + TimeSpan.FromDays(5),
                        EndDate = DateTime.Now + TimeSpan.FromDays(6),
                        Price = 120,
                        MovieCategory = MovieCategory.Action,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/1200px-Felis_catus-cat_on_snow.jpg"

                    }
                },
                new object[] {
                    new Movie {
                        Name = "Jezus nie by� bia�y",
                        Description = "Dokument o wszystkim znanym synu bo�ym.",
                        StartDate = DateTime.Now + TimeSpan.FromDays(1),
                        EndDate = DateTime.Now + TimeSpan.FromDays(2),
                        Price = 50,
                        MovieCategory = MovieCategory.Documentary,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/1200px-Felis_catus-cat_on_snow.jpg"
                    }
                },
        };

        public static IEnumerable<object[]> TestItemsDataNotOk =>
        new List<object[]>
        {
                new object[] {
                    new Movie {
                        Name = "Kie�basa Wiejska",
                        Description = "Dobra kie�basa",
                        Price = -5,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/1200px-Felis_catus-cat_on_snow.jpg"
                    }
                },
                new object[] {
                    new Movie {
                        StartDate = DateTime.Now + TimeSpan.FromDays(5),
                        EndDate = DateTime.Now + TimeSpan.FromDays(6),
                        Price = 123,
                        MovieCategory = MovieCategory.Documentary,
                        ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/1200px-Felis_catus-cat_on_snow.jpg"

                    }
                },
                new object[] {
                    new Movie {
                        Name = "Jezus nie by� bia�y",
                        Description = "Dokument o wszystkim znanym synu bo�ym.",
                        StartDate = DateTime.Now + TimeSpan.FromDays(1),
                        EndDate = DateTime.Now + TimeSpan.FromDays(2),
                    }
                },
        };

        [Theory]
        [MemberData(nameof(TestItemsDataNotOk))]
        public void MovieValidation_ForInvalidData_ReturnFalse(Movie movie)
        {
            // Arrage


            // Act
            bool result = MoviesService.ValidateMovie(movie);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(TestItemsDataOk))]
        public void MovieValidation_ForCorrectData_ReturnTrue(Movie movie)
        {
            // Arrage


            // Act
            bool result = MoviesService.ValidateMovie(movie);

            // Assert
            Assert.True(result);
        }
    }
}