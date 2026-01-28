using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kutuphane.Models
{
    public class Odunc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int oduncNo { get; set; }

        [Required(ErrorMessage = "Kitap seçimi gereklidir")]
        [Display(Name = "Kitap")]
        public int kitapNo { get; set; }

        [Required(ErrorMessage = "Üye seçimi gereklidir")]
        [Display(Name = "Üye")]
        public int uyeNo { get; set; }

        [Required(ErrorMessage = "Verme tarihi gereklidir")]
        [Display(Name = "Verme Tarihi")]
        [DataType(DataType.Date)]
        public DateTime vermeTarihi { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Verme süresi gereklidir")]
        [Display(Name = "Verme Süresi (Gün)")]
        public int vermeSuresi { get; set; } = 14;

        [Display(Name = "Geldi Mi?")]
        public bool geldiMi { get; set; } = false;

        // Navigation properties
        [ForeignKey("kitapNo")]
        public virtual Kitap Kitap { get; set; } = null!;

        [ForeignKey("uyeNo")]
        public virtual Uye Uye { get; set; } = null!;

        [NotMapped]
        [Display(Name = "Geri Getirme Tarihi")]
        public DateTime GeriGetirmeTarihi => vermeTarihi.AddDays(vermeSuresi);
    }
}
