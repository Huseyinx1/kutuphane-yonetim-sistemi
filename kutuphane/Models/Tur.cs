using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kutuphane.Models
{
    public class Tur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int turNo { get; set; }

        [Required(ErrorMessage = "Tür açıklaması gereklidir")]
        [Display(Name = "Tür Açıklaması")]
        [StringLength(100)]
        public string turAciklama { get; set; } = string.Empty;

        // Navigation property
        public virtual ICollection<KitapTur> KitapTurler { get; set; } = new List<KitapTur>();
    }
}
