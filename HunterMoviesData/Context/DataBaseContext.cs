
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HunterMoviesData
{
        public class DataBaseContext : DbContext
        {
            public DataBaseContext(DbContextOptions<DataBaseContext> options)
                    : base(options)
            {
            }

            public DbSet<Actors> Actors { get; set; }
            public DbSet<Movies> Movies { get; set; }
            public DbSet<Gender> Genders { get; set; }

    }

}
