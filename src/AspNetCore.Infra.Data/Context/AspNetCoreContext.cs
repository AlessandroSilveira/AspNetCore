using AspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Infra.Data.Context
{
   public class AspNetCoreContext : DbContext
    { 
		public IConfigurationRoot Configuration { get; set; }

		public AspNetCoreContext(DbContextOptions<AspNetCoreContext> option) : base(option)
        {
			Database.EnsureCreated();
		}

		public DbSet<Pessoa> Pessoa { get; set; }
		public DbSet<Endereco> Endereco { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
		{
			if (!optionBuilder.IsConfigured)
				optionBuilder.UseSqlServer(RetornaUrlConection());
		}

		public string RetornaUrlConection()
		{
			var builder = new ConfigurationBuilder()
			 .SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json");
			Configuration = builder.Build();

			string conexao = Configuration.GetConnectionString("DefaultConnection");
			return conexao;
		}
	}
}
