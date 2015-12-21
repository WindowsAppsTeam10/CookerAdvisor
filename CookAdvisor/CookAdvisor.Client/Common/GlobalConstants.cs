namespace CookAdvisor.Client.Common
{
    public class GlobalConstants
    {
        // Web API constants
        public const string DefaultApiBaseAddress = "http://localhost:55247/";
        
        // User endpoints:
        public const string RegisterUserEndpoint = "api/Account/Register";
        public const string LoginUserEndpoint = "token";

        // Cookbook endpoints:
        public const string GetUserCookbookFormatEndpoint = "api/cookbooks/{0}";
        public const string AddRecipeToCookbookEndpoint = "api/cookbooks";
        public const string RemoveRecipeFromCookbookEndpoint = "api/cookbooks";

        // Recipe endpoints:
        public const string GetRecipesFormatEndpoint = "api/recipes?skip={0}&take={1}";
        public const string GetRecipeById = "api/recipes/{0}";
        public const string AddNewRecipeEndpoint = "api/recipes";
        public const string UpdateRecipeEndpoint = "api/recipes";
        public const string DeleteRecipeByIdEndpoint = "/api/recipes/{0}";

        //
        public const string LocationBackgroundTaskName = "LocationBackgroundTask";
    }
}
