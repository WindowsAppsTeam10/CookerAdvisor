namespace CookAdvisor.Client.Managers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CookAdvisor.Client.Models;
    using System.Net;
    using Common;
    using Contracts;
    using Newtonsoft.Json;

    public class ContentManager : IContentManager
    {
        private IRemoteDataManager remoteClient;

        public ContentManager(IRemoteDataManager manager)
        {
            this.remoteClient = manager;
        }

        public async Task<IEnumerable<RecipeListItemModel>> GetRecipes(int skip = 0, int take = 10)
        {
            var response = await this.remoteClient.Get(string.Format(GlobalConstants.GetRecipesFormatEndpoint, skip, take));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseItems = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<RecipeListItemModel>>(responseItems);
            }

            return null;
        }
    }
}
