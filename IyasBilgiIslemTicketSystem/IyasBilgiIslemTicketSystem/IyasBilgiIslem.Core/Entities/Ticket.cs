using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IyasBilgiIslem.Core.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public TicketStatus Status { get; set; } = TicketStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // **Kullanıcı İlişkileri**
        [Required]
        public int CreatedByUserId { get; set; }

        [ForeignKey("CreatedByUserId")]
        public User CreatedByUser { get; set; } // Ticket'ı açan kullanıcı

        public int? AssignedUserId { get; set; }
        [ForeignKey("AssignedUserId")]
        public User? AssignedUser { get; set; } // Ticket'a atanmış kullanıcı (opsiyonel)

        // **Branch (Şube) İlişkisi**
        [Required]
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        // **Device (Cihaz) İlişkisi**
        public int? DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public Device? Device { get; set; } // Opsiyonel olarak cihaz bağlanabilir

        // **Category (Kategori) İlişkisi**
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } // Opsiyonel kategori

        // **Ticket Atamaları ve Durum Güncellemeleri**
        public List<Assignment> Assignments { get; set; } = new();
        public List<StatusLog> StatusLogs { get; set; } = new();

        // **Yeni Eklenen AssignedRole**
        public string AssignedRole { get; set; } // Teknik Destek mi, IT mi?
    }
}
