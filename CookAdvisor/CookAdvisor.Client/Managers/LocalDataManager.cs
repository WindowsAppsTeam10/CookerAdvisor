namespace CookAdvisor.Client.Managers
{
    using Contracts;
    using Models;
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Windows.Storage;

    public class LocalDataManager : ILocalDataManager
    {
        public LocalDataManager()
        {
            this.InitAsync();
        }

        private SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        private async void InitAsync()
        {
            var connection = this.GetDbConnectionAsync();
            await connection.CreateTableAsync<UserStorageModel>();
        }

        public async Task<int> InsertUserAsync(UserStorageModel item)
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.InsertAsync(item);
            return result;
        }

        public async Task<UserStorageModel> GetUserAsync()
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.Table<UserStorageModel>().OrderByDescending(e => e.Id).FirstOrDefaultAsync();
            return result;
        }
    }
}
