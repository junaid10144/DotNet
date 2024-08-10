using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiCachingWithRedis.Models;

namespace WebApiCachingWithRedis.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}