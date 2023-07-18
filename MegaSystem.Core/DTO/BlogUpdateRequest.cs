using MegaSystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.DTO
{
    public class BlogUpdateRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? BlogName { get; set; }

        public int UserId { get; set; }
    }
}
