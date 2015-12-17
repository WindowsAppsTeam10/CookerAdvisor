namespace CookAdvisor.Client.Models
{
    using SQLite.Net.Attributes;

    public class UserStorageModel
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Access_token { get; set; }

        public string Token_type { get; set; }

        public int Expires_in { get; set; }

        public string UserName { get; set; }

        public string Issued { get; set; }

        public string Expires { get; set; }
    }
}
