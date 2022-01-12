using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace back
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
            services.AddCors();
            services.AddControllersWithViews();
            services.AddControllers();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<LibraryContext>(Context => Context.UseSqlServer(connectionString));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "School API",
                    Description = "School API - ASP.NET Core Web API",
                    TermsOfService = new Uri("https://cla.dotnetfoundation.org/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Social App",
                        Email = string.Empty,

                        Url = new Uri("https://cla.dotnetfoundation.org/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licencia dotnet foundation",
                        Url = new Uri("https://www.byasystems.co/license"),
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region global cors policy activate Authentication/Authorization
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            #endregion
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prueba Librería"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }


    }
}