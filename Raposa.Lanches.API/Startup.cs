using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raposa.Lanches.API.Model;
using Raposa.Lanches.API.Service;
using Raposa.Lanches.API.Service.Handlers;
using Raposa.Lanches.DataBase;
using Raposa.Lanches.DataBase.Repostitories;
using Raposa.Lanches.DataBase.Repostitories.EFCore;

namespace Raposa.Lanches.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc();
            services.AddEntityFrameworkSqlServer();
            services.AddEntityFrameworkProxies();

            services.AddDbContextPool<RaposaLanchesContext>((optionsBuilder) =>
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(

             Configuration["ConnectionString:Default"],
             b =>
             b.MigrationsAssembly("Raposa.Lanches.DataBase")
             );

            });

            services.AddTransient<IIngredientesRepository, IngredientesRepository>();
            services.AddTransient<ILanchesRepository, LanchesRepository>();

            services.AddTransient<IIngredientesService, IngredientesService>();
            services.AddTransient<ILanchesService, LanchesService>();

            //automapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Lanche, LancheModel>();
                cfg.CreateMap<Ingrediente, IngredienteModel>();

                cfg.CreateMap<IngredienteModel, Ingrediente>();
                cfg.CreateMap<LancheModel, Lanche>();

                cfg.CreateMap<LancheIngrediente, LancheIngredienteModel>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<RaposaLanchesContext>();
                context.Database.Migrate();
            }
        }
    }
}