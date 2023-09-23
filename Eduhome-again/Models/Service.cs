using System.ComponentModel.DataAnnotations;

namespace Eduhome_again.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Salam qaqa eleme")]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public bool IsDeactive { get; set; }
    }
}
