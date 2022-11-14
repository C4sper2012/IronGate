using SQLite;
using IronGateApp.Constants;
using IronGateApp.Models;

namespace IronGateApp.DatabaseContext
{
    public class IronGateContext
    {
        readonly HttpClient client;
        SQLiteAsyncConnection Database;

        public IronGateContext()
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

        public async Task<Setting> GetSettingsAsync()
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
