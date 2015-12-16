namespace CookAdvisor.Services
{
    using Contracts;
    using Data.Repositories;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class RecipeService : BaseService, IRecipeService
    {
        private IRepository<Recipe> recipes;
        private IRepository<Country> countries;
        private IRepository<User> users;
        private IRepository<Product> products;

        public RecipeService()
        {
            this.recipes = new GenericRepository<Recipe>(this.Data);
            this.countries = new GenericRepository<Country>(this.Data);
            this.users = new GenericRepository<User>(this.Data);
            this.products = new GenericRepository<Product>(this.Data);
        }

        public ICollection<Recipe> GetAllRecipes(int skip = 0, int take = 10)
        {
            var recipes = this.recipes.All();
            var recipesCount = recipes.Count();

            return recipes
                .OrderBy(r => r.Name)
                .Skip(skip)
                .Take(recipesCount < take ? recipesCount : take)
                .ToList();
        }

        public IQueryable<Recipe> GetByCountryId(int countryId)
        {
            return this.recipes.All()
                .Where(r => r.CountryId == countryId);
        }

        public Recipe CreateRecipe(
            string name, 
            string imageUrl, 
            string description, 
            ICollection<string> products, 
            string countryName, 
            string creatorEmail)
        {
            var country = this.countries.All().Where(c => c.Name.ToLower() == countryName.ToLower()).FirstOrDefault();
            var creator = this.users.All().Where(u => u.Email == creatorEmail).FirstOrDefault();
            var productsList = new List<Product>();

            bool changed = false;
            foreach (var productName in products)
            {
                var product = this.products.All().Where(p => p.Name.ToLower() == productName.ToLower()).FirstOrDefault();
                if (product == null)
                {
                    changed = true;
                    product = new Product
                    {
                        Name = productName
                    };

                    this.products.Add(product);
                }

                productsList.Add(product);
            }

            if (changed)
            {
                this.products.SaveChanges();
            }

            if (country == null)
            {
                country = new Country
                {
                    Name = countryName
                };

                this.countries.Add(country);
                this.countries.SaveChanges();
            }
            
            var newRecipe = new Recipe
            {
                Name = name,
                Country = country,
                Description = description,
                ImageUrl = imageUrl,
                Creator = creator,
                Products = productsList
            };

            this.recipes.Add(newRecipe);
            this.recipes.SaveChanges();

            return newRecipe;
        }

        public Recipe DeleteById(int id)
        {
            var recipe = this.recipes.GetById(id);

            this.recipes.Delete(recipe);
            this.recipes.SaveChanges();

            return recipe;
        }

        public Recipe UpdateRecipe(
            int id,
            string name, 
            string imageUrl, 
            string description, 
            ICollection<string> products, 
            string countryName)
        {
            var recipe = this.recipes.GetById(id);
            var productsList = new List<Product>();
            foreach (var ingredient in products)
            {
                productsList.Add(new Product
                {
                    Name = ingredient
                });
            }
            recipe.Name = name;
            recipe.ImageUrl = imageUrl;
            recipe.Description = description;
            recipe.Products = new List<Product>(productsList);
            recipe.Country.Name = countryName;

            this.recipes.SaveChanges();
            return recipe;
        }

        public Recipe GetById(int id)
        {
            return this.recipes.GetById(id);
        }
    }
}
