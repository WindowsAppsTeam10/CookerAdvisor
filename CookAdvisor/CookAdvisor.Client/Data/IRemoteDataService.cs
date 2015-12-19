namespace CookAdvisor.Client.Managers.Contracts
{
    using System.Threading.Tasks;
    using Windows.Web.Http;

    public interface IRemoteDataService
    {
        Task<HttpResponseMessage> Get(string endPoint);

        Task<HttpResponseMessage> Post<T>(string endPoint, T data);

        Task<HttpResponseMessage> PostAsUrlFormEncoded(string endPoint, string username, string password, string format);

        Task<HttpResponseMessage> Put<T>(string endPoint, T data);

        Task<HttpResponseMessage> Delete(string endPoint);
    }
}
