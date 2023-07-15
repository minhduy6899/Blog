using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.Domain.Entities
{
    public class Blog
    {
        public int Id { get; set; }

        public string? BlogName { get; set; }

        public ICollection<Post> Posts { get; } = new List<Post>();

       
    }
}
