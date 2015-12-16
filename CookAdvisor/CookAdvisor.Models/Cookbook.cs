namespace CookAdvisor.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Cookbook
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
