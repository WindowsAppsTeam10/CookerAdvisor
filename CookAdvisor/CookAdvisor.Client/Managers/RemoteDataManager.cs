namespace CookAdvisor.Client.Managers
{
    using System;
    using CookAdvisor.Client.Managers.Contracts;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class RemoteDataManager : IRemoteDataManager
    {
        private const string FormUrlEncodedFormat = "UserName={0}&Password={1}&Grant_type=password";

        private HttpClient client;

        public RemoteDataManager(string baseAddress)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
        }

        public async Task<HttpResponseMessage> Delete(string endPoint)
        {
            return await client.DeleteAsync(endPoint).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> Get(string endPoint)
        {
            return await client.GetAsync(endPoint).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> Post<T>(string endPoint, T data)
        {
            return await client.PostAsJsonAsync(endPoint, data).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> PostAsUrlFormEncoded(string endPoint, string username, string password)
        {
            var data = string.Format(FormUrlEncodedFormat, username, password);
            return await client.PostAsync(endPoint, new StringContent(data)).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> Put<T>(string endPoint, T data)
        {
            return await client.PutAsJsonAsync(endPoint, data).ConfigureAwait(false);
        }
    }
}
