using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string? PostName { get; set; }

        public string? PostTitle { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; } = null!;
    }
}
