using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.DTO
{
    public class BlogAddRequest
    {
        [Required(ErrorMessage = "Blog Name can't be blank")]
        public string? BlogName { get; set; }
    }
}
