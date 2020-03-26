using System.ComponentModel.DataAnnotations;

namespace taskApiRest.Models

{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Field NameCategory required")]
        public string NameCategory { get; set; }

        public int IdTicket { get; set; }

        public Ticket Ticket { get; set; }
    }
}