using LibraryDAO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebAPI.Config
{
    public static class DependencyInjector
    {
        /*
         * IoC
         * AddSingleton: Get the same instance of an object every time, even in different request or thread.
         * AddTransient: Get a new object whenever you fetch it as a dependency, no matter if it is a new request or the same one.
         * AddScoped: The same instance will be returned within one request.
         * */
        public static IServiceCollection AddDependencies( this IServiceCollection services, IConfiguration config)
        {
            /* Method Configuration.GetConnectionString search in appsettings.json
             * entry with name ConnectionStrings and inside, the key in the parameter.
             * 
             * */
            var dbConn = config.GetConnectionString("LibraryConn");
            var dbName = config.GetConnectionString("LibraryDbName");
            var booksCollection = config.GetConnectionString("BooksCollection");
            var sampleValueFromAppSettings = config.GetValue<string>("EntradaConfigEjemplo");

            services.AddScoped<ILibraryDAO, LibraryDAO.LibraryDAO>(service => new LibraryDAO.LibraryDAO(dbConn, dbName, booksCollection));
            
            return services;
        }
    }
}
