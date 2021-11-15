using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppSolution.DataAccess
{
   public class Program
    {
       public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("settings.json").Build();
            var dbOptionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var connectionString = configuration.GetConnectionString("App");
            dbOptionsBuilder.UseSqlServer(connectionString);

            var appContext = new AppContext(dbOptionsBuilder.Options);
            appContext.Database.Migrate();
             
            appContext.SaveChanges();
        }
    }
} 
