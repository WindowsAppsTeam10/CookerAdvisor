namespace CookAdvisor.Client.Managers
{
    using System;
    using CookAdvisor.Client.Managers.Contracts;
    using System.Threading.Tasks;
    using System.Net.Http;

    public class RemoteDataManager : IRemoteDataManager
    {
        private HttpClient client;

        public RemoteDataManager(string baseAddress)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
        }

        public async Task<string> Delete(string endPoint)
        {
            var response = await client.DeleteAsync(endPoint).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> Get(string endPoint)
        {
            var response = await client.GetAsync(endPoint).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> Post<T>(string endPoint, T data)
        {
            var response = await client.PostAsJsonAsync(endPoint, data).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> Put<T>(string endPoint, T data)
        {
            var response = await client.PutAsJsonAsync(endPoint, data).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
