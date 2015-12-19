namespace CookAdvisor.Client.Models
{
    public class UserLoginModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string grant_type
        {
            get
            {
                return "password";
            }
        }
    }
}
