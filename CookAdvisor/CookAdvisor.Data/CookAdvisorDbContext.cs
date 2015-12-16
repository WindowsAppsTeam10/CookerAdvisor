namespace CookAdvisor.Data
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System;

    public class CookAdvisorDbContext : IdentityDbContext<User>, ICookAdvisorDbContext
    {
        public CookAdvisorDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Cookbook> Cookbooks { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Recipe> Recipes { get; set; }

        public static CookAdvisorDbContext Create()
        {
            return new CookAdvisorDbContext();
        }
    }
}