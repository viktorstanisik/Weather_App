using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp_Domain.Models;

namespace WeatherApp_Domain
{
    public class WeatherAppDbContext : DbContext
    {
        public WeatherAppDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<User> User { get; set; }

    }
}
