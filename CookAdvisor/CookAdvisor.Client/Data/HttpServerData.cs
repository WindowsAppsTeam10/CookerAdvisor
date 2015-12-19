namespace CookAdvisor.Client.Managers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CookAdvisor.Client.Models;
    using Windows.Web.Http;
    using Common;
    using Contracts;
    using Newtonsoft.Json;
    using Data.Models.Recipes;
    using System;

    public class HttpServerData : IData
    {
        private const string LoginFormUrlEncodedFormat = "UserName={0}&Password={1}&Grant_type=password";
        private const string RegisterFormUrlEncodedFormat = "Email={0}&Password={1}&ConfirmPassword={1}";

        private IRemoteDataService remoteClient;

        public HttpServerData()
            : this(new RemoteDataService(GlobalConstants.DefaultApiBaseAddress))
        {
        }

        public HttpServerData(IRemoteDataService manager)
        {
            this.remoteClient = manager;
        }

        public async Task<RecipeResponseModel> AddRecipe(RecipeRequestModel recipe)
        {
            var response = await this.remoteClient.Post(GlobalConstants.AddNewRecipeEndpoint, recipe);

            return ParseResponse<RecipeResponseModel>(response);
        }

        public async Task<IEnumerable<RecipeResponseModel>> GetRecipes(int skip = 0, int take = 10)
        {
            var response = await this.remoteClient.Get(string.Format(GlobalConstants.GetRecipesFormatEndpoint, skip, take));

            return ParseResponse<IEnumerable<RecipeResponseModel>>(response);
        }

        public async Task<UserStorageModel> LoginUser(string username, string password)
        {
            var response = await this.remoteClient.PostAsUrlFormEncoded(GlobalConstants.LoginUserEndpoint, username, password, LoginFormUrlEncodedFormat);

            return ParseResponse<UserStorageModel>(response);
        }

        public async Task<bool> RegisterUser(string username, string password)
        {
            var response = await this.remoteClient.PostAsUrlFormEncoded(GlobalConstants.RegisterUserEndpoint, username, password, RegisterFormUrlEncodedFormat);
            if (response.StatusCode == HttpStatusCode.Ok)
            {
                return true;
            }

            return false;
        }

        private static T ParseResponse<T>(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Ok)
            {
                var userData = response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<T>(userData.GetResults());
                return model;
            }

            return default(T);
        }

    }
}
