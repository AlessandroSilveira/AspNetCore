using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNetCore.Domain.Interface;
using AspNetCore.Infra.Data.Repository;
using AspNetCore.Application.Interface;
using AspNetCore.Application.App;

namespace AspNetCore.Mvc
{
    public class Startup
    {
        public Startup(/*IConfiguration configuration*/IHostingEnvironment env)
        {
			//Configuration = configuration;
			var builder = new ConfigurationBuilder()
		   .SetBasePath(env.ContentRootPath)
		   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
		   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
		   .AddEnvironmentVariables();
			Configuration = builder.Build();
		}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
			services.AddSingleton(typeof(IRepository<>), typeof(RepositoryBase<>));

			services.AddSingleton<IPessoa, PessoaRepository>();
			services.AddSingleton<IEndereco, EnderecoRepository>();

			services.AddSingleton<IPessoaAppRepository, PessoaAppRepository>();
			services.AddSingleton<IEnderecoAppRepository, EnderecoAppRepository>();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}