using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kutuphane.Models
{
    public class KitapTur
    {
        [Key]
        [Column(Order = 0)]
        public int kitapNo { get; set; }

        [Key]
        [Column(Order = 1)]
        public int turNo { get; set; }

        // Navigation properties
        [ForeignKey("kitapNo")]
        public virtual Kitap Kitap { get; set; } = null!;

        [ForeignKey("turNo")]
        public virtual Tur Tur { get; set; } = null!;
    }
}
