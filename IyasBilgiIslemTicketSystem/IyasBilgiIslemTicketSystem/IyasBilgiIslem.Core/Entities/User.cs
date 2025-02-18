using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IyasBilgiIslem.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public UserRole Role { get; set; } // ITPersoneli, TeknikEkipPersoneli, SubePersoneli

        [Required]
        public string PasswordHash { get; set; } // Kullanıcı şifresi, hashlenmiş olarak saklanacak

        // Kullanıcının oluşturduğu ticket'lar
        public List<Ticket> CreatedTickets { get; set; } = new();

        // Kullanıcıya atanmış ticket'lar
        public List<Ticket> AssignedTickets { get; set; } = new();

        // Kullanıcının zimmetli cihazları
        public List<Device> Devices { get; set; } = new();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
