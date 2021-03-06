using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Models
{
    public class MovieListContext : DbContext
    {
        public MovieListContext (DbContextOptions<MovieListContext> options) : base (options)
        { }

        public DbSet<Movie> Movies { get; set; }
    }
}
