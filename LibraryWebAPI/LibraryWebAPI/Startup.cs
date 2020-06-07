using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LibraryDAO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;


[assembly: ApiController]   /* Esta anotación aplica el comportamiento de API web a todos los controladores del ensamblado.
                             * No hay ninguna manera de excluir controladores específicos.
                             */

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
                            /* Esta anotación aplica a todo el ensamblado la convención de nombre DefaultApiConventions
                             */
namespace LibraryWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Encapsule all IoC
            ConfigureDependencyInjection(services);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Library API", 
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API V1");
                c.RoutePrefix = ""; // Swagger page will be in https://localhost:44373/index.html
            });
        } // end Configure


        /*
         * IoC
         * AddSingleton: Get the same instance of an object every time, even in different request or thread.
         * AddTransient: Get a new object whenever you fetch it as a dependency, no matter if it is a new request or the same one.
         * AddScoped: The same instance will be returned within one request.
         * */
        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            /* Method Configuration.GetConnectionString search in appsettings.json
             * entry with name ConnectionStrings and inside, the key in the parameter.
             * 
             * */
            var dbConn = Configuration.GetConnectionString("LibraryConn");
            var dbName = Configuration.GetConnectionString("LibraryDbName");
            var booksCollection = Configuration.GetConnectionString("BooksCollection");
            var sampleValueFromAppSettings = Configuration.GetValue<string>("EntradaConfigEjemplo");

            services.AddScoped<ILibraryDAO, LibraryDAO.LibraryDAO>(service => new LibraryDAO.LibraryDAO(dbConn, dbName, booksCollection));
        }

    } // end Starup class
}
