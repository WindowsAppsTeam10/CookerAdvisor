using System.Collections.Generic;

namespace CookAdvisor.Client.Models
{
    public class RecipeResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string Creator { get; set; }

        public ICollection<string> Products { get; set; }
    }
}
