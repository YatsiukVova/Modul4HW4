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
            builder.Property(x => x.Budget).HasColumnType("Budget");
            builder.Property(x => x.StartedDate).HasColumnType("date");

            builder.HasOne(x => x.Client)
               .WithMany(y => y.Projects)
               .HasForeignKey(x => x.ClientId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new Project { Id = 1, ClientId = 2, Name = "Chest", Budget = 1000, StartedDate = new DateTime(1) },
                            new Project { Id = 2, ClientId = 3, Name = "WebSite", Budget = 1000, StartedDate = new DateTime(1) },
                            new Project { Id = 3, ClientId = 2, Name = "Test", Budget = 1000, StartedDate = new DateTime(1) },
                            new Project { Id = 4, ClientId = 1, Name = "Game", Budget = 1000, StartedDate = new DateTime(2) },
                            new Project { Id = 5, ClientId = 4, Name = "Program", Budget = 1000, StartedDate = new DateTime(1) }); ;
        }
    }
}
