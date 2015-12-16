namespace CookAdvisor.WebApi.Controllers
{
    using Models.Cookbook;
    using Services;
    using Services.Contracts;
    using System.Web.Http;

    public class CookbooksController : ApiController
    {
        private ICookbookService cookbookService;

        public CookbooksController()
        {
            this.cookbookService = new CookbookService();
        }
        
        public IHttpActionResult Get(string userEmail, int skip = 0, int take = 10)
        {
            if (userEmail == null || userEmail == string.Empty)
            {
                return this.BadRequest("Invalid email!");
            }

            var result = this.cookbookService.GetUserFavourites(userEmail);

            return this.Ok(result);
        }

        public IHttpActionResult Post(AddToCookbookRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid favourite format!");
            }

            var result = this.cookbookService.LikeRecipe(model.RecipeId, model.UserEmail);
            if (result == null)
            {
                return this.BadRequest("Cannot like!");
            }

            return this.Ok(result);
        }

        public IHttpActionResult Delete(AddToCookbookRequestModel model)
        {
            var result = this.cookbookService.DislikeRecipe(model.RecipeId, model.UserEmail);
            if (result == null)
            {
                return this.BadRequest("Cannot dislike!");
            }

            return this.Ok(result);
        }
    }
}
