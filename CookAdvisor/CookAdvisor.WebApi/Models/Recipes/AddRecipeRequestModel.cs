namespace CookAdvisor.WebApi.Models.Recipes
{
    using System.Collections.Generic;

    public class AddRecipeRequestModel
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string CreatorEmail { get; set; }

        public ICollection<string> Products { get; set; }
    }
}