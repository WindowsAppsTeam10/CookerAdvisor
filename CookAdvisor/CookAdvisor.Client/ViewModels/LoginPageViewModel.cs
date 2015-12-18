namespace CookAdvisor.Client.ViewModels
{
    using Helpers;
    using Managers;
    using Managers.Contracts;
    using Models;
    using System.Windows.Input;
    using Newtonsoft.Json;
    using Common;
    using System.Net;
    using System.Threading.Tasks;
    using Windows.Storage;
    public class LoginPageViewModel : BaseViewModel
    {
        private ICommand loginCommand;
        private IRemoteDataManager remoteClient;
        private ILocalDataManager localClient;

        private UserLoginModel userLoginModel;

        public LoginPageViewModel()
        {
            this.userLoginModel = new UserLoginModel();
            this.remoteClient = new RemoteDataManager(GlobalConstants.DefaultApiBaseAddress);
            this.localClient = new LocalDataManager();
        }

        public async Task<UserStorageModel> GetUser()
        {
            var result = this.localClient.GetUserAsync().Result;
            return result;
        }
        
        public ICommand LoginCommand
        {
            get
            {
                if (this.loginCommand == null)
                {
                    this.loginCommand = new DelegateCommand<UserLoginModel>(async (user) =>
                    {
                        var response = await this.remoteClient.PostAsUrlFormEncoded(GlobalConstants.LoginUserEndpoint, user.UserName, user.Password);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var userData = await response.Content.ReadAsStringAsync();
                            var model = JsonConvert.DeserializeObject<UserStorageModel>(userData);
                            await this.localClient.InsertUserAsync(model);
                        }
                    });
                }

                return this.loginCommand;
            }
        }

        public UserLoginModel LoginModel
        {
            get
            {
                return this.userLoginModel;
            }
            set
            {
                this.userLoginModel = value;
            }
        }
    }
}
