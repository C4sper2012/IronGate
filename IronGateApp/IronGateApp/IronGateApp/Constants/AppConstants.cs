using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronGateApp.Constants
{
    public static class AppConstants
    {
        #region Database 

        public const string DatabaseFilename = "IronGateSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        #endregion

        #region API 

        public const string _humidityFeed = "CHANNELS";

        public const string _apiWriteUrl = "https://api.thingspeak.com/update?api_key=";

        public const string _readApiKey = "F803W0EVFO7BK3GG";
        public const string _writeApiKey = "AWR4TJXORG6EG6IL";




        public const string _windowChannelFeedsUrl = "https://api.thingspeak.com/channels/1916369/feeds.json?api_key=";

        public const string _basementWindow = "field1=";
        public const string _groundFloorWindow = "field3=";
        public const string _firstFloorWindow = "field5=";

        public const string _get100WindowFeeds = $"{_windowChannelFeedsUrl}{_readApiKey}&results=100";
        public const string _writeWindow = $"{_apiWriteUrl}{_writeApiKey}&";
        
        #endregion
    }
}
