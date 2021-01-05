using System.IO;
using SQLite;
using Xamarin.Essentials;

namespace PVBot.Clients.UI.Properties
{
    public static class PersistenceConfig
    {
        public const string DatabaseFilename = "PVBot.db3";

        public static string DatabasePath 
        {
            get
            {
#if MOCK
                return ":memory:";
#else
                return Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
#endif
            }
        }

        public static SQLiteOpenFlags SqliteFlags => (
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache);
    }
}
