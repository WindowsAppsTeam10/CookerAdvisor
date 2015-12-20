namespace CookAdvisor.Client.Models
{
    using SQLite.Net.Attributes;
    using System;
    public class UserStorageModel
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Access_token { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public override string ToString()
        {
            return string.Format("{0}; Name: {0}; Price: {1}", this.Id, this.UserName, this.Access_token);
        }
    }
}
