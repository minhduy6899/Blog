using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Mobile { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Intro { get; set; }

        public string? Profile { get; set; }

        public DateTime RegisteredAt { get; set; }

        public DateTime? LastLogin { get; set; }

    }
}
