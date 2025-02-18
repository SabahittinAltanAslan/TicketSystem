using System;

namespace IyasBilgiIslem.Core.Entities
{
    public class StatusLog
    {
        public int Id { get; set; }

        public int TicketId { get; set; } // Hangi Ticket için log kaydı?
        public Ticket Ticket { get; set; }

        public TicketStatus OldStatus { get; set; } // Önceki Durum
        public TicketStatus NewStatus { get; set; } // Yeni Durum

        public int ChangedByUserId { get; set; } // Durumu değiştiren kişi
        public User ChangedByUser { get; set; }

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow; // Değişiklik tarihi
    }
}
