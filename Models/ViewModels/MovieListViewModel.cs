using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Models.ViewModels
{
    public class MovieListViewModel
    {
        public MovieListViewModel (MovieListContext context)
        {
            Movies = context.Movies;
        }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
