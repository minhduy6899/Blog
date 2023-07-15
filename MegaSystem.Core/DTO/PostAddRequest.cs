using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.DTO
{
    public class PostAddRequest
    {
        [Required(ErrorMessage = "Post Name can't be blank")]
        public string? PostName { get; set; }
        [Required(ErrorMessage = "Please select a Blog")]
        public int BlogId { get; set; }

        public string? PostTitle { get; set; }
    }
}
