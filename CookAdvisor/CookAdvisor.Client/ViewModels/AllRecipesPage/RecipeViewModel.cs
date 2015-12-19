namespace CookAdvisor.Client.ViewModels
{
    using CookAdvisor.Client.Models;

    public class RecipeViewModel
    {
        public RecipeViewModel(RecipeResponseModel recipe)
        {
            this.Name = recipe.Name;
            this.ImageUrl = recipe.ImageUrl;
            this.Creator = recipe.Creator;
        }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Creator { get; set; }
    }
}
