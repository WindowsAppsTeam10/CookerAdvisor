namespace CookAdvisor.Client.Managers
{
    using CookAdvisor.Client.Models;
    using Data.Models.Recipes;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IData
    {
        Task<RecipeResponseModel> AddRecipe(RecipeRequestModel recipe);

        Task<IEnumerable<RecipeResponseModel>> GetRecipes(int skip, int take);

        Task<UserStorageModel> LoginUser(string username, string password);

        Task<bool> RegisterUser(string username, string password);

        Task<RecipeResponseModel> GetRecipe(int id);
    }
}
