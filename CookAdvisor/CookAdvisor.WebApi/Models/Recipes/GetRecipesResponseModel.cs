﻿namespace CookAdvisor.WebApi.Models.Recipes
{
    public class GetRecipesResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string Creator { get; set; }
    }
}