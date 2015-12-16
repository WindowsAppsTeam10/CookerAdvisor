namespace CookAdvisor.WebApi.App_Start
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CookAdvisorDbContext, Configuration>());
            CookAdvisorDbContext.Create().Database.Initialize(true);
        }
    }
}