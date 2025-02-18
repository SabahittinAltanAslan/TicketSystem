using System;
using System.ComponentModel.DataAnnotations;

namespace IyasBilgiIslem.Core.Entities
{
    public class Assignment
    {
        public int Id { get; set; }

        public int TicketId { get; set; } // Atanan Ticket ID
        public Ticket Ticket { get; set; }

        public int UserId { get; set; } // Atanan Teknik Personel
        public User User { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow; // Atanma Tarihi
    }
}
