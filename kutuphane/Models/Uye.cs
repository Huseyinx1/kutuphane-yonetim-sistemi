using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kutuphane.Models
{
    public class Uye
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int uyeNo { get; set; }

        [Required(ErrorMessage = "Üye adı gereklidir")]
        [Display(Name = "Adı")]
        [StringLength(50)]
        public string adi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Üye soyadı gereklidir")]
        [Display(Name = "Soyadı")]
        [StringLength(50)]
        public string soyadi { get; set; } = string.Empty;

        [Display(Name = "Adres")]
        [StringLength(200)]
        public string? adresi { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool aktifMi { get; set; } = true;

        // Navigation property
        public virtual ICollection<Odunc> Oduncler { get; set; } = new List<Odunc>();

        [NotMapped]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad => $"{adi} {soyadi}";
    }
}
