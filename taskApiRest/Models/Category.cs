using System.ComponentModel.DataAnnotations;

namespace taskApiRest.Models

{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Field NameCategory required")]
        public string NameCategory { get; set; }

        public int IdTask { get; set; }

        public Task Task { get; set; }
    }
}