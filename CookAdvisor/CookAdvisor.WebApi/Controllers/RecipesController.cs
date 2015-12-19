namespace CookAdvisor.WebApi.Controllers
{
    using Models.Recipes;
    using Services;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    //[Authorize]
    public class RecipesController : ApiController
    {
        private IRecipeService recipeService;

        public RecipesController()
        {
            this.recipeService = new RecipeService();
        }

        public IHttpActionResult Get(int skip = 0, int take = 10)
        {
            var allRecipes = this.recipeService.GetAllRecipes(skip, take);
            var result = new List<GetRecipesResponseModel>();
            foreach (var recipe in allRecipes)
            {
                result.Add(new GetRecipesResponseModel
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Country = recipe.Country.Name,
                    Creator = recipe.Creator.Email,
                    Description = recipe.Description,
                    ImageUrl = recipe.ImageUrl
                });
            }

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var recipe = this.recipeService.GetById(id);

            var newRecipe = new SingleRecipeResponseModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Country = recipe.Country.Name,
                CreatorEmail = recipe.Creator.Email,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Products = recipe.Products.Select(p => p.Name).ToList()
            };

            return this.Ok(newRecipe);
        }

        public IHttpActionResult Post(AddRecipeRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid recipe.");
            }

            this.recipeService.CreateRecipe(
                model.Name,
                model.ImageUrl,
                model.Description,
                model.Products,
                model.Country,
                model.CreatorEmail);

            return this.Created("", "Recipe added!");
        }

        public IHttpActionResult Put(UpdateRecipeRequestModel model)
        {
            var result = this.recipeService.UpdateRecipe(
                model.Id,
                model.Name,
                model.ImageUrl,
                model.Description,
                model.Products,
                model.Country);

            return this.Ok(result.Name + " was updated successfully!");
        }

        public IHttpActionResult Delete(int id)
        {
            var recipe = this.recipeService.GetById(id);
            this.recipeService.DeleteById(id);

            return this.Ok("Recipe deleted!");
        }
    }
}
