namespace CookAdvisor.Client.Managers
{
    using Models;
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Windows.Storage;

    public class LocalStorage
    {
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

        private async Task<int> InsertUserAsync(UserStorageModel item)
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.InsertAsync(item);
            return result;
        }

        private async Task<List<UserStorageModel>> GetAllUserAsync()
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.Table<UserStorageModel>().ToListAsync();
            return result;
        }

        public Task<string> Get(string endPoint)
        {
            throw new NotImplementedException();
        }

        public Task<string> Post<T>(string endPoint, T data)
        {
            throw new NotImplementedException();
        }

        public Task<string> Put<T>(string endPoint, T data)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(string endPoint)
        {
            throw new NotImplementedException();
        }
    }
}
