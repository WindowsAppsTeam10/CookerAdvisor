namespace CookAdvisor.Client.Managers
{
    using CookAdvisor.Client.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IData
    {
        Task<IEnumerable<Recipe>> GetRecipes(int skip, int take);

        Task<UserStorageModel> LoginUser(string username, string password);
    }
}
