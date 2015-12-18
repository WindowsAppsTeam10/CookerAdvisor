namespace CookAdvisor.Client.Managers
{
    using CookAdvisor.Client.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IContentManager
    {
        Task<IEnumerable<RecipeListItemModel>> GetRecipes(int skip, int take);
    }
}
