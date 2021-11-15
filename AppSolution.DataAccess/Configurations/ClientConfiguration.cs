using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppSolution.DataAccess.Models;

namespace AppSolution.DataAccess.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired(); 
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();

            builder.HasData(new Client { Id = 1, FirstName = "Vasay", LastName = "Pupkin", Country = "Ukraine", Email = "Pup@gmail.com" },
                            new Client { Id = 2, FirstName = "Misha", LastName = "Konev", Country = "Ukraine", Email = "KonevM@gmail.com" },
                            new Client { Id = 3, FirstName = "Petro", LastName = "Zaycev", Country = "Poland", Email = "PetrZ@gmail.com" },
                            new Client { Id = 4, FirstName = "Kostya", LastName = "Popov", Country = "Belorus", Email = "Kepel@gmail.com" },
                            new Client { Id = 5, FirstName = "Lexa", LastName = "Zolotoi", Country = "Ukraine", Email = "ZolotoiLex@gmail.com" });
        }
    }
}
