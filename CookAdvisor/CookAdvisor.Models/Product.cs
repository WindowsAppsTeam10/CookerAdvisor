using System.Collections.Generic;

namespace CookAdvisor.Models
{
    public class Product
    {
        private ICollection<Recipe> recipes;

        public Product()
        {
            this.recipes = new HashSet<Recipe>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes
        {
            get { return this.recipes; }
            set { this.recipes = value; }
        }
    }
}
