namespace CookAdvisor.Client.Managers.Contracts
{
    using System.Threading.Tasks;

    public interface IRemoteDataManager
    {
        Task<string> Get(string endPoint);

        Task<string> Post<T>(string endPoint, T data);

        Task<string> Put<T>(string endPoint, T data);

        Task<string> Delete(string endPoint);
    }
}
