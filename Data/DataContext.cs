using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContextApp : DbContext
    {
        public DataContextApp(DbContextOptions<DataContextApp> options) : base(options){}

        public DbSet<Value> values{get; set;}
    }
}