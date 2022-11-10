using SQLite;
using IronGateApp.Constants;
using IronGateApp.Models;

namespace IronGateApp.DatabaseContext
{
    public class MonkeyContext
    {
        readonly HttpClient client;
        SQLiteAsyncConnection Database;

        public MonkeyContext()
        {
            client = new HttpClient();
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(AppConstants.DatabasePath, AppConstants.Flags);
            await Database.CreateTableAsync<Setting>();

        }

        public async Task<Setting> GetSettingsAsync(int id)
        {
            await Init();
            return await Database.Table<Setting>().FirstOrDefaultAsync();
        }

        public async Task<int> SaveSettingsAsync(Setting item)
        {
            return await Database.UpdateAsync(item);
        }
    }
}
