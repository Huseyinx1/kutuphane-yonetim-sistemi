using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kutuphane.Models
{
    public class KitapYazar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kitap_yazarNo { get; set; }

        [Required(ErrorMessage = "Yazar seçimi gereklidir")]
        public int yazarNo { get; set; }

        [Required(ErrorMessage = "Kitap seçimi gereklidir")]
        public int kitapNo { get; set; }

        // Navigation properties
        [ForeignKey("yazarNo")]
        public virtual Yazar Yazar { get; set; } = null!;

        [ForeignKey("kitapNo")]
        public virtual Kitap Kitap { get; set; } = null!;
    }
}
