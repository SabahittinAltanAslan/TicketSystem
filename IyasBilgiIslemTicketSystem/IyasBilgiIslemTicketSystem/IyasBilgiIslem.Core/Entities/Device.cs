using System;
using System.ComponentModel.DataAnnotations;

namespace IyasBilgiIslem.Core.Entities
{
    public class Device
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } // Cihaz Adı

        [Required, MaxLength(50)]
        public string SerialNumber { get; set; } // Seri Numarası

        [Required, MaxLength(100)]
        public string Manufacturer { get; set; } // Üretici

        [Required, MaxLength(100)]
        public string Model { get; set; } // Model

        [Required, MaxLength(50)]
        public string OperatingSystem { get; set; } // İşletim Sistemi

        [Required, MaxLength(20)]
        public string IPAddress { get; set; } // IP Adresi

        [Required, MaxLength(20)]
        public string MACAddress { get; set; } // MAC Adresi

        public DeviceStatus Status { get; set; } = DeviceStatus.Working;

        public int? UserId { get; set; } // Cihaz zimmetliyse kullanıcı
        public User? AssignedTo { get; set; }

        public int BranchId { get; set; } // Şubeye ait cihaz
        public Branch Branch { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<Ticket> Tickets { get; set; } = new(); // Cihazla ilişkili ticket'lar
    }
}
