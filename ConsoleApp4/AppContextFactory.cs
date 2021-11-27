using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSolution.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AppSolution.DataAccess.Models;
using AppSolution.DataAccess.Configurations;

namespace ConsoleApp4
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("settings.json").Build();
            var dbOptionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var connectionString = configuration.GetConnectionString("App");
            dbOptionsBuilder.UseSqlServer(connectionString, i => i.CommandTimeout(120));

            return new AppContext(dbOptionsBuilder.Options);

            var appContextFactory = new AppContextFactory();

            using (var appContext = appContextFactory.CreateDbContext(args))
            {
                var leftJoin = (from o in appContext.Offices
                                join e in appContext.Employees on o.OfficeId equals e.OfficeId into officesEmployes
                                from oe in officesEmployes.DefaultIfEmpty()
                                select new { Id = o.OfficeId, OfficeLocation = o.Location, EmployeeName = oe.FirstName, TitleId = oe.TitleId })
                                .Join(
                    appContext.Titles,
                    oe => oe.TitleId,
                    t => t.TitleId,
                    (oe, t) => new { Id = oe.Id, OfficeLocation = oe.OfficeLocation, EmployeeName = oe.EmployeeName, TitleName = t.Name })
                                .ToList();

                var dateDifference = appContext.Employees.Select(e => System.DateTime.UtcNow - e.HiredDate);

                var employees = appContext.Employees.ToList();
                employees[0].FirstName = "FirstName1";
                employees[1].LastName = "LastName1";
                appContext.Employees.Update(employees[0]);
                appContext.Employees.Update(employees[1]);
                var newEmployee = new Employee() { FirstName = "FirstName2", LastName = "LastName2", HiredDate = new System.DateTime(1987, 3, 12), OfficeId = 2, TitleId = 2 };
                var newProject = new Project() { Name = "Name1", Budget = 123456, StartedDate = System.DateTime.UtcNow, ClientId = 1 };
                appContext.Employees.Add(newEmployee);
                appContext.Projects.Add(newProject);
                appContext.Employees.Remove(employees[1]);
                var title = appContext.Employees.ToList().GroupBy(e => e.Title.Name).Select(x => x.Key).FirstOrDefault(y => !y.Contains('a'));
                appContext.SaveChanges();
            }
        }
    }
}
