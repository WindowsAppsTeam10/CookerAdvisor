namespace CookAdvisor.Client.Managers.Contracts
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IRemoteDataManager
    {
        Task<HttpResponseMessage> Get(string endPoint);

        Task<HttpResponseMessage> Post<T>(string endPoint, T data);

        Task<HttpResponseMessage> PostAsUrlFormEncoded(string endPoint, string username, string password);

        Task<HttpResponseMessage> Put<T>(string endPoint, T data);

        Task<HttpResponseMessage> Delete(string endPoint);
    }
}
