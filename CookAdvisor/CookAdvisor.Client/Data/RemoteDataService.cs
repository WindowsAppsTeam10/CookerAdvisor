namespace CookAdvisor.Client.Managers
{
    using System;
    using CookAdvisor.Client.Managers.Contracts;
    using System.Threading.Tasks;
    using Windows.Web.Http;
    using Newtonsoft.Json;
    public class RemoteDataService : IRemoteDataService
    {
        private const string FormUrlEncodedFormat = "UserName={0}&Password={1}&Grant_type=password";
        private string baseAddress;
        private HttpClient client;

        public RemoteDataService(string baseAddress)
        {
            client = new HttpClient();
            this.baseAddress = baseAddress;
        }

        public async Task<HttpResponseMessage> Delete(string endPoint)
        {
            var response = await client.DeleteAsync(new Uri(baseAddress + endPoint));
            return response;
        }

        public async Task<HttpResponseMessage> Get(string endPoint)
        {
            var response = await client.GetAsync(new Uri(baseAddress + endPoint));
            return response;
        }

        public async Task<HttpResponseMessage> Post<T>(string endPoint, T data)
        {
            var dataAsJson = JsonConvert.SerializeObject(data);
            var response = await client.PostAsync(new Uri(baseAddress + endPoint), new HttpStringContent(dataAsJson));
            return response;
        }

        public async Task<HttpResponseMessage> PostAsUrlFormEncoded(string endPoint, string username, string password)
        {
            var data = string.Format(FormUrlEncodedFormat, username, password);
            var response = await client.PostAsync(new Uri(baseAddress + endPoint), new HttpStringContent(data));
            return response;
        }

        public async Task<HttpResponseMessage> Put<T>(string endPoint, T data)
        {
            var dataAsJson = JsonConvert.SerializeObject(data);
            var response = await client.PutAsync(new Uri(baseAddress + endPoint), new HttpStringContent(dataAsJson));
            return response;
        }
    }
}