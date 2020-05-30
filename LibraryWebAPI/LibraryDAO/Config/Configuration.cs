using System;
using System.Text;


namespace LibraryDAO.Config
{

    public class Configuration
    {
        public class DBConfig
        {
            public static string LibreryConnectionString = "mongodb://localhost:27017";
            public static string LibraryDbName = "Library";
            public static string BooksCollection = "Books";
        }

        /*
        public static dynamic _config
        {
            get
            {
                var jsonString = File.ReadAllText("config.json");
                return JObject.Parse(jsonString);
            }
        }
        */
    }
}
