using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>());

        // Check if the database has already been seeded
        if (context.Movie.Any())
        {
            return;
        }

        context.Movie.AddRange(
            new Movie
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-02-12"),
                Genre = "Romantic Comedy",
                Price = 7.99M,
                Rating = "R"
            },
            new Movie
            {
                Title = "Ghostbusters",
                ReleaseDate = DateTime.Parse("1984-03-13"),
                Genre = "Comedy",
                Price = 8.99M,
                Rating = "PG"
            },
            new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-02-23"),
                Genre = "Comedy",
                Price = 9.99M,
                Rating = "PG"
            },
            new Movie
            {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-04-15"),
                Genre = "Western",
                Price = 3.99M,
                Rating = "G"
            },
            new Movie
            {
                Title = "The Dark Knight",
                ReleaseDate = DateTime.Parse("2008-07-18"),
                Genre = "Action",
                Rating = "PG13",
                Price = 12.99M
            },
            new Movie
            {
                Title = "Inception",
                ReleaseDate = DateTime.Parse("2010-07-16"),
                Genre = "Sci-Fi",
                Rating = "PG13",
                Price = 11.99M
            },
            new Movie
            {
                Title = "Interstellar",
                ReleaseDate = DateTime.Parse("2014-11-07"),
                Genre = "Sci-Fi",
                Rating = "PG13",
                Price = 13.99M
            }
        );

        context.SaveChanges();
    }
}