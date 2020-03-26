using System.ComponentModel.DataAnnotations;

namespace taskApiRest.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Field Title required")]
        [MaxLength(120, ErrorMessage = "Title too big")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field Description required ")]
        public string  Description { get; set; }

        public string  DataCreate { get; set; }
    
        public string DataAter { get; set; }

        public string DataDrop { get; set; }
    }
}