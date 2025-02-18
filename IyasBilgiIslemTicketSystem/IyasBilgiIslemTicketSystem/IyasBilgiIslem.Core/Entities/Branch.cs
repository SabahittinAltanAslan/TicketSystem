using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IyasBilgiIslem.Core.Entities
{
    public class Branch
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        public List<Ticket> Tickets { get; set; } = new();
        public List<Device> Devices { get; set; } = new();
    }
}
