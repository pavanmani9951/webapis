using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class VillaCreateDTO

    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Location { get; set; }
        [Required]
        public int Rate { get; set; }
        public int SqFt { get; set; }
    }
}