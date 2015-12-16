namespace CookAdvisor.Services
{
    using System.Linq;
    using CookAdvisor.Data.Repositories;
    using CookAdvisor.Models;
    using CookAdvisor.Services.Contracts;
    using System.Collections.Generic;

    public class CookbookService : BaseService, ICookbookService
    {
        private IRepository<Cookbook> cookbooks;
        private IRepository<Recipe> recipes;
        private IRepository<User> users;

        public CookbookService()
        {
            this.cookbooks = new GenericRepository<Cookbook>(this.Data);
            this.recipes = new GenericRepository<Recipe>(this.Data);
            this.users = new GenericRepository<User>(this.Data);
        }
        
        public string DislikeRecipe(int recipeId, string userEmail)
        {
            var connections = this.cookbooks.All().Where(c => c.User.Email == userEmail);

            if (connections == null)
            {
                return null;
            }

            var connectionResult = new Cookbook();
            bool found = false;
            foreach (var connection in connections)
            {
                if (connection.RecipeId == recipeId)
                {
                    found = true;
                    connectionResult = connection;
                    break;
                }
            }
            if (!found)
            {
                return null;
            }

            this.cookbooks.Delete(connectionResult);
            this.cookbooks.SaveChanges();

            return "Recipe deleted!";
        }
        
        public ICollection<Recipe> GetUserFavourites(string userEmail)
        {
            var userId = this.users.All().Where(u => u.Email == userEmail).FirstOrDefault().Id;

            return this.cookbooks.All()
                .Where(c => c.UserId == userId)
                .Select(c => c.Recipe)
                .ToList();
        }

        public string LikeRecipe(int recipeId, string userEmail)
        {
            var recipe = this.recipes.GetById(recipeId);
            var user = this.users.All().Where(u => u.Email == userEmail).FirstOrDefault();

            if (recipe == null || user == null)
            {
                return null;
            }

            var allUserRecipes = this.cookbooks.All().Where(u => u.User.Email == userEmail);
            foreach (var favRecipe in allUserRecipes)
            {
                if (favRecipe.RecipeId == recipeId)
                {
                    return null;
                }
            }

            var connection = new Cookbook
            {
                Recipe = recipe,
                User = user
            };

            this.cookbooks.Add(connection);
            this.cookbooks.SaveChanges();

            return "Recipe liked!";
        }
    }
}