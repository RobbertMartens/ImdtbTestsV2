using System.IO;

namespace Domain
{
    public static class Constants
    {
        // Solution paths
        // Frontend 
        public const string HomePage = "http://localhost";

        // Base uri
        public const string BaseAddress = "http://localhost:8080/v1/proxy/";

        // Token
        public const string TokenUri = "tokens/";      // Post

        // Movies
        /// <summary>
        /// Used to POST movie, also GETs all movies
        /// </summary>
        public const string MoviesUri = "movies/";     // Get and post
        public const string PornUri = "admin/";        // Get
        public const string SearchPorn = "admin/";     // Get

        // User
        public const string UsersUri = "users/";       // Get and post -- suffix {id} => Put and Delete  -- suffix {username} => Get
        public const string AdminUri = "admin/";       // Post    

        public static string GetSolutionPath()
        {
            var directory = Directory.GetCurrentDirectory();
            var driverPath = directory.Split("ImdtbTests")[0] + "ImdtbTests\\";
            return driverPath;
        }

        public static string GetConfigFilePath()
        {
            return GetSolutionPath() + "Domain\\test.config.txt";
        }
    }
}
