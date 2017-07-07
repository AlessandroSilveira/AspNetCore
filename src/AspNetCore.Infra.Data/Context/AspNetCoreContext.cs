using AspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AspNetCore.Infra.Data.Context
{
   public class AspNetCoreContext : DbContext
    { 
		
		public AspNetCoreContext(DbContextOptions<AspNetCoreContext> option) : base(option)
        {
			Database.EnsureCreated();
		}

		public DbSet<Pessoa> Pessoas { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
		{
			var config = new ConfigurationBuilder()
			   .SetBasePath(Directory.GetCurrentDirectory())
			   .AddJsonFile("appsettings.json")
			   .Build();

			// define the database to use
			
			//optionBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
			optionBuilder.UseSqlServer("data source=.\\SQLEXPRESS;Initial Catalog=AspNetCore;Integrated Security=True;MultipleActiveResultSets=True");
		}
	}
}
