using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class VillaUpdateDTO

    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public int SqFt { get; set; }
    }
}