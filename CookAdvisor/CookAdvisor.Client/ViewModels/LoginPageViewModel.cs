namespace CookAdvisor.Client.ViewModels
{
    using Helpers;
    using Managers;
    using Managers.Contracts;
    using Models;
    using System.Windows.Input;
    using Common;
    using System.Threading.Tasks;
    using Contracts;
    public class LoginPageViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand loginCommand;
        private IData data;
        private ILocalDataManager localClient;

        private UserLoginModel userLoginModel;

        public LoginPageViewModel()
        {
            this.userLoginModel = new UserLoginModel();
            this.data = new HttpServerData(new RemoteDataService(GlobalConstants.DefaultApiBaseAddress));
            this.localClient = new LocalDataManager();
        }

        public async Task<bool> LoginUserSuccessful(string username, string password)
        {
            var userInfo = await this.data.LoginUser(username, password);
            if (userInfo == null)
            {
                return false;
            }
            else
            {
                await this.localClient.InsertUserAsync(userInfo);
                return true;
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
