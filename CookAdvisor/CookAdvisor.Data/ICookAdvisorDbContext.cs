namespace CookAdvisor.Data
{
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface ICookAdvisorDbContext
    {
        IDbSet<Recipe> Recipes { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Cookbook> Cookbooks { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
