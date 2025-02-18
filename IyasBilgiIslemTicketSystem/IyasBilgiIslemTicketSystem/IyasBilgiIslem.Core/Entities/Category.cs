using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IyasBilgiIslem.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } // Kategori adı (Donanım, Yazılım, Ağ vb.)

        [MaxLength(250)]
        public string? Description { get; set; } // Kategori açıklaması (Opsiyonel)

        public List<Ticket> Tickets { get; set; } = new(); // Kategoriye bağlı Ticket'lar
    }
}
