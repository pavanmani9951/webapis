using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaAPI.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }     
        public string Name { get; set; }
        public string Location { get; set; }
        [Required]
        public int Rate { get; set; }
        public int SqFt { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
