using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppSolution.DataAccess.Models;

namespace AppSolution.DataAccess.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();


            builder.HasData(new Project { Id = 1, Name = "Chest", Budget = 1000, StartedDate = new DateTime() },
                            new Project { Id = 2, Name = "WebSite", Budget = 1000, StartedDate = new DateTime() },
                            new Project { Id = 3, Name = "Test", Budget = 1000, StartedDate = new DateTime() },
                            new Project { Id = 4, Name = "Game", Budget = 1000, StartedDate = new DateTime() },
                            new Project { Id = 5, Name = "Program", Budget = 1000, StartedDate = new DateTime() });
        }
    }
}
