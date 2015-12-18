namespace CookAdvisor.Models
{
    using System.Collections.Generic;

    public class Recipe
    {
        private ICollection<Product> products;

        public Recipe()
        {
            this.products = new HashSet<Product>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
