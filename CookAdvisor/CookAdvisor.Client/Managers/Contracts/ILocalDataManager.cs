namespace CookAdvisor.Client.Managers.Contracts
{
    using CookAdvisor.Client.Models;
    using System.Threading.Tasks;

    public interface ILocalDataManager
    {
        Task<int> InsertUserAsync(UserStorageModel item);

        Task<UserStorageModel> GetUserAsync();
    }
}
