namespace CookAdvisor.Services.Contracts
{
    using CookAdvisor.Models;
    using System.Collections.Generic;

    public interface ICookbookService
    {
        /// <summary>
        /// Get the users cookbook content.
        /// </summary>
        /// <param name="userEmail">Email of the designated user.</param>
        /// <returns></returns>
        ICollection<Recipe> GetUserFavourites(string userEmail);

        /// <summary>
        /// Adds recipe to cookbook.
        /// </summary>
        /// <param name="recipeId">The id of the recipe.</param>
        /// <param name="userEmail">The email of the user who owns the cookbook.</param>
        /// <returns></returns>
        string LikeRecipe(int recipeId, string userEmail);

        /// <summary>
        /// Removes the recipe from the cookbook.
        /// </summary>
        /// <param name="recipeId">Id of the recipe for removal.</param>
        /// <returns></returns>
        string DislikeRecipe(int recipeId, string userEmail);
    }
}
