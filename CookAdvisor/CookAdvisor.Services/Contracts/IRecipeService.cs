namespace CookAdvisor.Services.Contracts
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRecipeService
    {
        ICollection<Recipe> GetAllRecipes(int skip = 0, int take = 10);

        IQueryable<Recipe> GetByCountryId(int countryId);

        Recipe CreateRecipe(
            string name,
            string imageUrl,
            string description,
            ICollection<string> products,
            string countryName,
            string creatorEmail);

        Recipe DeleteById(int id);

        Recipe GetById(int id);

        Recipe UpdateRecipe(
            int id,
            string name,
            string imageUrl,
            string description,
            ICollection<string> products,
            string countryName);
    }
}
