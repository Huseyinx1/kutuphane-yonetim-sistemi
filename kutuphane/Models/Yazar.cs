using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kutuphane.Models
{
    public class Yazar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int yazarNo { get; set; }

        [Required(ErrorMessage = "Yazar adı gereklidir")]
        [Display(Name = "Adı")]
        [StringLength(50)]
        public string adi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yazar soyadı gereklidir")]
        [Display(Name = "Soyadı")]
        [StringLength(50)]
        public string soyadi { get; set; } = string.Empty;

        [Display(Name = "Doğum Tarihi/Yılı")]
        [StringLength(20)]
        public string? dogum { get; set; }

        [Display(Name = "Hayat Özeti")]
        [DataType(DataType.MultilineText)]
        public string? hayatOzeti { get; set; }

        // Navigation property
        public virtual ICollection<KitapYazar> KitapYazarlar { get; set; } = new List<KitapYazar>();

        [NotMapped]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad => $"{adi} {soyadi}";
    }
}
