using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kutuphane.Models
{
    public class Kitap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kitapNo { get; set; }

        [Required(ErrorMessage = "Kitap adı gereklidir")]
        [Display(Name = "Kitap Adı")]
        [StringLength(200)]
        public string kitapAdi { get; set; } = string.Empty;

        [Display(Name = "ISBN No")]
        [StringLength(20)]
        public string? ISBNNo { get; set; }

        [Display(Name = "Sayfa Sayısı")]
        public int? sayfaSayisi { get; set; }

        [Display(Name = "Kitap Özeti")]
        [DataType(DataType.MultilineText)]
        public string? kitapOzeti { get; set; }

        // Navigation properties
        public virtual ICollection<KitapTur> KitapTurler { get; set; } = new List<KitapTur>();
        public virtual ICollection<KitapYazar> KitapYazarlar { get; set; } = new List<KitapYazar>();
        public virtual ICollection<Odunc> Oduncler { get; set; } = new List<Odunc>();
    }
}
