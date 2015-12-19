namespace CookAdvisor.Client.ViewModels
{
    using System.Collections.Generic;

    public class AddRecipeViewModel
    {       
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
        
        public ICollection<string> Products { get; set; }
    }
}
