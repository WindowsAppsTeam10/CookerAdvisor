namespace CookAdvisor.WebApi.Models.Cookbook
{
    public class AddToCookbookRequestModel
    {
        public int RecipeId { get; set; }

        public string UserEmail { get; set; }
    }
}