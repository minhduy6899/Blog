using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.Domain.Entities
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        public string? BlogName { get; set; }

        public int UserId{ get; set; }
    }
}
