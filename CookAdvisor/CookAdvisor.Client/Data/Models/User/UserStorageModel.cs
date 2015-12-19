namespace CookAdvisor.Client.Models
{
    using SQLite.Net.Attributes;

    public class UserStorageModel
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Access_token { get; set; }

        public string UserName { get; set; }

        public override string ToString()
        {
            return string.Format("{0}; Name: {0}; Price: {1}", this.Id, this.UserName, this.Access_token);
        }
    }
}
