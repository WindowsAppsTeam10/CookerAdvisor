namespace CookAdvisor.Client.Managers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CookAdvisor.Client.Models;
    using Windows.Web.Http;
    using Common;
    using Contracts;
    using Newtonsoft.Json;

    public class HttpServerData : IData
    {
        private IRemoteDataService remoteClient;

        public HttpServerData(IRemoteDataService manager)
        {
            this.remoteClient = manager;
        }

        public async Task<IEnumerable<Recipe>> GetRecipes(int skip = 0, int take = 10)
        {
            var response = await this.remoteClient.Get(string.Format(GlobalConstants.GetRecipesFormatEndpoint, skip, take));
            if (response.StatusCode == HttpStatusCode.Ok)
            {
                var responseItems = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Recipe>>(responseItems.GetResults());
            }

            return null;
        }

        public async Task<UserStorageModel> LoginUser(string username, string password)
        {
            var response = await this.remoteClient.PostAsUrlFormEncoded(GlobalConstants.LoginUserEndpoint, username, password);
            if (response.StatusCode == HttpStatusCode.Ok)
            {
                var userData = response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<UserStorageModel>(userData.GetResults());
                return model;
            }

            return null;
        }
    }
}
